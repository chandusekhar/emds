using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emds.common.Models
{
    public class DataProcessorConf
    {
        public bool IsUsed { get; set; }
        public string Type {get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public double[] InCC { get; set; }
        public double[] InCD { get; set; }
        public double[] OutCC { get; set; }
        public double[] OutCD { get; set; }
    }
}
