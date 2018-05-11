using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace N6700
{
    public partial class ConfigSet : Form
    {
        public int nMeasureItem;
        public int nPowerLeftSet;
        public double dRST_Delay;
        public double dDigitizer_Offset;
        public int nDigitizer_Point;
        public double dDigitizer_Seconds;
        public double dChassis_Delay;
        public double dSeqDelay;
        public string sPXIBoxIP;
        public string sPort;
        public string sDelay;
        public bool bShutdown;

      
        public ConfigSet()
        {
            InitializeComponent();
        }

        private void ConfigSet_Load(object sender, EventArgs e)
        {
            ReadINI();
            ConfigSetUI();
            CheckShutdownCmd();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_Digitizer_GraphPoint.Text) > 64000)
            {
                MessageBox.Show("The Maximum Offset point is 64000");
                txt_Digitizer_GraphPoint.Focus();
                txt_Digitizer_GraphPoint.SelectAll();
            }
            else
            {
                dRST_Delay = double.Parse(txt_Delay.Text);
                dDigitizer_Offset = double.Parse(txt_Digitizer_OffsetPoint.Text);
                nDigitizer_Point = int.Parse(txt_Digitizer_GraphPoint.Text);
                dDigitizer_Seconds = double.Parse(txt_Digitizer_Seconds.Text);
                dChassis_Delay = double.Parse(txt_Chassis_Delay.Text);
                dSeqDelay = double.Parse(Txt_SeqDelay.Text);
                sPXIBoxIP = TB_ClientIP.Text;
                sPort = TB_PORT.Text;
                sDelay = TB_Delay.Text;
                WriteINI();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Combo_PowerLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            nPowerLeftSet = Combo_PowerLeft.SelectedIndex;
        }

        private void Combo_Measure_SelectedIndexChanged(object sender, EventArgs e)
        {
            nMeasureItem = Combo_Measure.SelectedIndex;
        }

        private void ConfigSetUI()
        {
           txt_Delay.Text = dRST_Delay.ToString();
           txt_Digitizer_OffsetPoint.Text = dDigitizer_Offset.ToString();
           txt_Digitizer_GraphPoint.Text = nDigitizer_Point.ToString();
           txt_Digitizer_Seconds.Text = dDigitizer_Seconds.ToString();
           txt_Chassis_Delay.Text = dChassis_Delay.ToString();
           Txt_SeqDelay.Text = dSeqDelay.ToString();
           Combo_PowerLeft.SelectedIndex = nPowerLeftSet;
           Combo_Measure.SelectedIndex = nMeasureItem;
           TB_ClientIP.Text = sPXIBoxIP;
           TB_PORT.Text = sPort;
           TB_Delay.Text = sDelay;
        }

        private void CheckShutdownCmd()
        {
            if(bShutdown == true)
            {
                CB_SHUTDOWN.Checked = true;
                TB_ClientIP.Enabled = true;
                TB_PORT.Enabled = true;
                TB_Delay.Enabled = true;
            }
            else
            {
                CB_SHUTDOWN.Checked = false;
                TB_ClientIP.Enabled = false;
                TB_PORT.Enabled = false;
                TB_Delay.Enabled = false;
            }
        }

        private void txt_Delay_KeyPress(object sender, KeyPressEventArgs e)
        {
           CheckIfNumber(e,0);
        }

        private void txt_Digitizer_OffsetPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfNumber(e, 2);
        }

        private void txt_Digitizer_GraphPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfNumber(e,1);
           
        }

        private void txt_Digitizer_Seconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfNumber(e,0);
        }

        private void txt_Chassis_Delay_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfNumber(e,0);
        }

        private void CheckIfNumber(KeyPressEventArgs e, int nIsCanDouble)
        {
            e.Handled = false;
           switch(nIsCanDouble)
           {
               case 0:
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar.CompareTo('.') == 0))
                    {
                        e.Handled = true;
                    }
                        
                   break;
               case 1:
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                         e.Handled = true;
                    }
                   break;
               case 2:
                   if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar.CompareTo('.') == 0) &&!(e.KeyChar.CompareTo('-') == 0))
                   {
                       e.Handled = true;
                   }
                   break;
           }
        }

        private void CB_SHUTDOWN_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_SHUTDOWN.Checked == true)           
                bShutdown = true;            
            else
                bShutdown = false;

            CheckShutdownCmd();
        }

        private void WriteINI()
        {
            INIFileAPI writeconfig = new INIFileAPI();

            List<string> config = new List<string>();
            config.Add(nPowerLeftSet.ToString());
            config.Add(nMeasureItem.ToString());
            config.Add(dDigitizer_Offset.ToString());
            config.Add(dDigitizer_Seconds.ToString());
            config.Add(nDigitizer_Point.ToString());
            config.Add(dChassis_Delay.ToString());
            config.Add(dSeqDelay.ToString());

            writeconfig.writeConfigini(config); //get Config data

            string sSendShutdownCmd;
            if (bShutdown == true)
                sSendShutdownCmd = "1";
            else
                sSendShutdownCmd = "0";

            config.Clear();
            config.Add(sSendShutdownCmd);
            config.Add(TB_ClientIP.Text);
            config.Add(TB_PORT.Text);
            config.Add(TB_Delay.Text);
            writeconfig.writeShutdownConfigini(config); ////get shutdown Config data
          
        }
        private void ReadINI()
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
                bShutdown = false;
            else
                bShutdown = true;

            sPXIBoxIP = config[1];
            sPort = config[2];
            sDelay = config[3];
        }
    }
}
