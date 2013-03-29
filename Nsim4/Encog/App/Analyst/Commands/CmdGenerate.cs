namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using Encog.Util.Simple;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CmdGenerate : Cmd
    {
        public const string CommandName = "GENERATE";

        public CmdGenerate(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            FileInfo info;
            FileInfo info2;
            bool flag;
            string propertyString = base.Prop.GetPropertyString("GENERATE:CONFIG_sourceFile");
            string sourceID = base.Prop.GetPropertyString("GENERATE:CONFIG_targetFile");
            CSVFormat format = base.Analyst.Script.DetermineInputFormat(propertyString);
            EncogLogging.Log(0, "Beginning generate");
            if (((uint) flag) <= uint.MaxValue)
            {
                EncogLogging.Log(0, "source file:" + propertyString);
                EncogLogging.Log(0, "target file:" + sourceID);
                info = base.Script.ResolveFilename(propertyString);
                if (0 == 0)
                {
                    do
                    {
                        info2 = base.Script.ResolveFilename(sourceID);
                    }
                    while (4 == 0);
                }
                else
                {
                    goto Label_00F5;
                }
            }
            base.Script.MarkGenerated(sourceID);
            flag = base.Script.ExpectInputHeaders(propertyString);
            CSVHeaders headers = new CSVHeaders(info, flag, format);
            int[] input = this.x163e1f9de31a8b41(headers);
            int[] ideal = this.x176a88b9713cb7be(headers);
            EncogUtility.ConvertCSV2Binary(info, format, info2, input, ideal, flag);
        Label_00F5:
            return false;
        }

        private int[] x163e1f9de31a8b41(CSVHeaders x36c9f86d45fbd962)
        {
            int num;
            string str;
            int slice;
            AnalystField field;
            int[] numArray;
            int num3;
            IList<int> list = new List<int>();
            if (((uint) slice) >= 0)
            {
                goto Label_0155;
            }
            if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
            {
                goto Label_003D;
            }
        Label_0033:
            while (num3 < numArray.Length)
            {
                numArray[num3] = list[num3];
                num3++;
                if (((uint) slice) < 0)
                {
                    return numArray;
                }
            }
            return numArray;
        Label_003D:
            numArray = new int[list.Count];
            num3 = 0;
            if ((((uint) num3) - ((uint) slice)) > uint.MaxValue)
            {
                goto Label_015C;
            }
            goto Label_0033;
        Label_0094:
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00ED;
            }
            if ((((uint) num) + ((uint) slice)) > uint.MaxValue)
            {
                return numArray;
            }
        Label_00C3:
            num++;
            if ((((uint) num3) + ((uint) num)) < 0)
            {
                goto Label_00C3;
            }
        Label_00DF:
            if (num < x36c9f86d45fbd962.Size())
            {
                goto Label_015C;
            }
            goto Label_003D;
        Label_00ED:
            if (field == null)
            {
                goto Label_00C3;
            }
            if (!field.Input)
            {
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_00C3;
                }
                goto Label_0094;
            }
        Label_011F:
            list.Add(num);
            if (0 == 0)
            {
                goto Label_0094;
            }
        Label_0155:
            num = 0;
            goto Label_00DF;
        Label_015C:
            str = x36c9f86d45fbd962.GetBaseHeader(num);
            if ((((uint) num3) + ((uint) slice)) >= 0)
            {
                slice = x36c9f86d45fbd962.GetSlice(num);
                field = base.Analyst.Script.FindNormalizedField(str, slice);
                goto Label_00ED;
            }
            if (-1 == 0)
            {
                goto Label_00C3;
            }
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                goto Label_011F;
            }
            goto Label_0094;
        }

        private int[] x176a88b9713cb7be(CSVHeaders x36c9f86d45fbd962)
        {
            IList<int> list;
            int num;
            int slice;
            AnalystField field;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_type");
            if ((((uint) slice) & 0) == 0)
            {
                if (2 == 0)
                {
                    goto Label_007D;
                }
                if (propertyString.Equals("som"))
                {
                    return new int[0];
                }
                list = new List<int>();
                num = 0;
            }
            else
            {
                goto Label_0079;
            }
        Label_005D:
            if (num < x36c9f86d45fbd962.Size())
            {
                string baseHeader = x36c9f86d45fbd962.GetBaseHeader(num);
                slice = x36c9f86d45fbd962.GetSlice(num);
                field = base.Analyst.Script.FindNormalizedField(baseHeader, slice);
            }
            else
            {
                int[] numArray = new int[list.Count];
                int index = 0;
                do
                {
                    if (index >= numArray.Length)
                    {
                        return numArray;
                    }
                    numArray[index] = list[index];
                    index++;
                }
                while ((((uint) index) - ((uint) num)) <= uint.MaxValue);
                goto Label_005D;
            }
        Label_0079:
            if ((field != null) && field.Output)
            {
                list.Add(num);
            }
        Label_007D:
            num++;
            goto Label_005D;
        }

        public override string Name
        {
            get
            {
                return "GENERATE";
            }
        }
    }
}

