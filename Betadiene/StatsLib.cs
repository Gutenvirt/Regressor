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
        public static double Correlation(double [] col1, double [] col2)
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


        /*
        public delegate double rFunc(double arg);

        public static double h = 10e-6;

        public static double Derivative(rFunc f, double x)
        {
            double h2 = h * 2;
            return (f(x - h2) - 8 * f(x - h) + 8 * f(x + h) - f(x + h2)) / (h2 * 6);
        }

        public static double nDerivative(double[] data,double centeredx ,double dx = 1.0)
    {
        return (data[i+1]-data[i-1])/2/h;
    }
        */

    }
}
