using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betadiene
{
    public static class ANOVA
    {
        double grandMean = 0;
        double grandStdDev = 0;
        double grandVariance = 0;
        double SSTotal = 0;
        double SSBetween = 0;
        double SSWithin = 0;

        public static string ANOVA()
        {

            for (int i = 0; i < this.NumberVariables; i++)
            {
                grandMean += this[i].Mean;
            }

            grandMean = grandMean / this.NumberVariables;

            for (int i = 0; i < this.NumberVariables; i++)
            {
                for (int j = 0; j < this.NumberObservations; j++)
                {
                    SSTotal += (this[i, j] - grandMean) * (this[i, j] - grandMean);
                }
            }

            grandVariance = SSTotal / (this.NumberObservations * this.NumberVariables - 1);
            grandStdDev = Math.Sqrt(grandVariance);

            for (int i = 0; i < this.NumberVariables; i++)
            {
                SSBetween += (this[i].Mean - grandMean) * (this[i].Mean - grandMean);
            }

            SSBetween *= this.NumberObservations;
            SSWithin = SSTotal - SSBetween;



            return "gMean: " + grandMean + Environment.NewLine + "gVar: " + grandVariance + Environment.NewLine + "gStdDev: " + grandStdDev + Environment.NewLine + "SSTotal: " + SSTotal + Environment.NewLine + "SSBetween: " + SSBetween + Environment.NewLine + "SSWithin: " + SSWithin;
        }


    }
}
