//
//  Tabulate.cs
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
using System.Text;

namespace Betadiene
{

    public static class Tabulate
    {

        public static string[] Truncate(string[] txtData, bool center = false)
        {
            for (int i = 0; i < txtData.GetLength(0); i++)
            {
                if (center)
                {
                    if (txtData[i].Length > GlobalVars.CellLength - 1)
                        txtData[i] = " " + txtData[i][0] + txtData[i].Substring(1, GlobalVars.CellLength - 4) + '~' + txtData[i][txtData[i].Length - 1]; // + " ";
                    else
                        txtData[i] = new string(' ', (GlobalVars.CellLength - txtData[i].Length) / 2) + txtData[i] + new string(' ', (GlobalVars.CellLength - txtData[i].Length) / 2);
                }
                else
                {
                    if (txtData[i].Length > GlobalVars.CellLength)
                        txtData[i] = txtData[i][0] + txtData[i].Substring(1, GlobalVars.CellLength - 3) + '~' + txtData[i][txtData[i].Length - 1];
                    else
                        txtData[i] = txtData[i].PadRight(GlobalVars.CellLength);
                }
            }
            return txtData;
        }

        /// <summary>
        /// Create a table, row x cols.
        /// </summary>
        public static string CreateTable(double[,] data)
        {
            return CreateTable(data, null, null, null, false);
        }

        /// <summary>
        /// Create a table, row x cols.
        /// </summary>
        public static string CreateTable(double[,] data, string[] colHeading)
        {
            return CreateTable(data, colHeading, null, null, false);
        }

        /// <summary>
        /// Create a table, row x cols.
        /// </summary>
        public static string CreateTable(double[,] data, string[] colHeading, string[] rowHeading, string title, bool isFixed = false)
        {
            int nCols = data.GetLength(1);
            int nRows = data.GetLength(0);

            int recordLabel = GlobalVars.CellLength;

            if (colHeading != null)
                colHeading = Truncate(colHeading, true);

            if (rowHeading != null)
                rowHeading = Truncate(rowHeading);
            else
                recordLabel = (int)Math.Log10(data.GetLength(0))+3;
        
            if (isFixed)
                GlobalVars.StrFormat = "{0," + GlobalVars.CellLength.ToString() + ":0." + new string('0', GlobalVars.CellPrecision) + "}";
            else
                GlobalVars.StrFormat = "{0," + GlobalVars.CellLength.ToString() + ":0." + new string('#', GlobalVars.CellPrecision) + "}";

            var result = new StringBuilder();

            //Title
            if (title != null)
                result.Append(title.ToUpper() + Environment.NewLine);


            //Heading
            result.Append(new string(' ', recordLabel + 1) + SpcChar.UpperLeft + new string(SpcChar.Horizontal, (nCols) * GlobalVars.CellLength) + SpcChar.UpperRight + Environment.NewLine);

            if (colHeading != null)
            {
                result.Append(new string(' ', recordLabel+1) + SpcChar.Vertical);
                int colCount = 0;
                while (colCount < nCols)
                {
                    result.Append(colHeading[colCount].PadLeft(GlobalVars.CellLength));
                    colCount++;
                }
                result.Append(SpcChar.Vertical + Environment.NewLine);
                result.Append(SpcChar.UpperLeft + new string(SpcChar.Horizontal, recordLabel) + SpcChar.FourWay + new string(SpcChar.Horizontal, (nCols) * GlobalVars.CellLength) + SpcChar.ThreeWayLeft + Environment.NewLine);
            }

            //Rows
            int rowCount = 0;
            while (rowCount < nRows)
            {
                if (rowHeading != null)
                    result.Append(SpcChar.Vertical + rowHeading[rowCount] + SpcChar.Vertical);
                else
                    result.Append(SpcChar.Vertical + ((rowCount + 1) + ".").ToString().PadRight(recordLabel) + SpcChar.Vertical);

                int colCount = 0;
                while (colCount < nCols)
                {
                    if (double.IsNaN(data[rowCount, colCount]))
                        result.Append(new string(' ', GlobalVars.CellLength - 1) + '.');
                    else
                        result.Append(string.Format(GlobalVars.StrFormat, data[rowCount, colCount]));
                    colCount++;
                }
                result.Append(SpcChar.Vertical + Environment.NewLine);
                rowCount++;
            }

            result.Append(SpcChar.LowerLeft + new string(SpcChar.Horizontal, recordLabel) + SpcChar.ThreeWayUp + new string(SpcChar.Horizontal, (nCols) * GlobalVars.CellLength) + SpcChar.LowerRight + Environment.NewLine);

            return result.ToString();
        }
    }
}
