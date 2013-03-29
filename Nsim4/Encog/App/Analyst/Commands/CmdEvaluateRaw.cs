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

    public class CmdEvaluateRaw : Cmd
    {
        public const string CommandName = "EVALUATE-RAW";

        public CmdEvaluateRaw(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str2;
            string str3;
            FileInfo info;
            FileInfo info2;
            FileInfo info3;
            IMLRegression regression;
            bool flag;
            AnalystEvaluateRawCSV wcsv;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_evalFile");
            goto Label_0169;
        Label_0016:
            wcsv.Process(info3, regression);
        Label_0021:
            base.Analyst.CurrentQuantTask = null;
            if (((uint) flag) <= uint.MaxValue)
            {
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    return wcsv.ShouldStop();
                }
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_0169;
                }
                goto Label_010D;
            }
        Label_008D:
            info3 = base.Analyst.Script.ResolveFilename(str3);
            regression = (IMLRegression) EncogDirectoryPersistence.LoadObject(info2);
            flag = base.Script.ExpectInputHeaders(propertyString);
            wcsv = new AnalystEvaluateRawCSV {
                Script = base.Script
            };
            if (0 != 0)
            {
                goto Label_0016;
            }
            base.Analyst.CurrentQuantTask = wcsv;
            wcsv.Report = new AnalystReportBridge(base.Analyst);
            wcsv.Analyze(base.Analyst, info, flag, base.Prop.GetPropertyCSVFormat("SETUP:CONFIG_csvFormat"));
            if (-1 != 0)
            {
                goto Label_0016;
            }
            goto Label_008D;
        Label_010D:
            if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
            {
                goto Label_018B;
            }
            info2 = base.Script.ResolveFilename(str2);
            goto Label_008D;
        Label_0169:
            str2 = base.Prop.GetPropertyString("ML:CONFIG_machineLearningFile");
            str3 = base.Prop.GetPropertyString("ML:CONFIG_outputFile");
        Label_018B:
            EncogLogging.Log(0, "Beginning evaluate raw");
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_0021;
            }
            EncogLogging.Log(0, "evaluate file:" + propertyString);
            EncogLogging.Log(0, "resource file:" + str2);
            info = base.Script.ResolveFilename(propertyString);
            goto Label_010D;
        }

        public override string Name
        {
            get
            {
                return "EVALUATE-RAW";
            }
        }
    }
}

