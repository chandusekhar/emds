namespace Nsim.Calculator
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.Networks;
    using Nsim;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class NetworkCalculator
    {
        private readonly Nsim.Calculator.NetConfig _x438b660762649dbf = new Nsim.Calculator.NetConfig();
        private readonly IDataProcessor _x91bd2127cb8b0fed = new Nsim.Calculator.DataProcessorConfig();
        [CompilerGenerated]
        private BasicNetwork xd062f442b1aca8db;

        protected NetworkCalculator(XContainer config)
        {
            this._x438b660762649dbf.Xml = config.Element("NetStruct");
            this._x91bd2127cb8b0fed.Xml = config.Element("DataProcessor");
            this.Xml = config.Element("TrainStatus");
        }

        public double[] Calc(double[] dataArray)
        {
            IMLData row = new BasicMLData(dataArray);
            IMLData input = this._x91bd2127cb8b0fed.ProcessInputVector(row);
            IMLData data4 = this.x5b0926ce641e48a7.Compute(input);
            double[] data = this._x91bd2127cb8b0fed.RestoreIdealVector(data4).Data;
            if (2 != 0)
            {
            }
            return data;
        }

        public static NetworkCalculator LoadFromFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return LoadFromStream(stream);
            }
        }

        public static NetworkCalculator LoadFromStream(Stream stream)
        {
            return new NetworkCalculator(XDocument.Load(stream).Element("NeuroProject"));
        }

        private BasicNetwork x5b0926ce641e48a7
        {
            [CompilerGenerated]
            get
            {
                return this.xd062f442b1aca8db;
            }
            [CompilerGenerated]
            set
            {
                this.xd062f442b1aca8db = value;
            }
        }

        public XElement Xml
        {
            get
            {
                double[] numArray;
                XElement element2;
                XElement element = new XElement("TrainStatus");
                bool flag = this.x5b0926ce641e48a7 == null;
                if (0 != 0)
                {
                    goto Label_004C;
                }
            Label_0013:
                if (flag)
                {
                    return element;
                }
            Label_004C:
                numArray = new double[this.x5b0926ce641e48a7.EncodedArrayLength()];
                if (((uint) flag) > uint.MaxValue)
                {
                    return element;
                }
                this.x5b0926ce641e48a7.EncodeToArray(numArray);
                if (0 == 0)
                {
                    element.Add(numArray.ToXElement().AddContent("Weigths".ToNameAttribute()));
                }
                if ((((uint) flag) - ((uint) flag)) >= 0)
                {
                    return element;
                }
                if (-2147483648 != 0)
                {
                    goto Label_0013;
                }
                return element2;
            }
            set
            {
                bool flag = value.Elements().ByName("Weigths") != null;
                if (flag)
                {
                    double[] numArray;
                    if ((((uint) flag) - ((uint) flag)) >= 0)
                    {
                        this.x5b0926ce641e48a7 = this._x438b660762649dbf.GetNewNetwork();
                        numArray = value.Elements().ByName("Weigths").AsArray();
                    }
                    if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                    {
                        this.x5b0926ce641e48a7.DecodeFromArray(numArray);
                    }
                }
            }
        }
    }
}

