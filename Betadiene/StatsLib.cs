using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betadiene
{
    public static class StatsLib
    {

        public static double Correlation(double[] var1, double[] var2)
        {
            if (var1.Length != var2.Length)
                return double.NaN;
            
            double result = 0;
            for (int i = 0; i < var1.Length; i++ )
            {
                result += var1[i] * var2[i];
            }
            return result / (var1.Length - 1);
        }

        //public static double[,] CorrelationMatrix ()

    }
}
