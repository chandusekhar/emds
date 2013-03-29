namespace Nsim
{
    using Encog.Neural.Networks.Layers;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class LayerConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, ILayerStruct
    {
        private bool _x7dc3d9d322900926;
        internal ActivationConfig cbActivation;
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(LayerConfig), new UIPropertyMetadata(1, new PropertyChangedCallback(LayerConfig.x0e78c341e29235f2)));

        public LayerConfig()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        internal Delegate _x11287467a5422d1c(Type x127370c996b87499, string xa1b13fd4a6c07a01)
        {
            return Delegate.CreateDelegate(x127370c996b87499, this, xa1b13fd4a6c07a01);
        }

        public BasicLayer GetLayer()
        {
            return new BasicLayer(this.ActivationFunction.GetActivation(), true, this.Size);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._x7dc3d9d322900926)
            {
                this._x7dc3d9d322900926 = true;
                if (0 == 0)
                {
                }
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/layer/layerconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }

        private static void x0e78c341e29235f2(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            App.Services.FairEvent<xa443afcc736e1f3e>(new xa443afcc736e1f3e());
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            do
            {
                while (((uint) num) >= 0)
                {
                    if (num == 1)
                    {
                        this.cbActivation = (ActivationConfig) x11d58b056c032b03;
                        return;
                    }
                Label_0017:
                    this._x7dc3d9d322900926 = true;
                    return;
                }
            }
            while (0 != 0);
            goto Label_0017;
        }

        public IActivationStruct ActivationFunction
        {
            get
            {
                return this.cbActivation;
            }
        }

        public int Size
        {
            get
            {
                return (int) base.GetValue(SizeProperty);
            }
            set
            {
                base.SetValue(SizeProperty, value);
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
                if (value.Name.LocalName != "Layer")
                {
                    throw new ArgumentException();
                }
                this.Size = value.Attribute("Size").AsInt(0);
                this.ActivationFunction.Xml = value.Element("ActivationFunction");
            }
        }
    }
}

