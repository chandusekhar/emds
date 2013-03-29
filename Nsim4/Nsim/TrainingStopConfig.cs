namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class TrainingStopConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, x35a0e88a31c66173
    {
        private bool _x7dc3d9d322900926;
        public static readonly DependencyProperty IterationsProperty = DependencyProperty.Register("Iterations", typeof(int), typeof(TrainingStopConfig), new UIPropertyMetadata(0x3e8, new PropertyChangedCallback(TrainingStopConfig.xcdacc825628e5892)));
        public static readonly DependencyProperty TeachErrorProperty = DependencyProperty.Register("TeachError", typeof(double), typeof(TrainingStopConfig), new UIPropertyMetadata(0.01, new PropertyChangedCallback(TrainingStopConfig.x0371345679dff46d)));
        public static readonly DependencyProperty TestErrorProperty;
        public static readonly DependencyProperty UseIterationsProperty = DependencyProperty.Register("UseIterations", typeof(bool), typeof(TrainingStopConfig), new UIPropertyMetadata(true, new PropertyChangedCallback(TrainingStopConfig.xc56a43b8cb7ea82b)));
        public static readonly DependencyProperty UseTeachErrorProperty = DependencyProperty.Register("UseTeachError", typeof(bool), typeof(TrainingStopConfig), new UIPropertyMetadata(true, new PropertyChangedCallback(TrainingStopConfig.xe157f583e082a8ce)));
        public static readonly DependencyProperty UseTestErrorProperty;

        static TrainingStopConfig()
        {
            if (1 != 0)
            {
            }
            UseTestErrorProperty = DependencyProperty.Register("UseTestError", typeof(bool), typeof(TrainingStopConfig), new UIPropertyMetadata(false, new PropertyChangedCallback(TrainingStopConfig.x06dd390ee3ad1b4f)));
            TestErrorProperty = DependencyProperty.Register("TestError", typeof(double), typeof(TrainingStopConfig), new UIPropertyMetadata(0.01, new PropertyChangedCallback(TrainingStopConfig.xbe1cc5c5c6a5928c)));
        }

        public TrainingStopConfig()
        {
            this.InitializeComponent();
            App.Services.RegisterService<x35a0e88a31c66173>(this);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_0014;
                }
                goto Label_0031;
            }
            if (0 == 0)
            {
                goto Label_0031;
            }
        Label_0011:
            if (!flag)
            {
                return;
            }
        Label_0014:
            this._x7dc3d9d322900926 = true;
            Uri resourceLocator = new Uri("/Nsim4;component/components/train/stoptrain/trainingstopconfig.xaml", UriKind.Relative);
            Application.LoadComponent(this, resourceLocator);
            return;
        Label_0031:
            if ((((uint) flag) | 15) != 0)
            {
                goto Label_0011;
            }
        }

        private static void x0371345679dff46d(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private static void x06dd390ee3ad1b4f(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        private static void xbe1cc5c5c6a5928c(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private static void xc56a43b8cb7ea82b(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private static void xcdacc825628e5892(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private static void xe157f583e082a8ce(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        public int Iterations
        {
            get
            {
                return (int) base.GetValue(IterationsProperty);
            }
            set
            {
                base.SetValue(IterationsProperty, value);
            }
        }

        public double TeachError
        {
            get
            {
                return (double) base.GetValue(TeachErrorProperty);
            }
            set
            {
                base.SetValue(TeachErrorProperty, value);
            }
        }

        public double TestError
        {
            get
            {
                return (double) base.GetValue(TestErrorProperty);
            }
            set
            {
                base.SetValue(TestErrorProperty, value);
            }
        }

        public bool UseIterations
        {
            get
            {
                return (bool) base.GetValue(UseIterationsProperty);
            }
            set
            {
                base.SetValue(UseIterationsProperty, value);
            }
        }

        public bool UseTeachError
        {
            get
            {
                return (bool) base.GetValue(UseTeachErrorProperty);
            }
            set
            {
                base.SetValue(UseTeachErrorProperty, value);
            }
        }

        public bool UseTestError
        {
            get
            {
                return (bool) base.GetValue(UseTestErrorProperty);
            }
            set
            {
                base.SetValue(UseTestErrorProperty, value);
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element2;
                XElement element = new XElement("TrainingStopParams");
                element.Add(new XAttribute("UseIterations", this.UseIterations));
                element.Add(new XAttribute("Iterations", this.Iterations));
                element.Add(new XAttribute("UseTeachError", this.UseTeachError));
                element.Add(new XAttribute("TeachError", this.TeachError));
                element.Add(new XAttribute("UseTestError", this.UseTestError));
                do
                {
                    element.Add(new XAttribute("TestError", this.TestError));
                    element2 = element;
                }
                while (3 == 0);
                return element2;
            }
            set
            {
                XElement element = value;
                this.UseIterations = element.Attribute("UseIterations").AsBool(false);
                if (0 == 0)
                {
                    this.Iterations = element.Attribute("Iterations").AsInt(0);
                    this.UseTeachError = element.Attribute("UseTeachError").AsBool(false);
                    this.TeachError = element.Attribute("TeachError").AsDouble(0.0);
                    if (0xff != 0)
                    {
                    }
                    this.UseTestError = element.Attribute("UseTestError").AsBool(false);
                    this.TestError = element.Attribute("TestError").AsDouble(0.0);
                }
            }
        }
    }
}

