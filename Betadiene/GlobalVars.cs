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

using System.Collections.Generic;

namespace Betadiene
{
    public static class GlobalVars
    {

        public static int CellLength = 12;
        public static int CellPrecision = 4;
        public static string StrFormat = "{0," + CellLength + ":0." + new string('#', CellPrecision) + "}";
        public static string HeadingPrefix = "v";
        public static string WorkingDir = "c:\\";
        public static string DefaultExt = ".csv";
        public static int GraphWidth = 35;
        public static int GraphHeight = 15;
        public static int NBins = 10;


        public static Dictionary<string, int> VariableList = new Dictionary<string, int>();
    }
}
