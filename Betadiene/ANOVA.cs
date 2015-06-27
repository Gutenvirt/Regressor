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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Betadiene
{
    public static class ANOVA
    {
        public static double grandMean = 0;
        public static double grandStdDev = 0;
        public static double grandVariance = 0;
        public static double SSTotal = 0;
        public static double SSBetween = 0;
        public static double SSWithin = 0;

        public static string OneWay(double[,] data, double[] means)
        {
            int _numVar = data.GetLength(1);
            int _numObs = data.GetLength(0);

            for (int i = 0; i < _numVar; i++)
            {
                grandMean += means[i];
            }

            grandMean = grandMean / _numVar;

            for (int i = 0; i < _numVar; i++)
            {
                for (int j = 0; j < _numObs; j++)
                {
                    SSTotal += (data[j, i] - grandMean) * (data[j, i] - grandMean);
                }
            }

            grandVariance = SSTotal / (_numObs * _numVar - 1);
            grandStdDev = Math.Sqrt(grandVariance);

            for (int i = 0; i < _numVar; i++)
            {
                SSBetween += (means[i] - grandMean) * (means[i] - grandMean);
            }

            SSBetween *= _numObs;
            SSWithin = SSTotal - SSBetween;

            var outD = new double[3, 4];

            outD[0, 0] = SSBetween;
            outD[1, 0] = SSWithin;
            outD[2, 0] = SSTotal;
            
            outD[0, 1] = _numVar - 1;
            outD[1, 1] = _numObs*_numVar - _numVar;
            outD[2, 1] = _numObs*_numVar - 1;

            outD[0, 2] = SSBetween / outD[0, 1];
            outD[1, 2] = SSWithin / outD[1, 1];

            outD[0, 3] = outD[0, 2] / outD[1, 2];

            Debug.Write(outD[1, 3]);
            
            var cHead = new string[] { "Sum of Squares", "Degrees of Freedom", "Mean Square", "F Ratio" };
            var rHead = new string[] { "Between", "Within", "Total" };

            return Tabulate.CreateTable(outD, cHead, rHead, "ANOVA - One Way", true);
        }


    }
}
