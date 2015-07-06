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
    public static class Graphics
    {

        public static string CDF(Column Data, string ops)
        {
            var xData = new double[Data.Size];
            var yData = new double[Data.Size];

            Data.ColumnToArray().CopyTo(xData, 0);

            Array.Sort(xData);

            yData[0] = 1.0 / Data.Size;
            for (int i = 1; i < Data.Size; i++)
            {
                yData[i] = yData[i - 1] + yData[0];
            }

            return Scatter(new Column[] { new Column(xData, "Sorted Data"), new Column(yData, "Percent of Data") }, ops);

        }

        public static string Scatter(Column[] data, string ops)
        {



            double size = 1.0;
            double yline = double.NaN;

            if (ops.Length > 5)
            {
                string[] oTmp = ops.Split(SpcChar.Space);

                for (int i = 0; i < oTmp.Length; i++)
                {
                    if (oTmp[i].IndexOf("size=") > -1)
                    {
                        double.TryParse(oTmp[i].Substring(5, oTmp[i].Length - 5), out size);
                        Settings.graphHeight = (int)(Settings.graphHeight * size);
                        Settings.graphWidth = (int)(Settings.graphWidth * size);
                        continue;
                    }
                    if (oTmp[i].IndexOf("width=") > -1)
                    {
                        int.TryParse(oTmp[i].Substring(6, oTmp[i].Length - 6), out Settings.graphWidth);
                        continue;
                    }
                    if (oTmp[i].IndexOf("height=") > -1)
                    {
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out Settings.graphHeight);
                        continue;
                    }
                    if (oTmp[i].IndexOf("yline=") > -1)
                    {
                        double.TryParse(oTmp[i].Substring(6, oTmp[i].Length - 6), out yline);
                        continue;
                    }
                }
            }

            int dataSize = data[0].Size;

            // data[0] is y and is separate from these maxs and mins

            double max = data[1].Max;
            double min = data[1].Min;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].Max > max)
                    max = data[i].Max;
                if (data[i].Min < min)
                    min = data[i].Min;
            }

            char[,] plot = new char[Settings.graphHeight, Settings.graphWidth];

            yline = Settings.graphHeight * (yline);

            for (int i = 0; i < Settings.graphWidth; i++) //create grid of null (space) characters
            {
                for (int j = 0; j < Settings.graphHeight; j++)
                {
                    plot[j, i] = SpcChar.Space;
                    if (j == (int)(yline))
                        plot[j, i] = SpcChar.Dot;
                }
            }


            double[] mappedColX = MathsLib.MapToRange(data[0], 0, Settings.graphWidth - 1);

            for (int h = 1; h < data.Length; h++) //iterate through all columns
            {
                double[] mappedColY = MathsLib.MapToRange(data[h], min, max, 0, Settings.graphHeight - 1);

                for (int i = 0; i < dataSize; i++) //map x,y points from columns to grid above
                {
                    if (h == 1)
                        plot[(int)mappedColY[i], (int)mappedColX[i]] = SpcChar.Cross;
                    if (h == 2)
                        plot[(int)mappedColY[i], (int)mappedColX[i]] = SpcChar.Plus;
                    if (h == 3)
                        plot[(int)mappedColY[i], (int)mappedColX[i]] = SpcChar.Nought;
                    if (h == 4)
                        plot[(int)mappedColY[i], (int)mappedColX[i]] = SpcChar.Square;
                    if (h > 4)
                        plot[(int)mappedColY[i], (int)mappedColX[i]] = (char)(49 + h);

                }
            }

            var repDataTally = 0.0;
            var sOut = new StringBuilder();

            sOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, Settings.graphWidth) + SpcChar.UpperRight + Environment.NewLine);
            for (int i = Settings.graphHeight - 1; i > -1; i--)
            {
                sOut.Append(SpcChar.Vertical);
                for (int j = 0; j < Settings.graphWidth; j++)
                {
                    sOut.Append(plot[i, j]);
                    if (plot[i, j] != SpcChar.Space && plot[i, j] != SpcChar.Dot)
                        repDataTally++;
                }

                sOut.Append(SpcChar.Vertical);

                if (i == Settings.graphHeight - 1)
                    sOut.Append(max.ToString("0.00"));

                if (i == 0)
                    sOut.Append(min.ToString("0.00"));

                sOut.Append(Environment.NewLine);
            }

            sOut.Append(SpcChar.LowerLeft + new string(SpcChar.Horizontal, Settings.graphWidth) + SpcChar.LowerRight + Environment.NewLine);

            if (Settings.graphWidth > 9)
                sOut.Append(SpcChar.Space + data[0].Min.ToString("0.00") + new string(SpcChar.Space, Settings.graphWidth - 9) + data[0].Max.ToString("0.00") + Environment.NewLine);
            else
                sOut.Append(new string(SpcChar.Space, Settings.graphWidth) + Environment.NewLine);

            repDataTally = repDataTally / (double)((data.Length - 1) * data[0].Size) * 100.0; //two columns per scatter to only 50% is tally.

            sOut.Append(Environment.NewLine + "Data represented: " + repDataTally.ToString("0.00") + "%");

            return sOut.ToString();
        }


        public static string Histogram(Column[] data, string ops)
        {


            hType type = hType.Density;

            if (ops.Length > 5)
            {
                string[] oTmp = ops.Split(SpcChar.Space);

                for (int i = 0; i < oTmp.Length; i++)
                {
                    if (oTmp[i].IndexOf("bins=") > -1)
                        int.TryParse(oTmp[i].Substring(5, oTmp[i].Length - 5), out Settings.nBins);
                    if (oTmp[i].IndexOf("height=") > -1)
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out Settings.graphHeight);

                    //add type percent, density, freq 
                }
            }

            string sResult = string.Empty;
            double[] nResult;

            var cutoffs = new double[Settings.nBins];

            double max = data[0].Max;
            double min = data[0].Min;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].Max > max)
                    max = data[i].Max;
                if (data[i].Min < min)
                    min = data[i].Min;
            }

            double step = (max - min) / Settings.nBins;

            for (int l = 0; l < Settings.nBins; l++)
            {
                cutoffs[l] = l * step + min;
            }

            var visOut = new StringBuilder();

            visOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, Settings.nBins * 5) + SpcChar.UpperRight + Environment.NewLine);

            for (int h = 0; h < data.Length; h++)
            {
                nResult = new double[Settings.nBins];

                for (int i = 0; i < data[h].Size; i++)
                {
                    if (data[h][i] > cutoffs[Settings.nBins - 1])
                    {
                        nResult[Settings.nBins - 1]++;
                        continue;
                    }
                    for (int j = 1; j < Settings.nBins - 1; j++)
                    {
                        if ((data[h][i] >= cutoffs[j]) && (data[h][i] < cutoffs[j + 1]))
                        {
                            nResult[j]++;
                            continue;
                        }
                    }
                    if (data[h][i] < cutoffs[1])
                    {
                        nResult[0]++;
                        continue;
                    }
                }

                if (type == hType.Density)
                {
                    double divmax = 1.0 / nResult.Max();
                    for (int i = 0; i < Settings.nBins; i++)
                    {
                        nResult[i] = nResult[i] * divmax;
                    }
                }
                if (type == hType.Percent)
                {
                    double total = 1.0 / data[0].Size;
                    for (int i = 0; i < Settings.nBins; i++)
                    {
                        nResult[i] = nResult[i] * total;
                    }
                }

                for (int i = 0; i < Settings.graphHeight; i++) // down
                {
                    visOut.Append(SpcChar.Vertical);
                    for (int j = 0; j < Settings.nBins; j++) // across
                    {
                        if ((int)(Settings.graphHeight - nResult[j] * Settings.graphHeight) == i)
                            visOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, 3) + SpcChar.UpperRight);
                        else
                            if (i > Settings.graphHeight - nResult[j] * Settings.graphHeight)
                                visOut.Append(SpcChar.Vertical + new string(SpcChar.Space, 3) + SpcChar.Vertical);
                            else
                                visOut.Append(new string(SpcChar.Space, 5));
                    }
                    visOut.Append(SpcChar.Vertical + new string(SpcChar.Space, 1) + (1.0 - (double)i / Settings.graphHeight).ToString("0.00") + Environment.NewLine);
                }
                if (h == data.Length - 1)
                    visOut.Append(SpcChar.LowerLeft);
                else
                    visOut.Append(SpcChar.ThreeWayRight);

                for (int i = 0; i < Settings.nBins; i++)
                {
                    if (nResult[i] > 0)
                        visOut.Append(SpcChar.ThreeWayUp + new string(SpcChar.Horizontal, 3) + SpcChar.ThreeWayUp);
                    else
                        visOut.Append(new string(SpcChar.Horizontal, 5));
                }
                if (h == data.Length - 1)
                    visOut.Append(SpcChar.LowerRight);
                else
                    visOut.Append(SpcChar.ThreeWayLeft);
                visOut.Append(Environment.NewLine);
            }
            if (Settings.nBins > 2)
                visOut.Append(SpcChar.Space + cutoffs[0].ToString("0.00") + "<" + new string(SpcChar.Space, Settings.nBins * 5 - 11) + ">" + cutoffs[cutoffs.Length - 1].ToString("0.00") + Environment.NewLine);
            
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