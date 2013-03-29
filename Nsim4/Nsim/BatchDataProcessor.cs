namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class BatchDataProcessor : List<IDataProcessor>, IConfigurable, IDataProcessor
    {
        [CompilerGenerated]
        private static Func<IMLData, IDataProcessor, IMLData> x09f3b7f7cda63a03;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> x12426999b9efd872;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> x1eaffc8f4d56f3bd;
        [CompilerGenerated]
        private static Func<BasicMLDataSet, IDataProcessor, BasicMLDataSet> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> x21f584f1b098fa5d;
        [CompilerGenerated]
        private static Func<IMLData, IDataProcessor, IMLData> x29a521ff37bb5782;
        [CompilerGenerated]
        private static Func<BasicMLDataSet, IDataProcessor, BasicMLDataSet> x52e0eb7265061ab4;
        [CompilerGenerated]
        private static Func<IMLData, IDataProcessor, IMLData> x6feaca279d51dbd6;
        [CompilerGenerated]
        private static Func<IMLDataPair, IDataProcessor, IMLDataPair> x98afab8c2756fce1;
        [CompilerGenerated]
        private bool xb3e9a1b14f5cda01;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xca5ad8524f73e51f;
        [CompilerGenerated]
        private static Func<IMLDataPair, IDataProcessor, IMLDataPair> xcb0642a72e75e08e;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xcb5110745db8648f;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xcd3a29c3cfb3776e;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xd0f28b05be53fb24;
        [CompilerGenerated]
        private static Func<IMLData, IDataProcessor, IMLData> xdd534a2fc8520149;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xdfe864e3cf5a1f6a;
        [CompilerGenerated]
        private static Func<IDataProcessor, bool> xf245aaded35e9568;

        public void ConfigureProcessor(BasicMLDataSet data)
        {
            if (xf245aaded35e9568 == null)
            {
                xf245aaded35e9568 = new Func<IDataProcessor, bool>(null, (IntPtr) x85ebaf039e73b95c);
            }
            IEnumerator<IDataProcessor> enumerator = Enumerable.Where<IDataProcessor>(this, xf245aaded35e9568).GetEnumerator();
            try
            {
                IDataProcessor processor;
                goto Label_003D;
            Label_002F:
                data = processor.ProcessDataSet(data);
                if (0 != 0)
                {
                    return;
                }
            Label_003D:
                if (enumerator.MoveNext())
                {
                    enumerator.Current.ConfigureProcessor(data);
                    goto Label_002F;
                }
            }
            finally
            {
                bool flag = enumerator == null;
            Label_0061:
                if ((((uint) flag) - ((uint) flag)) >= 0)
                {
                    goto Label_0099;
                }
            Label_0079:
                enumerator.Dispose();
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_009C;
                }
                if (15 == 0)
                {
                    goto Label_0061;
                }
            Label_0099:
                if (!flag)
                {
                    goto Label_0079;
                }
            Label_009C:;
            }
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            if (xcb5110745db8648f == null)
            {
                xcb5110745db8648f = new Func<IDataProcessor, bool>(null, (IntPtr) xb3923b74f2aadcbe);
            }
            if (x1ecac4c96d3f3733 == null)
            {
                x1ecac4c96d3f3733 = new Func<BasicMLDataSet, IDataProcessor, BasicMLDataSet>(null, (IntPtr) x75319ca555c07a02);
            }
            return Enumerable.Aggregate<IDataProcessor, BasicMLDataSet>(Enumerable.Where<IDataProcessor>(this, xcb5110745db8648f), dataToProcess, x1ecac4c96d3f3733);
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            if (xcd3a29c3cfb3776e == null)
            {
                xcd3a29c3cfb3776e = new Func<IDataProcessor, bool>(null, (IntPtr) x44d7969678d9dcc8);
            }
            if (x98afab8c2756fce1 == null)
            {
                x98afab8c2756fce1 = new Func<IMLDataPair, IDataProcessor, IMLDataPair>(null, (IntPtr) x88f49c784667f0c5);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLDataPair>(Enumerable.Where<IDataProcessor>(this, xcd3a29c3cfb3776e), vectorToProcess, x98afab8c2756fce1);
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            if (x1eaffc8f4d56f3bd == null)
            {
                x1eaffc8f4d56f3bd = new Func<IDataProcessor, bool>(null, (IntPtr) xfbfbb5a1c82ca024);
            }
            if (xdd534a2fc8520149 == null)
            {
                xdd534a2fc8520149 = new Func<IMLData, IDataProcessor, IMLData>(null, (IntPtr) xe05b5a5df56e72d5);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLData>(Enumerable.Where<IDataProcessor>(this, x1eaffc8f4d56f3bd), row, xdd534a2fc8520149);
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            if (xdfe864e3cf5a1f6a == null)
            {
                xdfe864e3cf5a1f6a = new Func<IDataProcessor, bool>(null, (IntPtr) xdb1fa77325f3d0cb);
            }
            if (x6feaca279d51dbd6 == null)
            {
                x6feaca279d51dbd6 = new Func<IMLData, IDataProcessor, IMLData>(null, (IntPtr) x0ba3801079d7cc4d);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLData>(Enumerable.Where<IDataProcessor>(this, xdfe864e3cf5a1f6a), row, x6feaca279d51dbd6);
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToRestore)
        {
            if (xca5ad8524f73e51f == null)
            {
                xca5ad8524f73e51f = new Func<IDataProcessor, bool>(null, (IntPtr) x81cb515bd4f798b5);
            }
            if (x52e0eb7265061ab4 == null)
            {
                x52e0eb7265061ab4 = new Func<BasicMLDataSet, IDataProcessor, BasicMLDataSet>(null, (IntPtr) xfa41ba1fa9305bab);
            }
            return Enumerable.Aggregate<IDataProcessor, BasicMLDataSet>(Enumerable.Where<IDataProcessor>(this.x98b5c9f63d27aa65(), xca5ad8524f73e51f), dataToRestore, x52e0eb7265061ab4);
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            if (x21f584f1b098fa5d == null)
            {
                x21f584f1b098fa5d = new Func<IDataProcessor, bool>(null, (IntPtr) xe60c493ca69204fe);
            }
            if (xcb0642a72e75e08e == null)
            {
                xcb0642a72e75e08e = new Func<IMLDataPair, IDataProcessor, IMLDataPair>(null, (IntPtr) x148378b398290a60);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLDataPair>(Enumerable.Where<IDataProcessor>(this.x98b5c9f63d27aa65(), x21f584f1b098fa5d), vectorToProcess, xcb0642a72e75e08e);
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            if (xd0f28b05be53fb24 == null)
            {
                xd0f28b05be53fb24 = new Func<IDataProcessor, bool>(null, (IntPtr) x87342273904b4002);
            }
            if (x29a521ff37bb5782 == null)
            {
                x29a521ff37bb5782 = new Func<IMLData, IDataProcessor, IMLData>(null, (IntPtr) xfc36ab4acdf7a444);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLData>(Enumerable.Where<IDataProcessor>(this.x98b5c9f63d27aa65(), xd0f28b05be53fb24), row, x29a521ff37bb5782);
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            if (x12426999b9efd872 == null)
            {
                x12426999b9efd872 = new Func<IDataProcessor, bool>(null, (IntPtr) xe713670733f33395);
            }
            if (x09f3b7f7cda63a03 == null)
            {
                x09f3b7f7cda63a03 = new Func<IMLData, IDataProcessor, IMLData>(null, (IntPtr) x18ba30f784d22597);
            }
            return Enumerable.Aggregate<IDataProcessor, IMLData>(Enumerable.Where<IDataProcessor>(this.x98b5c9f63d27aa65(), x12426999b9efd872), row, x09f3b7f7cda63a03);
        }

        [CompilerGenerated]
        private static IMLData x0ba3801079d7cc4d(IMLData x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.ProcessInputVector(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static IMLDataPair x148378b398290a60(IMLDataPair x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.RestoreDataVector(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static IMLData x18ba30f784d22597(IMLData x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.RestoreInputVector(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static bool x44d7969678d9dcc8(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static BasicMLDataSet x75319ca555c07a02(BasicMLDataSet x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.ProcessDataSet(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static bool x81cb515bd4f798b5(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static bool x85ebaf039e73b95c(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static bool x87342273904b4002(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static IMLDataPair x88f49c784667f0c5(IMLDataPair x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.ProcessDataVector(x3bd62873fafa6252);
        }

        private IEnumerable<IDataProcessor> x98b5c9f63d27aa65()
        {
            List<IDataProcessor> list = this.ToList<IDataProcessor>();
            list.Reverse();
            return list;
        }

        [CompilerGenerated]
        private static bool xb3923b74f2aadcbe(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static bool xdb1fa77325f3d0cb(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static IMLData xe05b5a5df56e72d5(IMLData x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.ProcessIdealVector(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static bool xe60c493ca69204fe(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static bool xe713670733f33395(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static BasicMLDataSet xfa41ba1fa9305bab(BasicMLDataSet x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.RestoreDataSet(x3bd62873fafa6252);
        }

        [CompilerGenerated]
        private static bool xfbfbb5a1c82ca024(IDataProcessor x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.IsUsed;
        }

        [CompilerGenerated]
        private static IMLData xfc36ab4acdf7a444(IMLData x3bd62873fafa6252, IDataProcessor xb01e0f96838bac90)
        {
            return xb01e0f96838bac90.RestoreIdealVector(x3bd62873fafa6252);
        }

        public bool IsUsed
        {
            [CompilerGenerated]
            get
            {
                return this.xb3e9a1b14f5cda01;
            }
            [CompilerGenerated]
            set
            {
                this.xb3e9a1b14f5cda01 = value;
            }
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("DataProcessor", new XAttribute("Type", "BatchDataProcessor"));
                using (List<IDataProcessor>.Enumerator enumerator = base.GetEnumerator())
                {
                    IDataProcessor processor;
                    bool flag;
                    goto Label_005E;
                Label_002F:
                    processor = enumerator.Current;
                    if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                    {
                        goto Label_002F;
                    }
                    element.Add(processor.Xml);
                Label_005E:
                    if (enumerator.MoveNext())
                    {
                        goto Label_002F;
                    }
                }
                return element;
            }
            set
            {
                base.Clear();
                using (IEnumerator<XElement> enumerator = value.Elements("DataProcessor").GetEnumerator())
                {
                    bool flag;
                    goto Label_006F;
                Label_0021:
                    if (((uint) flag) > uint.MaxValue)
                    {
                        goto Label_0065;
                    }
                    return;
                Label_0035:
                    if (!flag)
                    {
                        goto Label_008E;
                    }
                    XElement current = enumerator.Current;
                    IDataProcessor item = current.Attribute("Type").AsType(null).AsInstance<IDataProcessor>();
                    item.Xml = current;
                Label_0065:
                    base.Add(item);
                Label_006F:
                    flag = enumerator.MoveNext();
                    if ((((uint) flag) + ((uint) flag)) >= 0)
                    {
                        goto Label_0035;
                    }
                Label_008E:
                    if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                    {
                        goto Label_0021;
                    }
                }
            }
        }
    }
}

