namespace Encog.Neural.Rbf
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.RBF;
    using Encog.Neural.Flat;
    using Encog.Neural.RBF;
    using Encog.Persist;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class PersistRBFNetwork : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogFileSection section;
            IDictionary<string, string> dictionary;
            IDictionary<string, string> dictionary2;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            RBFNetwork network = new RBFNetwork();
            FlatNetworkRBF flat = (FlatNetworkRBF) network.Flat;
            EncogReadHelper helper = new EncogReadHelper(mask0);
        Label_003B:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (!section.SectionName.Equals("RBF-NETWORK"))
                {
                    goto Label_0473;
                }
                goto Label_069F;
            }
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_0236;
            }
            goto Label_0070;
        Label_005E:
            if (!section.SectionName.Equals("RBF-NETWORK"))
            {
                goto Label_003B;
            }
        Label_0070:
            if (section.SubSectionName.Equals("RBF"))
            {
                num3 = 0;
                num4 = flat.LayerCounts[1];
                do
                {
                    if (0 != 0)
                    {
                        if ((((uint) num6) - ((uint) num2)) < 0)
                        {
                            goto Label_0473;
                        }
                        goto Label_0416;
                    }
                }
                while ((((uint) num3) - ((uint) num3)) > uint.MaxValue);
                num5 = flat.LayerCounts[2];
                if ((((uint) num4) | 0xfffffffe) == 0)
                {
                    goto Label_0473;
                }
                goto Label_0273;
            }
            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_02F4;
            }
            if ((((uint) num2) - ((uint) num5)) >= 0)
            {
                if (((((uint) num4) - ((uint) num3)) > uint.MaxValue) && ((((uint) num5) - ((uint) num5)) < 0))
                {
                    goto Label_005E;
                }
                goto Label_003B;
            }
        Label_0236:
            if ((((uint) num3) + ((uint) num4)) >= 0)
            {
                return network;
            }
            if (4 != 0)
            {
                goto Label_02F4;
            }
            if ((((uint) num) + ((uint) num5)) >= 0)
            {
                goto Label_005E;
            }
        Label_0273:
            flat.RBF = new IRadialBasisFunction[num4];
            if (((uint) num2) >= 0)
            {
                if ((((uint) num5) | 0xfffffffe) == 0)
                {
                    return network;
                }
                using (IEnumerator<string> enumerator2 = section.Lines.GetEnumerator())
                {
                    string str3;
                    IRadialBasisFunction function2;
                    IList<string> list2;
                    goto Label_00EC;
                Label_00D6:
                    if (num6 < num5)
                    {
                        goto Label_00FF;
                    }
                Label_00DC:
                    flat.RBF[num3++] = function2;
                Label_00EC:
                    if (enumerator2.MoveNext())
                    {
                        goto Label_01F2;
                    }
                    goto Label_003B;
                Label_00FA:
                    num6 = 0;
                    goto Label_00D6;
                Label_00FF:
                    function2.Centers[num6] = CSVFormat.EgFormat.Parse(list2[num6 + 3]);
                Label_011E:
                    num6++;
                    if (0 == 0)
                    {
                        goto Label_00D6;
                    }
                    goto Label_003B;
                Label_012C:
                    function2.Centers = new double[num5];
                    goto Label_00FA;
                Label_013F:
                    if (0 != 0)
                    {
                        goto Label_011E;
                    }
                    list2 = EncogFileSection.SplitColumns(str3);
                    string name = "Encog.MathUtil.RBF." + list2[0];
                    try
                    {
                        function2 = (IRadialBasisFunction) ReflectionUtil.LoadObject(name);
                    }
                    catch (TypeLoadException exception2)
                    {
                        throw new PersistError(exception2);
                    }
                    catch (TargetException exception3)
                    {
                        throw new PersistError(exception3);
                    }
                    catch (MemberAccessException exception4)
                    {
                        throw new PersistError(exception4);
                    }
                    function2.Width = CSVFormat.EgFormat.Parse(list2[1]);
                    function2.Peak = CSVFormat.EgFormat.Parse(list2[2]);
                    if ((((uint) num6) + ((uint) num)) >= 0)
                    {
                        goto Label_0200;
                    }
                    if ((((uint) num4) - ((uint) num3)) < 0)
                    {
                        goto Label_00DC;
                    }
                Label_01F2:
                    str3 = enumerator2.Current;
                    goto Label_013F;
                Label_0200:
                    if ((((uint) num4) | 3) != 0)
                    {
                        goto Label_012C;
                    }
                    goto Label_00FA;
                }
            }
        Label_02F4:
            using (IEnumerator<string> enumerator = section.Lines.GetEnumerator())
            {
                string str;
                IActivationFunction function;
                IList<string> list;
                goto Label_0313;
            Label_0303:
                flat.ActivationFunctions[num++] = function;
            Label_0313:
                if (enumerator.MoveNext())
                {
                    goto Label_03A2;
                }
                if (0xff != 0)
                {
                    goto Label_003B;
                }
            Label_032B:
                if (num2 < function.ParamNames.Length)
                {
                    goto Label_0376;
                }
                goto Label_03AD;
            Label_033A:
                list = EncogFileSection.SplitColumns(str);
                string str2 = "Encog.Engine.Network.Activation." + list[0];
                try
                {
                    function = (IActivationFunction) ReflectionUtil.LoadObject(str2);
                }
                catch (Exception exception)
                {
                    throw new PersistError(exception);
                }
                num2 = 0;
                goto Label_032B;
            Label_0376:
                function.Params[num2] = CSVFormat.EgFormat.Parse(list[num2 + 1]);
                num2++;
                goto Label_032B;
            Label_03A2:
                str = enumerator.Current;
                goto Label_033A;
            Label_03AD:
                if ((((uint) num2) | uint.MaxValue) != 0)
                {
                    goto Label_0303;
                }
                goto Label_003B;
            }
            goto Label_005E;
        Label_0416:
            if (!section.SectionName.Equals("RBF-NETWORK") || !section.SubSectionName.Equals("ACTIVATION"))
            {
                goto Label_005E;
            }
            if ((((uint) num2) | 4) == 0)
            {
                goto Label_069F;
            }
            num = 0;
        Label_045E:
            flat.ActivationFunctions = new IActivationFunction[flat.LayerCounts.Length];
            goto Label_02F4;
        Label_0473:
            if (section.SectionName.Equals("RBF-NETWORK"))
            {
                goto Label_05FF;
            }
            goto Label_0416;
        Label_05EB:
            flat.InputCount = EncogFileSection.ParseInt(dictionary2, "inputCount");
            flat.LayerCounts = EncogFileSection.ParseIntArray(dictionary2, "layerCounts");
            if ((((uint) num) + ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_06F4;
            }
            goto Label_06B4;
        Label_05FF:
            if (!section.SubSectionName.Equals("NETWORK"))
            {
                goto Label_0416;
            }
            dictionary2 = section.ParseParams();
            flat.BeginTraining = EncogFileSection.ParseInt(dictionary2, "beginTraining");
            flat.ConnectionLimit = EncogFileSection.ParseDouble(dictionary2, "connectionLimit");
            flat.ContextTargetOffset = EncogFileSection.ParseIntArray(dictionary2, "contextTargetOffset");
            flat.ContextTargetSize = EncogFileSection.ParseIntArray(dictionary2, "contextTargetSize");
            flat.EndTraining = EncogFileSection.ParseInt(dictionary2, "endTraining");
            flat.HasContext = EncogFileSection.ParseBoolean(dictionary2, "hasContext");
            goto Label_05EB;
        Label_069F:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                dictionary = section.ParseParams();
            }
            else if (0 == 0)
            {
                goto Label_06D9;
            }
        Label_06B4:
            EngineArray.PutAll<string, string>(dictionary, network.Properties);
            if ((((uint) num5) - ((uint) num5)) >= 0)
            {
                goto Label_0473;
            }
        Label_06D9:
            if ((((uint) num) - ((uint) num3)) >= 0)
            {
                if (0 == 0)
                {
                    goto Label_0473;
                }
                goto Label_05FF;
            }
        Label_06F4:
            if (-2147483648 != 0)
            {
                flat.LayerFeedCounts = EncogFileSection.ParseIntArray(dictionary2, "layerFeedCounts");
                if (((uint) num3) < 0)
                {
                    goto Label_05EB;
                }
                flat.LayerContextCount = EncogFileSection.ParseIntArray(dictionary2, "layerContextCount");
                flat.LayerIndex = EncogFileSection.ParseIntArray(dictionary2, "layerIndex");
                if (0 == 0)
                {
                    flat.LayerOutput = EncogFileSection.ParseDoubleArray(dictionary2, "output");
                    flat.LayerSums = new double[flat.LayerOutput.Length];
                    flat.OutputCount = EncogFileSection.ParseInt(dictionary2, "outputCount");
                }
                flat.WeightIndex = EncogFileSection.ParseIntArray(dictionary2, "weightIndex");
                if ((((uint) num3) > uint.MaxValue) || ((((uint) num2) - ((uint) num2)) < 0))
                {
                    goto Label_045E;
                }
                flat.Weights = EncogFileSection.ParseDoubleArray(dictionary2, "weights");
                flat.BiasActivation = EncogFileSection.ParseDoubleArray(dictionary2, "biasActivation");
                goto Label_003B;
            }
            return network;
        }

        public void Save(Stream os, object obj)
        {
            IActivationFunction function;
            double num;
            IRadialBasisFunction function2;
            IActivationFunction[] activationFunctions;
            int num3;
            double[] @params;
            int num4;
            IRadialBasisFunction[] functionArray2;
            int num5;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            RBFNetwork network = (RBFNetwork) obj;
            FlatNetworkRBF flat = (FlatNetworkRBF) network.Flat;
            helper.AddSection("RBF-NETWORK");
            helper.AddSubSection("PARAMS");
            goto Label_03F8;
        Label_0033:
            if (num5 < functionArray2.Length)
            {
                function2 = functionArray2[num5];
                if (0 == 0)
                {
                    helper.AddColumn(function2.GetType().Name);
                    helper.AddColumn(function2.Width);
                    goto Label_006E;
                }
                if ((((uint) num3) | 0x7fffffff) != 0)
                {
                    goto Label_02E5;
                }
                goto Label_020D;
            }
            helper.Flush();
            return;
        Label_006E:
            helper.AddColumn(function2.Peak);
            double[] centers = function2.Centers;
            int index = 0;
            while (index < centers.Length)
            {
                double d = centers[index];
                helper.AddColumn(d);
                index++;
            }
            if ((((uint) index) - ((uint) num5)) <= uint.MaxValue)
            {
                helper.WriteLine();
                if ((((uint) num5) - ((uint) index)) < 0)
                {
                    goto Label_02A1;
                }
                num5++;
                goto Label_0033;
            }
            return;
        Label_00C6:
            functionArray2 = flat.RBF;
            num5 = 0;
            if ((((uint) num) - ((uint) num)) < 0)
            {
                goto Label_0125;
            }
            goto Label_0033;
        Label_00FA:
            if (num3 < activationFunctions.Length)
            {
                function = activationFunctions[num3];
                goto Label_0161;
            }
            helper.AddSubSection("RBF");
            if ((((uint) num5) | 15) != 0)
            {
                goto Label_01B0;
            }
            goto Label_011D;
        Label_0117:
            num4++;
        Label_011D:
            if (num4 < @params.Length)
            {
                num = @params[num4];
                helper.AddColumn(num);
                goto Label_0117;
            }
        Label_0125:
            helper.WriteLine();
            num3++;
            goto Label_00FA;
        Label_0161:
            helper.AddColumn(function.GetType().Name);
            @params = function.Params;
        Label_017A:
            num4 = 0;
            if ((((uint) num5) + ((uint) index)) > uint.MaxValue)
            {
                goto Label_03BC;
            }
            if ((((uint) num4) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_011D;
            }
        Label_01B0:
            if (((uint) num3) >= 0)
            {
                goto Label_00C6;
            }
        Label_01C2:
            if (0xff == 0)
            {
                goto Label_017A;
            }
            num3 = 0;
            if ((((uint) index) | 1) != 0)
            {
                goto Label_00FA;
            }
            goto Label_00C6;
        Label_020D:
            helper.WriteProperty("biasActivation", flat.BiasActivation);
            helper.AddSubSection("ACTIVATION");
            activationFunctions = flat.ActivationFunctions;
            goto Label_01C2;
        Label_02A1:
            helper.WriteProperty("layerContextCount", flat.LayerContextCount);
            helper.WriteProperty("layerIndex", flat.LayerIndex);
            if ((((uint) index) + ((uint) num)) < 0)
            {
                goto Label_0117;
            }
            helper.WriteProperty("output", flat.LayerOutput);
            helper.WriteProperty("outputCount", flat.OutputCount);
            helper.WriteProperty("weightIndex", flat.WeightIndex);
            if ((((uint) num) - ((uint) num5)) < 0)
            {
                goto Label_03F8;
            }
            helper.WriteProperty("weights", flat.Weights);
            goto Label_020D;
        Label_02E5:
            helper.WriteProperty("inputCount", flat.InputCount);
            helper.WriteProperty("layerCounts", flat.LayerCounts);
            if ((((uint) num4) - ((uint) index)) < 0)
            {
                goto Label_0161;
            }
            helper.WriteProperty("layerFeedCounts", flat.LayerFeedCounts);
            if (0x7fffffff != 0)
            {
                goto Label_02A1;
            }
        Label_0378:
            helper.WriteProperty("beginTraining", flat.BeginTraining);
            helper.WriteProperty("connectionLimit", flat.ConnectionLimit);
            helper.WriteProperty("contextTargetOffset", flat.ContextTargetOffset);
            helper.WriteProperty("contextTargetSize", flat.ContextTargetSize);
        Label_03BC:
            helper.WriteProperty("endTraining", flat.EndTraining);
            helper.WriteProperty("hasContext", flat.HasContext);
            if ((((uint) num5) | 3) == 0)
            {
                goto Label_006E;
            }
            goto Label_02E5;
        Label_03F8:
            helper.AddProperties(network.Properties);
            helper.AddSubSection("NETWORK");
            goto Label_0378;
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
                return typeof(RBFNetwork);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "RBFNetwork";
            }
        }
    }
}

