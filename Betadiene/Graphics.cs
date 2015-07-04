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

        public static string Scatter (Column xData, Column yData, string ops)
        {
            int xSize = 35;
            int ySize = 15;

            if (ops.Length > 5)
            {
                string[] oTmp = ops.Split(SpcChar.Space);

                for (int i = 0; i < oTmp.Length; i++)
                {
                    if (oTmp[i].IndexOf("width=") > -1)
                        int.TryParse(oTmp[i].Substring(6, oTmp[i].Length - 6), out xSize);
                    if (oTmp[i].IndexOf("height=") > -1)
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out ySize);
                }
            }

            double xRatio = (xData.Max - xData.Min) / (xSize-1);
            double yRatio = (yData.Max - yData.Min) / (ySize-1);

            char[,] plot = new char[ySize, xSize];

            for (int i = 0; i < xData.Size; i++)
            {
                int ycoord = (int)((yData[i]-yData.Min)/yRatio);
                int xcoord = (int)((xData[i] - xData.Min) / xRatio);

                plot[ycoord, xcoord] = SpcChar.Cross;
            }

            var sOut = new StringBuilder();

            for (int i = ySize-1; i > -1; i-- )
            {
                sOut.Append(SpcChar.Vertical);
                for (int j = 0; j < xSize; j++)
                {
                    if (plot[i, j] == SpcChar.Cross)
                        sOut.Append(plot[i, j]);
                    else
                        sOut.Append(SpcChar.Space);
                }
                sOut.Append(Environment.NewLine);
                if (i == 0)
                    sOut.Append(SpcChar.LowerLeft + new string(SpcChar.Horizontal, xSize));
            }

            return sOut.ToString();
        }


        public static string Histogram(Column[] data, string ops)
        {
            int nBins = 10;
            int height = 10;

            hType type = hType.Density;

            if (ops.Length > 5)
            {
                string[] oTmp = ops.Split(SpcChar.Space);

                for (int i = 0; i < oTmp.Length; i++ )
                {
                    if (oTmp[i].IndexOf("bins=") > -1)
                        int.TryParse(oTmp[i].Substring(5, oTmp[i].Length - 5), out nBins);
                    if (oTmp[i].IndexOf("height=") > -1)
                        int.TryParse(oTmp[i].Substring(7, oTmp[i].Length - 7), out height);
                    
                    
                    //add type percent, density, freq 
                }
            }

            string sResult = string.Empty;
            double[] nResult;

            var cutoffs = new double[nBins];

            double max = data[0].Max;
            double min = data[0].Min;

            for (int i = 1; i < data.Length; i++)
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

            foreach (Column col in data)
            {
                nResult = new double[nBins];

                for (int i = 0; i < col.Size; i++)
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

                sResult += col.Heading + Environment.NewLine + RenderHistogram(nResult, nBins, max, height) + Environment.NewLine;
            }
            return sResult;
        }

        public static string RenderHistogram(double[] data, int nBins, double max, int height)
        {
            var visOut = new StringBuilder();

            for (int i = 0; i < height; i++) // down
            {
                for (int j = 0; j < nBins; j++) // across
                {
                    if ((int)(height - data[j] * height) == i)
                    {
                        visOut.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, 3) + SpcChar.UpperRight);
                    }
                    else
                    {
                        if (i > height - data[j] * height)
                            visOut.Append(SpcChar.Vertical + new string(SpcChar.Space, 3) + SpcChar.Vertical);
                        else
                            visOut.Append(new string(SpcChar.Space, 5));
                    }
                }
                visOut.Append(new string(SpcChar.Space, 3) +(1.0 - (double)i / height) + Environment.NewLine);
            }
            for (int i = 0; i < nBins; i++)
            {
                if (data[i] > 0)
                { 
                    visOut.Append(SpcChar.ThreeWayUp + new string(SpcChar.Horizontal, 3) + SpcChar.ThreeWayUp); 
                } 
                else
                {
                    visOut.Append (new string(SpcChar.Horizontal,5));
                }
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