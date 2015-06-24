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


        public DataDozier(double[] yData)
        {
            this.Size = yData.GetLength(0);
            this.Min = yData.Min();
            this.Max = yData.Max();
            this.Sum = yData.Sum();
            this.Mean = yData.Average();
            this.Variance = CalculateVariance(yData);
            this.StndDev = CalculateStndDev(yData);
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
