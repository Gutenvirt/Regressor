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
    public static class Settings
    {

        public static int _cellLength = 12;
        public static int _cellPrecision = 4;
        public static string strFormat = "{0," + _cellLength.ToString() + ":0." + new string('#', _cellPrecision) + "}";
        public static string headingPrefix = "v";
        public static string workingDir = "c:\\";
        public static string defaultExt = ".csv";
        public static int graphWidth = 35;
        public static int graphHeight = 15;
        public static int nBins = 10;
    }
}
