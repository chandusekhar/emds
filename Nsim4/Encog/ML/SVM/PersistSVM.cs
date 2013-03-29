namespace Encog.ML.SVM
{
    using Encog.MathUtil.LIBSVM;
    using Encog.Persist;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class PersistSVM : IEncogPersistor
    {
        public const string ParamC = "C";
        public const string ParamCacheSize = "cacheSize";
        public const string ParamCoef0 = "coef0";
        public const string ParamDegree = "degree";
        public const string ParamEps = "eps";
        public const string ParamGamma = "gamma";
        public const string ParamKernelType = "kernelType";
        public const string ParamNu = "nu";
        public const string ParamNumWeight = "nrWeight";
        public const string ParamP = "p";
        public const string ParamProbability = "probability";
        public const string ParamShrinking = "shrinking";
        public const string ParamStartIterations = "statIterations";
        public const string ParamSVMType = "svmType";
        public const string ParamWeight = "weight";
        public const string ParamWeightLabel = "weightLabel";

        public object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            IDictionary<string, string> dictionary2;
            SupportVectorMachine machine = new SupportVectorMachine();
            goto Label_0306;
        Label_000B:
            if (section.SubSectionName.Equals("SVM-MODEL"))
            {
                try
                {
                    svm_model _model;
                    StringReader fp = new StringReader(section.LinesAsString);
                    TextReader reader2 = fp;
                    if (0 == 0)
                    {
                        _model = svm.svm_load_model(fp);
                    }
                    machine.Model = _model;
                    reader2.Close();
                    fp.Close();
                }
                catch (IOException exception)
                {
                    throw new PersistError(exception);
                }
            }
        Label_001D:
            if ((section = helper.ReadNextSection()) != null)
            {
                goto Label_028D;
            }
            return machine;
        Label_002F:
            if (!section.SectionName.Equals("SVM"))
            {
                goto Label_001D;
            }
            if (-2 == 0)
            {
                goto Label_023F;
            }
            if (3 != 0)
            {
                goto Label_000B;
            }
            return machine;
        Label_0237:
            dictionary2 = section.ParseParams();
        Label_023F:
            machine.InputCount = EncogFileSection.ParseInt(dictionary2, "inputCount");
            machine.Params.C = EncogFileSection.ParseDouble(dictionary2, "C");
            machine.Params.cache_size = EncogFileSection.ParseDouble(dictionary2, "cacheSize");
            if (0 == 0)
            {
                if (0 == 0)
                {
                    while (true)
                    {
                        machine.Params.coef0 = EncogFileSection.ParseDouble(dictionary2, "coef0");
                        machine.Params.degree = EncogFileSection.ParseDouble(dictionary2, "degree");
                        machine.Params.eps = EncogFileSection.ParseDouble(dictionary2, "eps");
                        machine.Params.gamma = EncogFileSection.ParseDouble(dictionary2, "gamma");
                        machine.Params.kernel_type = EncogFileSection.ParseInt(dictionary2, "kernelType");
                        machine.Params.nr_weight = EncogFileSection.ParseInt(dictionary2, "nrWeight");
                        machine.Params.nu = EncogFileSection.ParseDouble(dictionary2, "nu");
                        machine.Params.p = EncogFileSection.ParseDouble(dictionary2, "p");
                        if (0 == 0)
                        {
                            machine.Params.probability = EncogFileSection.ParseInt(dictionary2, "probability");
                            if (-2147483648 == 0)
                            {
                                goto Label_001D;
                            }
                            machine.Params.shrinking = EncogFileSection.ParseInt(dictionary2, "shrinking");
                            machine.Params.svm_type = EncogFileSection.ParseInt(dictionary2, "svmType");
                            machine.Params.weight = EncogFileSection.ParseDoubleArray(dictionary2, "weight");
                            machine.Params.weight_label = EncogFileSection.ParseIntArray(dictionary2, "weightLabel");
                            if (0xff != 0)
                            {
                                goto Label_001D;
                            }
                            goto Label_002F;
                        }
                    }
                }
                goto Label_000B;
            }
            if (0 == 0)
            {
                goto Label_0306;
            }
        Label_028D:
            if (section.SectionName.Equals("SVM") && section.SubSectionName.Equals("PARAMS"))
            {
                IDictionary<string, string> source = section.ParseParams();
                if (0x7fffffff == 0)
                {
                    goto Label_0237;
                }
                EngineArray.PutAll<string, string>(source, machine.Properties);
            }
            if (section.SectionName.Equals("SVM") && section.SubSectionName.Equals("SVM-PARAM"))
            {
                if (8 != 0)
                {
                    if (3 == 0)
                    {
                        goto Label_001D;
                    }
                    goto Label_0237;
                }
            }
            else
            {
                goto Label_002F;
            }
        Label_0306:
            helper = new EncogReadHelper(mask0);
            goto Label_001D;
        }

        public void Save(Stream os, object obj)
        {
            SupportVectorMachine machine;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            if (8 != 0)
            {
            }
        Label_026A:
            machine = (SupportVectorMachine) obj;
            helper.AddSection("SVM");
            if (0 == 0)
            {
                while (true)
                {
                    helper.AddSubSection("PARAMS");
                    helper.AddProperties(machine.Properties);
                    helper.AddSubSection("SVM-PARAM");
                    helper.WriteProperty("inputCount", machine.InputCount);
                    helper.WriteProperty("C", machine.Params.C);
                    if (0 == 0)
                    {
                        helper.WriteProperty("cacheSize", machine.Params.cache_size);
                        if (-2 == 0)
                        {
                            goto Label_026A;
                        }
                        helper.WriteProperty("coef0", machine.Params.coef0);
                        helper.WriteProperty("degree", machine.Params.degree);
                        helper.WriteProperty("eps", machine.Params.eps);
                        helper.WriteProperty("gamma", machine.Params.gamma);
                        helper.WriteProperty("kernelType", machine.Params.kernel_type);
                    }
                    helper.WriteProperty("nrWeight", machine.Params.nr_weight);
                    if (1 != 0)
                    {
                        helper.WriteProperty("nu", machine.Params.nu);
                        helper.WriteProperty("p", machine.Params.p);
                        helper.WriteProperty("probability", machine.Params.probability);
                        helper.WriteProperty("shrinking", machine.Params.shrinking);
                        helper.WriteProperty("svmType", machine.Params.svm_type);
                        helper.WriteProperty("weight", machine.Params.weight);
                        helper.WriteProperty("weightLabel", machine.Params.weight_label);
                        break;
                    }
                }
            }
        Label_0092:
            while (machine.Model != null)
            {
                helper.AddSubSection("SVM-MODEL");
                try
                {
                    StreamWriter writer;
                    ASCIIEncoding encoding;
                    MemoryStream stream = new MemoryStream();
                    if (1 != 0)
                    {
                        goto Label_005F;
                    }
                Label_003E:
                    helper.Write(encoding.GetString(stream.ToArray()));
                    writer.Close();
                    stream.Close();
                    break;
                Label_005F:
                    writer = new StreamWriter(stream);
                    if (0 == 0)
                    {
                        svm.svm_save_model(writer, machine.Model);
                    }
                    encoding = new ASCIIEncoding();
                    goto Label_003E;
                }
                catch (IOException exception)
                {
                    throw new PersistError(exception);
                }
            }
            while (true)
            {
                helper.Flush();
                if (-2147483648 != 0)
                {
                    return;
                }
                if (0 != 0)
                {
                    goto Label_0092;
                }
            }
        }

        public int FileVersion
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
                return typeof(SupportVectorMachine);
            }
        }

        public string PersistClassString
        {
            get
            {
                return "SVM";
            }
        }
    }
}

