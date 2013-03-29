namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Segregate;
    using Encog.App.Analyst.Script.Segregate;
    using Encog.App.Analyst.Util;
    using Encog.Util;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdSegregate : Cmd
    {
        public const string CommandName = "SEGREGATE";

        public CmdSegregate(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            FileInfo info;
            CSVFormat format;
            CSVFormat format2;
            bool flag;
            SegregateCSV ecsv;
            AnalystSegregateTarget target;
            FileInfo info2;
            AnalystSegregateTarget[] segregateTargets;
            int num;
            string propertyString = base.Prop.GetPropertyString("SEGREGATE:CONFIG_sourceFile");
            if (((uint) num) >= 0)
            {
                info = base.Script.ResolveFilename(propertyString);
                goto Label_01C5;
            }
        Label_0026:
            if (((uint) num) >= 0)
            {
                ecsv.Analyze(info, flag, format);
            }
            ecsv.OutputFormat = format2;
            if (0 != 0)
            {
                goto Label_00ED;
            }
            ecsv.Process();
            base.Analyst.CurrentQuantTask = null;
            goto Label_021F;
        Label_008C:
            if (num < segregateTargets.Length)
            {
                goto Label_00E6;
            }
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_01AD;
            }
            if (15 != 0)
            {
                goto Label_00E1;
            }
        Label_00B6:
            EncogLogging.Log(0, "target file:" + target.File + ", Percent: " + Format.FormatPercent((double) target.Percent));
            num++;
            goto Label_008C;
        Label_00E1:
            num = 0;
            goto Label_008C;
        Label_00E6:
            target = segregateTargets[num];
        Label_00ED:
            info2 = base.Script.ResolveFilename(target.File);
            ecsv.Targets.Add(new SegregateTargetPercent(info2, target.Percent));
            base.Script.MarkGenerated(target.File);
            goto Label_00B6;
        Label_01AD:
            if ((((uint) flag) - ((uint) num)) <= uint.MaxValue)
            {
                if (0 != 0)
                {
                    goto Label_00E6;
                }
                ecsv.Report = new AnalystReportBridge(base.Analyst);
                if (2 != 0)
                {
                    goto Label_0026;
                }
                goto Label_021F;
            }
        Label_01C5:
            EncogLogging.Log(0, "Beginning segregate");
            EncogLogging.Log(0, "source file:" + propertyString);
            format = base.Script.DetermineInputFormat(propertyString);
            format2 = base.Script.DetermineOutputFormat();
            flag = base.Script.ExpectInputHeaders(propertyString);
            ecsv = new SegregateCSV {
                Script = base.Script
            };
            if (((uint) flag) <= uint.MaxValue)
            {
                base.Analyst.CurrentQuantTask = ecsv;
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_0026;
                }
                segregateTargets = base.Script.Segregate.SegregateTargets;
                if (0 == 0)
                {
                    goto Label_00E1;
                }
            }
            goto Label_01AD;
        Label_021F:
            return ecsv.ShouldStop();
        }

        public override string Name
        {
            get
            {
                return "SEGREGATE";
            }
        }
    }
}

