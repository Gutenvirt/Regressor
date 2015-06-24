//
//  DataDozier.cs
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
    public class DataDozier
    {

        public double Variance { get; set; }
        public double Mean { get; set; }
        public double Sum { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double StndDev { get; set; }
        public int Size { get; set; }
        public int UniqueValues { get; set; }


        public DataDozier(double[] yData)
        {
            this.Size = yData.GetLength(0);
            this.Min = yData.Min();
            this.Max = yData.Max();
            this.Sum = yData.Sum();
            this.Mean = yData.Average();
            this.Variance = CalculateVariance(yData);
            this.StndDev = CalculateStndDev(yData);
            this.UniqueValues = yData.Distinct().Count();
        }

        private double CalculateStndDev(double[] _data)
        {
            return Math.Sqrt(this.Variance / Size);
        }

        private double CalculateVariance(double[] _data)
        {
            var result = new double();
            for (int i = 0; i < this.Size; i++)
            {
                result += (_data[i] - this.Mean) * (_data[i] - this.Mean);
            }
            result = result / (this.Size - 1);
            return result;
        }

    }
}
