namespace Nsim.Calculator
{
    using Encog.Neural.Networks.Layers;
    using Nsim;
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class LayerConfig : IConfigurable, ILayerStruct
    {
        [CompilerGenerated]
        private IActivationStruct x66c2e884def499b8;
        [CompilerGenerated]
        private int xf85603d5e2065c3d;

        public LayerConfig()
        {
            this.ActivationFunction = new Nsim.Calculator.ActivationConfig();
        }

        public BasicLayer GetLayer()
        {
            return new BasicLayer(this.ActivationFunction.GetActivation(), true, this.Size);
        }

        public IActivationStruct ActivationFunction
        {
            [CompilerGenerated]
            get
            {
                return this.x66c2e884def499b8;
            }
            [CompilerGenerated]
            set
            {
                this.x66c2e884def499b8 = value;
            }
        }

        public int Size
        {
            [CompilerGenerated]
            get
            {
                return this.xf85603d5e2065c3d;
            }
            [CompilerGenerated]
            set
            {
                this.xf85603d5e2065c3d = value;
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("Layer");
                element.Add(new XAttribute("Size", this.Size));
                element.Add(this.ActivationFunction.Xml);
                return element;
            }
            set
            {
                bool flag = !(value.Name.LocalName != "Layer");
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_006E;
                }
            Label_002E:
                this.ActivationFunction.Xml = value.Element("ActivationFunction");
                if ((((uint) flag) | 8) != 0)
                {
                    return;
                }
            Label_006E:
                while (!flag)
                {
                    throw new ArgumentException();
                }
                this.Size = value.Attribute("Size").AsInt(0);
                if (2 == 0)
                {
                    return;
                }
                goto Label_002E;
            }
        }
    }
}

