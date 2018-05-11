using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace N6700
{
    public partial class DataGraph : Form
    {
        public List<string> Labels = new List<string>();
        public int nTabCnt;
        public double dOffset;
        public int nPoints;
        public double dTimeDelta;
        public HandleUIData hui = new HandleUIData();
        public List<double> dTime = new List<double>();
        public List<double[]> datalst = new List<double[]>();
        double[] dData;// = new double[nPoints];

        public DataGraph()
        {
            InitializeComponent();
        }

        private void DataGraph_Load(object sender, EventArgs e)
        {
            chart_Data.Palette = ChartColorPalette.Pastel;
            chart_Data.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart_Data.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart_Data.ChartAreas[0].AxisX.Minimum = 0;
            chart_Data.ChartAreas[0].AxisX.Interval = (dTimeDelta * nPoints) / 10;
            chart_Data.ChartAreas[0].AxisX.Title = "Time (Sec)";
            chart_Data.ChartAreas[0].AxisY.Title = "Voltage (V)";        
        }

        public void diaplay()
        {
            xHandleSeqData();
            drawdatagraph();
        }

        private void xHandleSeqData()
        {
            for (int index = 0; index < nTabCnt; index++)
            {
                dData = new double[nPoints];
                dData = Array.ConvertAll(hui.DigitizerData[index].Split(','), Double.Parse);

                if (Labels[index].Contains("-"))
                {
                    for (int n = 0; n < nPoints; n++)
                    {
                        dData[n] = dData[n] * -1;
                    }
                }
                datalst.Add(dData);
            }
        }

        private void drawdatagraph()
        {
            for (int n = 1; n <= nPoints; n++)
            {
                dTime.Add((dTimeDelta * dOffset) + (dTimeDelta * (n - 1)));
            }

            for (int index = 0; index < nTabCnt; index++)
            {
                chart_Data.Series.Add(Labels[index]);
                chart_Data.Series[index].ChartType = SeriesChartType.Line;
                chart_Data.Series[index].BorderWidth = 5;

                double[] ddata = datalst[index];

                chart_Data.Series[index].Points.DataBindXY(dTime.ToArray(), ddata);
            }
        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfDialog = new SaveFileDialog();

            sfDialog.Filter = "csv |*.csv";
            sfDialog.Title = "Save File Dialog";

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                bt_Save.Enabled = false;
                bt_Save.Text = "Saving...";
                string fileName = sfDialog.FileName;
                FileStream myStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(myStream);

                string sData = null;

                for (int index = 0; index < nTabCnt; index++)
                {
                    if (index != 0)
                        sData = sData + "," + Labels[index];
                    else
                        sData = sData + "Time" + "," + Labels[index];
                }

                sw.WriteLine(sData);

                for (int n = 0; n < nPoints; n++)
                {
                    sData = null;
                    for (int index = 0; index < nTabCnt; index++)
                    {   
                        double dElement = datalst[index][n];

                        if (index != 0)
                            sData = sData + "," + dElement.ToString();
                        else
                            sData = sData + dTime.ToArray()[n] + "," + dElement.ToString();
                    }
                    sw.WriteLine(sData);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("Save File Success!");
                bt_Save.Text = "Save";
                bt_Save.Enabled = true;
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_SAVEIMG_Click(object sender, EventArgs e)
        {
            this.chart_Data.SaveImage(".\\data.png", ChartImageFormat.Png);
            MessageBox.Show("Save picture Success!");
        }
    }
}
