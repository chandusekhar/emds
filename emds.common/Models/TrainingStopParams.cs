using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace emds.common.Models
{
    [Serializable]
    [XmlRoot("TrainingStopParams")]
    public class TrainingStopParams
    {
        [XmlAttribute("UseIterations")]
        public bool UseIterations { get; set; }
        [XmlAttribute("Iterations")]
        public int Iterations { get; set; }
        [XmlAttribute("UseTeachError")]
        public bool UseTeachError { get; set; }
        [XmlAttribute("TeachError")]
        public double TeachError { get; set; }
        [XmlAttribute("UseTestError")]
        public bool UseTestError { get; set; }
        [XmlAttribute("TestError")]
        public double TestError { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }

        public static TrainingStopParams GetTraningStopParams(XElement xml)
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(TrainingStopParams));
            TrainingStopParams res = (TrainingStopParams) xmlS.Deserialize(xml.CreateReader());
            return res;
        }
    }
}
