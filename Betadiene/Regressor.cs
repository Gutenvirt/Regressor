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

        private static double[,] x;
        private static double[] y;
        private static double[] b;
        private static double[] resid;
        private static double[] yHat;

        private static string[] VariableHeadings;

        public static double[] Coeff { get { return b; } }

        public static void Initialize(double[] depVar, double[,] indVar, string[] headings)
        {
            VariableHeadings = headings;

            nObs = depVar.GetLength(0);
            nVars = indVar.GetLength(0);

            x = indVar;
            y = depVar;

            b = new double[nVars];
            resid = new double[nObs];
            yHat = new double[nObs];

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
            for (int i =0 ; i < b.GetLength(0); i++)
            {
                result += VariableHeadings[i] + jntType.Vertical + "b" + i + "=" + b[i].ToString("0.00000") + Environment.NewLine;
            }
            return result;
        }
    }
}
