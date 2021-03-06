﻿namespace Betadiene
{
    public static class MathsLib
    {

        public static double NIntegrate(DblColumn col)
        {
            var result = 0.0;
            for (int i = 0; i < col.Size - 1; i++)
            {
                result += (col[i] + col[i + 1]) * .5;
            }
            return result;
        }

        public static double[] MapToRange(DblColumn col, double newMin, double newMax)
        {
            return MapToRange(col, col.Min, col.Max, newMin, newMax);
        }

        public static double[] MapToRange(DblColumn col, double oldMin, double oldMax, double newMin, double newMax)
        {
            var result = new double[col.Size];

            double ratio = (newMax - newMin)/(oldMax - oldMin);

            for (int i = 0; i < col.Size; i++)
            {
                result[i] = newMin + ratio * (col[i] - oldMin);
            }
            return result;
        }

    }
}
