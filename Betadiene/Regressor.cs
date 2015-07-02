//
//  Regressor.cs
//
//  Author:
//       Christopher Stefancik <gutenvirt@gmail.com>
//
//  Copyright (c) 2015 CD Stefancik
//
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
    public static class Regressor
    {
        private static int nObs;
        private static int nVars;

        private static double yMean;

        private static double[,] x;
        private static double[] y;
        private static double[] b;
        private static double[] resid;
        private static double[] yHat;

        private static double[] totalDeviation;
        private static double[] explainedDeviation;
        private static double[] unExplainedDeviation;

        private static string[] VariableHeadings;

        public static double[] Coeff { get { return b; } }

        public static void Initialize(double[] depVar, double[,] indVar, string[] headings)
        {
            VariableHeadings = headings;

            nObs = depVar.GetLength(0);
            nVars = indVar.GetLength(0);

            yMean = depVar.Average();

            x = indVar;
            y = depVar;

            b = new double[nVars];
            resid = new double[nObs];
            yHat = new double[nObs];

            explainedDeviation = new double[nObs];
            unExplainedDeviation = new double[nObs];

            double globalSumOfSquares = 0;
            double pGlobalSumOfSquares = 10;

            int c2 = 0;
            while (Math.Abs(pGlobalSumOfSquares - globalSumOfSquares) > 0.0001)
            {
                pGlobalSumOfSquares = globalSumOfSquares;

                for (int z = 0; z < nVars; z++)
                {
                    globalSumOfSquares = Iterate(z);
                }
                c2++;
            }
            //Debug.Write(explainedDeviation.Sum() / (explainedDeviation.Sum() + unExplainedDeviation.Sum()));
        }

        private static double Iterate(int varIndex)
        {
            double sumSquares = 0;
            double prevSumSquares = 10;
            double step = 100.0;

            while (Math.Abs(prevSumSquares - sumSquares) > 0.0001)
            {
                b[varIndex] += step;
                for (int i = 0; i < nVars; i++)
                {
                    for (int j = 0; j < nObs; j++)
                    {
                        yHat[j] += b[i] * x[i, j];
                        //explainedDeviation[j] = (yHat[j] - yMean) * (yHat[j] - yMean);
                        //unExplainedDeviation[j] = (y[j] - yHat[j]) *(y[j] - yHat[j]);
                    }
                }

                prevSumSquares = sumSquares;
                sumSquares = 0.0;
                for (int j = 0; j < nObs; j++)
                {
                    resid[j] = y[j] - yHat[j];
                    yHat[j] = 0.0;
                    sumSquares += resid[j] * resid[j];
                }
                yHat = new double[nObs];
                if ((prevSumSquares - sumSquares) < 0)
                    step = step * (-.5);
            }
            return sumSquares;
        }

        public static string StringOut()
        {
            string result = string.Empty;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                result += VariableHeadings[i] + jntType.Vertical + "b" + i + "=" + b[i].ToString("0.00000") + Environment.NewLine;
            }
            return result;
        }
    }
}