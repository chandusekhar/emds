namespace Encog.App.Analyst.Script.Prop
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Util;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class ScriptProperties
    {
        private readonly IDictionary<string, string> _x4a3f0a05c02f235f = new Dictionary<string, string>();
        public const string BalanceConfigBalanceField = "BALANCE:CONFIG_balanceField";
        public const string BalanceConfigCountPer = "BALANCE:CONFIG_countPer";
        public const string BalanceConfigSourceFile = "BALANCE:CONFIG_sourceFile";
        public const string BalanceConfigTargetFile = "BALANCE:CONFIG_targetFile";
        public const string ClusterConfigClusters = "CLUSTER:CONFIG_clusters";
        public const string ClusterConfigSourceFile = "CLUSTER:CONFIG_sourceFile";
        public const string ClusterConfigTargetFile = "CLUSTER:CONFIG_targetFile";
        public const string ClusterConfigType = "CLUSTER:CONFIG_type";
        public const string DataConfigGoal = "DATA:CONFIG_goal";
        public const string GenerateConfigSourceFile = "GENERATE:CONFIG_sourceFile";
        public const string GenerateConfigTargetFile = "GENERATE:CONFIG_targetFile";
        public const string HeaderDatasourceRawFile = "HEADER:DATASOURCE_rawFile";
        public const string HeaderDatasourceSourceFile = "HEADER:DATASOURCE_sourceFile";
        public const string HeaderDatasourceSourceFormat = "HEADER:DATASOURCE_sourceFormat";
        public const string HeaderDatasourceSourceHeaders = "HEADER:DATASOURCE_sourceHeaders";
        public const string MlConfigArchitecture = "ML:CONFIG_architecture";
        public const string MlConfigEvalFile = "ML:CONFIG_evalFile";
        public const string MlConfigMachineLearningFile = "ML:CONFIG_machineLearningFile";
        public const string MlConfigOutputFile = "ML:CONFIG_outputFile";
        public const string MlConfigTrainingFile = "ML:CONFIG_trainingFile";
        public const string MlConfigType = "ML:CONFIG_type";
        public const string MlTrainArguments = "ML:TRAIN_arguments";
        public const string MlTrainCross = "ML:TRAIN_cross";
        public const string MlTrainTargetError = "ML:TRAIN_targetError";
        public const string MlTrainType = "ML:TRAIN_type";
        public const string NormalizeConfigSourceFile = "NORMALIZE:CONFIG_sourceFile";
        public const string NormalizeConfigTargetFile = "NORMALIZE:CONFIG_targetFile";
        public const string NormalizeMissingValues = "NORMALIZE:CONFIG_missingValues";
        public const string RandomizeConfigSourceFile = "RANDOMIZE:CONFIG_sourceFile";
        public const string RandomizeConfigTargetFile = "RANDOMIZE:CONFIG_targetFile";
        public const string SegregateConfigSourceFile = "SEGREGATE:CONFIG_sourceFile";
        public const string SetupConfigAllowedClasses = "SETUP:CONFIG_allowedClasses";
        public const string SetupConfigCSVFormat = "SETUP:CONFIG_csvFormat";
        public const string SetupConfigInputHeaders = "SETUP:CONFIG_inputHeaders";
        public const string SetupConfigMaxClassCount = "SETUP:CONFIG_maxClassCount";
        [CompilerGenerated]
        private static Func<<>f__AnonymousType0<string, int>, bool> x52e0eb7265061ab4;
        [CompilerGenerated]
        private static Func<<>f__AnonymousType0<string, int>, string> x66406001675ff321;
        [CompilerGenerated]
        private static Func<string, <>f__AnonymousType0<string, int>> xca5ad8524f73e51f;
        [CompilerGenerated]
        private static Func<string, bool> xec790bb6d0304faa;

        public void ClearFilenames()
        {
            string str3;
            string[] strArray2;
            int num2;
            string[] strArray = new string[this._x4a3f0a05c02f235f.Keys.Count];
            int num = 0;
            goto Label_00B5;
        Label_002F:
            num2++;
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_00B5;
            }
        Label_004A:
            if (num2 < strArray2.Length)
            {
                string str2 = strArray2[num2];
                if (0 != 0)
                {
                    return;
                }
                str3 = str2;
            }
            else
            {
                return;
            }
            while (true)
            {
                if (str3.StartsWith("SETUP:FILENAMES"))
                {
                    this._x4a3f0a05c02f235f.Remove(str3);
                }
                else
                {
                    if ((((uint) num2) - ((uint) num)) > uint.MaxValue)
                    {
                        goto Label_00F3;
                    }
                    goto Label_002F;
                }
                if (((((uint) num) - ((uint) num2)) >= 0) && (((uint) num2) <= uint.MaxValue))
                {
                    goto Label_002F;
                }
            }
        Label_00B5:
            foreach (string str in this._x4a3f0a05c02f235f.Keys)
            {
                strArray[num++] = str;
            }
            strArray2 = strArray;
        Label_00F3:
            num2 = 0;
            goto Label_004A;
        }

        public string GetFilename(string file)
        {
            string key = "SETUP:FILENAMES_" + file;
            if ((1 == 0) || !this._x4a3f0a05c02f235f.ContainsKey(key))
            {
                throw new AnalystError("Undefined file: " + file);
            }
            return this._x4a3f0a05c02f235f[key];
        }

        public object GetProperty(string name)
        {
            return this._x4a3f0a05c02f235f[name];
        }

        public bool GetPropertyBoolean(string name)
        {
            if (!this._x4a3f0a05c02f235f.ContainsKey(name))
            {
                return false;
            }
            return this._x4a3f0a05c02f235f[name].ToLower().StartsWith("t");
        }

        public CSVFormat GetPropertyCSVFormat(string name)
        {
            string str = this._x4a3f0a05c02f235f[name];
            return ConvertStringConst.ConvertToCSVFormat(ConvertStringConst.String2AnalystFileFormat(str));
        }

        public double GetPropertyDouble(string name)
        {
            string str = this._x4a3f0a05c02f235f[name];
            return CSVFormat.EgFormat.Parse(str);
        }

        public string GetPropertyFile(string name)
        {
            return this._x4a3f0a05c02f235f[name];
        }

        public AnalystFileFormat GetPropertyFormat(string name)
        {
            string str = this._x4a3f0a05c02f235f[name];
            return ConvertStringConst.String2AnalystFileFormat(str);
        }

        public int GetPropertyInt(string name)
        {
            int num;
            try
            {
                string s = this._x4a3f0a05c02f235f[name];
                if (s == null)
                {
                    return 0;
                }
                num = int.Parse(s);
            }
            catch (FormatException exception)
            {
                throw new AnalystError(exception);
            }
            return num;
        }

        public string GetPropertyString(string name)
        {
            if (!this._x4a3f0a05c02f235f.ContainsKey(name))
            {
                return null;
            }
            return this._x4a3f0a05c02f235f[name];
        }

        public Uri GetPropertyURL(string name)
        {
            Uri uri;
            try
            {
                uri = new Uri(this._x4a3f0a05c02f235f[name]);
            }
            catch (UriFormatException exception)
            {
                throw new AnalystError(exception);
            }
            return uri;
        }

        public void PerformRevert(IDictionary<string, string> revertedData)
        {
            this._x4a3f0a05c02f235f.Clear();
            EngineArray.PutAll<string, string>(revertedData, this._x4a3f0a05c02f235f);
        }

        public IDictionary<string, string> PrepareRevert()
        {
            IDictionary<string, string> target = new Dictionary<string, string>();
            EngineArray.PutAll<string, string>(this._x4a3f0a05c02f235f, target);
            return target;
        }

        public void SetFilename(string key, string v)
        {
            string str = "SETUP:FILENAMES_" + key;
            this._x4a3f0a05c02f235f[str] = v;
        }

        public void SetProperty(string name, AnalystFileFormat format)
        {
            this._x4a3f0a05c02f235f[name] = ConvertStringConst.AnalystFileFormat2String(format);
        }

        public void SetProperty(string name, AnalystGoal v)
        {
            switch (v)
            {
                case AnalystGoal.Regression:
                    this._x4a3f0a05c02f235f[name] = "regression";
                    return;

                case AnalystGoal.Classification:
                    this._x4a3f0a05c02f235f[name] = "classification";
                    return;
            }
            this._x4a3f0a05c02f235f[name] = "";
        }

        public void SetProperty(string name, bool b)
        {
            if (b)
            {
                this._x4a3f0a05c02f235f[name] = "t";
            }
            else
            {
                this._x4a3f0a05c02f235f[name] = "f";
            }
        }

        public void SetProperty(string name, double d)
        {
            this._x4a3f0a05c02f235f[name] = CSVFormat.EgFormat.Format(d, 10);
        }

        public void SetProperty(string name, int i)
        {
            this._x4a3f0a05c02f235f[name] = i;
        }

        public void SetProperty(string name, FileInfo f)
        {
            this._x4a3f0a05c02f235f[name] = f.ToString();
        }

        public void SetProperty(string name, string v)
        {
            this._x4a3f0a05c02f235f[name] = v;
        }

        public void SetProperty(string name, Uri url)
        {
            this._x4a3f0a05c02f235f[name] = url.ToString();
        }

        public static string ToDots(string str)
        {
            int num2;
            string str2;
            string str3;
            string str4;
            int index = str.IndexOf(':');
            goto Label_00DE;
        Label_005F:
            str4 = str.Substring(num2 + 1);
            string[] strArray = new string[5];
            strArray[0] = str2;
            strArray[1] = ".";
            if ((((uint) num2) + ((uint) num2)) >= 0)
            {
                strArray[2] = str3;
                strArray[3] = ".";
                strArray[4] = str4;
                return string.Concat(strArray);
            }
            goto Label_00DE;
        Label_00A6:
            return null;
        Label_00DE:
            if (index != -1)
            {
                num2 = str.IndexOf('_');
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                    if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                    {
                        if (num2 == -1)
                        {
                            goto Label_00A6;
                        }
                        str2 = str.Substring(0, index);
                        str3 = str.Substring(index + 1, num2 - (index + 1));
                        goto Label_005F;
                    }
                    if (((uint) num2) > uint.MaxValue)
                    {
                        goto Label_005F;
                    }
                }
                goto Label_00A6;
            }
            return null;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            builder.Append(" :");
            builder.Append(this._x4a3f0a05c02f235f.ToString());
            builder.Append("]");
            return builder.ToString();
        }

        [CompilerGenerated]
        private static string x249765dc017ab96b(<>f__AnonymousType0<string, int> x91340c656450e7ee)
        {
            return x91340c656450e7ee.key.Substring(x91340c656450e7ee.index + 1);
        }

        [CompilerGenerated]
        private static bool x4f0989f5ccbe71e2(<>f__AnonymousType0<string, int> x91340c656450e7ee)
        {
            return (x91340c656450e7ee.index != -1);
        }

        [CompilerGenerated]
        private static <>f__AnonymousType0<string, int> x96b490bee5457597(string xba08ce632055a1d9)
        {
            return new { key = xba08ce632055a1d9, index = xba08ce632055a1d9.IndexOf('_') };
        }

        [CompilerGenerated]
        private static bool xfe87d183f28f90ad(string xba08ce632055a1d9)
        {
            return xba08ce632055a1d9.StartsWith("SETUP:FILENAMES");
        }

        public IList<string> Filenames
        {
            get
            {
                if (xec790bb6d0304faa == null)
                {
                    xec790bb6d0304faa = new Func<string, bool>(ScriptProperties.xfe87d183f28f90ad);
                }
                if (xca5ad8524f73e51f == null)
                {
                    xca5ad8524f73e51f = new Func<string, <>f__AnonymousType0<string, int>>(ScriptProperties.x96b490bee5457597);
                }
                if (x52e0eb7265061ab4 == null)
                {
                    x52e0eb7265061ab4 = new Func<<>f__AnonymousType0<string, int>, bool>(ScriptProperties.x4f0989f5ccbe71e2);
                }
                if (x66406001675ff321 == null)
                {
                    x66406001675ff321 = new Func<<>f__AnonymousType0<string, int>, string>(ScriptProperties.x249765dc017ab96b);
                }
                return this._x4a3f0a05c02f235f.Keys.Where<string>(xec790bb6d0304faa).Select(xca5ad8524f73e51f).Where(x52e0eb7265061ab4).Select(x66406001675ff321).ToList<string>();
            }
        }
    }
}

