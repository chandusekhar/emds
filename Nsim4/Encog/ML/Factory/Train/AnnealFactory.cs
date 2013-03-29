namespace Encog.ML.Factory.Train
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Anneal;
    using Encog.Util;
    using System;

    public class AnnealFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            double num2;
            int num3;
            if (!(method is BasicNetwork))
            {
                throw new TrainingError("Invalid method type, requires BasicNetwork");
            }
            ICalculateScore calculateScore = new TrainingSetScore(training);
            ParamsHolder holder = new ParamsHolder(ArchitectureParse.ParseParams(argsStr));
            double startTemp = holder.GetDouble("startTemp", false, 10.0);
            if (((((uint) num3) & 0) != 0) || ((((uint) num2) - ((uint) num2)) < 0))
            {
                IMLTrain train;
                return train;
            }
            num2 = holder.GetDouble("stopTemp", false, 2.0);
            return new NeuralSimulatedAnnealing((BasicNetwork) method, calculateScore, startTemp, num2, holder.GetInt("cycles", false, 100));
        }
    }
}

