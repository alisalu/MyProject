using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Drawing;
using Newtonsoft.Json;


namespace N6700
{        
    public partial class MainForm : Form
    {
        HandleUIData hdUI = new HandleUIData();

        private delegate void UIUpdateCallback(string sText);
        private delegate void ButtonUI(bool benbale);

        List<string> Labels = new List<string>();
        List<Steps> Modellst = new List<Steps>();
        private List<string> ChassisLANAddrLst = new List<string>();
   
        System.Diagnostics.Process p2 = new System.Diagnostics.Process();
        private Proshot.CommandClient.CMDClient client;

        public int nMeasureItem;
        public int nPowerLeftSet;
        public double dRST_Delay;
        public static double dDigitizer_Offset;
        public int nDigitizer_Point;
        public double dDigitizer_Seconds;
        public double dChassis_Delay;
        public double dSeqDelay;
        private string sFileName;
        private bool bRunNoSet = false;
        private string sPXIBoxIP; 
        private string sPort;
        private string sDelay;
        private bool bsendshutdown;
        private string sMsg;
        private VISA_Connect visa, visa2;
        private string sTitle;
        Thread th;
       
        TextBox tb_33_AdjustVoltVal = new TextBox();
        CheckBox cb_33_Adjust = new CheckBox();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);
        uint MSG_RUN = RegisterWindowMessage("Running Seq");
        uint MSG_STOP = RegisterWindowMessage("Stop Running");
        uint MSG_SHUTDOWN = RegisterWindowMessage("Shutdown chassis");

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public MainForm(string sCommand)
        {
            InitializeComponent();
            sTitle = "PXI Power Simulator Software version 5.0";
            this.Text = sTitle;
          
            //createTooltips();
            TB_MSG.BackColor = Control.DefaultBackColor;
            
            checkCmd(sCommand);
        }
        
        private void checkCmd(string sCmds)
        {
            if (sCmds.Contains(":\\"))  //Open file
            {
                readSeqfile(sCmds);
            }

            if (sCmds == "/R") //Execute Seq
            {
                IntPtr form_name = FindWindow(null, sTitle);
                if (form_name != IntPtr.Zero)
                {
                    SendMessage(form_name, MSG_RUN, IntPtr.Zero);
                    //Application.Exit();
                    this.Close();
                    Environment.Exit(Environment.ExitCode);
                }
                
            }
            if (sCmds == "/STOP")
            {
                IntPtr form_name = FindWindow(null, sTitle);
                if (form_name != IntPtr.Zero)
                {
                    SendMessage(form_name, MSG_STOP, IntPtr.Zero);
                    this.Close();
                    Environment.Exit(Environment.ExitCode);
                }
            }

            if (sCmds == "/SHUTDOWN")
            {
                IntPtr form_name = FindWindow(null, sTitle);
                if (form_name != IntPtr.Zero)
                {
                    SendMessage(form_name, MSG_SHUTDOWN, IntPtr.Zero);
                    this.Close();
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MSG_RUN)
            {
                ExeSeq();
            }
            else if(m.Msg == MSG_STOP)
            {
                if(th != null)
                {
                    sMsg = "Stop running Seq";
                    this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
                    th.Abort();
                    th = null;
                }
            }
            else if (m.Msg == MSG_SHUTDOWN)
            {
                Thread sdth = new Thread(doShutdown);
                sdth.Start();
            }

            base.WndProc(ref m);
        }

        private void readSeqfile(string sfilepath)
        {
            StreamReader sr = new StreamReader(sfilepath);
            string sModelInfo = null;
            string slabel = null;
            List<string> MyList = new List<string>();
            // int i=0;
            tab_Model.TabPages.Clear();
            hdUI.SeqData.Clear();
            Labels.Clear();
            tab_Model.TabIndex = 0;
            sModelInfo = sr.ReadToEnd();
            MyList = sModelInfo.Split('\\').ToList();
            MyList.RemoveAt(MyList.Count - 1);
            //while((sModelInfo = sr.ReadLine())!= null)
            for (int n = 0; n < MyList.Count; n++)
            {
                TabPage tabpage = hdUI.createTab(tab_Model);

                string sValue = MyList.ElementAt(n);

                ModelInfo modelinfo = JsonConvert.DeserializeObject<ModelInfo>(sValue);
                AddModeSetInfo(tabpage, modelinfo, out slabel);
                DataGridView dgModelLabel = CreateLabellDG(tabpage, tab_Model.TabCount);
                ModelSlew slew = new ModelSlew();
                slew = modelinfo.ModelSlew;
                string[] ModelLabel = { slew.Label, slew.Slew, " Vol/Sec" };
                dgModelLabel.Rows.Add(ModelLabel);

                AddModelSeqInfo(tabpage, n, modelinfo);
                             
                if(slabel == "+3.3V")
                {
                    cb_33_Adjust.Text = "Apply Voltage Drop Compensation";
                    cb_33_Adjust.Name = "DoDrop";
                    cb_33_Adjust.Location = new Point(4, 125);
                    cb_33_Adjust.Size = new Size(250, 20);
                    tabpage.Controls.Add(cb_33_Adjust);

                    Label lb = new Label();
                    lb.Location = new Point(4, 155);
                    lb.Text = "Fixture Voltage Drop Value (V):";
                    lb.Size = new Size(205, 20);
                    tabpage.Controls.Add(lb);
                    
                    tb_33_AdjustVoltVal.Name = "AdjustVlot";
                    tb_33_AdjustVoltVal.Location = new Point(210,155);
                    tb_33_AdjustVoltVal.Size = new Size(50,50);
                    tb_33_AdjustVoltVal.TextChanged += new System.EventHandler(tb_33_TextChanged);
                    tabpage.Controls.Add(tb_33_AdjustVoltVal);
                }
                   
                tabpage.Text = slabel;
                Labels.Add(slabel);
                //i++;
            }
            sr.Close();
        }

        private void bt_AddModel_Click(object sender, EventArgs e)
        {
            createTab();
        }

        private void createTab()
        {
            TabPage tabpage = hdUI.createTab(this.tab_Model);

            DataGridView dgModelSet = CreateSetDG(tabpage, tab_Model.TabIndex);
            string[] ModelSetRow = { "172.16.9.244", "6752A-05", "+3.3V", "1", "3.3", "3.7", "10", "37", "" };
            dgModelSet.Rows.Add(ModelSetRow);

            Labels.Add("+3.3V");

            DataGridView dgModelLabel = CreateLabellDG(tabpage, tab_Model.TabIndex);
            string[] sModelLabelAry = { "+3.3V", "1000", "Vol/Sec" };
            dgModelLabel.Rows.Add(sModelLabelAry);

            List<double> VolLst = new List<double>() { };
            List<double> CurrLst = new List<double>() { };
            List<double> ElapseTimeLst = new List<double>() { };
            List<double> DwellLst = new List<double>() { };

            CreateSeqDG(tabpage, tab_Model.TabIndex, VolLst, CurrLst, ElapseTimeLst, DwellLst);

            tabpage.Text = "+3.3V";
        }

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            ConfigSet setdlg = new ConfigSet();

            setdlg.ShowDialog();
        }

