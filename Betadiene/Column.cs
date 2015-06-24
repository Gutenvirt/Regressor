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
    public class Column : DataDozier
    {

        protected double[] _Storage;

        protected string myHeading;
        public string Heading { get { return myHeading; } }

        public Column(double[] data, string heading)
            : base (data)
        {
            myHeading = heading.Trim();
            Size  = data.GetLength(0);
            _Storage = new double[Size];
            data.CopyTo(_Storage, 0);
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

        public double[] ReturnZScore ()
        {
            var result = new double[this.Size];
            double recip = 1.0/this.StndDev;

            for (int i = 0; i < this.Size ; i++)
            {
                result[i] = (this[i] - this.Mean) * recip;
            }

            return result;
        }

        public double[] ToArray()
        {
            return _Storage;
        }
    }
}
