using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FanControl
{
    public class MeasureValue
    {
        public enum TestType
        {
            Thermistor = 0,
            Voltage,
            VDP,
            FanSpeed,
            Thermocouple,
        }

        public delegate void VolValue(int nCh, string sVal);
        public delegate void ValueCol(int nCh);
        public event VolValue returnVolValue;
        public event ValueCol ChgvalCol;
        public bool bstop;
        private int DevNo;
        public string sNPLC;
        GPIBCmd gpibstr = new GPIBCmd();
        Thread MeasValue;
        public List<int> Testlist = new List<int> ();
        string sRes;
        string sVal = string.Empty;
        double fval;

        public void MeasureSet()
        {
            bstop = false;                       
            short gpibaddr = gpibstr.getAddress(0, "34980");
            DevNo = gpibstr.GetDevNo(0, (ushort)gpibaddr);
            sRes = string.Empty;
            gpibstr.GPIBWrite(DevNo, ":NPLCycles " + sNPLC);
            MeasValue = new Thread(Measure);
            MeasValue.Start();           
        }

        public void Measure()
        {          
           foreach(int var in Testlist)
            {
                switch(var)
                {
                    case (int)TestType.Thermistor:
                        dothermistorMeas();
                        break;
                    case (int)TestType.Voltage:
                        doVoltageMeas();
                        break;
                    case (int)TestType.VDP:
                        doVDPMeas();
                        break;
                    case (int)TestType.FanSpeed:
                        doFanSpeedMeas();
                        break;
                    case (int)TestType.Thermocouple:
                        doThermocoupleMeas();
                        break;
                }
            }
        }

        public void dothermistorMeas()
        {
            sVal =MeasureVal("1001");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(1, fval.ToString());
            ChgvalCol(1);
            sVal = MeasureVal("1002");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(2, fval.ToString());
            ChgvalCol(2);
            sVal = MeasureVal("1003");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(3, fval.ToString());
            ChgvalCol(3);
            sVal = MeasureVal("1004");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(4, fval.ToString());
            ChgvalCol(4);
            sVal = MeasureVal("1011");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(11, fval.ToString());
            ChgvalCol(11);
            sVal = MeasureVal("1012");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(12, fval.ToString());
            ChgvalCol(12);
            sVal = MeasureVal("1013");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(13, fval.ToString());
            ChgvalCol(13);
            sVal = MeasureVal("1014");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(14, fval.ToString());
            ChgvalCol(14);
        }

        public void doVoltageMeas()
        {
            sVal = MeasureVal("1005");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(10, fval.ToString());
            ChgvalCol(10);
            sVal = MeasureVal("1010");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(15, fval.ToString());
            ChgvalCol(15);
            sVal = MeasureVal("1015");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(5, fval.ToString());
            ChgvalCol(5);
        }

        public void doVDPMeas()
        {
            sVal = MeasureVal("1006");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(6, fval.ToString());
            ChgvalCol(6);
            sVal = MeasureVal("1007");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(7, fval.ToString());
            ChgvalCol(7);
            sVal = MeasureVal("1008");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(8, fval.ToString());
            ChgvalCol(8);
            sVal = MeasureVal("1009");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(9, fval.ToString());
            ChgvalCol(9);
        }

        public void doFanSpeedMeas()
        {
            sVal = MeasureFreq("1016");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(16, fval.ToString());            
            ChgvalCol(16);
            sVal = MeasureFreq("1017");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(17, fval.ToString());         
            ChgvalCol(17);
            sVal = MeasureFreq("1018");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(18, fval.ToString());          
            ChgvalCol(18);
            sVal = MeasureFreq("1019");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(19, fval.ToString());       
            ChgvalCol(19);
        }

        public void doThermocoupleMeas()
        {
            sVal = MeasureTC("1036");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(36, fval.ToString());        
            ChgvalCol(36);
            sVal = MeasureTC("1037");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(37, fval.ToString());           
            ChgvalCol(37);
            sVal = MeasureTC("1038");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(38, fval.ToString());          
            ChgvalCol(38);
            sVal = MeasureTC("1039");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(39, fval.ToString());            
            ChgvalCol(39);
            sVal = MeasureTC("1040");
            fval = Convert.ToDouble(sVal);
            returnVolValue.Invoke(40, fval.ToString());          
            ChgvalCol(40);
        }

        private string MeasureVal(string sChan)
        {
            string tmp = string.Empty; ;
            gpibstr.GPIBWrite(DevNo, "ROUTe:CLOSe (@"+ sChan + ")");
            gpibstr.GPIBWrite(DevNo, "MEASure:VOLTage:DC? 26, 0.0001,(@"+ sChan + ")");
            string sResVal = gpibstr.GPIBRead(DevNo);
            int nPos = sResVal.IndexOf("\n");           
            tmp = sResVal.Substring(0, nPos);
            return tmp;
        }

        private string MeasureFreq(string sChan)
        {
            string sVal;
            gpibstr.GPIBWrite(DevNo, "ROUTe:CLOSe (@" + sChan + ")");
            gpibstr.GPIBWrite(DevNo, "MEASure:FREQuency? (@" + sChan + ")");
            string sResVal = gpibstr.GPIBRead(DevNo);
            int nPos = sResVal.IndexOf("\n");
            sVal = string.Empty;
            sVal = sResVal.Substring(0, nPos);
            return sVal;
        }

        private string MeasureTC(string sChan)
        {
            string sVal;
            gpibstr.GPIBWrite(DevNo, "ROUTe:CLOSe (@" + sChan + ")");
            gpibstr.GPIBWrite(DevNo, "MEASure:TEMPerature? TCouple,k, (@" + sChan + ")");
            string sResVal = gpibstr.GPIBRead(DevNo);
            int nPos = sResVal.IndexOf("\n");
            sVal = string.Empty;
            sVal = sResVal.Substring(0, nPos);
            return sVal;
        }

        //do
        //{
        //  DateTime start = DateTime.Now;
        //    gpibstr.GPIBWrite(DevNo, "CONFigure: VOLTage: DC 1,0.001, (@1001:1004,1011:1014)");

        //    gpibstr.GPIBWrite(DevNo, "INITiate");
        //    gpibstr.GPIBWrite(DevNo, "FETCh?");
        //    //gpibstr.GPIBWrite(gpibaddr, "MEASure:VOLTage:DC? 5, 0.001,(@1001:1004,1010,1011:1014)");
        //    string sResVal = gpibstr.GPIBRead(DevNo);

        //    DateTime end = DateTime.Now;
        //    ShowResuleVal(sResVal);
        //    TimeSpan ts = end - start;
        //    double dayCount = ts.TotalSeconds;
        //    ShowDurationTime(dayCount.ToString());
        //} while (bstop == false);




    }
}
