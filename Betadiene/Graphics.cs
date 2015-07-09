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

namespace Betadiene
{
    public static class Graphics
    {
        public static string Cdf(DblColumn data, string ops)
        {
            var xData = new double[data.Size];
            var yData = new double[data.Size];

            data.ColumnToArray().CopyTo(xData, 0);

            Array.Sort(xData);

            yData[0] = 1.0/data.Size;
            for (var i = 1; i < data.Size; i++)
            {
                yData[i] = yData[i - 1] + yData[0];
            }

            return Scatter(new[] {new DblColumn(xData, "Sorted Data"), new DblColumn(yData, "Percent of Data")}, ops);
        }

        public static string Scatter(DblColumn[] data, string ops)
        {
            var yline = double.NaN;

            if (ops.Length > 5)
            {
                var oTmp = ops.Split(SpcChar.Space);

                for (var i = 0; i < oTmp.Length; i++)
                {
                    if (oTmp[i].IndexOf("size=") > -1)
                    {
                        var size = 1.0;
                        double.TryParse(oTmp[i].Substring(5, oTmp[i].Length - 5), out size);
                        GlobalVars.GraphHeight = (int) (GlobalVars.GraphHeight*size);
                        GlobalVars.GraphWidth = (int) (GlobalVars.GraphWidth*size);
                        continue;
                    }
                    if (oTmp[i].IndexOf("width=") > -1)
                    {
                        int.TryParse(oTmp[i].Substring(6, oTmp[i].Length - 6), out GlobalVars.GraphWidth);
                        continue;
                    }
                    if (oTmp[i].IndexOf("height=") > -1)
                    {
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out GlobalVars.GraphHeight);
                        continue;
                    }
                    if (oTmp[i].IndexOf("yline=") > -1)
                    {
                        double.TryParse(oTmp[i].Substring(6, oTmp[i].Length - 6), out yline);
                    }
                }
            }

            var dataSize = data[0].Size;

            // data[0] is y and is separate from these maxs and mins

            var max = data[1].Max;
            var min = data[1].Min;

            for (var i = 1; i < data.Length; i++)
            {
                if (data[i].Max > max)
                    max = data[i].Max;
                if (data[i].Min < min)
                    min = data[i].Min;
            }

            var plot = new char[GlobalVars.GraphHeight, GlobalVars.GraphWidth];

            yline = GlobalVars.GraphHeight*(yline);

            for (var i = 0; i < GlobalVars.GraphWidth; i++) //create grid of null (space) characters
            {
                for (var j = 0; j < GlobalVars.GraphHeight; j++)
                {
                    plot[j, i] = SpcChar.Space;
                    if (j == (int) (yline))
                        plot[j, i] = SpcChar.Dot;
                }
            }


            var mappedColX = MathsLib.MapToRange(data[0], 0, GlobalVars.GraphWidth - 1);

            for (var h = 1; h < data.Length; h++) //iterate through all columns
            {
                var mappedColY = MathsLib.MapToRange(data[h], min, max, 0, GlobalVars.GraphHeight - 1);

                for (var i = 0; i < dataSize; i++) //map x,y points from columns to grid above
                {
                    if (h == 1)
                        plot[(int) mappedColY[i], (int) mappedColX[i]] = SpcChar.Cross;
                    if (h == 2)
                        plot[(int) mappedColY[i], (int) mappedColX[i]] = SpcChar.Plus;
                    if (h == 3)
                        plot[(int) mappedColY[i], (int) mappedColX[i]] = SpcChar.Nought;
                    if (h == 4)
                        plot[(int) mappedColY[i], (int) mappedColX[i]] = SpcChar.Square;
                    if (h > 4)
                        plot[(int) mappedColY[i], (int) mappedColX[i]] = (char) (49 + h);
                }
            }

            var repDataTally = 0.0;
            var sOut = new StringBuilder();

            sOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, GlobalVars.GraphWidth) + SpcChar.UpperRight +
                        Environment.NewLine);
            for (var i = GlobalVars.GraphHeight - 1; i > -1; i--)
            {
                sOut.Append(SpcChar.Vertical);
                for (var j = 0; j < GlobalVars.GraphWidth; j++)
                {
                    sOut.Append(plot[i, j]);
                    if (plot[i, j] != SpcChar.Space && plot[i, j] != SpcChar.Dot)
                        repDataTally++;
                }

                sOut.Append(SpcChar.Vertical);

                if (i == GlobalVars.GraphHeight - 1)
                    sOut.Append(max.ToString("0.00"));

                if (i == 0)
                    sOut.Append(min.ToString("0.00"));

                sOut.Append(Environment.NewLine);
            }

            sOut.Append(SpcChar.LowerLeft + new string(SpcChar.Horizontal, GlobalVars.GraphWidth) + SpcChar.LowerRight +
                        Environment.NewLine);

            if (GlobalVars.GraphWidth > 9)
                sOut.Append(SpcChar.Space + data[0].Min.ToString("0.00") +
                            new string(SpcChar.Space, GlobalVars.GraphWidth - 9) + data[0].Max.ToString("0.00") +
                            Environment.NewLine);
            else
                sOut.Append(new string(SpcChar.Space, GlobalVars.GraphWidth) + Environment.NewLine);

            repDataTally = repDataTally/((data.Length - 1)*data[0].Size)*100.0;
                //two columns per scatter to only 50% is tally.

            sOut.Append(Environment.NewLine + "Data represented: " + repDataTally.ToString("0.00") + "%");

            return sOut.ToString();
        }

        public static string Histogram(DblColumn[] data, string ops)
        {
            var type = HType.Density;

            if (ops.Length > 5)
            {
                var oTmp = ops.Split(SpcChar.Space);

                for (var i = 0; i < oTmp.Length; i++)
                {
                    if (oTmp[i].IndexOf("bins=") > -1)
                        int.TryParse(oTmp[i].Substring(5, oTmp[i].Length - 5), out GlobalVars.NBins);
                    if (oTmp[i].IndexOf("height=") > -1)
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out GlobalVars.GraphHeight);

                    //add type percent, density, freq 
                }
            }

            var cutoffs = new double[GlobalVars.NBins];

            var max = data[0].Max;
            var min = data[0].Min;

            for (var i = 1; i < data.Length; i++)
            {
                if (data[i].Max > max)
                    max = data[i].Max;
                if (data[i].Min < min)
                    min = data[i].Min;
            }

            var step = (max - min)/GlobalVars.NBins;

            for (var l = 0; l < GlobalVars.NBins; l++)
            {
                cutoffs[l] = l*step + min;
            }

            var visOut = new StringBuilder();

            visOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, GlobalVars.NBins*5) + SpcChar.UpperRight +
                          Environment.NewLine);

            var nResult = new double[GlobalVars.NBins];

            for (var h = 0; h < data.Length; h++)
            {
                for (var i = 0; i < data[h].Size; i++)
                {
                    if (data[h][i] > cutoffs[GlobalVars.NBins - 1])
                    {
                        nResult[GlobalVars.NBins - 1]++;
                        continue;
                    }
                    for (var j = 1; j < GlobalVars.NBins - 1; j++)
                    {
                        if ((data[h][i] >= cutoffs[j]) && (data[h][i] < cutoffs[j + 1]))
                        {
                            nResult[j]++;
                        }
                    }
                    if (data[h][i] < cutoffs[1])
                    {
                        nResult[0]++;
                    }
                }

                if (type == HType.Density)
                {
                    var divmax = 1.0/nResult.Max();
                    for (var i = 0; i < GlobalVars.NBins; i++)
                    {
                        nResult[i] = nResult[i]*divmax;
                    }
                }
                if (type == HType.Percent)
                {
                    var total = 1.0/data[0].Size;
                    for (var i = 0; i < GlobalVars.NBins; i++)
                    {
                        nResult[i] = nResult[i]*total;
                    }
                }

                for (var i = 0; i < GlobalVars.GraphHeight; i++) // down
                {
                    visOut.Append(SpcChar.Vertical);
                    for (var j = 0; j < GlobalVars.NBins; j++) // across
                    {
                        if ((int) (GlobalVars.GraphHeight - nResult[j]*GlobalVars.GraphHeight) == i)
                            visOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, 3) + SpcChar.UpperRight);
                        else if (i > GlobalVars.GraphHeight - nResult[j]*GlobalVars.GraphHeight)
                            visOut.Append(SpcChar.Vertical + new string(SpcChar.Space, 3) + SpcChar.Vertical);
                        else
                            visOut.Append(new string(SpcChar.Space, 5));
                    }
                    visOut.Append(SpcChar.Vertical + new string(SpcChar.Space, 1) +
                                  (1.0 - (double) i/GlobalVars.GraphHeight).ToString("0.00") + Environment.NewLine);
                }
                visOut.Append(h == data.Length - 1 ? SpcChar.LowerLeft : SpcChar.ThreeWayRight);

                for (var i = 0; i < GlobalVars.NBins; i++)
                {
                    if (nResult[i] > 0)
                        visOut.Append(SpcChar.ThreeWayUp + new string(SpcChar.Horizontal, 3) + SpcChar.ThreeWayUp);
                    else
                        visOut.Append(new string(SpcChar.Horizontal, 5));
                }
                visOut.Append(h == data.Length - 1 ? SpcChar.LowerRight : SpcChar.ThreeWayLeft);
                visOut.Append(Environment.NewLine);
            }
            if (GlobalVars.NBins > 2)
                visOut.Append(SpcChar.Space + cutoffs[0].ToString("0.00") + "<" +
                              new string(SpcChar.Space, GlobalVars.NBins*5 - 11) + ">" +
                              cutoffs[cutoffs.Length - 1].ToString("0.00") + Environment.NewLine);

            return visOut.ToString();
        }
    }

    public enum HType
    {
        Density,
        Frequency,
        Percent
    }
}