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
using System.Linq;

namespace Betadiene
{
    public static class Regressor
    {
        private static int _nObs;
        private static int _nVars;

        private static double _yMean;

        private static double[,] _x;
        private static double[] _y;
        private static double[] _b;
        private static double[] _resid;
        private static double[] _yHat;

        private static double[] _totalDeviation;
        private static double[] _explainedDeviation;
        private static double[] _unExplainedDeviation;

        private static string[] _variableHeadings;

        public static double[] Coeff { get { return _b; } }

        public static void Initialize(double[] depVar, double[,] indVar, string[] headings)
        {
            _variableHeadings = headings;

            _nObs = depVar.GetLength(0);
            _nVars = indVar.GetLength(0);

            _yMean = depVar.Average();

            _x = indVar;
            _y = depVar;

            _b = new double[_nVars];
            _resid = new double[_nObs];
            _yHat = new double[_nObs];

            _explainedDeviation = new double[_nObs];
            _unExplainedDeviation = new double[_nObs];

            double globalSumOfSquares = 0;
            double pGlobalSumOfSquares = 10;

            int c2 = 0;
            while (Math.Abs(pGlobalSumOfSquares - globalSumOfSquares) > 0.0001)
            {
                pGlobalSumOfSquares = globalSumOfSquares;

                for (int z = 0; z < _nVars; z++)
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
                _b[varIndex] += step;
                for (int i = 0; i < _nVars; i++)
                {
                    for (int j = 0; j < _nObs; j++)
                    {
                        _yHat[j] += _b[i] * _x[i, j];
                        //explainedDeviation[j] = (yHat[j] - yMean) * (yHat[j] - yMean);
                        //unExplainedDeviation[j] = (y[j] - yHat[j]) *(y[j] - yHat[j]);
                    }
                }

                prevSumSquares = sumSquares;
                sumSquares = 0.0;
                for (int j = 0; j < _nObs; j++)
                {
                    _resid[j] = _y[j] - _yHat[j];
                    _yHat[j] = 0.0;
                    sumSquares += _resid[j] * _resid[j];
                }
                _yHat = new double[_nObs];
                if ((prevSumSquares - sumSquares) < 0)
                    step = step * (-.5);
            }
            return sumSquares;
        }

        public static string StringOut()
        {
            string result = string.Empty;
            for (int i = 0; i < _b.GetLength(0); i++)
            {
                result += _variableHeadings[i] + SpcChar.Vertical + "b" + i + "=" + _b[i].ToString("0.00000") + Environment.NewLine;
            }
            return result;
        }
    }
}