namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV;
    using Encog.App.Analyst.Util;
    using Encog.ML;
    using Encog.Persist;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdEvaluate : Cmd
    {
        public const string CommandName = "EVALUATE";

        public CmdEvaluate(EncogAnalyst theAnalyst) : base(theAnalyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str2;
            string str3;
            FileInfo info;
            FileInfo info3;
            IMLMethod method;
            bool flag;
            AnalystEvaluateCSV ecsv;
            AnalystEvaluateCSV ecsv2;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_evalFile");
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_00E0;
                }
                goto Label_0118;
            }
            if (((uint) flag) >= 0)
            {
                goto Label_0118;
            }
        Label_002C:
            ecsv = ecsv2;
            base.Analyst.CurrentQuantTask = ecsv;
            ecsv.Report = new AnalystReportBridge(base.Analyst);
            ecsv.Analyze(base.Analyst, info, flag, base.Prop.GetPropertyCSVFormat("SETUP:CONFIG_csvFormat"));
            ecsv.Process(info3, method);
            base.Analyst.CurrentQuantTask = null;
            goto Label_0180;
        Label_00E0:
            info = base.Script.ResolveFilename(propertyString);
            if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0180;
            }
            FileInfo file = base.Script.ResolveFilename(str2);
            info3 = base.Analyst.Script.ResolveFilename(str3);
            method = (IMLMethod) EncogDirectoryPersistence.LoadObject(file);
            if ((((uint) flag) | uint.MaxValue) != 0)
            {
                flag = true;
                ecsv2 = new AnalystEvaluateCSV {
                    Script = base.Script
                };
                goto Label_002C;
            }
        Label_0118:
            str2 = base.Prop.GetPropertyString("ML:CONFIG_machineLearningFile");
            str3 = base.Prop.GetPropertyString("ML:CONFIG_outputFile");
            EncogLogging.Log(0, "Beginning evaluate");
            EncogLogging.Log(0, "evaluate file:" + propertyString);
            EncogLogging.Log(0, "resource file:" + str2);
            goto Label_00E0;
        Label_0180:
            return ecsv.ShouldStop();
        }

        public override string Name
        {
            get
            {
                return "EVALUATE";
            }
        }
    }
}