        private void dgModelSeq_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 1)
                return;

            int nCuttTab = tab_Model.SelectedIndex;
            DataGridView dg = hdUI.GetdgModel(tab_Model, nCuttTab, "modelSeq");

            int nIdx = int.Parse(tab_Model.TabPages[nCuttTab].Name);
            TestSeq ts = hdUI.SeqData[nIdx];
            List<double> lst = new List<double>();                     
              
            switch (e.ColumnIndex)
            {
                case 1:
                    lst = ts.VoutPoints;
                    break;
                case 2:
                    lst = ts.CurrPoints;
                    break;
                case 3:
                    lst = ts.DWellPoints;
                    break;
                case 4:
                    lst = ts.ElapseTime;
                    break;
            }

            if (dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                MessageBox.Show("Please enter the value!");
                //dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;               
                return;
            }
            
            if(lst.Count < e.RowIndex + 1) //Add
            {
                ts.VoutPoints.Add(double.Parse(dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                ts.CurrPoints.Add(double.Parse(dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                ts.DWellPoints.Add(double.Parse(dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
            else //Modify
            {
                lst[e.RowIndex] = double.Parse( dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }

            double dElapseTime = 0.0;
            int nRowIdx = e.RowIndex;
            int nMax = dg.RowCount - 1;

            for (int nStart = nRowIdx; nStart < nMax; nStart++)
            { 
                if (nRowIdx > 0)               
                    dElapseTime = double.Parse(dg.Rows[nRowIdx - 1].Cells[4].Value.ToString());

                double dDwell = double.Parse(dg.Rows[nRowIdx].Cells[3].Value.ToString());
         
                ts.ElapseTime[nRowIdx] = dDwell + dElapseTime;
                dg.Rows[nRowIdx].Cells[4].Value = dDwell + dElapseTime;
            }        
        }

        private void dg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox innerTextBox;
            if (e.Control is TextBox)
            {
                innerTextBox = e.Control as TextBox;
                innerTextBox.KeyPress += new KeyPressEventHandler(dgModelSeq_CheckifNumber);
            }
        }

        private void dgModelSeq_CheckifNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar.CompareTo('.') == 0))
            {
                e.Handled = true;
            }
        }

        private void dgModelSet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nCuttTab = tab_Model.SelectedIndex;
            DataGridView dg = hdUI.GetdgModel(tab_Model, nCuttTab, "modelSet");

            if(e.ColumnIndex == 2)
            {
                string sLabel = dg.Rows[0].Cells[2].Value.ToString();
                tab_Model.TabPages[nCuttTab].Text = sLabel;
                dg = (DataGridView)tab_Model.TabPages[nCuttTab].Controls["modellabel" + tab_Model.TabPages[nCuttTab].Name];
                dg.Rows[0].Cells[0].Value = sLabel;
                Labels[nCuttTab] = sLabel;
            }
        }

        private void bt_ViewSeqGraph_Click(object sender, EventArgs e)
        {
            ShowSeqGraph seqGraph = new ShowSeqGraph();
            List<int> TabIdxLst = new List<int>();

            for (int n = 0; n < tab_Model.TabCount; n++ )
            {
                int id = int.Parse(tab_Model.TabPages[n].Name);
                TabIdxLst.Add(id);
            }

            seqGraph.Hui = hdUI;
            seqGraph.TabIdx = TabIdxLst;
            seqGraph.Labels = Labels;
            seqGraph.Show();
        }

        private void bt_ViewDataGraph_Click(object sender, EventArgs e)
        {            
            DataGraph dGraph = new DataGraph();
            dGraph.nTabCnt = tab_Model.TabCount;
            dGraph.dOffset = dDigitizer_Offset;
            dGraph.nPoints = nDigitizer_Point;
            dGraph.dTimeDelta = dDigitizer_Seconds / nDigitizer_Point;
            dGraph.hui = hdUI;
            dGraph.Labels = Labels;
            if(hdUI.DigitizerData.Count == 0)
            {
                MessageBox.Show("No Test result data!\r\nPlease check if the instrument works fine!");
                return;
            }
            dGraph.Show();
            dGraph.diaplay();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void savefile()
        {
            int nModelCount = tab_Model.TabCount;
            string sDataStr = null;

            FileStream myStream = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(myStream);

            for (int tabIdx = 0; tabIdx < nModelCount; tabIdx++)
            {
                ModelInfo root = new ModelInfo();
                saveModelSetInfo(tabIdx, root);
                saveModelSlew(tabIdx, root);
                saveModelSeqInfo(tabIdx, root);
                sDataStr = JsonConvert.SerializeObject(root);
                sDataStr = sDataStr + "\\";

                int npos = 0;
                string sa = sDataStr;
                do
                {
                    npos = sa.IndexOf("Steps", npos);
                    if (npos>0)
                    {
                        sa = sa.Insert(npos - 2, "\r\n");
                        npos += 4;
                    }                 
                } while (npos < sDataStr.Length && npos>0);

                sw.WriteLine(sa);
            }
            sw.Close();
            myStream.Close();
            
            MessageBox.Show("Save File Success!");
        }

        private void saveModelSetInfo(int nModelIdx, ModelInfo ModelInf)
        {
            DataGridView SelectedDg = hdUI.GetdgModel(tab_Model, nModelIdx, "modelSet");

            if (SelectedDg.Rows[0].Cells[0].Value != null)
                 ModelInf.IPAddress = SelectedDg.Rows[0].Cells[0].Value.ToString();
            else
            {
                MessageBox.Show("Please enter the IP address!");
                return;
            }
            ModelInf.Module = SelectedDg.Rows[0].Cells[1].Value.ToString();
            ModelInf.Label = SelectedDg.Rows[0].Cells[2].Value.ToString();
            ModelInf.Channel = Int16.Parse(SelectedDg.Rows[0].Cells[3].Value.ToString());
            ModelInf.NomVout = double.Parse(SelectedDg.Rows[0].Cells[4].Value.ToString());
            ModelInf.MaxVout = double.Parse(SelectedDg.Rows[0].Cells[5].Value.ToString());
            ModelInf.MaxIout = double.Parse(SelectedDg.Rows[0].Cells[6].Value.ToString());
            ModelInf.MaxWatts = double.Parse(SelectedDg.Rows[0].Cells[7].Value.ToString());
            ModelInf.Comment = SelectedDg.Rows[0].Cells[8].Value.ToString();
        }

        private void saveModelSeqInfo(int nModelIdx, ModelInfo ModelInf)
        {
            DataGridView SelectedDg = hdUI.GetdgModel(tab_Model, nModelIdx, "modelSeq");
            List<ModelSeq> seqlist = new List<ModelSeq>();

            for (int nRowIdx = 0; nRowIdx < SelectedDg.Rows.Count - 1; nRowIdx++)
            {
                ModelSeq modelseq = new ModelSeq();

                if (SelectedDg.Rows[nRowIdx].Cells[0].Value != null)
                      modelseq.Steps = Int16.Parse(SelectedDg.Rows[nRowIdx].Cells[0].Value.ToString());
                if (SelectedDg.Rows[nRowIdx].Cells[1].Value != null)
                     modelseq.VoutPoints = double.Parse(SelectedDg.Rows[nRowIdx].Cells[1].Value.ToString());
                if (SelectedDg.Rows[nRowIdx].Cells[2].Value != null)
                     modelseq.IMaxPoints = double.Parse(SelectedDg.Rows[nRowIdx].Cells[2].Value.ToString());
                if (SelectedDg.Rows[nRowIdx].Cells[3].Value != null)
                     modelseq.DWellPoints = double.Parse(SelectedDg.Rows[nRowIdx].Cells[3].Value.ToString());
                if (SelectedDg.Rows[nRowIdx].Cells[4].Value != null)
                    modelseq.ElapseTime = double.Parse(SelectedDg.Rows[nRowIdx].Cells[4].Value.ToString());
                seqlist.Add(modelseq);
            }
            ModelInf.ModelSeq = seqlist;
        }

        private void saveModelSlew(int nModelIdx, ModelInfo ModelInf)
        {
            DataGridView SlewdDg = hdUI.GetdgModel(tab_Model, nModelIdx, "modelLabel");
            ModelSlew MSlew = new ModelSlew();
            MSlew.Label = SlewdDg.Rows[0].Cells[0].Value.ToString();
            MSlew.Slew = SlewdDg.Rows[0].Cells[1].Value.ToString();
            ModelInf.ModelSlew = MSlew;
        }

        private void bt_ImportSeq_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
           
            ofdlg.Filter = "Text |*.txt";
            ofdlg.Title = "Open File Dialog";
            
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
               
                readSeqfile(ofdlg.FileName);
                sFileName = ofdlg.FileName;
                bt_Save.Enabled = true;
                bt_ViewSeqGraph.Enabled = true;
                bt_RunSeq.Enabled = true;
                bt_SAVEAS.Enabled = true;
                CB_RUNNOREST.Enabled = true;
                //CB_SHUTDOWN.Enabled = true;
            }
        }

        private void AddModeSetInfo(TabPage tp, ModelInfo modelinfo, out string sLabel)
        {
            DataGridView dgModelSet = CreateSetDG(tp, tab_Model.TabCount);
            string[] sModelSetRowAry = {modelinfo.IPAddress, modelinfo.Module, modelinfo.Label, 
                                     modelinfo.Channel.ToString(), modelinfo.NomVout.ToString(), modelinfo.MaxVout.ToString(),
                                     modelinfo.MaxIout.ToString(), modelinfo.MaxWatts.ToString(), modelinfo.Comment };
            dgModelSet.Rows.Add(sModelSetRowAry);
        
            sLabel = modelinfo.Label;
        }

        private void AddModelSeqInfo(TabPage tp, int nTabIdx, ModelInfo modelinfo)
        {
            List<double> Vol = new List<double>();
            List<double> Curr = new List<double>();
            List<double> ElapseTime = new List<double>();
            List<double> Dwell = new List<double>();

            DataGridView dgModelSeq = CreateSeqDG(tp, nTabIdx, Vol, Curr, ElapseTime, Dwell);
          
            foreach (var modelseqs in modelinfo.ModelSeq)
            {
                string[] sModelStepAry = {modelseqs.Steps.ToString(), modelseqs.VoutPoints.ToString(), modelseqs.IMaxPoints.ToString(),
                                            modelseqs.DWellPoints.ToString(), modelseqs.ElapseTime.ToString()};
                dgModelSeq.Rows.Add(sModelStepAry);
                Vol.Add(modelseqs.VoutPoints);
                Curr.Add(modelseqs.IMaxPoints);
                ElapseTime.Add(modelseqs.ElapseTime);
                Dwell.Add(modelseqs.DWellPoints);
            }
        }

        private void bt_ExportSeq_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfDialog = new SaveFileDialog();
          
            sfDialog.Filter = "Text |*.txt";
            sfDialog.Title = "Save File Dialog";

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sfDialog.FileName;
                savefile();
                bt_Save.Enabled = true;
            }
        }

        public void UpdateTextBox(string sText)
        {
            TB_MSG.Text = sText;
        }

        private void bt_RunSeq_Click(object sender, EventArgs e)
        {
            ExeSeq();
        }

        private void ExeSeq()
        {
            checkIfInitial();
            ReadIniFile();
            RunTestSeqs();
        }

        private void RunTestSeqs()
        {          
            int nModel = tab_Model.TabCount;
            Modellst.Clear();

            for(int i=0 ; i<nModel ; i++)
            {
                Steps st = new Steps();
               // int nidx = int.Parse(tab_Model.TabPages[i].Name.ToString());
                DataGridView Modeldg = hdUI.GetdgModel(tab_Model, i, "modelSet");
                DataGridView Modeldg2 = hdUI.GetdgModel(tab_Model, i, "modellabel");
               
                st.sIPAddr = Modeldg.Rows[0].Cells[0].Value.ToString();
                st.nChannel = int.Parse(Modeldg.Rows[0].Cells[3].Value.ToString());
                st.sVolMaxout = Modeldg.Rows[0].Cells[5].Value.ToString();
                st.sSlewRate = Modeldg2.Rows[0].Cells[1].Value.ToString();

                int nTab = int.Parse(tab_Model.TabPages[i].Name);
                TestSeq ts = hdUI.SeqData[nTab];
                List<double> dVolPoinlst = ts.VoutPoints;
                List<double> dCurrPointlst = ts.CurrPoints;
                List<double> dDwellPointlst = ts.DWellPoints;
                string sVol;
                //add for adjust voltage
                string svol = Modeldg2.Rows[0].Cells[0].Value.ToString();
                if (this.cb_33_Adjust.Checked == true && svol == "+3.3V")
                {
                    svol = "";
                    for (int x =0; x< dVolPoinlst.Count; x++)
                    {
                        double dvol = dVolPoinlst.ElementAt(x);
                        if(dvol!=0)
                        {
                            dvol = dvol *((3.3 + Convert.ToDouble(this.tb_33_AdjustVoltVal.Text))/ 3.3);
                        }                      
                        svol = svol + dvol.ToString() + ",";
                    }
                    sVol = svol;
                }
                else
                    sVol = string.Join(",", dVolPoinlst.ToArray());
                string sCurr = string.Join(",", dCurrPointlst.ToArray());
                string sWdell = string.Join(",", dDwellPointlst.ToArray());
                
                st.sVolpoint = sVol;
                st.sCurrpoint = sCurr;
                st.sDwellpoint = sWdell;
                Modellst.Add(st);
            }

            if (bsendshutdown == true)
            {
                Thread sdth = new Thread(doShutdown);
                sdth.Start();
            }

            this.Invoke(new ButtonUI(this.ButtonEnable), false);
            th = new Thread(runseq);
            int iSec = Convert.ToInt32(dSeqDelay * 1000);
            Thread.Sleep(iSec);
            th.Start();
        }

        private void doShutdown()
        {
            double dSec = double.Parse(sDelay);
            int nSec = Convert.ToInt32(dSec * 1000);
            Thread.Sleep(nSec);

            this.client = new Proshot.CommandClient.CMDClient(IPAddress.Parse(sPXIBoxIP), int.Parse(sPort), "None");
            this.client.ConnectToServer();
            Thread.Sleep(1000);

            this.client.SendCommand(new Proshot.CommandClient.Command(Proshot.CommandClient.CommandType.PCShutDown, IPAddress.Parse(sPXIBoxIP)));
         
            sMsg = "Sending Shutdown command......OK";
            this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
        }

        private void checkIfInitial()
        {
            if (CB_RUNNOREST.Checked == true)
            {
                bRunNoSet = true;
            }
            else
                bRunNoSet = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nTab = int.Parse(tab_Model.SelectedTab.Name);
            hdUI.SeqData.Remove(nTab);
            Labels.RemoveAt(tab_Model.SelectedIndex);
            tab_Model.TabPages.Remove(tab_Model.SelectedTab);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_AddModel_Click(sender, e);
        }

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nCuttTab = tab_Model.SelectedIndex;
            DataGridView dg = hdUI.GetdgModel(tab_Model, nCuttTab, "modelSeq");

            string[] DataAry = hdUI.GetDataGridRowData(dg, dg.CurrentRow.Index);
            DataAry[0] = dg.Rows.Count.ToString();
           
            int nTab = int.Parse(tab_Model.SelectedTab.Name);
            TestSeq ts = hdUI.SeqData[nTab];
            ts.VoutPoints.Add(double.Parse(DataAry[1]));
            ts.CurrPoints.Add(double.Parse(DataAry[2]));
            ts.DWellPoints.Add(double.Parse(DataAry[3]));
            ts.ElapseTime.Add(double.Parse(DataAry[4]));

            dg.Rows.Add(DataAry);
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int nCuttTab = tab_Model.SelectedIndex;
            //DataGridView dg = hdUI.GetdgModel(tab_Model, nCuttTab, "modelSeq");
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nCuttTab = tab_Model.SelectedIndex;
            DataGridView dg = hdUI.GetdgModel(tab_Model, nCuttTab, "modelSeq");

            int nTab = int.Parse(tab_Model.SelectedTab.Name);
            TestSeq ts = hdUI.SeqData[nTab];
            ts.VoutPoints.RemoveAt(dg.CurrentRow.Index);
            ts.CurrPoints.RemoveAt(dg.CurrentRow.Index);
            ts.DWellPoints.RemoveAt(dg.CurrentRow.Index);
            ts.ElapseTime.RemoveAt(dg.CurrentRow.Index);

            dg.Rows.RemoveAt(dg.CurrentRow.Index);
        }

        private void bt_TurnOff_Click(object sender, EventArgs e)
        {
            TurnOFF();
        }
       
        private void TurnOFF()
        {
            visa.SendSCPICmd("*CLS");
            visa.SendSCPICmd("*RST");
            visa.DisConnectInstr();
            visa = null;

            visa2.SendSCPICmd("*CLS");
            visa2.SendSCPICmd("*RST");
            visa2.DisConnectInstr();
            visa2 = null;

            this.TB_MSG.Text = "N6700 is reset!";
        }

        private DataGridView CreateSetDG(TabPage tp, int nTabIdx)
        {
            DataGridView dgModelSet = hdUI.createDataGrid("modelSet" + tab_Model.TabIndex.ToString(), 800, 50, 3, 10, hdUI.sModelInfoColAry);
            tp.Controls.Add(dgModelSet);
            dgModelSet.Columns[0].Width = 120;
            dgModelSet.Columns[8].Width = 100;
             
            dgModelSet.AllowUserToAddRows = false;
            dgModelSet.RowHeadersVisible = false;
            dgModelSet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgModelSet.CellValueChanged += new DataGridViewCellEventHandler(dgModelSet_CellValueChanged);

            return dgModelSet;
        }

        private DataGridView CreateLabellDG(TabPage tp, int nTabIdx)
        {
            DataGridView dgModelLabel = hdUI.createDataGrid("modellabel" + tab_Model.TabIndex.ToString(), 240, 50, 3, 70, hdUI.sModelLabelColAry);
            tp.Controls.Add(dgModelLabel);
            dgModelLabel.Columns[0].Width = 60;
            dgModelLabel.Columns[1].Width = 70;
           //dgModelLabel.Columns[2].Width = 90;
            dgModelLabel.Columns[2].ReadOnly = true;
            dgModelLabel.RowHeadersVisible = false;
            dgModelLabel.AllowUserToAddRows = false;

            
            return dgModelLabel;
        }

        private DataGridView CreateSeqDG(TabPage tp, int nTabIdx, List<double> Vol, List<double> Curr, List<double> ElapseTime, List<double> Dwell)
        {
            DataGridView dgModelSeq = hdUI.createDataGrid("modelSeq" + tab_Model.TabCount.ToString(), 545, 550, 270, 70, hdUI.sModelStepColAry);
            tp.Controls.Add(dgModelSeq);

            TestSeq seq = new TestSeq();

            seq.VoutPoints = Vol;
            seq.ElapseTime = ElapseTime;
            seq.DWellPoints = Dwell;
            seq.CurrPoints = Curr;
            hdUI.SeqData.Add(tab_Model.TabIndex, seq);

            dgModelSeq.CellValueChanged += new DataGridViewCellEventHandler(dgModelSeq_CellValueChanged);
            dgModelSeq.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dg_EditingControlShowing);
            dgModelSeq.ContextMenuStrip = datagrid_contextMenu;
            dgModelSeq.RowHeadersVisible = false;

            return dgModelSeq;
        }

        private void ReadIniFile()
        {
            INIFileAPI readconfig = new INIFileAPI();

            List<string> config = new List<string>();
            config = readconfig.ReadConfigini();

            nPowerLeftSet = int.Parse(config[0]);
            nMeasureItem = int.Parse(config[1]);
            dDigitizer_Offset = double.Parse(config[2]);
            dDigitizer_Seconds = double.Parse(config[3]);
            nDigitizer_Point = int.Parse(config[4]);
            dChassis_Delay = double.Parse(config[5]);
            dSeqDelay = double.Parse(config[6]);

            config.Clear();
            config = readconfig.ReadShutdownConfigini();

            if (config[0] == "0")
                bsendshutdown = false;
            else
                bsendshutdown = true;

            sPXIBoxIP = config[1];
            sPort = config[2];
            sDelay = config[3];
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    {
                        if (bt_RunSeq.Enabled == true)
                            RunTestSeqs();
                    }
                    return true;
                case Keys.F6:
                    { 
                       if(bt_TurnOff.Enabled == true)
                           TurnOFF();
                    }
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
       
        private void ButtonEnable(bool enable)
        {
            bt_RunSeq.Enabled = enable;
            bt_ImportSeq.Enabled = enable;
            bt_Save.Enabled = enable;
            bt_SAVEAS.Enabled = enable;
            bt_Settings.Enabled = enable;
            bt_TurnOff.Enabled = enable;
            bt_ViewDataGraph.Enabled = enable;
            bt_ViewSeqGraph.Enabled = enable;
            CB_RUNNOREST.Enabled = enable;

            tab_Model.Enabled = enable;
            ControlBox = enable;
        }

        private void createTooltips()
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(bt_ImportSeq, "Import Sequence file");
            tp.SetToolTip(bt_Save, "Save Sequence file");
            tp.SetToolTip(bt_Settings, "Config Settings");
            tp.SetToolTip(bt_SAVEAS, "Save Sequence to anther files name");
            tp.SetToolTip(bt_ViewDataGraph, "Show Result data graph");
            tp.SetToolTip(bt_ViewSeqGraph, "Show Sequence data graph");         
            tp.SetToolTip(bt_RunSeq, "Execute sequence data");
            tp.SetToolTip(CB_RUNNOREST, "Execute sequence without set power simulator again!");
        }

        public void runseq()
        {
            List<string> sChannelList1 = new List<string>();
            List<string> sChannelList2 = new List<string>();
            hdUI.DigitizerData.Clear();
       
            this.Invoke(new UIUpdateCallback(this.UpdateTextBox), "Test Seq Runnung.....");
            if (visa == null && bRunNoSet == true)
            {
                sMsg = "Please initial the instruments at first time!!";               
                this.Invoke(new ButtonUI(this.ButtonEnable), true);
                this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
                return;
            }

            int dDelay = Convert.ToInt32(dSeqDelay * 1000);
            Thread.Sleep(dDelay);

            if (bRunNoSet == false)
            {
                if (visa != null)
                    visa.DisConnectInstr();
                if (visa2 != null)
                    visa2.DisConnectInstr();

                visa = new VISA_Connect();
                visa2 = new VISA_Connect();

                ChassisLANAddrLst.Clear();

                bool bFirstInit = false;
                for (int ntab = 0; ntab < Modellst.Count; ntab++)
                {
                    if (bFirstInit == false && ChassisLANAddrLst.Count == 0)
                    {
                        ChassisLANAddrLst.Add(Modellst[ntab].sIPAddr);
                        bFirstInit = true;
                    }
                    else if (!ChassisLANAddrLst.Exists(x => x.Contains(Modellst[ntab].sIPAddr)))
                        ChassisLANAddrLst.Add(Modellst[ntab].sIPAddr);
                }

                if (visa.ConnectInstr("TCPIP0::" + ChassisLANAddrLst[0] + "::inst0::INSTR") != "Connected")
                {
                    sMsg = "Can't Connect the instrument, Please check again!";
                    this.Invoke(new ButtonUI(this.ButtonEnable), true);
                    this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
                    return;
                }

                if (ChassisLANAddrLst.Count > 1)
                {
                    if (visa2.ConnectInstr("TCPIP0::" + ChassisLANAddrLst[1] + "::inst0::INSTR") != "Connected")
                    {
                        sMsg = "Can't Connect the instrument, Please check again!";
                        this.Invoke(new ButtonUI(this.ButtonEnable), true);
                        this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
                        return;
                    }
                }
            }

            sChannelList1.Clear();
            sChannelList2.Clear();

            foreach (Steps step in Modellst)
            {
                if (step.sIPAddr == ChassisLANAddrLst[0])
                {
                    setTestSeqData(visa, step);
                    sChannelList1.Add(step.nChannel.ToString());
                }
                else
                {
                    setTestSeqData(visa2, step);
                    sChannelList2.Add(step.nChannel.ToString());
                }
            }

            if (bRunNoSet == false)
            {
                digitizerTOUTSetup(visa, sChannelList1);
                if (visa2 != null)
                    digitizerTINSetup(visa2, sChannelList2);
            }

            string sCh = string.Join(",", sChannelList1.ToArray());
            visa.SendSCPICmd("TRIG:TRANSIENT:IMM " + "(@" + sCh + ")");

            sMsg = "Running Test.........";
            this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
            //int nDelay = (int) (dRST_Delay * 1000); //(millisecond)
            //Thread.Sleep(nDelay);
            //visa.SendSCPICmd("DIG:OUTP:DATA 16");

            int nDelay = (int)(dChassis_Delay * 1000); //(millisecond)
            Thread.Sleep(nDelay);
            visa.SendSCPICmd("DIG:OUTP:DATA 64");
            hdUI.DigitizerData.Clear();

            string sResData = null;
            sMsg = "Start to get Test Result Data.........";
            this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);

            int i = 0;
            for (int chancnt = 0; chancnt < sChannelList1.Count; chancnt++)
            {
                sResData = null;
                sResData = getDigitizerData(visa, sChannelList1.ElementAt(chancnt));
                hdUI.DigitizerData.Add(i, sResData);
                i++;
            }

            if (visa2 != null)
            {
                for (int chancnt = 0; chancnt < sChannelList2.Count; chancnt++)
                {
                    sResData = null;
                    sResData = getDigitizerData(visa2, sChannelList2.ElementAt(chancnt));
                    if (sResData != "VI_ERROR_TMO: A timeout occurred")
                        hdUI.DigitizerData.Add(i, sResData);
                    else
                    {
                        sMsg = "Get Timeout Error...\r\n";
                        this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
                    }
                }
            }

            sMsg ="Run Seqences is finished.";
            this.Invoke(new ButtonUI(this.ButtonEnable), true);
            this.Invoke(new UIUpdateCallback(this.UpdateTextBox), sMsg);
        }

        private void setTestSeqData(VISA_Connect visa, Steps step)
        {
            visa.SendSCPICmd("DISP:VIEW METER4");
            visa.SendSCPICmd("VOLT:PROT:LEV " + step.sVolMaxout + "," + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("VOLT:MODE LIST, " + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("CURR:MODE LIST, " + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("LIST:VOLT " + step.sVolpoint + "," + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("LIST:CURR " + step.sCurrpoint + "," + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("LIST:DWEL " + step.sDwellpoint + "," + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("VOLT:SLEW " + step.sSlewRate + "," + "(@" + step.nChannel.ToString() + ")");
            if (nPowerLeftSet == 0)
                visa.SendSCPICmd("LIST:TERM:LAST ON," + "(@" + step.nChannel.ToString() + ")");
            else
                visa.SendSCPICmd("LIST:TERM:LAST OFF," + "(@" + step.nChannel.ToString() + ")");
            visa.SendSCPICmd("OUTP ON," + " (@" + step.nChannel.ToString() + ")");
        }

        private void digitizerTOUTSetup(VISA_Connect visa, List<string> channLst)
        {
            string schann = string.Join(",", channLst.ToArray());
            string sMeasureType = "CURRENT";
            if (nMeasureItem == 1)
                sMeasureType = "VOLT";

            visa.SendSCPICmd("DIG:PIN3:FUNC INH");
            visa.SendSCPICmd("DIG:PIN3:POL NEG");
            visa.SendSCPICmd("DIG:PIN1:FUNC FAUL");
            visa.SendSCPICmd("DIG:PIN1:POL NEG");
            visa.SendSCPICmd("OUTP:INH:MODE OFF");
            visa.SendSCPICmd("OUTP:INH:MODE LATC");

            visa.SendSCPICmd("DIG:PIN5:FUNC DIO");
            visa.SendSCPICmd("DIG:OUTP:DATA 0");
            visa.SendSCPICmd("DIG:PIN7:FUNC DIO");
            visa.SendSCPICmd("DIG:OUTP:DATA 0");
            visa.SendSCPICmd("DIG:PIN4:FUNC TOUT");
            visa.SendSCPICmd("LIST:TOUT:BOST 1, (@" + schann.ElementAt(0) + ")");
            visa.SendSCPICmd("TRIG:TRAN:SOUR BUS, (@" + schann + ")");

            double dPeriodSecond = dDigitizer_Seconds / nDigitizer_Point;
            visa.SendSCPICmd("SENSE:FUNCTION:" + sMeasureType + " ON, (@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:OFFSET:POINTS " + dDigitizer_Offset.ToString() + ", (@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:POINTS " + nDigitizer_Point.ToString() + ", (@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:TINT " + dPeriodSecond.ToString() + ", (@" + schann + ")");

            //Digitizer Trigger Setup
            visa.SendSCPICmd("TRIG:ACQ:SOUR TRAN1" + ", (@" + schann + ")");
            visa.SendSCPICmd("INIT:ACQ " + "(@" + schann + ")");
            visa.SendSCPICmd("INIT:TRAN " + "(@" + schann + ")");
        }

        private void digitizerTINSetup(VISA_Connect visa, List<string> channLst)
        {
            string schann = string.Join(",", channLst.ToArray());

            string sMeasureType = "CURRENT";
            if (nMeasureItem == 1)
                sMeasureType = "VOLT";

            visa.SendSCPICmd("DIG:PIN3:FUNC INH");
            visa.SendSCPICmd("DIG:PIN3:POL NEG");
            visa.SendSCPICmd("DIG:PIN1:FUNC FAUL");
            visa.SendSCPICmd("DIG:PIN1:POL NEG");
            visa.SendSCPICmd("OUTP:INH:MODE OFF");
            visa.SendSCPICmd("OUTP:INH:MODE LATC");
            visa.SendSCPICmd("DIG:PIN4:FUNC TINP");
            visa.SendSCPICmd("TRIG:TRAN:SOUR PIN4, (@" + schann + ")");

            visa.SendSCPICmd("DIG:PIN7:FUNC DIO");
            visa.SendSCPICmd("DIG:OUTP:DATA 0");
            double dPeriodSecond = dDigitizer_Seconds / nDigitizer_Point;
            visa.SendSCPICmd("SENSE:FUNCTION:" + sMeasureType + " ON,(@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:OFFSET:POINTS " + dDigitizer_Offset.ToString() + ",(@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:POINTS " + nDigitizer_Point.ToString() + ",(@" + schann + ")");
            visa.SendSCPICmd("SENSE:SWEEP:TINT " + dPeriodSecond.ToString() + ",(@" + schann + ")");

            //Digitizer Trigger Setup
            visa.SendSCPICmd("TRIG:ACQ:SOUR PIN4" + ", (@" + schann + ")");
            visa.SendSCPICmd("INIT:ACQ " + "(@" + schann + ")");
            visa.SendSCPICmd("INIT:TRAN " + "(@" + schann + ")");
        }

        private string getDigitizerData(VISA_Connect visa, string sChan)
        {
            string sMeasureType = "CURRENT";
            if (nMeasureItem == 1)
                sMeasureType = "VOLT";

            string sCmd = "FETCH:ARRAY:" + sMeasureType + "? (@" + sChan + ")";
            visa.SendSCPICmd(sCmd);
            string sPoint = visa.ReadResult();
            return sPoint;
        }

        private void tb_33_TextChanged(object Sender, EventArgs e)
        {
            tb_33_AdjustVoltVal.ForeColor = Color.Black;
            string str = this.tb_33_AdjustVoltVal.Text;
            if (str == "")
                return;
            double dVol = Convert.ToDouble(str);
            if(dVol< 0.0 || dVol >0.25)
            {
                MessageBox.Show("Please re enter the adjust voltage vaule");
                tb_33_AdjustVoltVal.ForeColor = Color.Red;
            }
        }
    }
}
