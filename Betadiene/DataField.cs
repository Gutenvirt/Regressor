﻿//
//  DataField.cs
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
using System.IO;
using System.Data.Common;
using System.Diagnostics;

namespace Betadiene
{
    public class DataField
    {
        private List<Column> _dblField = new List<Column>();

        private int _indexer = 0;
        private int _length = 0;

        public int NumberVariables { get { return _indexer; } }
        public int NumberObservations { get { return _length; } }

        public string MsgServer { get; set; }
        public int[] SelectedColumns { get; set; }

        //public string[] ColumnHeadings { get; set; }

        //public double[] ColumnMeans { get; set; }

        //add property missing data points

        public DataField()
        {
            SelectedColumns = new int[] { };
        }

        public void AddColumn(double[] data, string heading = "V")
        {
            if (heading == "V")
                heading = "V" + _indexer.ToString();
            _dblField.Add(new Column(data, heading));
            _indexer++;
            _length = data.GetLength(0);
        }

        public Column this[int col]
        {
            get { return _dblField[col]; }
        }

        public double this[int col, int row]
        {
            get { return _dblField[col][row]; }
        }

        public double[] ToRegressionArray(int column)
        {
            double[] result = new double[this.NumberObservations];

            for (int j = 0; j < this.NumberObservations; j++)
            {
                result[j] = this[column][j];
            }
            return result;
        }

        public double[,] ToRegressionArray(int[] indices)
        {
            double[,] result = new double[indices.GetLength(0) + 1, this.NumberObservations];

            int count = 1;
            foreach (int col in indices)
            {
                for (int j = 0; j < this.NumberObservations; j++)
                {
                    result[count, j] = this[col][j];
                }
                count++;
            }
            for (int i = 0; i < this.NumberObservations; i++)
            {
                result[0, i] = 1;
            }

            return result;
        }

        public double[,] ToArray(int[] indices)
        {
            double[,] result = new double[this.NumberObservations, indices.Length];

            int count = 0;
            foreach (int col in indices)
            {
                for (int j = 0; j < this.NumberObservations; j++)
                {
                    result[j, count] = this[col][j];
                }
                count++;
            }
            return result;
        }

        public Column[] ToField(int[] indices)
        {
            Column[] result = new Column[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                result[i] = this[indices[i]];
            }
            return result;
        }

        public double[,] CalculateDescriptiveStatistics()
        {
            double[,] result = new double[10, this.NumberVariables];

            for (int i = 0; i < this.NumberVariables; i++)
            {
                result[0, i] = this[i].UniqueValues;
                result[1, i] = this[i].Min;
                result[2, i] = this[i].Q1;
                result[3, i] = this[i].Mean;
                result[4, i] = this[i].Median;
                result[5, i] = this[i].Q3;
                result[6, i] = this[i].Max;
                result[7, i] = this[i].Sum;
                result[8, i] = this[i].Variance;
                result[9, i] = this[i].StndDev;
            }

            return result;
        }

        public double[] GetColumnAverages(int[] indices)
        {
            var result = new double[NumberVariables];

            int count = 0;
            foreach (int col in indices)
            {
                result[count] = this[col].Mean;
                count++;
            }
            return result;
        }

        public string[] ReturnColumnHeadings(int[] indices)
        {
            var result = new string[indices.Length];
            for (int i = 0 ; i < indices.Length ; i++)
            {
                result[i] = this[indices[i]].Heading;
            }
            return result;
        }

        public void FileRead(string filename, bool hasHeaders = true)
        {
            StreamReader srFile = new StreamReader(filename);

            var nObs = File.ReadLines(filename).Count();

            var headerNames = srFile.ReadLine().Split(',');
            var nVars = headerNames.GetLength(0);

            if (headerNames[0].Any(x => char.IsLetter(x)))
                hasHeaders = true;

            if (hasHeaders)
                nObs--;

            var dblRawData = new double[nObs, nVars];

            srFile.BaseStream.Position = 0;
            srFile.DiscardBufferedData();

            var strBuffer = new string[nVars];

            if (hasHeaders)
                headerNames = srFile.ReadLine().Split(',');
            else
            {
                for (int m = 0; m < nVars; m++)
                {
                    headerNames[m] = "V";
                }
            }

            int counter = 0;
            while (!srFile.EndOfStream)
            {
                strBuffer = srFile.ReadLine().Split(',');
                for (int j = 0; j < nVars; j++)
                    double.TryParse(strBuffer[j], out dblRawData[counter, j]);
                counter++;
            }

            srFile.Close();

            var dblTemp = new double[nObs];
            for (int i = 0; i < nVars; i++)
            {
                for (int j = 0; j < nObs; j++)
                {
                    dblTemp[j] = dblRawData[j, i];
                }
                this.AddColumn(dblTemp, headerNames[i]);
            }
            MsgServer = NumberObservations + " OBS in " + NumberVariables + " VAR";
        }
    }
}
