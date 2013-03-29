namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class LinearScaleConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, IDataProcessor
    {
        private bool _x7dc3d9d322900926;
        private readonly LinearScale _x9a9fa564793616f5 = new LinearScale();
        public static readonly DependencyProperty AProperty = DependencyProperty.Register("A", typeof(double), typeof(LinearScaleConfig), new UIPropertyMetadata(-1.0, new PropertyChangedCallback(LinearScaleConfig.xb20f17ffb7d0ef83)));
        public static readonly DependencyProperty BProperty = DependencyProperty.Register("B", typeof(double), typeof(LinearScaleConfig), new UIPropertyMetadata(1.0, new PropertyChangedCallback(LinearScaleConfig.xa6f06e5c85cea5d3)));
        public static readonly DependencyProperty IsUsedProperty = DependencyProperty.Register("IsUsed", typeof(bool), typeof(LinearScaleConfig), new UIPropertyMetadata(true, new PropertyChangedCallback(LinearScaleConfig.xf5135a1c913bd35f)));

        public LinearScaleConfig()
        {
            this.InitializeComponent();
        }

        public void ConfigureProcessor(BasicMLDataSet data)
        {
            this._x9a9fa564793616f5.ConfigureProcessor(data);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (true)
            {
                if (flag)
                {
                    this._x7dc3d9d322900926 = true;
                    if ((((uint) flag) & 0) != 0)
                    {
                        break;
                    }
                    Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataprocessors/scale/linearscaleconfig.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                    if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                    {
                    }
                }
                break;
            }
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            return this._x9a9fa564793616f5.ProcessDataSet(dataToProcess);
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            return this._x9a9fa564793616f5.ProcessDataVector(vectorToProcess);
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            return this._x9a9fa564793616f5.ProcessIdealVector(row);
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            return this._x9a9fa564793616f5.ProcessInputVector(row);
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToRestore)
        {
            return this._x9a9fa564793616f5.RestoreDataSet(dataToRestore);
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorTorestore)
        {
            return this._x9a9fa564793616f5.RestoreDataVector(vectorTorestore);
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            return this._x9a9fa564793616f5.RestoreIdealVector(row);
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            return this._x9a9fa564793616f5.RestoreInputVector(row);
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        private static void xa6f06e5c85cea5d3(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            LinearScaleConfig config = x73f821c71fe1e676 as LinearScaleConfig;
            config._x9a9fa564793616f5.B = (double) xfbf34718e704c6bc.NewValue;
        }

        private static void xb20f17ffb7d0ef83(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            LinearScaleConfig config = x73f821c71fe1e676 as LinearScaleConfig;
            config._x9a9fa564793616f5.A = (double) xfbf34718e704c6bc.NewValue;
        }

        private static void xf5135a1c913bd35f(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        public double A
        {
            get
            {
                return (double) base.GetValue(AProperty);
            }
            set
            {
                base.SetValue(AProperty, value);
            }
        }

        public double B
        {
            get
            {
                return (double) base.GetValue(BProperty);
            }
            set
            {
                base.SetValue(BProperty, value);
            }
        }

        public bool IsUsed
        {
            get
            {
                return (bool) base.GetValue(IsUsedProperty);
            }
            set
            {
                base.SetValue(IsUsedProperty, value);
            }
        }

        public XElement Xml
        {
            get
            {
                return this._x9a9fa564793616f5.Xml;
            }
            set
            {
                this._x9a9fa564793616f5.Xml = value;
                this.IsUsed = this._x9a9fa564793616f5.IsUsed;
                this.A = this._x9a9fa564793616f5.A;
                this.B = this._x9a9fa564793616f5.B;
            }
        }
    }
}

