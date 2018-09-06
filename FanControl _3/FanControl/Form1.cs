using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace FanControl
{
    public partial class Form1 : Form
    {
        ComCmd cmd = new ComCmd();
        FanSet fanSet = new FanSet();
        MeasureValue meas = new MeasureValue();
        public delegate void TextInvoke(int nCh, string sVal);
        public delegate void ColorInvoke(int nCh);
        Dictionary<int, TextBox> diclist = new Dictionary<int, TextBox>();

        string sPWM;
        string sFanID;
        string sPartName;
        string sNPLC = "1";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CB_comport.Items.AddRange(SerialPort.GetPortNames());
            CB_comport.SelectedIndex = 0;
            sPartName = CB_comport.Text;
            //tabControl1.Enabled = false;
            UISet();
            //BT_GetInfo.Enabled = false;
            TB_ArduinoInfo.Enabled = false;
            BT_STOP.Enabled = false;
            meas.returnVolValue += new MeasureValue.VolValue(this.SetReturnValue);
            meas.ChgvalCol += new MeasureValue.ValueCol(this.chgColor);
            this.groupBox1.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            cmb_NPLC.SelectedIndex = 2;

        }
        private void UISet()
        {
            ckb_Thermistor.Checked = true;
            ckb_FanSpeed.Checked = true;
            ckb_Thermocouple.Checked = true;
            ckb_VDP.Checked = true;
            ckb_Voltage.Checked = true;

            diclist.Add(1,TXT_TH011);
            diclist.Add(2, TXT_TH012);
            diclist.Add(3, TXT_TH013);
            diclist.Add(4, TXT_TH014);
            diclist.Add(5, txt_v12);
            diclist.Add(6, txt_VDP11);
            diclist.Add(7, txt_VDP12);
            diclist.Add(8, txt_VDP13);
            diclist.Add(9, txt_VDP14);
            diclist.Add(10, txt_v24);
            diclist.Add(11, TXT_TH114);
            diclist.Add(12, TXT_TH113);
            diclist.Add(13, TXT_TH112);
            diclist.Add(14, TXT_TH111);
            diclist.Add(15, txt_v5);
            diclist.Add(16, txt_FT11);
            diclist.Add(17, txt_FT12);
            diclist.Add(18, txt_FT13);
            diclist.Add(19, txt_FT14);
            diclist.Add(36, txt_TC000);
            diclist.Add(37, txt_TC111);
            diclist.Add(38, txt_TC112);
            diclist.Add(39, txt_TC113);
            diclist.Add(40, txt_TC114);
            //diclist.Add(20, TXT_TH011);
        }

        private void TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_1.Text != string.Empty)
            {
                trackBar1.Value = Convert.ToInt16(TB_Fan0_1.Text);
            }
        }

        private void setChange(TrackBar trackBar, TextBox tbPWM)
        {
            fanSet.tracker = trackBar;
            fanSet.tb = tbPWM;
            fanSet.GetFanPWMVal();
            SetFanPWM();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar1, TB_Fan0_1);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar2, TB_Fan0_2);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar3, TB_Fan0_3);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar4, TB_Fan0_4);
        }

        private void FAN2_TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_2.Text != string.Empty)
            {
                trackBar2.Value = Convert.ToInt16(TB_Fan0_2.Text);                
            }
        }

        private void FAN3_TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_3.Text != string.Empty)
            {
                trackBar3.Value = Convert.ToInt16(TB_Fan0_3.Text);              
            }
        }

        private void FAN4_TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_4.Text != string.Empty)
            {
                trackBar4.Value = Convert.ToInt16(TB_Fan0_4.Text);              
            }
        }

        private void BT_GetArduinoID_Click(object sender, EventArgs e)
        {
            cmd.sPartName = sPartName;
            cmd.OpenComport();
            //string sFanID = cmd.ReadCmdFID();
            //if (sFanID == null)
            //    return;
            //TEXT_ArduinoID.Text = sFanID;
            TB_ArduinoInfo.Text = cmd.ReadArduinoInfo();
            //tabControl1.Enabled = true;
            this.groupBox1.Enabled = true;
            groupBox6.Enabled = true;
            groupBox7.Enabled = true;
            groupBox8.Enabled = true;
        }

        private void WriteCmd()
        {
            //string sArduinoId = TEXT_ArduinoID.Text;
        }

        private void SetFanPWM()
        {
            sFanID = fanSet.GetFanID();
            sPWM = fanSet.GetFanPWM();
            int nLen = sPWM.Length;
            switch (nLen)
            {
                case 1:
                    sPWM = "00" + sPWM;
                    break;
                case 2:
                    sPWM = "0" + sPWM;
                    break;
                case 3:
                    break;
            }

            string SendCmd = sFanID + sPWM;
            cmd.WriteCmd(SendCmd);
        }

        private void CB_comport_SelectedIndexChanged(object sender, EventArgs e)
        {
            sPartName = CB_comport.Text;
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            cmd.CloseComport();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar5, TB_Fan4);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar6, TB_Fan5);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar7, TB_Fan6);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar8, TB_Fan7);
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar9, TB_Fan8);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar10, TB_Fan9);
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar11, TB_Fan10);
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar12, TB_Fan11);
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar13, TB_Fan12);
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar14, TB_Fan13);
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar15, TB_Fan14);
        }

        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            setChange(trackBar16, TB_Fan15);
        }

        private void BT_GetInfo_Click(object sender, EventArgs e)
        {
            TB_ArduinoInfo.Text = cmd.ReadArduinoInfo();
        }

        private void BT_START_Click(object sender, EventArgs e)
        {
            SetStartUI();
            meas.bstop = true;
            meas.Testlist.Clear();
            if (ckb_Thermistor.Checked == true)
                meas.Testlist.Add((int)MeasureValue.TestType.Thermistor);
            if (ckb_Voltage.Checked == true)
                meas.Testlist.Add((int)MeasureValue.TestType.Voltage);
            if (ckb_VDP.Checked == true)
                meas.Testlist.Add((int)MeasureValue.TestType.VDP);
            if (ckb_FanSpeed.Checked == true)
                meas.Testlist.Add((int)MeasureValue.TestType.FanSpeed);
            if (ckb_Thermocouple.Checked == true)
                meas.Testlist.Add((int)MeasureValue.TestType.Thermocouple);
            meas.sNPLC = sNPLC;
            meas.MeasureSet();
        }

        private void BT_STOP_Click(object sender, EventArgs e)
        {
            BT_STOP.Enabled = false;
            BT_START.Enabled = true;

            ckb_Thermistor.Enabled = true;
            ckb_FanSpeed.Enabled = true;
            ckb_Thermocouple.Enabled = true;
            ckb_VDP.Enabled = true;
            ckb_Voltage.Enabled = true;
        }

        private void SetStartUI()
        {
            //BT_STOP.Enabled = true;
            //BT_START.Enabled = false;

            //ckb_Thermistor.Enabled = false;
            //ckb_FanSpeed.Enabled = false;
            //ckb_Thermocouple.Enabled = false;
            //ckb_VDP.Enabled = false;
            //ckb_Voltage.Enabled = false;

            foreach(KeyValuePair<int,TextBox> nkey in diclist)
            {
                nkey.Value.Text=string.Empty;
            }
        }

        private void SetReturnValue(int nch, string sVal)
        {
            TextInvoke mi = new TextInvoke(UpdateForm);
            this.BeginInvoke(mi, new Object[] { nch, sVal }); 
        }

        private void UpdateForm(int nCh, string sVal)
        {
            TextBox tb = diclist[nCh];
            tb.ReadOnly = false;
            Color bk = tb.BackColor;
            tb.ForeColor = Color.Blue;
            tb.Text = sVal;            
        }

        private void chgColor(int nCh)
        {
            ColorInvoke col = new ColorInvoke(ChangeFontColor);
            this.BeginInvoke(col, nCh);
        }

        private void ChangeFontColor(int nCh)
        {
            TextBox tb = diclist[nCh];
            tb.ReadOnly = true;
        }

        private void BT_Disconnect_Click(object sender, EventArgs e)
        {
            cmd.CloseComport();
            this.groupBox1.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
        }

        private void cmb_NPLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            sNPLC = cmb_NPLC.SelectedItem.ToString();           
        }
    }
}
