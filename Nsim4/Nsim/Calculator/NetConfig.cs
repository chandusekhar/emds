namespace Nsim.Calculator
{
    using Encog.Neural.Networks;
    using Nsim;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class NetConfig : IConfigurable, INetStruct
    {
        [CompilerGenerated]
        private ILayerStruct x8d678fdb51e187e1;
        [CompilerGenerated]
        private IHiddenLayers xd83b06713c993a25;
        [CompilerGenerated]
        private ILayerStruct xd91bf915479c5850;

        public NetConfig()
        {
            this.InputLayer = new Nsim.Calculator.LayerConfig();
            this.OutputLayer = new Nsim.Calculator.LayerConfig();
            this.HiddenLayers = new Nsim.Calculator.HiddenLayersConfig();
        }

        public BasicNetwork GetNewNetwork()
        {
            BasicNetwork network = new BasicNetwork();
            network.AddLayer(this.InputLayer.GetLayer());
            if (0 == 0)
            {
                IEnumerator<ILayerStruct> enumerator = this.HiddenLayers.Layers.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        network.AddLayer(enumerator.Current.GetLayer());
                    }
                }
                finally
                {
                    bool flag = enumerator == null;
                    goto Label_006E;
                Label_004D:
                    enumerator.Dispose();
                    if ((((uint) flag) - ((uint) flag)) < 0)
                    {
                        goto Label_004D;
                    }
                    goto Label_0072;
                Label_006E:
                    if (!flag)
                    {
                        goto Label_004D;
                    }
                Label_0072:;
                }
                network.AddLayer(this.OutputLayer.GetLayer());
                network.Structure.FinalizeStructure();
            }
            network.Reset();
            return network;
        }

        public IHiddenLayers HiddenLayers
        {
            [CompilerGenerated]
            get
            {
                return this.xd83b06713c993a25;
            }
            [CompilerGenerated]
            set
            {
                this.xd83b06713c993a25 = value;
            }
        }

        public ILayerStruct InputLayer
        {
            [CompilerGenerated]
            get
            {
                return this.x8d678fdb51e187e1;
            }
            [CompilerGenerated]
            set
            {
                this.x8d678fdb51e187e1 = value;
            }
        }

        public ILayerStruct OutputLayer
        {
            [CompilerGenerated]
            get
            {
                return this.xd91bf915479c5850;
            }
            [CompilerGenerated]
            set
            {
                this.xd91bf915479c5850 = value;
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("NetStruct");
                do
                {
                    element.Add(this.InputLayer.Xml.AddContent("Input".ToNameAttribute()));
                    element.Add(this.HiddenLayers.Xml);
                }
                while (-2 == 0);
                element.Add(this.OutputLayer.Xml.AddContent("Output".ToNameAttribute()));
                return element;
            }
            set
            {
                this.InputLayer.Xml = value.Elements().ByName("Input");
                this.OutputLayer.Xml = value.Elements().ByName("Output");
                this.HiddenLayers.Xml = value.Element("HiddenLayers");
            }
        }
    }
}

