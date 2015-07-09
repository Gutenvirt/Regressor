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

namespace Betadiene
{
    public static class StatsLib
    {
        private static double[,] _fCritical = new double[,]{
            {161.45,199.5,215.71,224.58,230.16,236.77,241.88,245.95,248.01,250.1,252.2,253.25,254.06,254.19, 254.3},
            {18.513,19,19.164,19.247,19.296,19.353,19.396,19.429,19.446,19.462,19.479,19.487,19.494,19.495, 19.5},
            {10.128,9.5522,9.2766,9.1172,9.0135,8.8867,8.7855,8.7028,8.6602,8.6165,8.572,8.5493,8.532,8.5292, 8.53},
            {7.7086,6.9443,6.5915,6.3882,6.256,6.0942,5.9644,5.8579,5.8026,5.7458,5.6877,5.658,5.6352,5.6317, 5.63},
            {6.6078,5.7862,5.4095,5.1922,5.0504,4.8759,4.7351,4.6187,4.5582,4.4958,4.4314,4.3985,4.3731,4.3691, 4.36},
            {5.5914,4.7375,4.3469,4.1202,3.9715,3.7871,3.6366,3.5108,3.4445,3.3758,3.3043,3.2675,3.2388,3.2344, 3.23},
            {4.9645,4.1028,3.7082,3.478,3.3259,3.1354,2.9782,2.845,2.7741,2.6996,2.621,2.5801,2.5482,2.543, 2.54},
            {4.5431,3.6823,3.2874,3.0556,2.9013,2.7066,2.5437,2.4035,2.3275,2.2467,2.1601,2.1141,2.0776,2.0718, 2.07},
            {4.3512,3.4928,3.0983,2.866,2.7109,2.514,2.3479,2.2032,2.1241,2.0391,1.9463,1.8962,1.8563,1.8498, 1.84},
            {4.1709,3.3159,2.9223,2.6896,2.5336,2.3343,2.1646,2.0149,1.9317,1.8408,1.7396,1.6835,1.6376,1.63, 1.64},
            {4.0012,3.1505,2.7581,2.5252,2.3683,2.1666,1.9927,1.8365,1.748,1.6492,1.5343,1.4672,1.4093,1.3994, 1.39},
            {3.9201,3.0718,2.6802,2.4473,2.2898,2.0868,1.9104,1.7505,1.6587,1.5544,1.4289,1.3519,1.2804,1.2674, 1.25},
            {3.8601,3.0137,2.6227,2.3898,2.232,2.0278,1.8496,1.6864,1.5917,1.482,1.3455,1.2552,1.1586,1.1378, 1.14},
            {3.8508,3.0047,2.6137,2.3808,2.223,2.0187,1.8402,1.6765,1.5811,1.4705,1.3318,1.2385,1.1342,1.1096, 1.1},
            {3.84, 3, 2.6, 2.37, 2.21, 2.01, 1.83, 1.67, 1.57, 1.46, 1.32, 1.22, 1.21, 1.1, 1}
            };

        public static double FCritical(int dfn, int dfd)
        {
            int[] dfRanges = new int[] { 1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 60, 120, 500, 1000, 1001 };

            int lbn = 1;
            int ubn = 1;

            int lbd = 1;
            int ubd = 1;

            for (int i = 0; i < dfRanges.Length; i++)
            {
                if (dfn > dfRanges[i])
                {
                    lbn = i;
                    if (i == dfRanges.Length - 1)
                        ubn = lbn;
                    else
                        ubn = lbn + 1;
                }

                if (dfd > dfRanges[i])
                {
                    lbd = i;
                    if (i == dfRanges.Length - 1)
                        ubd = lbd;
                    else
                        ubd = lbd + 1;
                }

                if (dfn == dfRanges[i])
                {
                    lbn = i;
                    ubn = lbn;
                }

                if (dfd == dfRanges[i])
                {
                    lbd = i;
                    ubd = lbd;
                }
            }

            double nRatio = 1;
            double dRatio = 1;

            if (dfRanges[ubn] - dfRanges[lbn] != 0)
                nRatio = 1.0 - (dfRanges[ubn] - dfn) / (dfRanges[ubn] - dfRanges[lbn]);

            if (dfRanges[ubd] - dfRanges[lbd] != 0)
                dRatio = 1.0 - (dfRanges[ubd] - dfd) / (dfRanges[ubd] - dfRanges[lbd]);
       
            double p1 = _fCritical[lbd, lbn] + nRatio * (_fCritical[lbd, ubd] - _fCritical[lbd, lbn]);

            return p1 + dRatio * (_fCritical[ubd, lbn] - p1);
        }

        public static double[] TwoSampleTTest(double[] numberlist)
        {
            return numberlist.Length < 6 ? new double[] { double.NaN } : TwoSampleTTest((int)numberlist[0], numberlist[1], numberlist[2], (int)numberlist[3], numberlist[4], numberlist[5]);
        }

        public static double[] TwoSampleTTest(DblColumn col1, DblColumn col2)
        {
            return TwoSampleTTest(col1.Size, col1.Mean, col1.StndDev, col2.Size, col2.Mean, col2.StndDev);
        }

        public static double[] TwoSampleTTest(int sizeA, double meanA, double stdDevA, int sizeB, double meanB, double stdDevB)
        {
            double sn1 = (stdDevA * stdDevA) / sizeA;
            double sn2 = (stdDevB * stdDevB) / sizeB;
            double rec1 = 1.0 / (sizeA - 1.0);
            double rec2 = 1.0 / (sizeB - 1.0);

            double dfstat = Math.Pow(sn1 + sn2, 2) / (rec1 * Math.Pow(sn1, 2) + rec2 * Math.Pow(sn2, 2));
            double tstat = (meanA - meanB) / Math.Sqrt(sn1 + sn2);

            return new double[] { dfstat, tstat };
        }

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

        public static double[,] CorrelationMatrix(DblColumn[] zScorefield)
        {
            var result = new double[zScorefield.Length, zScorefield.Length];
            for (int i = 0; i < zScorefield.Length; i++)
            {
                for (int j = 0; j < zScorefield.Length; j++)
                {
                    if (j <= i)
                        result[i, j] = Correlation(zScorefield[i].StandardizeValues(), zScorefield[j].StandardizeValues());
                    else
                        result[i, j] = double.NaN;
                }
            }

            return result;
        }

        public static double[,] EffectSize(DblColumn col1, DblColumn col2)
        {
            var result = new double[4, 2];

            result[0, 0] = col1.Mean;
            result[1, 0] = col1.StndDev;

            result[0, 1] = col2.Mean;
            result[1, 1] = col2.StndDev;

            result[2, 0] = double.NaN;
            result[2, 1] = 0.5 * (col1.StndDev + col2.StndDev);

            result[3, 0] = double.NaN;
            result[3, 1] = (col2.Mean - col1.Mean) / result[2, 1];

            return result;
        }

        public static double[] Ols(DblColumn y, DblColumn[] x)
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
                if (varCnt == nVars + 1)
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
