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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Betadiene
{

    public static class Tabulate
    {
        public static int _cellLength = 12;
        public static int _cellPrecision = 4;

        static string strFormat = "{0," + _cellLength.ToString() + ":0." + new string('#', _cellPrecision) + "}";

        public static string[] Truncate(string[] txtData, bool center = false)
        {
            for (int i = 0; i < txtData.GetLength(0); i++)
            {
                if (center)
                {
                    if (txtData[i].Length > _cellLength - 1)
                        txtData[i] = " " + txtData[i][0] + txtData[i].Substring(1, _cellLength - 4) + '~' + txtData[i][txtData[i].Length - 1] + " ";
                    else
                        txtData[i] = new string(' ', (_cellLength - txtData[i].Length) / 2) + txtData[i] + new string(' ', (_cellLength - txtData[i].Length) / 2);
                }
                else
                {
                    if (txtData[i].Length > _cellLength)
                        txtData[i] = txtData[i][0] + txtData[i].Substring(1, _cellLength - 3) + '~' + txtData[i][txtData[i].Length - 1];
                    else
                        txtData[i] = txtData[i].PadRight(_cellLength);
                }
            }
            return txtData;
        }

        public static string CreateTable(double[,] data)
        {
            return CreateTable(data, null, null, null, false);
        }

        public static string CreateTable(double[,] data, string[] colHeading)
        {
            return CreateTable(data, colHeading, null, null, false);
        }

        public static string CreateTable(double[,] data, string[] colHeading, string[] rowHeading, string title, bool isFixed = false)
        {
            int nCols = data.GetLength(1);
            int nRows = data.GetLength(0);

            int _recordLabel = _cellLength;

            if (colHeading != null)
                colHeading = Truncate(colHeading, true);

            if (rowHeading != null)
                rowHeading = Truncate(rowHeading);
            else
                _recordLabel = (int)Math.Log10(data.GetLength(0))+3;
        
            if (isFixed)
                strFormat = "{0," + _cellLength.ToString() + ":0." + new string('0', _cellPrecision) + "}";
            else
                strFormat = "{0," + _cellLength.ToString() + ":0." + new string('#', _cellPrecision) + "}";

            var result = new StringBuilder();

            //Title
            if (title != null)
                result.Append(title.ToUpper() + Environment.NewLine);


            //Heading
            result.Append(jntType.UpperLeft + new string(jntType.Horizontal, _recordLabel) + jntType.ThreeWayDown + new string(jntType.Horizontal, (nCols) * _cellLength) + jntType.UpperRight + Environment.NewLine);

            if (colHeading != null)
            {
                result.Append(jntType.Vertical + new string(' ', _recordLabel) + jntType.Vertical);
                int colCount = 0;
                while (colCount < nCols)
                {
                    result.Append(colHeading[colCount].PadLeft(_cellLength ));
                    colCount++;
                }
                result.Append(jntType.Vertical + Environment.NewLine);
                result.Append(jntType.ThreeWayRight + new string(jntType.Horizontal, _recordLabel) + jntType.FourWay + new string(jntType.Horizontal, (nCols) * _cellLength) + jntType.ThreeWayLeft + Environment.NewLine);
            }

            //Rows
            int rowCount = 0;
            while (rowCount < nRows)
            {
                if (rowHeading != null)
                    result.Append(jntType.Vertical + rowHeading[rowCount] + jntType.Vertical);
                else
                    result.Append(jntType.Vertical + ((rowCount + 1) + ".").ToString().PadRight(_recordLabel) + jntType.Vertical);

                int colCount = 0;
                while (colCount < nCols)
                {
                    if (double.IsNaN(data[rowCount, colCount]))
                        result.Append(new string(' ', _cellLength));
                    else
                        result.Append(string.Format(strFormat, data[rowCount, colCount]));
                    colCount++;
                }
                result.Append(jntType.Vertical + Environment.NewLine);
                rowCount++;
            }

            result.Append(jntType.LowerLeft + new string(jntType.Horizontal, _recordLabel) + jntType.ThreeWayUp + new string(jntType.Horizontal, (nCols) * _cellLength) + jntType.LowerRight + Environment.NewLine);

            return result.ToString();
        }
    }
}
