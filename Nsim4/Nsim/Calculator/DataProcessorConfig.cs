namespace Nsim.Calculator
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using mscorlib;
    using Nsim;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class DataProcessorConfig : IConfigurable, IDataProcessor
    {
        private readonly LinearScale _x0e8d64ad39a2867f = new LinearScale();
        private readonly IDataProcessor _x77b7953c6a3402bf = new NullProcessor();
        private readonly SimpleFunctionalPreprocessorLogic _x829059c1f308dc0c = new SimpleFunctionalPreprocessorLogic();
        private readonly BatchDataProcessor _x91bd2127cb8b0fed;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> x3ea1037ccf291a94;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xec790bb6d0304faa;

        public DataProcessorConfig()
        {
            this._x91bd2127cb8b0fed = new BatchDataProcessor { this._x829059c1f308dc0c, this._x0e8d64ad39a2867f };
        }

        public void ConfigureProcessor(BasicMLDataSet data)
        {
            this.xd3764d4f1e921081.ConfigureProcessor(data);
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
        private static bool x716bafe7619d8264(IDataProcessor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.GetType().Name == typeof(LinearScale).Name);
        }

        [CompilerGenerated]
        private static bool xad1d75c4f41a1f7d(IDataProcessor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.GetType().Name == typeof(SimpleFunctionalPreprocessorLogic).Name);
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
                System.Boolean ReflectorVariable0;
                if (this._x91bd2127cb8b0fed == null)
                {
                    ReflectorVariable0 = false;
                }
                else
                {
                    ReflectorVariable0 = true;
                }
                bool flag = ReflectorVariable0 ? (this._x91bd2127cb8b0fed.Count >= 1) : false;
                if (flag)
                {
                    IDataProcessor processor = this._x91bd2127cb8b0fed;
                    if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                    {
                        return processor;
                    }
                }
                return this._x77b7953c6a3402bf;
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
                if (x3ea1037ccf291a94 == null)
                {
                    x3ea1037ccf291a94 = new Func<IDataProcessor, bool>(null, (IntPtr) xad1d75c4f41a1f7d);
                }
                this._x829059c1f308dc0c.Xml = Enumerable.First<IDataProcessor>(processor, x3ea1037ccf291a94).Xml;
                if (xec790bb6d0304faa == null)
                {
                    xec790bb6d0304faa = new Func<IDataProcessor, bool>(null, (IntPtr) x716bafe7619d8264);
                }
                this._x0e8d64ad39a2867f.Xml = Enumerable.First<IDataProcessor>(processor, xec790bb6d0304faa).Xml;
            }
        }
    }
}

