//
//  Histogram.cs
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
using System.Text;
using System.Diagnostics;


namespace Betadiene
{
    public static class Histogram
    {

        public static string GetValues(hType type, Column[] data, int nBins = 10)
        {
            string sResult = string.Empty;
            double[] nResult;

            var cutoffs = new double[nBins];

            double max = data[0].Max;
            double min = data[0].Min;

            for (int i = 1; i < data.Length ; i++)
            {
                if (data[i].Max > max)
                    max = data[i].Max;
                if (data[i].Min < min)
                    min = data[i].Min;
            }

            double step = (max - min) / nBins;

            for (int l = 0; l < nBins; l++)
            {
                cutoffs[l] = l * step + min;
            }

            foreach (Column col in data )
            {
                nResult = new double[nBins];

                for (int i = 0; i < col.Size; i++ )
                {
                    if (col[i] > cutoffs[nBins - 1])
                    {
                        nResult[nBins - 1]++;
                        continue;
                    }
                    for (int j = 1; j < nBins - 1; j++)
                    {
                        if ((col[i] >= cutoffs[j]) && (col[i] < cutoffs[j + 1]))
                        {
                            nResult[j]++;
                            continue;
                        }
                    }
                    if (col[i] < cutoffs[1])
                    {
                        nResult[0]++;
                        continue;
                    }
                }

                if (type == hType.Density)
                {
                    double divmax = 1.0 / nResult.Max();
                    for (int i = 0; i < nBins; i++)
                    {
                        nResult[i] = nResult[i] * divmax;
                    }
                }
                if (type == hType.Percent)
                {
                    double total = 1.0 / data[0].Size;
                    for (int i = 0; i < nBins; i++)
                    {
                        nResult[i] = nResult[i] * total;
                    }
                }

                sResult += display(nResult) + Environment.NewLine;
            }
            return sResult;
        }

        public static string display(double[] data)
        {
            var visOut = new StringBuilder();

            for (int i = 0; i < 10; i++) // down
            {
                for (int j = 0; j < 10; j++) // across
                {
                    if ((int)(10 - data[j] * 10) == i)
                    {
                        visOut.Append(jntType.UpperLeft + new string(jntType.Horizontal, 3) + jntType.UpperRight);
                    }
                    else
                    {
                        if (i > 10 - data[j] * 10)
                            visOut.Append(jntType.Vertical + new string(' ', 3) + jntType.Vertical);
                        else
                            visOut.Append(new string(' ', 5));
                    }
                }
                visOut.Append(Environment.NewLine);
            }

            return visOut.ToString();
        }

    }

    public enum hType
    {
        Density,
        Frequency,
        Percent
    }
}