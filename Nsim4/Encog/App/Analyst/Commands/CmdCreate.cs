namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.ML;
    using Encog.ML.Data.Buffer;
    using Encog.ML.Factory;
    using Encog.Persist;
    using Encog.Util.Logging;
    using System;
    using System.IO;

    public class CmdCreate : Cmd
    {
        public const string CommandName = "CREATE";

        public CmdCreate(EncogAnalyst theAnalyst) : base(theAnalyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            FileInfo info2;
            string str3;
            string str4;
            EncogEGBFile file;
            int inputCount;
            int num2;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_trainingFile");
            if (0x7fffffff != 0)
            {
                FileInfo info;
                string sourceID = base.Prop.GetPropertyString("ML:CONFIG_machineLearningFile");
                if (((uint) num2) <= uint.MaxValue)
                {
                    info = base.Script.ResolveFilename(propertyString);
                    info2 = base.Script.ResolveFilename(sourceID);
                }
                str3 = base.Prop.GetPropertyString("ML:CONFIG_type");
                str4 = base.Prop.GetPropertyString("ML:CONFIG_architecture");
                EncogLogging.Log(0, "Beginning create");
                EncogLogging.Log(0, "training file:" + propertyString);
                EncogLogging.Log(0, "resource file:" + sourceID);
                EncogLogging.Log(0, "type:" + str3);
                EncogLogging.Log(0, "arch:" + str4);
                file = new EncogEGBFile(info.ToString());
                goto Label_00A6;
            }
        Label_002E:
            num2 = file.IdealCount;
            file.Close();
            IMLMethod method = new MLMethodFactory().Create(str3, str4, inputCount, num2);
            if ((((uint) inputCount) + ((uint) num2)) >= 0)
            {
                if (1 != 0)
                {
                }
                EncogDirectoryPersistence.SaveObject(info2, method);
                return false;
            }
        Label_00A6:
            file.Open();
            inputCount = file.InputCount;
            goto Label_002E;
        }

        public override string Name
        {
            get
            {
                return "CREATE";
            }
        }
    }
}

