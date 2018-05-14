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
        string sPWM;
        string sFanID;
        string sPartName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CB_comport.Items.AddRange(SerialPort.GetPortNames());
            CB_comport.SelectedIndex = 0;
            sPartName = CB_comport.Text;
            tabControl1.Enabled = false;
            tabcontrolSet();
            BT_GetInfo.Enabled = false;
            TB_ArduinoInfo.Enabled = false;
        }
        private void tabcontrolSet()
        {

        }

        private void TextCanged(object sender, EventArgs e)
        {
            if(TB_Fan0_1.Text != string.Empty)
            {
                trackBar1.Value = Convert.ToInt16(TB_Fan0_1.Text);
              
                //cmd.WriteCmd(0, trackBar1.Value.ToString());
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
                //cmd.WriteCmd(0, trackBar2.Value.ToString());
            }
        }

        private void FAN3_TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_3.Text != string.Empty)
            {
                trackBar3.Value = Convert.ToInt16(TB_Fan0_3.Text);
                //cmd.WriteCmd(0, trackBar3.Value.ToString());
            }
        }

        private void FAN4_TextCanged(object sender, EventArgs e)
        {
            if (TB_Fan0_4.Text != string.Empty)
            {
                trackBar4.Value = Convert.ToInt16(TB_Fan0_4.Text);
                //cmd.WriteCmd(0, trackBar4.Value.ToString());
            }
        }

        private void BT_GetArduinoID_Click(object sender, EventArgs e)
        {
            cmd.sPartName = sPartName;
            cmd.OpenComport();
            string sFanID = cmd.ReadCmdFID();
            if (sFanID == null)
                return;
            TEXT_ArduinoID.Text = sFanID;
            tabControl1.Enabled = true;
            // cmd.ReadArduinoInfo();
        }

        private void WriteCmd()
        {
            string sArduinoId = TEXT_ArduinoID.Text;
        }
        
        private void SetFanPWM()
        {           
            sFanID = fanSet.GetFanID();
            sPWM = fanSet.GetFanPWM();
            int nLen = sPWM.Length;
            switch(nLen)
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
    }
}
