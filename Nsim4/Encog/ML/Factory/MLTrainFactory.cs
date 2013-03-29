namespace Encog.ML.Factory
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Plugin;
    using System;
    using System.Collections.Generic;

    public class MLTrainFactory
    {
        public const string Cycles = "cycles";
        public const string PropertyBayesianRegularization = "BAYES_REG";
        public const string PropertyC = "C";
        public const string PropertyDimensions = "DIM";
        public const string PropertyEndLearningRate = "END_LR";
        public const string PropertyEndRadius = "END_RADIUS";
        public const string PropertyGamma = "GAMMA";
        public const string PropertyInitialUpdate = "INIT_UPDATE";
        public const string PropertyIterations = "ITERATIONS";
        public const string PropertyLearningMomentum = "MOM";
        public const string PropertyLearningRate = "LR";
        public const string PropertyMate = "mate";
        public const string PropertyMaxStep = "MAX_STEP";
        public const string PropertyMutation = "mutate";
        public const string PropertyNeighborhood = "NEIGHBORHOOD";
        public const string PropertyPopulationSize = "population";
        public const string PropertyPropertyNeighborhood = "NEIGHBORHOOD";
        public const string PropertyRBFType = "RBF_TYPE";
        public const string PropertyStartLearningRate = "START_LR";
        public const string PropertyStartRadius = "START_RADIUS";
        public const string PropertyTemperatureStart = "startTemp";
        public const string PropertyTemperatureStop = "stopTemp";
        public const string TypeAnneal = "anneal";
        public const string TypeBackprop = "backprop";
        public const string TypeGenetic = "genetic";
        public const string TypeLma = "lma";
        public const string TypeManhattan = "manhattan";
        public const string TypePNN = "pnn";
        public const string TypeQPROP = "qprop";
        public const string TypeRPROP = "rprop";
        public const string TypeSCG = "scg";
        public const string TypeSOMCluster = "som-cluster";
        public const string TypeSOMNeighborhood = "som-neighborhood";
        public const string TypeSvd = "rbf-svd";
        public const string TypeSVM = "svm-train";
        public const string TypeSVMSearch = "svm-search";

        public IMLTrain Create(IMLMethod method, IMLDataSet training, string type, string args)
        {
            using (IEnumerator<EncogPluginBase> enumerator = EncogFramework.Instance.Plugins.GetEnumerator())
            {
                EncogPluginBase base2;
                IMLTrain train;
                goto Label_0015;
            Label_0012:
                if (train != null)
                {
                    return train;
                }
            Label_0015:
                if (enumerator.MoveNext())
                {
                    goto Label_0033;
                }
                if (-1 != 0)
                {
                    goto Label_0066;
                }
            Label_0024:
                if (-1 != 0)
                {
                    goto Label_0012;
                }
                return train;
            Label_0033:
                base2 = enumerator.Current;
                if (!(base2 is IEncogPluginService1))
                {
                    goto Label_0015;
                }
                train = ((IEncogPluginService1) base2).CreateTraining(method, training, type, args);
                if (8 != 0)
                {
                    goto Label_0024;
                }
            }
        Label_0066:
            throw new EncogError("Unknown training type: " + type);
        }
    }
}

