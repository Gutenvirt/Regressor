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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betadiene
{
    public class Column
    {
        private double[] _Storage;

        public string Heading { get; set; }

        public int Size { get; set; }
        public int UniqueValues { get; set; }
        public int MissingValues {get; set;}
        
        public double Min { get; set; }
        public double Q1 { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Q3 { get; set; }
        public double Max { get; set; }
        public double Variance { get; set; }
        public double Sum { get; set; }
        public double StndDev { get; set; }

    public Column(double[] data, string heading)
        {
            this.Heading = heading.Replace(" ",string.Empty);
            this.Size  = data.GetLength(0);
            this._Storage = new double[Size];
            
            data.CopyTo(_Storage, 0);//add missing data NAN here!@@@@@@@@@@@@@@
            Array.Sort(data);

            this.Min = data[0];
            this.Q1 = this.Size % 2 != 0 ? data[this.Size / 4] : (data[this.Size / 4] + data[this.Size / 4 - 1]) / 2;
            this.Median= this.Size % 2 != 0 ? data[this.Size / 2] : (data[this.Size / 2] + data[this.Size / 2 - 1]) / 2;
            this.Q3 = this.Size % 2 != 0 ? data[this.Size /4*3] : (data[this.Size /4*3] + data[this.Size / 4*3 - 1]) / 2;
            this.Max = data[this.Size - 1];
            this.Sum = data.Sum();
            this.Mean = this.Sum / this.Size;
            this.Variance = CalculateVariance();
            this.StndDev = CalculateStndDev();
            this.UniqueValues = data.Distinct().Count();
    }

        public double this[int i]
        {
            get
            {
                if (i < Size)
                    return _Storage[i];
                else
                    return double.NaN;
            }
            set { _Storage[i] = value; }
        }

        private double CalculateVariance()
        {
            var result = new double();
            for (int i = 0; i < this.Size; i++)
            {
                result += (this[i] - this.Mean) * (this[i] - this.Mean);
            }
            return result / (this.Size - 1);
        }

        private double CalculateStndDev()
        {
            return Math.Sqrt(this.Variance);
        }      

        public double[] StandardizeValues ()
        {
            var result = new double[this.Size];
            double recip = 1.0/this.StndDev;

            for (int i = 0; i < this.Size ; i++)
            {
                result[i] = (this[i] - this.Mean) * recip;
            }
            return result;
        }

        public double[] ColumnToArray()
        {
            return _Storage;
        }
    }
}
