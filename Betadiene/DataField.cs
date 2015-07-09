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

using System.Collections.Generic;

namespace Betadiene
{
    public class DataField
    {
        private List<DblColumn> _dblField = new List<DblColumn>();
        private List<StrColumn> _strField = new List<StrColumn>();

        private int _indexer;
        private int _length;

        public int NumberVariables { get { return _indexer; } }
        public int NumberObservations { get { return _length; } }

        public string MsgServer { get; set; } //convert to voids to boolean and report here
        public int[] SelectedColumns { get; set; }
        public int[] AllColumns { get; set; }

        public string InternalMessage { get; set; }

        public Dictionary<string, int> VariableList = new Dictionary<string, int>();

        //add property missing data points

        public DataField()
        {
            SelectedColumns = new int[] { };
            AllColumns = new int[] { };
        }

        public void AddColumn(string[] data, string heading = "")
        {
            if (heading == "" | heading == string.Empty)
                heading = Settings.HeadingPrefix + _indexer;
                _strField.Add(new StrColumn(data, heading));

            if (VariableList.ContainsKey(heading))
                heading += _indexer;

            VariableList.Add(heading, _indexer);

            _indexer++;
            _length = data.GetLength(0);
        }

        public void AddColumn(double[] data, string heading = "")
        {
            if (string.IsNullOrEmpty(heading))
                heading = Settings.HeadingPrefix + _indexer;
            _dblField.Add(new DblColumn(data, heading));
            
            if (VariableList.ContainsKey(heading))
                heading += _indexer;
            
            VariableList.Add(heading, _indexer);

            _indexer++;
            _length = data.GetLength(0);
        }

        public void Drop(int[] indices)
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

        public DblColumn this[int col]
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

            double[,] result = new double[NumberObservations, indices.Length];

            int count = 0;
            foreach (int col in indices)
            {
                for (int j = 0; j < NumberObservations; j++)
                {
                    result[j, count] = this[col][j];
                }
                count++;
            }
            return result;
        }

        public DblColumn[] ToField(int[] indices)
        {
            if (indices.Length == 0)
                indices = AllColumns;

            DblColumn[] result = new DblColumn[indices.Length];
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

            double[,] result = new double[12, indices.Length];

            for (int i = 0; i < indices.Length; i++)
            {
                result[0, i] = this[indices[i]].Size;
                result[1, i] = this[indices[i]].UniqueValues;
                result[2, i] = this[indices[i]].MissingValues;
                result[3, i] = this[indices[i]].Min;
                result[4, i] = this[indices[i]].Q1;
                result[5, i] = this[indices[i]].Mean;
                result[6, i] = this[indices[i]].Median;
                result[7, i] = this[indices[i]].Q3;
                result[8, i] = this[indices[i]].Max;
                result[9, i] = this[indices[i]].Sum;
                result[10, i] = this[indices[i]].Variance;
                result[11, i] = this[indices[i]].StndDev;
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
