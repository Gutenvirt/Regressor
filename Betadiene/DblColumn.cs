//
//  Column.cs
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

namespace Betadiene
{
    public class DblColumn
    {
        private double[] _storage;

        public string Heading { get; set; }

        public int Size { get; set; }
        public int UniqueValues { get; set; }
        public int MissingValues {get; set;} //implement

        public bool Sorted { get; set; }
        
        public double Min { get; set; }
        public double Q1 { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Q3 { get; set; }
        public double Max { get; set; }
        public double Variance { get; set; }
        public double Sum { get; set; }
        public double StndDev { get; set; }

    public DblColumn(double[] data, string heading)
        {
            Heading = heading.Replace(" ",string.Empty);
            Size  = data.GetLength(0);
            _storage = new double[Size];
            Sorted = false;
            
            data.CopyTo(_storage, 0);//add missing data NAN here!@@@@@@@@@@@@@@
            Array.Sort(data);

            Min = data[data.Length - 1];
            
            int counter = 0;
            for (int i = 0; i < Size; i++ )
            {
                if (!double.IsNaN(this[i]))
                {
                    Sum += this[i];
                    if (this[i] < Min)
                        Min = this[i];
                    counter++;
                }
            }
            MissingValues = Size - counter;    
            Size = counter;

            Min = data[0];
            Q1 = Size % 2 != 0 ? data[Size / 4] : (data[Size / 4] + data[Size / 4 - 1]) / 2;
            Median= Size % 2 != 0 ? data[Size / 2] : (data[Size / 2] + data[Size / 2 - 1]) / 2;
            Q3 = Size % 2 != 0 ? data[Size /4*3] : (data[Size /4*3] + data[Size / 4*3 - 1]) / 2;
            Max = data[Size - 1];
            Mean = Sum / Size;
            Variance = CalculateVariance();
            StndDev = CalculateStndDev();
            UniqueValues = data.Distinct().Count();
    }

        public double this[int i]
        {
            get
            {
                if (i < Size && !double.IsNaN(_storage[i]))
                    return _storage[i];
                return double.NaN;
            }
            set { _storage[i] = value; }
        }

        private double CalculateVariance()
        {
            var result = new double();
            for (int i = 0; i < Size; i++)
            {
                result += (this[i] - Mean) * (this[i] - Mean);
            }
            return result / (Size - 1);
        }

        private double CalculateStndDev()
        {
            return Math.Sqrt(Variance);
        }      

        public double[] StandardizeValues ()
        {
            var result = new double[Size];
            double recip = 1.0/StndDev;

            for (int i = 0; i < Size ; i++)
            {
                result[i] = (this[i] - Mean) * recip;
            }
            return result;
        }

        public double[] ColumnToArray()
        {
            return _storage;
        }

        public void Sort()
        {
            if (Sorted == false)
                Array.Sort(_storage);
            else
                if (this[0] < this[1])
                    Array.Reverse(_storage);
                else
                    Array.Sort(_storage);
            Sorted = true;
        }
    }
}
