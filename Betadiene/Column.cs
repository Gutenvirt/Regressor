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
