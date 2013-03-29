namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Normalize;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdNormalize : Cmd
    {
        public const string CommandName = "NORMALIZE";

        public CmdNormalize(EncogAnalyst theAnalyst) : base(theAnalyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str2;
            FileInfo info;
            FileInfo info2;
            CSVFormat format;
            CSVFormat format2;
            AnalystNormalizeCSV ecsv;
            bool flag;
            string propertyString = base.Prop.GetPropertyString("NORMALIZE:CONFIG_sourceFile");
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                str2 = base.Prop.GetPropertyString("NORMALIZE:CONFIG_targetFile");
                info = base.Script.ResolveFilename(propertyString);
                goto Label_017F;
            }
            if ((((uint) flag) | 2) != 0)
            {
                goto Label_017F;
            }
        Label_008B:
            flag = base.Script.ExpectInputHeaders(propertyString);
        Label_0099:
            ecsv.Analyze(info, flag, format, base.Analyst);
            ecsv.OutputFormat = format2;
            if ((((uint) flag) | 0x7fffffff) != 0)
            {
                ecsv.ProduceOutputHeaders = true;
                ecsv.Normalize(info2);
                base.Analyst.CurrentQuantTask = null;
            }
            return ecsv.ShouldStop();
        Label_017F:
            if ((((uint) flag) | 0x7fffffff) == 0)
            {
                goto Label_0099;
            }
            do
            {
                AnalystNormalizeCSV ecsv2;
                info2 = base.Script.ResolveFilename(str2);
                EncogLogging.Log(0, "Beginning normalize");
                EncogLogging.Log(0, "source file:" + propertyString);
                EncogLogging.Log(0, "target file:" + str2);
                base.Script.MarkGenerated(str2);
                if (2 != 0)
                {
                    format = base.Script.DetermineInputFormat(propertyString);
                    format2 = base.Script.DetermineOutputFormat();
                    ecsv2 = new AnalystNormalizeCSV();
                }
                ecsv2.Script = base.Script;
                ecsv = ecsv2;
                base.Analyst.CurrentQuantTask = ecsv;
                ecsv.Report = new AnalystReportBridge(base.Analyst);
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_008B;
                }
            }
            while (3 == 0);
            goto Label_017F;
        }

        public override string Name
        {
            get
            {
                return "NORMALIZE";
            }
        }
    }
}

