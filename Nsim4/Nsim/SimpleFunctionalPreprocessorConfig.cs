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
    public class SimpleFunctionalPreprocessorConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, IDataProcessor
    {
        private bool _x7dc3d9d322900926;
        private readonly SimpleFunctionalPreprocessorLogic _x9a9fa564793616f5 = new SimpleFunctionalPreprocessorLogic();
        internal CheckBox cbUseFP;
        public static readonly DependencyProperty CorrelationFunctionProperty = DependencyProperty.Register("CorrelationFunction", typeof(CorrelationSelector), typeof(SimpleFunctionalPreprocessorConfig), new UIPropertyMetadata(CorrelationSelector.Mean, new PropertyChangedCallback(SimpleFunctionalPreprocessorConfig.x414281f0f1ed46f2)));
        public static readonly DependencyProperty IsUsedProperty = DependencyProperty.Register("IsUsed", typeof(bool), typeof(SimpleFunctionalPreprocessorConfig), new UIPropertyMetadata(false, new PropertyChangedCallback(SimpleFunctionalPreprocessorConfig.xf5135a1c913bd35f)));

        public SimpleFunctionalPreprocessorConfig()
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
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataprocessors/functional/simplefunctionalpreprocessorconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                }
                return;
            }
            if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
            {
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

        private static void x414281f0f1ed46f2(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            SimpleFunctionalPreprocessorConfig config = x73f821c71fe1e676 as SimpleFunctionalPreprocessorConfig;
            config._x9a9fa564793616f5.CorrelationSelectMode = (CorrelationSelector) xfbf34718e704c6bc.NewValue;
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            if ((((uint) num) - ((uint) num)) < 0)
            {
                return;
            }
        Label_003D:
            switch (num)
            {
                case 1:
                    this.cbUseFP = (CheckBox) x11d58b056c032b03;
                    if (1 != 0)
                    {
                        return;
                    }
                    break;

                case 2:
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    if ((((uint) xf3efd21c486a5cce) + ((uint) num)) <= uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_003D;
            }
            ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.x7ce50b15d48de9a6);
            if (15 == 0)
            {
            }
        }

        private void x7ce50b15d48de9a6(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            SimpleFunctionalPreprocessorLogic logic;
            BasicMLDataSet data = App.Services.GetService<ITrainData>().xd378208b5267f7e2();
            bool flag = data.Count >= 1L;
            if (((((uint) flag) + ((uint) flag)) <= uint.MaxValue) && flag)
            {
                SimpleFunctionalPreprocessorLogic logic2 = new SimpleFunctionalPreprocessorLogic {
                    CorrelationSelectMode = this.CorrelationFunction
                };
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    goto Label_001D;
                }
                if (3 != 0)
                {
                    logic = logic2;
                    if ((((uint) flag) + ((uint) flag)) >= 0)
                    {
                        if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                        {
                            return;
                        }
                        logic.ConfigureProcessor(data);
                        goto Label_001D;
                    }
                }
            }
            App.Services.GetService<x63523dbec506f4f5>().x09644b6258719f63("Нет данных для анализа.");
            return;
        Label_001D:
            App.Services.GetService<x63523dbec506f4f5>().x09644b6258719f63(logic.DecodeC());
            if (((uint) flag) <= uint.MaxValue)
            {
                return;
            }
            goto Label_001D;
        }

        private static void xf5135a1c913bd35f(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        public CorrelationSelector CorrelationFunction
        {
            get
            {
                return (CorrelationSelector) base.GetValue(CorrelationFunctionProperty);
            }
            set
            {
                base.SetValue(CorrelationFunctionProperty, value);
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
                this.CorrelationFunction = this._x9a9fa564793616f5.CorrelationSelectMode;
            }
        }
    }
}

