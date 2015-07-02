//
//  Settings.cs
//
//  Author:
//       Christopher Stefancik <gutenvirt@gmail.com>
//
//  Copyright (c) 2015
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
