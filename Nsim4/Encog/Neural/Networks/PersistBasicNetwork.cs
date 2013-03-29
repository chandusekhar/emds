namespace Encog.Neural.Networks
{
    using Encog.Engine.Network.Activation;
    using Encog.Neural.Flat;
    using Encog.Persist;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class PersistBasicNetwork : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            FlatNetwork network2;
            EncogReadHelper helper;
            EncogFileSection section;
            IDictionary<string, string> dictionary2;
            int num;
            int num2;
            BasicNetwork network = new BasicNetwork();
            goto Label_03B8;
        Label_000B:
            if ((section = helper.ReadNextSection()) != null)
            {
                goto Label_036A;
            }
            network.Structure.Flat = network2;
            if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
            {
                if (8 != 0)
                {
                    return network;
                }
                goto Label_03B8;
            }
        Label_003F:
            num = 0;
            network2.ActivationFunctions = new IActivationFunction[network2.LayerCounts.Length];
            using (IEnumerator<string> enumerator = section.Lines.GetEnumerator())
            {
                string str;
                IActivationFunction function;
                IList<string> list;
            Label_0064:
                if (enumerator.MoveNext())
                {
                    goto Label_00E2;
                }
                goto Label_000B;
            Label_0072:
                network2.ActivationFunctions[num++] = function;
                if (0 == 0)
                {
                    goto Label_00D6;
                }
            Label_0087:
                num2 = 0;
                while (num2 < function.ParamNames.Length)
                {
                    function.Params[num2] = CSVFormat.EgFormat.Parse(list[num2 + 1]);
                    num2++;
                }
                if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_0072;
                }
            Label_00D6:
                if (4 != 0)
                {
                    goto Label_0064;
                }
                goto Label_000B;
            Label_00E2:
                str = enumerator.Current;
                list = EncogFileSection.SplitColumns(str);
                string name = "Encog.Engine.Network.Activation." + list[0];
                try
                {
                    function = (IActivationFunction) ReflectionUtil.LoadObject(name);
                    goto Label_0087;
                }
                catch (TypeLoadException exception)
                {
                    throw new PersistError(exception);
                }
                catch (TargetException exception2)
                {
                    throw new PersistError(exception2);
                }
                catch (MemberAccessException exception3)
                {
                    throw new PersistError(exception3);
                }
            }
            goto Label_000B;
        Label_0182:
            if (!section.SectionName.Equals("BASIC"))
            {
                goto Label_01A9;
            }
        Label_0194:
            if (section.SubSectionName.Equals("NETWORK"))
            {
                dictionary2 = section.ParseParams();
                network2.BeginTraining = EncogFileSection.ParseInt(dictionary2, "beginTraining");
                network2.ConnectionLimit = EncogFileSection.ParseDouble(dictionary2, "connectionLimit");
                goto Label_032A;
            }
        Label_01A9:
            if (section.SectionName.Equals("BASIC") && section.SubSectionName.Equals("ACTIVATION"))
            {
                goto Label_003F;
            }
            goto Label_000B;
        Label_032A:
            network2.ContextTargetOffset = EncogFileSection.ParseIntArray(dictionary2, "contextTargetOffset");
            network2.ContextTargetSize = EncogFileSection.ParseIntArray(dictionary2, "contextTargetSize");
            network2.EndTraining = EncogFileSection.ParseInt(dictionary2, "endTraining");
            network2.HasContext = EncogFileSection.ParseBoolean(dictionary2, "hasContext");
            network2.InputCount = EncogFileSection.ParseInt(dictionary2, "inputCount");
            if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    return network;
                }
                network2.LayerCounts = EncogFileSection.ParseIntArray(dictionary2, "layerCounts");
                do
                {
                    network2.LayerFeedCounts = EncogFileSection.ParseIntArray(dictionary2, "layerFeedCounts");
                    network2.LayerContextCount = EncogFileSection.ParseIntArray(dictionary2, "layerContextCount");
                    network2.LayerIndex = EncogFileSection.ParseIntArray(dictionary2, "layerIndex");
                    network2.LayerOutput = EncogFileSection.ParseDoubleArray(dictionary2, "output");
                }
                while ((((uint) num) + ((uint) num)) < 0);
                network2.LayerSums = new double[network2.LayerOutput.Length];
                network2.OutputCount = EncogFileSection.ParseInt(dictionary2, "outputCount");
                network2.WeightIndex = EncogFileSection.ParseIntArray(dictionary2, "weightIndex");
                do
                {
                    network2.Weights = EncogFileSection.ParseDoubleArray(dictionary2, "weights");
                }
                while (0 != 0);
                network2.BiasActivation = EncogFileSection.ParseDoubleArray(dictionary2, "biasActivation");
                goto Label_000B;
            }
        Label_036A:
            if (section.SectionName.Equals("BASIC"))
            {
                if (section.SubSectionName.Equals("PARAMS"))
                {
                    EngineArray.PutAll<string, string>(section.ParseParams(), network.Properties);
                }
                goto Label_0182;
            }
            if (0 == 0)
            {
                goto Label_0182;
            }
            if ((((uint) num2) + ((uint) num2)) < 0)
            {
                goto Label_032A;
            }
            goto Label_0194;
        Label_03B8:
            network2 = new FlatNetwork();
            helper = new EncogReadHelper(mask0);
            goto Label_000B;
        }

        public void Save(Stream os, object obj)
        {
            BasicNetwork network;
            FlatNetwork flat;
            IActivationFunction function;
            int num;
            IActivationFunction[] activationFunctions;
            int num2;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                goto Label_0290;
            }
            goto Label_0059;
        Label_0024:
            if (num < function.Params.Length)
            {
                helper.AddColumn(function.Params[num]);
                goto Label_0080;
            }
            if (-1 == 0)
            {
                goto Label_00CC;
            }
            helper.WriteLine();
        Label_0040:
            num2++;
        Label_0046:
            if (num2 < activationFunctions.Length)
            {
                goto Label_00F8;
            }
            helper.Flush();
            goto Label_0071;
        Label_0059:
            num++;
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0024;
            }
        Label_0071:
            if (1 != 0)
            {
                return;
            }
            goto Label_0290;
        Label_0080:
            if ((((uint) num2) + ((uint) num)) < 0)
            {
                goto Label_0135;
            }
            goto Label_0059;
        Label_00CC:
            helper.WriteProperty("biasActivation", flat.BiasActivation);
            helper.AddSubSection("ACTIVATION");
            activationFunctions = flat.ActivationFunctions;
            num2 = 0;
            goto Label_0046;
        Label_00F8:
            function = activationFunctions[num2];
            if (((uint) num2) >= 0)
            {
                helper.AddColumn(function.GetType().Name);
            }
            if (0x7fffffff != 0)
            {
                num = 0;
                goto Label_0024;
            }
            goto Label_0080;
        Label_0135:
            helper.WriteProperty("outputCount", flat.OutputCount);
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00F8;
            }
            helper.WriteProperty("weightIndex", flat.WeightIndex);
            helper.WriteProperty("weights", flat.Weights);
            goto Label_00CC;
        Label_0290:
            network = (BasicNetwork) obj;
            flat = network.Structure.Flat;
            helper.AddSection("BASIC");
            helper.AddSubSection("PARAMS");
            helper.AddProperties(network.Properties);
            if (((uint) num2) < 0)
            {
                goto Label_0040;
            }
            helper.AddSubSection("NETWORK");
            helper.WriteProperty("beginTraining", flat.BeginTraining);
            helper.WriteProperty("connectionLimit", flat.ConnectionLimit);
            helper.WriteProperty("contextTargetOffset", flat.ContextTargetOffset);
            helper.WriteProperty("contextTargetSize", flat.ContextTargetSize);
            helper.WriteProperty("endTraining", flat.EndTraining);
            helper.WriteProperty("hasContext", flat.HasContext);
            helper.WriteProperty("inputCount", flat.InputCount);
            helper.WriteProperty("layerCounts", flat.LayerCounts);
            helper.WriteProperty("layerFeedCounts", flat.LayerFeedCounts);
            helper.WriteProperty("layerContextCount", flat.LayerContextCount);
            helper.WriteProperty("layerIndex", flat.LayerIndex);
            if (0 != 0)
            {
                goto Label_00CC;
            }
            helper.WriteProperty("output", flat.LayerOutput);
            goto Label_0135;
        }

        public virtual int FileVersion
        {
            get
            {
                return 1;
            }
        }

        public Type NativeType
        {
            get
            {
                return typeof(BasicNetwork);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "BasicNetwork";
            }
        }
    }
}

