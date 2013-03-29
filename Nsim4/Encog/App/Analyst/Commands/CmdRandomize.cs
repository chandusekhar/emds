namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Shuffle;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdRandomize : Cmd
    {
        public const string CommandName = "RANDOMIZE";

        public CmdRandomize(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            FileInfo info2;
            CSVFormat format;
            CSVFormat format2;
            ShuffleCSV ecsv;
            bool flag;
            ShuffleCSV ecsv2;
            string propertyString = base.Prop.GetPropertyString("RANDOMIZE:CONFIG_sourceFile");
            string filename = base.Prop.GetPropertyString("RANDOMIZE:CONFIG_targetFile");
            EncogLogging.Log(0, "Beginning randomize");
            EncogLogging.Log(0, "source file:" + propertyString);
            if ((((uint) flag) - ((uint) flag)) < 0)
            {
                goto Label_0094;
            }
            EncogLogging.Log(0, "target file:" + filename);
            FileInfo inputFile = base.Script.ResolveFilename(propertyString);
            goto Label_0167;
        Label_0027:
            ecsv.Analyze(inputFile, flag, format);
            ecsv.OutputFormat = format2;
            ecsv.Process(info2);
            if (((uint) flag) <= uint.MaxValue)
            {
                base.Analyst.CurrentQuantTask = null;
                return ecsv.ShouldStop();
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_00B7;
            }
        Label_0071:
            ecsv = ecsv2;
            if (((uint) flag) <= uint.MaxValue)
            {
            }
            base.Analyst.CurrentQuantTask = ecsv;
        Label_0094:
            ecsv.Report = new AnalystReportBridge(base.Analyst);
            flag = base.Script.ExpectInputHeaders(propertyString);
            if (0 == 0)
            {
                goto Label_0027;
            }
        Label_00B7:
            format2 = base.Script.DetermineOutputFormat();
            base.Script.MarkGenerated(filename);
            ecsv2 = new ShuffleCSV();
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                ecsv2.Script = base.Script;
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_0071;
                }
                goto Label_0027;
            }
        Label_0167:
            info2 = base.Script.ResolveFilename(filename);
            format = base.Script.DetermineInputFormat(propertyString);
            goto Label_00B7;
        }

        public override string Name
        {
            get
            {
                return "RANDOMIZE";
            }
        }
    }
}

