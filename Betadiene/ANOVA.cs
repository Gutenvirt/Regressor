//
//  ANOVA.cs
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

namespace Betadiene
{
    public static class Anova
    {

        public static string OneWay(double[,] data, double[] means)
        {
            double grandMean = 0;
            double ssTotal = 0;
            double ssBetween = 0;
            double ssWithin = 0;

            int numVar = data.GetLength(1);
            int numObs = data.GetLength(0);

            for (int i = 0; i < numVar; i++)
            {
                grandMean += means[i];
            }

            grandMean = grandMean / numVar;

            for (int i = 0; i < numVar; i++)
            {
                for (int j = 0; j < numObs; j++)
                {
                    ssTotal += (data[j, i] - grandMean) * (data[j, i] - grandMean);
                }
            }

            for (int i = 0; i < numVar; i++)
            {
                ssBetween += (means[i] - grandMean) * (means[i] - grandMean);
            }

            ssBetween *= numObs;
            ssWithin = ssTotal - ssBetween;

            var outD = new double[3, 5];

            outD[0, 0] = ssBetween;
            outD[1, 0] = ssWithin;
            outD[2, 0] = ssTotal;

            outD[0, 1] = numVar - 1;
            outD[1, 1] = numObs * numVar - numVar;
            outD[2, 1] = numObs * numVar - 1;

            outD[0, 2] = ssBetween / outD[0, 1];
            outD[1, 2] = ssWithin / outD[1, 1];
            outD[2, 2] = double.NaN;

            outD[0, 3] = outD[0, 2] / outD[1, 2];
            outD[1, 3] = double.NaN;
            outD[2, 3] = double.NaN;

            outD[0, 4] = StatsLib.FCritical((int)outD[0,1], (int)outD[1,1]);
            outD[1, 4] = double.NaN;
            outD[2, 4] = double.NaN;

            var cHead = new string[] { "SS", "DF", "MS", "F Ratio", "F Critical" };
            var rHead = new string[] { "Between", "Within", "Total" };

            string s = "Null Hypothesis (H0): All population means are equal." + Environment.NewLine + "Alternative Hypothesis (Ha): At least one population was different from the others.";

            return Tabulate.CreateTable(outD, cHead, rHead, "ANOVA - One Way", true) + s ;
        }


    }
}
