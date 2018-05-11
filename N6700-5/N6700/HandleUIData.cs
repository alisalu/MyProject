using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



namespace N6700
{
    public class TestSeq
    {
        public List<double> VoutPoints { get; set; }
        public List<double> CurrPoints { get; set; }
        public List<double> DWellPoints { get; set; }
        public List<double> ElapseTime { get; set; }
    }

    public class Steps
    {
        public string sIPAddr;
        public int nChannel;
        public string sVolpoint;
        public string sCurrpoint;
        public string sDwellpoint;
        public string sElapseTime;
        public string sVolMaxout;
        public string sSlewRate;
    }

    public class HandleUIData
    {
        public string[] sModelInfoColAry = { "IP Address", "Module", "Label", "Channel", "Nom Vout", "Max Vout", "Max Iout", "Max Watts", "Comment" };
        public string[] sModelStepColAry = { "Step", "Vout Points", "IMax Points", "DWell Points", "Elapse Time" };
        public string[] sModelLabelColAry = { "SUPPLY:", "Slew Rate" ,"Unit"};
        public Dictionary<int, TestSeq> SeqData = new Dictionary<int, TestSeq>();
        public Dictionary<int, string> DigitizerData = new Dictionary<int, string>();
        public List<string> Labels = new List<string>();

        public DataGridView createDataGrid(string dgName, int dgSizeL, int dgSizeH, int dglocationX, int dglocationY, string[] sColumnAry)
        {
            DataGridView dg = new DataGridView();
            dg.Name = dgName;
            dg.Location = new Point(dglocationX, dglocationY);
            dg.Size = new Size(dgSizeL, dgSizeH);
            int i = 0;
            foreach (string Colname in sColumnAry)
            {
                dg.Columns.Add(Colname, Colname);
                dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                i++;
            }
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            return dg;
        }

        public TabPage createTab(TabControl tb)
        {
            tb.TabIndex++;
            string title = "Model " + tb.TabIndex.ToString();
            TabPage tabpage = new TabPage(title);
            tabpage.Name = (tb.TabCount + 1).ToString();
            tb.TabPages.Add(tabpage);
           
            return tabpage;
        }

        public void GetDataGridColData(DataGridView dg, int nColIdx, ref string[] DataGridData)
        {
            for (int nRowCount = 0; nRowCount < dg.Rows.Count - 1; nRowCount++)
            {
                if (dg.Rows[nRowCount].Cells[nColIdx].Value!= null)
                    DataGridData[nRowCount] = dg.Rows[nRowCount].Cells[nColIdx].Value.ToString();
            }
        }

        public string[] GetDataGridRowData(DataGridView dg, int nRowIdx)
        {
            string[] DataGridData = new string[dg.Columns.Count];
            for (int nColCount = 0; nColCount < dg.Columns.Count; nColCount++)
            {
                if (dg.Rows[nRowIdx].Cells[nColCount].Value != null)
                    DataGridData[nColCount] = dg.Rows[nRowIdx].Cells[nColCount].Value.ToString();
            }
            return DataGridData;
        }

        public DataGridView GetdgModel(TabControl tb,int nIdx, string dgType)
        {
            string model = dgType + tb.TabPages[nIdx].Name;
            DataGridView dg = (DataGridView)tb.TabPages[nIdx].Controls[model];
            return dg;
        }     
    }
}
