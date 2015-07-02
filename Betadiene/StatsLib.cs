//
//  StatsLib.cs
//
//  Author:
//       Christopher Stefancik <gutenvirt@gmail.com>
//
//  Copyright (c) 2015
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Betadiene
{
    public static class StatsLib
    {
        public static double Correlation(double[] col1, double[] col2)
        {
            if (col1.Length != col2.Length)
                return double.NaN;

            double result = 0;
            for (int i = 0; i < col1.Length; i++)
            {
                result += col1[i] * col2[i];
            }
            return result / (col1.Length - 1);
        }

        public static double[,] CorrelationMatrix(Column[] zScorefield)
        {
            var result = new double[zScorefield.Length, zScorefield.Length];
            for (int i = 0; i < zScorefield.Length; i++)
            {
                for (int j = 0; j < zScorefield.Length; j++)
                {
                    if (j <= i)
                        result[i, j] = StatsLib.Correlation(zScorefield[i].StandardizeValues(), zScorefield[j].StandardizeValues());
                    else
                        result[i, j] = double.NaN;
                }
            }

            return result;
        }

        public static double NIntegrate(Column col)
        {
            var result = 0.0;
            for (int i = 0; i < col.Size - 1; i++)
            {
                result += (col[i] + col[i + 1]) * .5;
            }
            return result;
        }


        public static double[] OLS(Column y, Column[] x)
        {
            int nObs = y.Size;
            int nVars = x.Length;

            double[] b = new double[nVars + 1];
            double[] resid = new double[nObs];
            double[] yHat = new double[nObs];

            double sumSquares = 0;
            double prevSumSquares = 10;
            double step = 100.0;

            //set inital b values
            for (int h = 0; h < nVars; h++)
            {
                b[h] = x[h].Mean;
            }
            b[nVars] = y.Mean;

            step = y.Mean;
            int varCnt = 0;
            int cnt = 0;
            while (cnt < 100)
            {
                cnt++;
                while (prevSumSquares - sumSquares > .00001)
                {
                    b[varCnt] += step;

                    sumSquares = 0.0;
                    for (int i = 0; i < nObs; i++)
                    {
                        for (int j = 0; j < nVars + 1; j++)
                        {
                            if (j < nVars)
                                yHat[i] += b[j] * x[j][i];
                            else
                                yHat[i] += b[j];
                        }
                        resid[i] = y[i] - yHat[i];
                        sumSquares += resid[i] * resid[i];
                    }

                    if (prevSumSquares < sumSquares)
                        step = step * (-.5);

                    prevSumSquares = sumSquares;
                }
                varCnt++;
                if (varCnt == nVars+1)
                    varCnt = 0;
            }


            //set coeff in output
            var result = new double[nVars + 1];
            for (int i = 0; i < nVars + 1; i++)
            {
                result[i] = b[i];
            }

            return result;
        }
    }
}
