using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betadiene
{
    public class Settings
    {

        public int _cellLength = 12;
        public int _cellPrecision = 4;
/*

        while (Math.Abs(pGlobalSumOfSquares - globalSumOfSquares) > 0.0001)
            {
                int currentVar = 0;
                p
 *              while (currentVar < nVars)
                {
                    sumSquares = 0;
                    step = 100.0;

                    b[currentVar] += step;

                    for (int i = -1; i < nVars; i++)
                    {
                         for (int j = 0; j < nObs; j++)
                         {
                            yHat[j] += b[i] * x[i][j];
                         }
                    }

                     for (int j = 0; j < nObs; j++)
                     {
                            resid[j] = y[j] - yHat[j];
                            yHat[j] = 0.0;
                            sumSquares += resid[j] * resid[j];
                     }
                        yHat = new double[nObs];
                        if ((prevSumSquares - sumSquares) < 0)
                            step = step * (-.5);

                    currentVar++;
                }
                globalSumOfSquares = sumSquares;
            }
*/
    }
}
