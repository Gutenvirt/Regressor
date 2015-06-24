using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Betadiene
{
    public partial class Form1 : Form
    {
        public DataField abcd = new DataField();

        public Form1()
        {
            InitializeComponent();

            var watch = Stopwatch.StartNew();

            

            abcd.FileRead("c:\\datareg.csv");

            int u = abcd.NumberVariables;
            for (int i = 0; i < u; i++)
            {
                abcd.AddColumn(abcd[i].ReturnZScore(),"V"+i+"_z");
            }            

            double[] dv = abcd.ToRegressionArray(7);
            double[,] iv = abcd.ToRegressionArray(new int[] {8,9,10,11,12});

            Regressor.Initialize(dv, iv);

            txtOut.Text = "Vars: " + abcd.NumberVariables + " Obs: " + abcd.NumberObservations + Environment.NewLine + Environment.NewLine + "Elapsed time (ms): " + watch.ElapsedMilliseconds.ToString() + Environment.NewLine + Environment.NewLine;

            txtOut.Text += Regressor.StringOut();

            txtOut.Text += abcd.ToString()+Environment.NewLine;
            watch.Stop();

        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            txtCmds.Text = txtCmds.Text.ToLower();
            string[] cmd = txtCmds.Text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            txtCmds.Text = string.Empty;

                for (int i = 0; i < cmd.GetLength(0); i++)
                {
                    string _c = cmd[0];

                    switch (_c)
                    {
                        case "hist":
                            Histogram.Parse(cmd[1]);
                            txtOut.Text = Histogram.MsgQueue;
                            
                            cmd = new string[] { };
                            break;
                    }
                }
            }
    }
}
