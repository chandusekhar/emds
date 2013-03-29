namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Folded;
    using Encog.ML.Factory;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Cross;
    using Encog.Persist;
    using Encog.Util.Logging;
    using Encog.Util.Simple;
    using Encog.Util.Validate;
    using System;
    using System.IO;

    public class CmdTrain : Cmd
    {
        private int _x33d31451731666c6;
        public const string CommandName = "TRAIN";

        public CmdTrain(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            this._x33d31451731666c6 = this.xdd3322c83e23089c();
            while (true)
            {
                IMLDataSet set = this.x13d6d581f93d9ea3();
                IMLMethod method = this.xf2f79e06f77a0f33();
                IMLTrain train = this.x8d3a841b4ad80901(method, set);
                EncogLogging.Log(0, "Beginning training");
                this.x0d87de1eb44df41c(train, method, set);
                string propertyString = base.Prop.GetPropertyString("ML:CONFIG_machineLearningFile");
                FileInfo filename = base.Analyst.Script.ResolveFilename(propertyString);
                method = train.Method;
                do
                {
                    EncogDirectoryPersistence.SaveObject(filename, method);
                    EncogLogging.Log(0, "save to:" + propertyString);
                }
                while (1 == 0);
                if (0 == 0)
                {
                    return base.Analyst.ShouldStopCommand();
                }
            }
        }

        private void x0d87de1eb44df41c(IMLTrain xd87f6a9c53c2ed9f, IMLMethod x1306445c04667cc7, IMLDataSet x1c9e132f434262d8)
        {
            int maxIteration;
            ValidateNetwork.ValidateMethodToData(x1306445c04667cc7, x1c9e132f434262d8);
            double propertyDouble = base.Prop.GetPropertyDouble("ML:TRAIN_targetError");
            base.Analyst.ReportTrainingBegin();
            if ((((uint) maxIteration) & 0) == 0)
            {
                if (2 == 0)
                {
                    goto Label_0038;
                }
                maxIteration = base.Analyst.MaxIteration;
                if (0xff != 0)
                {
                    goto Label_0038;
                }
            }
        Label_001B:
            if (!xd87f6a9c53c2ed9f.TrainingDone && ((maxIteration == -1) || (xd87f6a9c53c2ed9f.IterationNumber < maxIteration)))
            {
                goto Label_0038;
            }
        Label_0023:
            xd87f6a9c53c2ed9f.FinishTraining();
            base.Analyst.ReportTrainingEnd();
            return;
        Label_0038:
            xd87f6a9c53c2ed9f.Iteration();
            base.Analyst.ReportTraining(xd87f6a9c53c2ed9f);
            if ((xd87f6a9c53c2ed9f.Error <= propertyDouble) || base.Analyst.ShouldStopCommand())
            {
                goto Label_0023;
            }
            goto Label_001B;
        }

        private IMLDataSet x13d6d581f93d9ea3()
        {
            IMLDataSet set;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_trainingFile");
            FileInfo filename = base.Script.ResolveFilename(propertyString);
            if (1 != 0)
            {
                set = EncogUtility.LoadEGB2Memory(filename);
                while (this._x33d31451731666c6 > 0)
                {
                    do
                    {
                        set = new FoldedDataSet(set);
                    }
                    while (-1 == 0);
                    if (-2147483648 != 0)
                    {
                        return set;
                    }
                }
                return set;
            }
            return set;
        }

        private IMLTrain x8d3a841b4ad80901(IMLMethod x1306445c04667cc7, IMLDataSet x1c9e132f434262d8)
        {
            string propertyString;
            string str2;
            MLTrainFactory factory = new MLTrainFactory();
            if (0 == 0)
            {
                propertyString = base.Prop.GetPropertyString("ML:TRAIN_type");
                do
                {
                    str2 = base.Prop.GetPropertyString("ML:TRAIN_arguments");
                    EncogLogging.Log(0, "training type:" + propertyString);
                    EncogLogging.Log(0, "training args:" + str2);
                }
                while (0 != 0);
            }
            IMLTrain train = factory.Create(x1306445c04667cc7, x1c9e132f434262d8, propertyString, str2);
            while (this._x33d31451731666c6 > 0)
            {
                return new CrossValidationKFold(train, this._x33d31451731666c6);
            }
            return train;
        }

        private int xdd3322c83e23089c()
        {
            int num;
            string propertyString = base.Prop.GetPropertyString("ML:TRAIN_cross");
            if (-2 != 0)
            {
                if ((((((uint) num) + ((uint) num)) >= 0) || (1 == 0)) && string.IsNullOrEmpty(propertyString))
                {
                    goto Label_0058;
                }
            }
            else if ((((uint) num) - ((uint) num)) >= 0)
            {
                goto Label_0058;
            }
            if (propertyString.ToLower().StartsWith("kfold:"))
            {
                string s = propertyString.Substring(6);
                try
                {
                    return int.Parse(s);
                }
                catch (FormatException)
                {
                    throw new AnalystError("Invalid kfold :" + s);
                }
            }
            throw new AnalystError("Unknown cross validation: " + propertyString);
        Label_0058:
            return 0;
        }

        private IMLMethod xf2f79e06f77a0f33()
        {
            object obj2;
            string propertyString = base.Prop.GetPropertyString("ML:CONFIG_machineLearningFile");
            while (0 != 0)
            {
                if (0 == 0)
                {
                    goto Label_0057;
                }
            Label_0016:
                if (!(obj2 is IMLMethod))
                {
                    throw new AnalystError("The object to be trained must be an instance of MLMethod. " + obj2.GetType().Name);
                }
                if (0 == 0)
                {
                    goto Label_0057;
                }
            }
            obj2 = EncogDirectoryPersistence.LoadObject(base.Script.ResolveFilename(propertyString));
            goto Label_0016;
        Label_0057:
            return (IMLMethod) obj2;
        }

        public override string Name
        {
            get
            {
                return "TRAIN";
            }
        }
    }
}

