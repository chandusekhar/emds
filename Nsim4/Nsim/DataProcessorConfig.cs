namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using mscorlib;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class DataProcessorConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, IDataProcessor
    {
        private readonly IDataProcessor _x77b7953c6a3402bf = new NullProcessor();
        private bool _x7dc3d9d322900926;
        private readonly BatchDataProcessor _x91bd2127cb8b0fed;
        internal SimpleFunctionalPreprocessorConfig func;
        internal LinearScaleConfig scaler;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xcb5110745db8648f;

        public DataProcessorConfig()
        {
            do
            {
                this.InitializeComponent();
            }
            while (0 != 0);
            this._x91bd2127cb8b0fed = new BatchDataProcessor();
            this._x91bd2127cb8b0fed.Add(this.func);
            this._x91bd2127cb8b0fed.Add(this.scaler);
            App.Services.RegisterService<IDataProcessor>(this);
        }

        public void ConfigureProcessor(BasicMLDataSet data)
        {
            this.xd3764d4f1e921081.ConfigureProcessor(data);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            Uri uri;
            bool flag = !this._x7dc3d9d322900926;
            if (((uint) flag) >= 0)
            {
                if (!flag)
                {
                    return;
                }
                this._x7dc3d9d322900926 = true;
                uri = new Uri("/Nsim4;component/components/train/dataprocessors/dataprocessorconfig.xaml", UriKind.Relative);
            }
            if (0 == 0)
            {
                Application.LoadComponent(this, uri);
            }
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            return this.xd3764d4f1e921081.ProcessDataSet(dataToProcess);
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            return this.xd3764d4f1e921081.ProcessDataVector(vectorToProcess);
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            return this.xd3764d4f1e921081.ProcessIdealVector(row);
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            return this.xd3764d4f1e921081.ProcessInputVector(row);
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToRestore)
        {
            return this.xd3764d4f1e921081.RestoreDataSet(dataToRestore);
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            return this.xd3764d4f1e921081.RestoreDataVector(vectorToProcess);
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            return this.xd3764d4f1e921081.RestoreIdealVector(row);
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            return this.xd3764d4f1e921081.RestoreInputVector(row);
        }

        [CompilerGenerated]
        private static bool x1e076d75160be815(IDataProcessor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.GetType().Name == typeof(SimpleFunctionalPreprocessorLogic).Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            if (0 == 0)
            {
                goto Label_0025;
            }
        Label_0006:
            if (0 == 0)
            {
                if (0 == 0)
                {
                    return;
                }
                goto Label_0025;
            }
        Label_001C:
            this._x7dc3d9d322900926 = true;
            if (0 == 0)
            {
                goto Label_0006;
            }
            return;
        Label_0025:
            switch (num)
            {
                case 1:
                    this.func = (SimpleFunctionalPreprocessorConfig) x11d58b056c032b03;
                    break;

                case 2:
                    this.scaler = (LinearScaleConfig) x11d58b056c032b03;
                    break;

                default:
                    goto Label_001C;
            }
        }

        [CompilerGenerated]
        private static bool xdeb098800b3ee141(IDataProcessor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.GetType().Name == typeof(LinearScale).Name);
        }

        public bool IsUsed
        {
            get
            {
                return true;
            }
        }

        private IDataProcessor xd3764d4f1e921081
        {
            get
            {
                IDataProcessor processor;
                System.Boolean ReflectorVariable0;
                if (this._x91bd2127cb8b0fed == null)
                {
                    ReflectorVariable0 = false;
                    goto Label_0032;
                }
                if (0 == 0)
                {
                    ReflectorVariable0 = true;
                    goto Label_0032;
                }
            Label_000C:
                return this._x77b7953c6a3402bf;
            Label_0032:
                if (ReflectorVariable0 ? (this._x91bd2127cb8b0fed.Count >= 1) : false)
                {
                    return this._x91bd2127cb8b0fed;
                }
                if (3 != 0)
                {
                    goto Label_000C;
                }
                return processor;
            }
        }

        public XElement Xml
        {
            get
            {
                return this._x91bd2127cb8b0fed.Xml;
            }
            set
            {
                BatchDataProcessor processor = new BatchDataProcessor {
                    Xml = value
                };
                if (xcb5110745db8648f == null)
                {
                    xcb5110745db8648f = new Func<IDataProcessor, bool>(null, (IntPtr) x1e076d75160be815);
                }
                this.func.Xml = Enumerable.First<IDataProcessor>(processor, xcb5110745db8648f).Xml;
                if (x1ecac4c96d3f3733 == null)
                {
                    x1ecac4c96d3f3733 = new Func<IDataProcessor, bool>(null, (IntPtr) xdeb098800b3ee141);
                }
                this.scaler.Xml = Enumerable.First<IDataProcessor>(processor, x1ecac4c96d3f3733).Xml;
            }
        }
    }
}

