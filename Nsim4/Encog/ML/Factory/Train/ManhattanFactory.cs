namespace Encog.ML.Factory.Train
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation.Manhattan;
    using Encog.Util;
    using System;

    public class ManhattanFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            double learnRate = new ParamsHolder(ArchitectureParse.ParseParams(argsStr)).GetDouble("LR", false, 0.1);
            return new ManhattanPropagation((BasicNetwork) method, training, learnRate);
        }
    }
}

