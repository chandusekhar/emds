namespace Encog.Neural.Pnn
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.PNN;
    using Encog.Persist;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistBasicPNN : IEncogPersistor
    {
        public const string PropertyOutputMode = "outputMode";

        public static string KernelToString(PNNKernelType k)
        {
            switch (k)
            {
                case PNNKernelType.Gaussian:
                    return "gaussian";

                case PNNKernelType.Reciprocal:
                    return "reciprocal";
            }
            return null;
        }

        public static string OutputModeToString(PNNOutputMode mode)
        {
            switch (mode)
            {
                case PNNOutputMode.Unsupervised:
                    return "unsupervised";

                case PNNOutputMode.Regression:
                    return "regression";

                case PNNOutputMode.Classification:
                    return "classification";
            }
            return null;
        }

        public object Read(Stream mask0)
        {
            EncogFileSection section;
            double num3;
            double[] numArray;
            IDictionary<string, string> dictionary2;
            int num4;
            int num5;
            int num6;
            BasicPNN cpnn;
            EncogReadHelper helper = new EncogReadHelper(mask0);
            BasicMLDataSet set = new BasicMLDataSet();
            IDictionary<string, string> source = null;
            PNNKernelType gaussian = PNNKernelType.Gaussian;
            PNNOutputMode unsupervised = PNNOutputMode.Unsupervised;
            int inputCount = 0;
            int outputCount = 0;
            goto Label_042A;
        Label_000C:
            cpnn.Error = num3;
            while (numArray != null)
            {
                EngineArray.ArrayCopy(numArray, cpnn.Sigma);
                return cpnn;
            }
            if ((((uint) num3) - ((uint) outputCount)) <= uint.MaxValue)
            {
                if ((((uint) num5) - ((uint) outputCount)) >= 0)
                {
                    return cpnn;
                }
                if ((((uint) inputCount) - ((uint) inputCount)) >= 0)
                {
                    goto Label_0319;
                }
                if (((uint) num4) >= 0)
                {
                    goto Label_02F1;
                }
                goto Label_02BB;
            }
            goto Label_00D8;
        Label_0075:
            while (source != null)
            {
                EngineArray.PutAll<string, string>(source, cpnn.Properties);
                if ((((uint) outputCount) + ((uint) num3)) >= 0)
                {
                    break;
                }
            }
            cpnn.Samples = set;
            goto Label_00A5;
        Label_0082:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (section.SectionName.Equals("PNN") && (((((uint) num4) & 0) != 0) || section.SubSectionName.Equals("PARAMS")))
                {
                    source = section.ParseParams();
                }
                if (section.SectionName.Equals("PNN") && section.SubSectionName.Equals("NETWORK"))
                {
                    dictionary2 = section.ParseParams();
                    if ((((uint) outputCount) + ((uint) num6)) <= uint.MaxValue)
                    {
                        inputCount = EncogFileSection.ParseInt(dictionary2, "inputCount");
                        outputCount = EncogFileSection.ParseInt(dictionary2, "outputCount");
                    }
                    gaussian = StringToKernel(dictionary2["kernel"]);
                    if (0 != 0)
                    {
                        return cpnn;
                    }
                    unsupervised = StringToOutputMode(dictionary2["outputMode"]);
                    goto Label_0319;
                }
                goto Label_02BB;
            }
            cpnn = new BasicPNN(gaussian, unsupervised, inputCount, outputCount);
            if (4 != 0)
            {
                goto Label_0075;
            }
        Label_00A5:
            if ((((uint) outputCount) | 15) != 0)
            {
                goto Label_000C;
            }
            goto Label_0082;
        Label_00D8:
            if (0 != 0)
            {
                goto Label_042A;
            }
            if ((((uint) num3) | 1) != 0)
            {
                goto Label_0082;
            }
            goto Label_000C;
        Label_02BB:
            if (section.SectionName.Equals("PNN"))
            {
                if (((uint) inputCount) > uint.MaxValue)
                {
                    goto Label_0075;
                }
                if (section.SubSectionName.Equals("SAMPLES"))
                {
                    using (IEnumerator<string> enumerator = section.Lines.GetEnumerator())
                    {
                        string str;
                        IList<string> list;
                        IMLData data;
                        IMLData data2;
                        IMLDataPair pair;
                        goto Label_0193;
                    Label_0174:
                        set.Add(pair);
                        if ((((uint) num4) & 0) != 0)
                        {
                            goto Label_0206;
                        }
                    Label_0193:
                        if (enumerator.MoveNext())
                        {
                            goto Label_0255;
                        }
                        goto Label_0082;
                    Label_01A1:
                        data2[num6] = CSVFormat.EgFormat.Parse(list[num4++]);
                        num6++;
                    Label_01C8:
                        if (num6 < outputCount)
                        {
                            goto Label_01A1;
                        }
                        pair = new BasicMLDataPair(data, data2);
                        if (((uint) num3) >= 0)
                        {
                            goto Label_0174;
                        }
                        goto Label_0082;
                    Label_01ED:
                        if (((uint) num5) > uint.MaxValue)
                        {
                            goto Label_0238;
                        }
                        num6 = 0;
                        goto Label_01C8;
                    Label_0206:
                        num5 = 0;
                        while (num5 < inputCount)
                        {
                            data[num5] = CSVFormat.EgFormat.Parse(list[num4++]);
                            num5++;
                        }
                    Label_0238:
                        data2 = new BasicMLData(inputCount);
                        goto Label_01ED;
                    Label_0245:
                        num4 = 0;
                        data = new BasicMLData(inputCount);
                        goto Label_0206;
                    Label_0255:
                        str = enumerator.Current;
                        list = EncogFileSection.SplitColumns(str);
                        if ((((uint) num6) + ((uint) num4)) <= uint.MaxValue)
                        {
                            goto Label_0245;
                        }
                        goto Label_0082;
                    }
                    if ((((uint) inputCount) + ((uint) num5)) <= uint.MaxValue)
                    {
                        if ((((uint) outputCount) + ((uint) num6)) <= uint.MaxValue)
                        {
                            goto Label_033B;
                        }
                        goto Label_0319;
                    }
                    goto Label_02F1;
                }
            }
            goto Label_0082;
        Label_02F1:
            numArray = EncogFileSection.ParseDoubleArray(dictionary2, "sigma");
            goto Label_02BB;
        Label_0319:
            num3 = EncogFileSection.ParseDouble(dictionary2, "error");
            if ((((uint) inputCount) & 0) == 0)
            {
                goto Label_02F1;
            }
        Label_033B:
            if ((((uint) inputCount) & 0) == 0)
            {
                goto Label_00D8;
            }
            return cpnn;
        Label_042A:
            num3 = 0.0;
            numArray = null;
            if ((((uint) num4) - ((uint) num6)) < 0)
            {
                goto Label_0075;
            }
            goto Label_0082;
        }

        public void Save(Stream os, object obj)
        {
            BasicPNN cpnn;
            int num;
            int num2;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            goto Label_01F0;
        Label_0017:
            using (IEnumerator<IMLDataPair> enumerator = cpnn.Samples.GetEnumerator())
            {
                IMLDataPair pair;
                goto Label_0054;
            Label_0026:
                helper.AddColumn(pair.Ideal[num2]);
                num2++;
            Label_003F:
                if (num2 < pair.Ideal.Count)
                {
                    goto Label_0026;
                }
                helper.WriteLine();
            Label_0054:
                if (enumerator.MoveNext())
                {
                    goto Label_00F0;
                }
                if ((((uint) num) - ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_00DD;
                }
                if ((((uint) num2) + ((uint) num)) >= 0)
                {
                    goto Label_010F;
                }
                if ((((uint) num2) - ((uint) num)) >= 0)
                {
                    goto Label_00F0;
                }
                if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_010F;
                }
            Label_00C7:
                helper.AddColumn(pair.Input[num]);
                num++;
            Label_00DD:
                if (num < pair.Input.Count)
                {
                    goto Label_00C7;
                }
                num2 = 0;
                goto Label_003F;
            Label_00F0:
                pair = enumerator.Current;
                num = 0;
                goto Label_00DD;
            }
        Label_010F:
            helper.Flush();
            return;
        Label_01F0:
            cpnn = (BasicPNN) obj;
            helper.AddSection("PNN");
            helper.AddSubSection("PARAMS");
            helper.AddProperties(cpnn.Properties);
            helper.AddSubSection("NETWORK");
            helper.WriteProperty("error", cpnn.Error);
            helper.WriteProperty("inputCount", cpnn.InputCount);
            helper.WriteProperty("kernel", KernelToString(cpnn.Kernel));
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0017;
            }
            helper.WriteProperty("outputCount", cpnn.OutputCount);
            helper.WriteProperty("outputMode", OutputModeToString(cpnn.OutputMode));
            if ((((uint) num2) | 1) == 0)
            {
                goto Label_0017;
            }
            helper.WriteProperty("sigma", cpnn.Sigma);
            if (0 == 0)
            {
                helper.AddSubSection("SAMPLES");
                goto Label_0017;
            }
            goto Label_01F0;
        }

        public static PNNKernelType StringToKernel(string k)
        {
            if (!k.Equals("gaussian", StringComparison.InvariantCultureIgnoreCase) && k.Equals("reciprocal", StringComparison.InvariantCultureIgnoreCase))
            {
                return PNNKernelType.Reciprocal;
            }
            return PNNKernelType.Gaussian;
        }

        public static PNNOutputMode StringToOutputMode(string mode)
        {
            if (!mode.Equals("regression", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!mode.Equals("unsupervised", StringComparison.InvariantCultureIgnoreCase) && mode.Equals("classification", StringComparison.InvariantCultureIgnoreCase))
                {
                    return PNNOutputMode.Classification;
                }
                return PNNOutputMode.Unsupervised;
            }
            return PNNOutputMode.Regression;
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
                return typeof(BasicPNN);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "BasicPNN";
            }
        }
    }
}

