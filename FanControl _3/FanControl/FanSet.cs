using System;
using System.Collections.Generic;
//using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace FanControl
{
    public class FanSet
    {
        public System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
        public System.Windows.Forms.TrackBar tracker = new System.Windows.Forms.TrackBar();
        string sFanID = string.Empty;
        string sPWM = string.Empty;

        public void GetFanPWMVal()
        {
            sPWM = tracker.Value.ToString();
            sFanID = tracker.Tag.ToString();
            tb.Text = sPWM;
        }

        public string GetFanID()
        {
            return sFanID;
        }

        public string GetFanPWM()
        {
            return sPWM;
        }
    }
}
