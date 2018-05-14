using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace FanControl
{
    class FanSet:Form
    {
        public TextBox tb = new TextBox();
        public TrackBar tracker = new TrackBar();
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
