namespace Nsim
{
    using Encog.ML.Data.Basic;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Threading;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class TrainStatusControl : UserControl, IConfigurable, xf8efd7615008d32e, System.Windows.Markup.IComponentConnector
    {
        private ICommand _x1ff7a95b0ad2f9ea;
        private int _x2dbd2db61e3c05e9;
        private ICommand _x6b925c6d5a209bac;
        private bool _x7dc3d9d322900926;
        private bool _x83a69dd52dfad789;
        private ICommand _xbbc362261b98bf1e;
        internal TextBlock lblTestError;
        internal TextBlock lblTotalIterations;
        internal TextBlock lblTrainError;
        public static readonly DependencyProperty TrainingInProgressProperty = DependencyProperty.Register("TrainingInProgress", typeof(bool), typeof(TrainStatusControl), new UIPropertyMetadata(false, new PropertyChangedCallback(TrainStatusControl.xbf1041259c8a0903)));
        [CompilerGenerated]
        private BasicMLDataSet xc99b0d468438a6bb;
        [CompilerGenerated]
        private BasicNetwork xd062f442b1aca8db;
        [CompilerGenerated]
        private int xea71d2e5a55c2cd1;

        public TrainStatusControl()
        {
            Action<xa443afcc736e1f3e> action = null;
            this.InitializeComponent();
            App.Services.RegisterService<xf8efd7615008d32e>(this);
            if (action == null)
            {
                action = new Action<xa443afcc736e1f3e>(this.xf29670e286f5562f);
            }
            App.Services.SubscribeEvent<xa443afcc736e1f3e>(action);
        }

        [DebuggerNonUserCode]
        internal Delegate _x11287467a5422d1c(Type x127370c996b87499, string xa1b13fd4a6c07a01)
        {
            return Delegate.CreateDelegate(x127370c996b87499, this, xa1b13fd4a6c07a01);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            do
            {
                if (!flag)
                {
                    return;
                }
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/train/trainstatus/trainstatuscontrol.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if (0 != 0)
                {
                    return;
                }
            }
            while ((((uint) flag) - ((uint) flag)) < 0);
        }

        [CompilerGenerated]
        private bool x0197e1d3a5900091(object x08db3aeabb253cb1)
        {
            return this.TrainingInProgress;
        }

        [CompilerGenerated]
        private void x0391c47a3c19d285(object x08db3aeabb253cb1)
        {
            this.xd7c6aaa737a7575c(false);
        }

        private void x0ccf2e2c362943c5()
        {
            this.CurrentIteration = 0;
            this.x5b0926ce641e48a7 = App.Services.GetService<INetStruct>().GetNewNetwork();
            App.Services.GetService<IRandomStruct>().GetRandom().Randomize(this.x5b0926ce641e48a7);
            App.Services.GetService<x9d88849cdb32703c>().Clear();
        }

        public void x4ab8973167965816()
        {
            // This item is obfuscated and can not be translated.
        }

        private void x5eb7e005797fdf8f()
        {
            this.x0ccf2e2c362943c5();
            this._x2dbd2db61e3c05e9 = 0;
            this.xd7c6aaa737a7575c(true);
            TabControl control = App.Services.GetService<x759d1c29622e3303>().x1dba2c5863398e07("trainTabControl") as TabControl;
            bool flag = control == null;
        Label_000C:
            if (!flag)
            {
                control.SelectedItem = App.Services.GetService<x759d1c29622e3303>().x1dba2c5863398e07("trainGraphTab") ?? control.SelectedItem;
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_000C;
                }
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            switch (xf3efd21c486a5cce)
            {
                case 1:
                    this.lblTrainError = (TextBlock) x11d58b056c032b03;
                    break;

                case 2:
                    this.lblTestError = (TextBlock) x11d58b056c032b03;
                    break;

                case 3:
                    do
                    {
                        this.lblTotalIterations = (TextBlock) x11d58b056c032b03;
                    }
                    while (-1 == 0);
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    break;
            }
        }

        [CompilerGenerated]
        private void x8f954f5e55f310ea(object x08db3aeabb253cb1)
        {
            this.x9a7897b1673db77a();
        }

        [CompilerGenerated]
        private void x91414433db138a3a(object x08db3aeabb253cb1)
        {
            this.x5eb7e005797fdf8f();
        }

        [CompilerGenerated]
        private bool x98e3bd5fb043b728(object x08db3aeabb253cb1)
        {
            return !this.TrainingInProgress;
        }

        private void x9a7897b1673db77a()
        {
            this._x83a69dd52dfad789 = false;
        }

        [CompilerGenerated]
        private bool x9f2d939f14317fae(object x08db3aeabb253cb1)
        {
            return (!this.TrainingInProgress && (this.x5b0926ce641e48a7 != null));
        }

        private void xabe7a52326814935(double x04104e5c0f50211b, double? x567c342c37e1907c, int x2dbd2db61e3c05e9)
        {
            bool flag;
            this.lblTrainError.Text = x04104e5c0f50211b.ToString("0.00000");
            if ((((uint) x04104e5c0f50211b) + ((uint) flag)) >= 0)
            {
                goto Label_007F;
            }
        Label_0030:
            if (!flag)
            {
                double num;
                if ((((uint) num) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_007F;
                }
                this.lblTestError.Text = x567c342c37e1907c.Value.ToString("0.00000");
            }
            this.lblTotalIterations.Text = x2dbd2db61e3c05e9.ToString();
            return;
        Label_007F:
            this.lblTestError.Text = "-";
            flag = !x567c342c37e1907c.HasValue;
            goto Label_0030;
        }

        private static void xbf1041259c8a0903(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private void xd7c6aaa737a7575c(bool x81b598cd14e426a9)
        {
            x35a0e88a31c66173 service;
            <>c__DisplayClassd classd;
            bool flag;
            bool hasTestData;
            IMLTrain trainer;
            double tchErrStp;
            bool useTestError;
            double tstErrStp;
            goto Label_01C8;
        Label_000C:
            this.CurrentIteration = 0;
            x9d88849cdb32703c errorGraph = App.Services.GetService<x9d88849cdb32703c>();
            List<Point> trainErrBuf = new List<Point>(200);
            List<Point> testErrBuf = new List<Point>(200);
            Task task = Task.get_Factory().StartNew(new Action(classd, (IntPtr) this.<DoResumeTraining>b__6));
            if (0 == 0)
            {
                return;
            }
        Label_0072:
            useTestError = service.UseTestError && hasTestData;
        Label_008B:
            tstErrStp = service.TestError;
            goto Label_000C;
        Label_00E5:
            this._x83a69dd52dfad789 = true;
            service = App.Services.GetService<x35a0e88a31c66173>();
            bool useIterations = service.UseIterations;
            if (0 != 0)
            {
                goto Label_000C;
            }
            int iterationsStp = service.Iterations;
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_008B;
            }
            bool useTeachError = service.UseTeachError;
            if (8 != 0)
            {
                tchErrStp = service.TeachError;
            }
            goto Label_0072;
        Label_01C8:
            this.TrainingInProgress = true;
            base.Dispatcher.Invoke(new Action(null, (IntPtr) CommandManager.InvalidateRequerySuggested), DispatcherPriority.Send, null);
            IDataProcessor processor = App.Services.GetService<IDataProcessor>();
            BasicMLDataSet data = App.Services.GetService<ITrainData>().xd378208b5267f7e2();
            processor.ConfigureProcessor(data);
            this.xddda66ad7e26f074 = processor.ProcessDataSet(data);
            BasicMLDataSet testData = App.Services.GetService<ITestData>().xd378208b5267f7e2();
            if (15 == 0)
            {
                goto Label_00E5;
            }
            hasTestData = testData.Count > 0L;
            if (0 == 0)
            {
                trainer = App.Services.GetService<ITrainerStruct>().GetTrainer(x81b598cd14e426a9);
                if (hasTestData)
                {
                    testData = processor.ProcessDataSet(testData);
                }
                goto Label_00E5;
            }
            goto Label_01C8;
        }

        [CompilerGenerated]
        private void xf29670e286f5562f(xa443afcc736e1f3e x08db3aeabb253cb1)
        {
            this.x0ccf2e2c362943c5();
        }

        public int CurrentIteration
        {
            [CompilerGenerated]
            get
            {
                return this.xea71d2e5a55c2cd1;
            }
            [CompilerGenerated]
            private set
            {
                this.xea71d2e5a55c2cd1 = value;
            }
        }

        public IDataProcessor DataProcessor
        {
            get
            {
                return App.Services.GetService<IDataProcessor>();
            }
        }

        public ICommand PauseTraining
        {
            get
            {
                return (this._x1ff7a95b0ad2f9ea ?? (this._x1ff7a95b0ad2f9ea = new RelayCommand(new Action<object>(this.x8f954f5e55f310ea), new Predicate<object>(this.x0197e1d3a5900091))));
            }
        }

        public ICommand ResumeTraining
        {
            get
            {
                return (this._x6b925c6d5a209bac ?? (this._x6b925c6d5a209bac = new RelayCommand(new Action<object>(this.x0391c47a3c19d285), new Predicate<object>(this.x9f2d939f14317fae))));
            }
        }

        public ICommand StarNewTraining
        {
            get
            {
                return (this._xbbc362261b98bf1e ?? (this._xbbc362261b98bf1e = new RelayCommand(new Action<object>(this.x91414433db138a3a), new Predicate<object>(this.x98e3bd5fb043b728))));
            }
        }

        public bool TrainingInProgress
        {
            get
            {
                return (bool) base.GetValue(TrainingInProgressProperty);
            }
            set
            {
                base.SetValue(TrainingInProgressProperty, value);
            }
        }

        public BasicNetwork x5b0926ce641e48a7
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

        public BasicMLDataSet xddda66ad7e26f074
        {
            [CompilerGenerated]
            get
            {
                return this.xc99b0d468438a6bb;
            }
            [CompilerGenerated]
            set
            {
                this.xc99b0d468438a6bb = value;
            }
        }

        public XElement Xml
        {
            get
            {
                double[] numArray;
                XElement element2;
                bool flag;
                XElement element = new XElement("TrainStatus");
                if (((uint) flag) <= uint.MaxValue)
                {
                    flag = this.x5b0926ce641e48a7 == null;
                    goto Label_010D;
                }
                if (((uint) flag) >= 0)
                {
                    goto Label_010D;
                }
                goto Label_009E;
            Label_003D:
                element.Add(new XAttribute("TotalIterations", this._x2dbd2db61e3c05e9));
                return element;
            Label_007F:
                if (flag)
                {
                    goto Label_003D;
                }
            Label_009E:
                numArray = new double[this.x5b0926ce641e48a7.EncodedArrayLength()];
                this.x5b0926ce641e48a7.EncodeToArray(numArray);
                element.Add(numArray.ToXElement().AddContent("Weigths".ToNameAttribute()));
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_007F;
                }
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    if (((((uint) flag) + ((uint) flag)) >= 0) && ((((uint) flag) - ((uint) flag)) <= uint.MaxValue))
                    {
                        goto Label_003D;
                    }
                    goto Label_007F;
                }
                return element2;
            Label_010D:
                if (-2147483648 == 0)
                {
                    goto Label_009E;
                }
                goto Label_007F;
            }
            set
            {
                bool flag = value.Elements().ByName("Weigths") == null;
                if (0 == 0)
                {
                    if (flag)
                    {
                        return;
                    }
                }
                else if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    return;
                }
                this.x5b0926ce641e48a7 = App.Services.GetService<INetStruct>().GetNewNetwork();
                double[] encoded = value.Elements().ByName("Weigths").AsArray();
                this._x2dbd2db61e3c05e9 = value.IntAttribute("TotalIterations", 0);
                this.x5b0926ce641e48a7.DecodeFromArray(encoded);
                if (0 != 0)
                {
                }
            }
        }
    }
}

