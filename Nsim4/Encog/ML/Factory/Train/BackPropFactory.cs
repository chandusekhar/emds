namespace Encog.ML.Factory.Train
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation.Back;
    using Encog.Util;
    using System;

    public class BackPropFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            ParamsHolder holder = new ParamsHolder(ArchitectureParse.ParseParams(argsStr));
            double learnRate = holder.GetDouble("LR", false, 0.7);
            return new Backpropagation((BasicNetwork) method, training, learnRate, holder.GetDouble("MOM", false, 0.3));
        }
    }
}

