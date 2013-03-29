namespace Nsim.Calculator
{
    using Nsim;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class HiddenLayersConfig : IConfigurable, IHiddenLayers
    {
        private readonly List<Nsim.Calculator.LayerConfig> _xac98a99ed8268faa = new List<Nsim.Calculator.LayerConfig>();
        [CompilerGenerated]
        private IActivationStruct x66c2e884def499b8;
        [CompilerGenerated]
        private int xc281c1a56ad963f7;

        public HiddenLayersConfig()
        {
            this.ActivationFunction = new Nsim.Calculator.ActivationConfig();
        }

        private void EdtActivationFunctionChanged(object sender, ActivationChangedEventArgs e)
        {
            foreach (Nsim.Calculator.LayerConfig config in this._xac98a99ed8268faa.OfType<Nsim.Calculator.LayerConfig>())
            {
                config.ActivationFunction.Xml = e.ActivationFunction.Xml;
            }
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

        public int Count
        {
            [CompilerGenerated]
            get
            {
                return this.xc281c1a56ad963f7;
            }
            [CompilerGenerated]
            set
            {
                this.xc281c1a56ad963f7 = value;
            }
        }

        public IEnumerable<ILayerStruct> Layers
        {
            get
            {
                return this._xac98a99ed8268faa.OfType<ILayerStruct>();
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("HiddenLayers");
                element.Add(this.ActivationFunction.Xml);
                using (List<Nsim.Calculator.LayerConfig>.Enumerator enumerator = this._xac98a99ed8268faa.GetEnumerator())
                {
                    ILayerStruct struct2;
                    bool flag;
                    goto Label_0049;
                Label_0032:
                    struct2 = enumerator.Current;
                    element.Add(struct2.Xml);
                Label_0049:
                    flag = enumerator.MoveNext();
                    if ((-2147483648 != 0) && flag)
                    {
                        goto Label_0032;
                    }
                }
                return element;
            }
            set
            {
                bool flag = !(value.Name.LocalName != "HiddenLayers");
                if (!flag)
                {
                    throw new ArgumentException();
                }
                this.ActivationFunction.Xml = value.Element("ActivationFunction");
                this._xac98a99ed8268faa.Clear();
                using (IEnumerator<XElement> enumerator = value.Elements("Layer").GetEnumerator())
                {
                    XElement element;
                    goto Label_00A1;
                Label_007D:
                    element = enumerator.Current;
                    Nsim.Calculator.LayerConfig item = new Nsim.Calculator.LayerConfig {
                        Xml = element
                    };
                    this._xac98a99ed8268faa.Add(item);
                Label_00A1:
                    flag = enumerator.MoveNext();
                    do
                    {
                        if (flag)
                        {
                            goto Label_007D;
                        }
                    }
                    while (0 != 0);
                    goto Label_001C;
                }
                if (-2 == 0)
                {
                    return;
                }
            Label_001C:
                this.Count = this._xac98a99ed8268faa.Count;
            }
        }
    }
}

