namespace Nsim
{
    using Encog.Neural.Networks;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class NetConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, INetStruct
    {
        private bool _x7dc3d9d322900926;
        internal HiddenLayersConfig hiddenConfig;
        internal LayerConfig inConfig;
        internal LayerConfig outConfig;

        public NetConfig()
        {
            this.InitializeComponent();
            App.Services.RegisterService<INetStruct>(this);
        }

        public BasicNetwork GetNewNetwork()
        {
            bool flag;
            BasicNetwork network = new BasicNetwork();
            if (8 == 0)
            {
                BasicNetwork network2;
                return network2;
            }
            network.AddLayer(this.InputLayer.GetLayer());
            IEnumerator<ILayerStruct> enumerator = this.HiddenLayers.Layers.GetEnumerator();
            try
            {
                ILayerStruct struct2;
                goto Label_0079;
            Label_0063:
                struct2 = enumerator.Current;
                network.AddLayer(struct2.GetLayer());
            Label_0079:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_0063;
                }
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_0079;
                }
            }
            finally
            {
                flag = enumerator == null;
                while (!flag)
                {
                    enumerator.Dispose();
                    while ((((uint) flag) | 1) == 0)
                    {
                    }
                    break;
                }
            }
            network.AddLayer(this.OutputLayer.GetLayer());
            network.Structure.FinalizeStructure();
            network.Reset();
            return network;
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/net/netconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                {
                }
                break;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            switch (num)
            {
                case 1:
                    this.inConfig = (LayerConfig) x11d58b056c032b03;
                    return;

                case 2:
                    this.hiddenConfig = (HiddenLayersConfig) x11d58b056c032b03;
                    if (-2147483648 == 0)
                    {
                        break;
                    }
                    return;

                case 3:
                    this.outConfig = (LayerConfig) x11d58b056c032b03;
                    return;

                default:
                    if (((uint) num) <= uint.MaxValue)
                    {
                        break;
                    }
                    return;
            }
            this._x7dc3d9d322900926 = true;
        }

        public IHiddenLayers HiddenLayers
        {
            get
            {
                return this.hiddenConfig;
            }
        }

        public ILayerStruct InputLayer
        {
            get
            {
                return this.inConfig;
            }
        }

        public ILayerStruct OutputLayer
        {
            get
            {
                return this.outConfig;
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
                    element.Add(this.OutputLayer.Xml.AddContent("Output".ToNameAttribute()));
                }
                while (0 != 0);
                return element;
            }
            set
            {
                this.InputLayer.Xml = value.Elements().ByName("Input");
                this.OutputLayer.Xml = value.Elements().ByName("Output");
                this.HiddenLayers.Xml = value.Element("HiddenLayers");
                App.Services.FairEvent<xa443afcc736e1f3e>(new xa443afcc736e1f3e());
            }
        }
    }
}

