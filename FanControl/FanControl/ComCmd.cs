using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace FanControl
{
    class ComCmd
    {
        SerialPort sp = new SerialPort();        
        public string sPartName;

        public void WriteCmd(string sCmd)
        {                      
           sp.WriteLine("W" + sCmd); 
        }

        public string ReadCmdFID()
        {           
            sp.WriteLine("R1");
            Thread.Sleep(100);
            string sRead = GetReadCmd();
            return sRead;
        }

        public string ReadArduinoInfo()
        {           
            sp.WriteLine("R0");
            Thread.Sleep(100);
            sp.ReadTimeout = 3000;
            string sRead = GetReadCmd();
          
            return sRead;
        }

        private string GetReadCmd()
        {
            string sReadStr = string.Empty;
            try
            {
                sReadStr = sp.ReadLine();
            }
            catch(TimeoutException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return sReadStr;
        }

        public void OpenComport()
        {
            sp.PortName = sPartName;
            if (sp.IsOpen)
                return;
            sp.Open();
        }
        public void CloseComport()
        {
            sp.Close();
        }

    }
}
