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

        private int _cellLength = 12;
        private int _cellPrecision = 4;

        public int NumberVariables { get { return _indexer; } }
        public int NumberObservations { get { return _length; } }

        public string MsgServer { get; set; }
        public bool Initialized { get; set; }
        public List<int> SelectedColumns { get; set; }

        public DataField()
        {
            Initialized = true;
            SelectedColumns = new List<int>();
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

        public string CalculateDescriptiveStatistics()
        {
            var Output = new StringBuilder();

            string strFormat = "{0," + _cellLength.ToString() + ":0." + new string('#', _cellPrecision) + "}";

            Output.Append(jntType.UpperLeft + new string(jntType.Horizontal , _cellLength ) + jntType.ThreeWayDown  + new string(jntType.Horizontal, (_indexer) * _cellLength) + jntType.UpperRight + Environment.NewLine);

            Output.Append(jntType.Vertical + "Unique Obs  " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].UniqueValues)); 
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Minimum     " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].Min));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Mean        " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].Mean));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Maximum     " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].Max));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Sum         " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].Sum));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Variance    " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].Variance));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.Vertical + "Std. Dev.   " + jntType.Vertical);
            for (int i = 0; i < _indexer; i++)
            {
                Output.Append(string.Format(strFormat,_dblField[i].StndDev));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);


            Output.Append(jntType.LowerLeft + new string(jntType.Horizontal , _cellLength ) + jntType.ThreeWayUp  + new string(jntType.Horizontal, (_indexer) * _cellLength) + jntType.LowerRight + Environment.NewLine);

            return Output.ToString();
        }

        public override string ToString()
        {
            var Output = new StringBuilder();

            string strFormat = "{0," + _cellLength.ToString() + ":0." + new string('#', _cellPrecision) + "}";

            Output.Append(jntType.UpperLeft + new string(jntType.Horizontal, (_indexer) * _cellLength) + jntType.UpperRight + Environment.NewLine);

            Output.Append(jntType.Vertical);
            for (int j = 0; j < _indexer; j++)
            {
                if (SelectedColumns.Contains(j))
                    Output.Append((jntType.ThreeWayLeft + _dblField[j].Heading + jntType.ThreeWayRight).PadLeft(_cellLength));
                else
                    Output.Append(_dblField[j].Heading.PadLeft(_cellLength));
            }
            Output.Append(jntType.Vertical + Environment.NewLine);

            Output.Append(jntType.ThreeWayRight + new string(jntType.Horizontal, (_indexer) * _cellLength) + jntType.ThreeWayLeft + Environment.NewLine);

            for (int i = 0; i < _length; i++)
            {
                Output.Append(jntType.Vertical);
                for (int j = 0; j < _indexer; j++)
                {
                    Output.Append(string.Format(strFormat, _dblField[j][i]));
                }
                Output.Append(jntType.Vertical + Environment.NewLine);
            }

            Output.Append(jntType.LowerLeft + new string(jntType.Horizontal, (_indexer) * _cellLength) + jntType.LowerRight + Environment.NewLine);

            return Output.ToString();
        }

        public void FileRead(string filename, bool hasHeaders = true)
        {
            StreamReader srFile = new StreamReader(filename);
            
            var nObs = File.ReadLines(filename).Count();
            
            var headerNames = srFile.ReadLine().Split(',');
            var nVars = headerNames.GetLength(0);

            if (headerNames[0].Any(x => char.IsLetter(x)))
                hasHeaders = true ;

            if (hasHeaders)
                nObs--;

            var dblRawData = new double[nObs, nVars];

            srFile.BaseStream.Position = 0;
            srFile.DiscardBufferedData();

            var strBuffer = new string[nVars];

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
