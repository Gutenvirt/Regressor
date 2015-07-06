//
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

        public string MsgServer { get; set; } //convert to voids to boolean and report here
        public int[] SelectedColumns { get; set; }
        public int[] AllColumns { get; set; }

        public Dictionary<String, int> VariableList = new Dictionary<string, int>();

        //add property missing data points

        public DataField()
        {
            SelectedColumns = new int[] { };
            AllColumns = new int[] { };
        }

        public void AddColumn(double[] data, string heading = "")
        {
            if (heading == "" | heading == string.Empty)
                heading = Settings.headingPrefix + _indexer.ToString();
            _dblField.Add(new Column(data, heading));
            
            if (VariableList.ContainsKey(heading))
                heading += _indexer;
            
            VariableList.Add(heading, _indexer);

            // need to add check for duplicate columns and rename it with a modifier!!!!!!!!!!

            _indexer++;
            _length = data.GetLength(0);
        }

        public void drop(int[] indices)
        {
            if (indices.Length == 0)
                return;

            foreach (int i in indices)
            {
                VariableList.Remove(this[i].Heading);
                
                _dblField.RemoveAt(i);
                _indexer--;
            }
        }

        public Column this[int col]
        {
            get { return _dblField[col]; }
        }

        public double this[int col, int row]
        {
            get { return _dblField[col][row]; }
        }

        public double[,] ToArray(int[] indices)
        {
            if (indices.Length == 0)
                indices = AllColumns;

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
            if (indices.Length == 0)
                indices = AllColumns;

            Column[] result = new Column[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                result[i] = this[indices[i]];
            }
            return result;
        }

        public double[,] Describe(int[] indices)
        {
            if (indices.Length == 0)
                indices = AllColumns;

            double[,] result = new double[10, indices.Length];

            for (int i = 0; i < indices.Length; i++)
            {
                result[0, i] = this[indices[i]].UniqueValues;
                result[1, i] = this[indices[i]].Min;
                result[2, i] = this[indices[i]].Q1;
                result[3, i] = this[indices[i]].Mean;
                result[4, i] = this[indices[i]].Median;
                result[5, i] = this[indices[i]].Q3;
                result[6, i] = this[indices[i]].Max;
                result[7, i] = this[indices[i]].Sum;
                result[8, i] = this[indices[i]].Variance;
                result[9, i] = this[indices[i]].StndDev;
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
            if (indices.Length == 0)
                indices = AllColumns;

            var result = new string[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                if (this[indices[i]].Sorted)
                    result[i] = SpcChar.Not + this[indices[i]].Heading;
                else
                    result[i] = this[indices[i]].Heading;
            }
            return result;
        }

        
    }
}
