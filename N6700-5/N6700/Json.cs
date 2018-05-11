using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using Newtonsoft.Json;

namespace N6700
{
    public class ModelSeq
    {
        public int Steps { get; set; }
        public double VoutPoints { get; set; }
        public double IMaxPoints { get; set; }
        public double DWellPoints { get; set; }
        public double ElapseTime { get; set; }
    }

    public class ModelInfo
    {
        public string ChassisName { get; set; }
        public string IPAddress { get; set; }
        public string Module { get; set; }
        public string Label { get; set; }
        public int Channel { get; set; }
        public double NomVout { get; set; }
        public double MaxVout { get; set; }
        public double MaxIout { get; set; }
        public double MaxWatts { get; set; }
        public string Comment { get; set; }
        public ModelSlew ModelSlew { get; set; }
        public List<ModelSeq> ModelSeq { get; set; }
    }

    public class ModelSlew
    {
        public string Label { get; set; }
        public string Slew { get; set; }
    }

}
