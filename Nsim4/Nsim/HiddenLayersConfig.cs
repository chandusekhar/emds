namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class HiddenLayersConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, IHiddenLayers
    {
        private bool _x7dc3d9d322900926;
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(HiddenLayersConfig), new UIPropertyMetadata(0, new PropertyChangedCallback(HiddenLayersConfig.xcecac585893337d9)));
        internal ActivationConfig edtActivation;
        internal ListBox layersList;

        public HiddenLayersConfig()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        internal Delegate _x11287467a5422d1c(Type x127370c996b87499, string xa1b13fd4a6c07a01)
        {
            return Delegate.CreateDelegate(x127370c996b87499, this, xa1b13fd4a6c07a01);
        }

        private void EdtActivationFunctionChanged(object sender, ActivationChangedEventArgs e)
        {
            using (IEnumerator<LayerConfig> enumerator = this.layersList.Items.OfType<LayerConfig>().GetEnumerator())
            {
                LayerConfig config;
                goto Label_003D;
            Label_001A:
                config = enumerator.Current;
                config.ActivationFunction.Xml = e.ActivationFunction.Xml;
                if (0 != 0)
                {
                    goto Label_001A;
                }
            Label_003D:
                if (enumerator.MoveNext())
                {
                    goto Label_001A;
                }
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/layer/hiddenlayersconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if (0 == 0)
                {
                    break;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            if (((uint) num) >= 0)
            {
                switch (num)
                {
                    case 1:
                        goto Label_0015;

                    case 2:
                        goto Label_0023;
                }
                if ((((uint) xf3efd21c486a5cce) + ((uint) xf3efd21c486a5cce)) >= 0)
                {
                    this._x7dc3d9d322900926 = true;
                    return;
                }
                goto Label_0023;
            }
        Label_0015:
            this.edtActivation = (ActivationConfig) x11d58b056c032b03;
            return;
        Label_0023:
            this.layersList = (ListBox) x11d58b056c032b03;
        }

        private static void xcecac585893337d9(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            int num;
            bool flag;
            HiddenLayersConfig config = x73f821c71fe1e676 as HiddenLayersConfig;
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0170;
            }
            goto Label_00E8;
        Label_002D:
            App.Services.FairEvent<xa443afcc736e1f3e>(new xa443afcc736e1f3e());
            if (-1 != 0)
            {
                return;
            }
            goto Label_0170;
        Label_009F:
            flag = num >= config.layersList.Items.Count;
            if (((((uint) num) - ((uint) flag)) <= uint.MaxValue) && flag)
            {
                goto Label_002D;
            }
            int count = config.layersList.Items.Count;
        Label_0067:
            flag = count > num;
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_011E;
            }
            if (flag)
            {
                config.layersList.Items.RemoveAt(config.layersList.Items.Count - 1);
                count--;
                goto Label_0067;
            }
            goto Label_002D;
        Label_00E8:
            if (!flag)
            {
                goto Label_0134;
            }
            if (((uint) num) < 0)
            {
                goto Label_002D;
            }
            goto Label_009F;
        Label_011E:
            if (count < num)
            {
                LayerConfig newItem = new LayerConfig {
                    ActivationFunction = { Xml = config.ActivationFunction.Xml }
                };
                config.layersList.Items.Add(newItem);
                count++;
                if ((((uint) num) | 0x7fffffff) != 0)
                {
                    goto Label_011E;
                }
                goto Label_0170;
            }
            goto Label_009F;
        Label_0134:
            count = config.layersList.Items.Count;
            goto Label_011E;
        Label_0170:
            num = (int) xfbf34718e704c6bc.NewValue;
            flag = num <= config.layersList.Items.Count;
            if (0 != 0)
            {
                goto Label_0134;
            }
            goto Label_00E8;
        }

        public IActivationStruct ActivationFunction
        {
            get
            {
                return this.edtActivation;
            }
        }

        public int Count
        {
            get
            {
                return (int) base.GetValue(CountProperty);
            }
            set
            {
                base.SetValue(CountProperty, value);
            }
        }

        public IEnumerable<ILayerStruct> Layers
        {
            get
            {
                return this.layersList.Items.OfType<ILayerStruct>();
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("HiddenLayers");
                element.Add(this.ActivationFunction.Xml);
                IEnumerator enumerator = ((IEnumerable) this.layersList.Items).GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ILayerStruct current = (ILayerStruct) enumerator.Current;
                        do
                        {
                            element.Add(current.Xml);
                        }
                        while (15 == 0);
                    }
                }
                finally
                {
                    bool flag;
                    IDisposable disposable = enumerator as IDisposable;
                    goto Label_007A;
                Label_0071:
                    if (15 != 0)
                    {
                    }
                    goto Label_0093;
                Label_007A:
                    flag = disposable == null;
                    while (!flag)
                    {
                        disposable.Dispose();
                        goto Label_0093;
                    }
                    goto Label_0071;
                Label_0093:;
                }
                return element;
            }
            set
            {
                bool flag = !(value.Name.LocalName != "HiddenLayers");
                do
                {
                    if (!flag)
                    {
                        throw new ArgumentException();
                    }
                    break;
                }
                while (-2 == 0);
                this.ActivationFunction.Xml = value.Element("ActivationFunction");
                this.layersList.Items.Clear();
                IEnumerator<XElement> enumerator = value.Elements("Layer").GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        XElement current = enumerator.Current;
                        LayerConfig newItem = new LayerConfig {
                            Xml = current
                        };
                        this.layersList.Items.Add(newItem);
                        if (2 != 0)
                        {
                        }
                    }
                }
                finally
                {
                    flag = enumerator == null;
                    while (!flag)
                    {
                        enumerator.Dispose();
                        break;
                    }
                }
                this.Count = this.layersList.Items.Count;
            }
        }
    }
}

