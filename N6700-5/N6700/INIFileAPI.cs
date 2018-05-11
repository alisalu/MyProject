using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace N6700
{
    public class INIFileAPI
    {
        public string iniPath = @".\Config.ini";

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        string[] config = {"Power Left", "Measure Type", "Points_Offset", "Seconds2Digitizer", "Graph_Points", "ChassisDelay", "RunSeqDelay"};
        string[] ShutdownSetting = { "Send ShutdownCmd", "PXIe Controller IP", "Port", "Send Command Delay(s)" };
        string[] configVal = { "0", "1", "-10", "1.5", "2048", "1", "0" };
        string[] ShutdownSettingVal = { "0", "172.16.9.1", "8080", "0" };

        private string ReadiniFile(string section,string keyname, string defauleValue)
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(section, keyname, defauleValue, sb, 20, iniPath);
            return sb.ToString();
        }

        private void WriteiniFile(string section, string keyname, string value)
        {
            WritePrivateProfileString(section, keyname, value, iniPath);
        }

        public List<string> ReadConfigini()
        {
            string sSection = "Settings";
            int nPos = 0;
            List<string> configlst = new List<string>();

            foreach(var value in config)
            {
                string sVal = ReadiniFile(sSection, config[nPos], configVal[nPos]);
                configlst.Add(sVal);
                nPos++;
            }
            return configlst;
        }

        public List<string> ReadShutdownConfigini()
        {
            string sSection = "Shutdown Settings";
            int nPos = 0;
            List<string> configlst = new List<string>();

            foreach (var value in ShutdownSetting)
            {
                string sVal = ReadiniFile(sSection, ShutdownSetting[nPos], ShutdownSettingVal[nPos]);
                configlst.Add(sVal);
                nPos++;
            }
            return configlst;
        }

        public void writeConfigini(List<string> ConfigSet)
        {
            int npos = 0;
            string sSection = "Settings";

            foreach(var setvalue in ConfigSet )
            { 
                WriteiniFile(sSection,config[npos],setvalue);
                npos++;
            }
        }

        public void writeShutdownConfigini(List<string> ConfigSet)
        {
            int npos = 0;
            string sSection = "Shutdown Settings";

            foreach (var setvalue in ConfigSet)
            { 
                WriteiniFile(sSection,ShutdownSetting[npos],setvalue);
                npos++;
            }
        }
    }
}
