namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdCluster : Cmd
    {
        public const string CommandName = "CLUSTER";
        public const int DefaultIterations = 100;

        public CmdCluster(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str2;
            int propertyInt;
            FileInfo info;
            FileInfo info2;
            CSVFormat format;
            CSVFormat format2;
            AnalystClusterCSV rcsv;
            AnalystClusterCSV rcsv2;
            string propertyString = base.Prop.GetPropertyString("CLUSTER:CONFIG_sourceFile");
            goto Label_019A;
        Label_0039:
            rcsv.Report = new AnalystReportBridge(base.Analyst);
            bool headers = base.Script.ExpectInputHeaders(propertyString);
            rcsv.Analyze(base.Analyst, info, headers, format);
            rcsv.OutputFormat = format2;
            rcsv.Process(info2, propertyInt, base.Analyst, 100);
            if (0 == 0)
            {
                base.Analyst.CurrentQuantTask = null;
                return rcsv.ShouldStop();
            }
        Label_0094:
            rcsv2 = new AnalystClusterCSV();
            rcsv2.Script = base.Script;
            rcsv = rcsv2;
            base.Analyst.CurrentQuantTask = rcsv;
            goto Label_0039;
        Label_00BB:
            format = base.Script.DetermineInputFormat(propertyString);
            if ((((uint) propertyInt) + ((uint) propertyInt)) >= 0)
            {
                format2 = base.Script.DetermineOutputFormat();
                base.Script.MarkGenerated(str2);
                goto Label_0094;
            }
        Label_00E5:
            info2 = base.Script.ResolveFilename(str2);
            if (0 == 0)
            {
                goto Label_00BB;
            }
            goto Label_0039;
        Label_019A:
            str2 = base.Prop.GetPropertyString("CLUSTER:CONFIG_targetFile");
            propertyInt = base.Prop.GetPropertyInt("CLUSTER:CONFIG_clusters");
        Label_011F:
            base.Prop.GetPropertyString("CLUSTER:CONFIG_type");
            if ((((uint) propertyInt) - ((uint) propertyInt)) < 0)
            {
                goto Label_00BB;
            }
            EncogLogging.Log(0, "Beginning cluster");
            EncogLogging.Log(0, "source file:" + propertyString);
            EncogLogging.Log(0, "target file:" + str2);
            EncogLogging.Log(0, "clusters:" + propertyInt);
            info = base.Script.ResolveFilename(propertyString);
            if (((uint) propertyInt) <= uint.MaxValue)
            {
                if (-1 != 0)
                {
                    goto Label_00E5;
                }
            }
            else
            {
                goto Label_011F;
            }
            goto Label_019A;
        }

        public override string Name
        {
            get
            {
                return "CLUSTER";
            }
        }
    }
}

