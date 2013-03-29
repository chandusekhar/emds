namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Balance;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdBalance : Cmd
    {
        public const string CommandName = "BALANCE";

        public CmdBalance(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str2;
            FileInfo info;
            FileInfo info2;
            int propertyInt;
            string str3;
            DataField field;
            int num2;
            CSVFormat format;
            CSVFormat format2;
            BalanceCSV ecsv;
            bool flag;
            string propertyString = base.Prop.GetPropertyString("BALANCE:CONFIG_sourceFile");
            if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                str2 = base.Prop.GetPropertyString("BALANCE:CONFIG_targetFile");
                EncogLogging.Log(0, "Beginning balance");
                if (0 != 0)
                {
                    goto Label_011C;
                }
                EncogLogging.Log(0, "source file:" + propertyString);
                if (0 != 0)
                {
                    goto Label_0143;
                }
                EncogLogging.Log(0, "target file:" + str2);
                info = base.Script.ResolveFilename(propertyString);
            }
            goto Label_01C1;
        Label_0031:
            ecsv.OutputFormat = format2;
            ecsv.ProduceOutputHeaders = true;
            ecsv.Process(info2, num2, propertyInt);
            if (2 == 0)
            {
                goto Label_0153;
            }
            base.Analyst.CurrentQuantTask = null;
            if ((((uint) propertyInt) + ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_0299;
            }
            if ((((uint) num2) - ((uint) propertyInt)) <= uint.MaxValue)
            {
                goto Label_01C1;
            }
            goto Label_0191;
        Label_00CB:
            format2 = base.Script.DetermineOutputFormat();
            BalanceCSV ecsv2 = new BalanceCSV();
            if ((((uint) propertyInt) | 0xff) != 0)
            {
                ecsv2.Script = base.Script;
                ecsv = ecsv2;
                base.Analyst.CurrentQuantTask = ecsv;
                ecsv.Report = new AnalystReportBridge(base.Analyst);
                flag = base.Script.ExpectInputHeaders(propertyString);
                ecsv.Analyze(info, flag, format);
                if ((((uint) propertyInt) + ((uint) flag)) < 0)
                {
                    goto Label_00CB;
                }
            }
            goto Label_0031;
        Label_011C:
            format = base.Script.DetermineInputFormat(propertyString);
            if (0 == 0)
            {
                goto Label_00CB;
            }
            goto Label_0031;
        Label_0143:
            if (!field.Class)
            {
                throw new AnalystError("Can't balance on non-class field: " + str3);
            }
            if (0 == 0)
            {
                num2 = base.Analyst.Script.FindDataFieldIndex(field);
                base.Script.MarkGenerated(str2);
                goto Label_011C;
            }
            goto Label_0031;
        Label_0153:
            if (field == null)
            {
                throw new AnalystError("Can't find balance target field: " + str3);
            }
            goto Label_0143;
        Label_0191:
            if (((uint) num2) < 0)
            {
                goto Label_0299;
            }
            goto Label_0153;
            if (3 != 0)
            {
                goto Label_0143;
            }
        Label_01C1:
            if ((((uint) propertyInt) & 0) != 0)
            {
                goto Label_00CB;
            }
            info2 = base.Script.ResolveFilename(str2);
            propertyInt = base.Prop.GetPropertyInt("BALANCE:CONFIG_countPer");
            str3 = base.Prop.GetPropertyString("BALANCE:CONFIG_balanceField");
            field = base.Analyst.Script.FindDataField(str3);
            if (((uint) flag) >= 0)
            {
                goto Label_0191;
            }
            goto Label_0143;
        Label_0299:
            return ecsv.ShouldStop();
        }

        public override string Name
        {
            get
            {
                return "BALANCE";
            }
        }
    }
}

