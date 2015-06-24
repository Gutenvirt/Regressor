using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;

namespace Betadiene
{
    public class DataField
    {
        private List<Column> _dblField = new List<Column>();

        private int _indexer = 0;
        private int _length = 0;

        public int NumberVariables { get { return _indexer; } }
        public int NumberObservations { get { return _length; } }

        public string MsgServer { get; set; }
        public bool Initialized { get; set; }
        public int CurrentColumn { get; set; }

        public DataField()
        {
            Initialized = true;
            CurrentColumn = 0;
        }

        public void AddColumn(double[] data, string heading = "V")
        {
            if (heading == "V")
                heading = "V" + _indexer.ToString();
            _dblField.Add(new Column(data, heading));
            _indexer++;
            _length = data.GetLength(0);
        }

        public Column this[int col]
        {
            get { return _dblField[col]; }
        }

        public double this[int col, int row]
        {
            get { return _dblField[col][row]; }
        }

        public double[] ToRegressionArray(int column)
        {
            double[] result = new double[this.NumberObservations];

            for (int j = 0; j < this.NumberObservations; j++)
            {
                result[j] = this[column][j];
            }
            return result;
        }

        public double[,] ToRegressionArray(int[] indices)
        {
            double[,] result = new double[indices.GetLength(0) + 1, this.NumberObservations];

            int count = 1;
            foreach (int col in indices)
            {
                for (int j = 0; j < this.NumberObservations; j++)
                {
                    result[count, j] = this[col][j];
                }
                count++;
            }
            for (int i = 0; i < this.NumberObservations; i++)
            {
                result[0, i] = 1;
            }

            return result;
        }

        public double[,] ToArray()
        {
            double[,] tMatrix = new double[this.NumberObservations, this.NumberVariables];
            for (int i = 0; i < this.NumberVariables; i++)
            {
                for (int j = 0; j < this.NumberObservations; j++)
                {
                    tMatrix[i, j] = this[i][j];
                }
            }
            return tMatrix;
        }

        public override string ToString()
        {
            var Output = new StringBuilder();
            int cellPrecision = 2;
            int cellLength = cellPrecision * 2 + 4;

            string strFormat = "{0," + cellLength.ToString() + ":0." + new string('0', cellPrecision) + "}";

            Output.Append(jntType.UpperLeft + new string(jntType.Horizontal, (_indexer) * cellLength) + jntType.UpperRight + Environment.NewLine);

            Output.Append(jntType.Vertical);
            for (int j = 0; j < _indexer; j++)
            {
                if (j == CurrentColumn)
                    Output.Append((jntType.ThreeWayLeft + _dblField[j].Heading + jntType.ThreeWayRight).PadLeft(cellLength));
                else
                    Output.Append(_dblField[j].Heading.PadLeft(cellLength));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.ThreeWayRight + new string(jntType.Horizontal, (_indexer) * cellLength) + jntType.ThreeWayLeft + Environment.NewLine);

            for (int i = 0; i < _length; i++)
            {
                Output.Append(jntType.Vertical);
                for (int j = 0; j < _indexer; j++)
                {
                    Output.Append(string.Format(strFormat, _dblField[j][i]));
                }
                Output.Append(jntType.Vertical + Environment.NewLine);
            }

            Output.Append(jntType.LowerLeft + new string(jntType.Horizontal, (_indexer) * cellLength) + jntType.LowerRight + Environment.NewLine);

            return Output.ToString();
        }

        public void FileRead(string filename, bool hasHeaders = true)
        {
            StreamReader srFile = new StreamReader(filename);
            
            var nObs = File.ReadLines(filename).Count();
            var nVars = srFile.ReadLine().Split(',').GetLength(0);

            if (hasHeaders)
                nObs--;

            var dblRawData = new double[nObs, nVars];

            srFile.BaseStream.Position = 0;
            srFile.DiscardBufferedData();

            var strBuffer = new string[nVars];
            var headerNames = new string[nVars];

            if (hasHeaders)
                headerNames = srFile.ReadLine().Split(',');
            else
            {
                for (int m = 0; m < nVars; m++)
                {
                    headerNames[m] = "V";
                }
            }
            
            int counter = 0;
            while (!srFile.EndOfStream)
            {                    
                strBuffer = srFile.ReadLine().Split(',');
                for (int j = 0; j < nVars; j++)
                    double.TryParse(strBuffer[j], out dblRawData[counter, j]);
                counter++;
            }

            srFile.Close();

            var dblTemp = new double[nObs];
            for (int i = 0; i < nVars; i++)
            {
                for (int j = 0; j < nObs; j++)
                {
                    dblTemp[j] = dblRawData[j, i];
                }
                this.AddColumn(dblTemp, headerNames[i]);
            }
            MsgServer = NumberObservations + " OBS in " + NumberVariables + " VAR";
        }
    }

    public enum ColumnType
    {
        Integer,
        String
    }

    static class jntType
    {
        public const char Vertical = '│';
        public const char Horizontal = '─';
        public const char UpperLeft = '┌';
        public const char UpperRight = '┐';
        public const char LowerLeft = '└';
        public const char LowerRight = '┘';
        public const char ThreeWayDown = '┬';
        public const char ThreeWayUp = '┴';
        public const char ThreeWayLeft = '┤';
        public const char ThreeWayRight = '├';
        public const char FourWay = '┼';
        public const char FullBlock = '█';
        public const char Emphatic = '*';
    }
}
