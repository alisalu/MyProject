using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace N6700
{
    public partial class ShowSeqGraph : Form
    {
        public List<string> Labels = new List<string>();
        public List<int> TabIdx = new List<int>();
        public HandleUIData Hui = new HandleUIData();

        public ShowSeqGraph()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowSeqGraph_Load(object sender, EventArgs e)
        {
            chart_seq.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart_seq.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart_seq.ChartAreas[0].AxisX.Minimum = 0;
            chart_seq.ChartAreas[0].AxisX.Interval = 0.025; //0.05
           // chart_seq.ChartAreas[0].AxisY.Interval = 2;
            chart_seq.ChartAreas[0].AxisX.Title = "Time (Sec)";
            chart_seq.ChartAreas[0].AxisY.Title = "Voltage (V)";

            for (int index = 0; index < TabIdx.Count; index++)
            {
                int nid = TabIdx.ElementAt(index);
                TestSeq Tseq = Hui.SeqData[nid];
                chart_seq.Series.Add(Labels[index]);               
                chart_seq.Series[index].ChartType = SeriesChartType.Line;
                chart_seq.Series[index].BorderWidth = 5;
           
                double[] Vout = new double[Tseq.VoutPoints.Count];
        
                Tseq.VoutPoints.CopyTo(Vout);
                if (Labels[index].Contains("-"))
                {
                    for (int iIdx = 0; iIdx < Tseq.VoutPoints.Count; iIdx++)
                   {
                       Vout[iIdx] = Vout[iIdx] * -1;
                   }
                }
                chart_seq.Series[index].Points.DataBindXY(Tseq.ElapseTime.ToArray(), Vout.ToArray());
            }
        }
    }
}
