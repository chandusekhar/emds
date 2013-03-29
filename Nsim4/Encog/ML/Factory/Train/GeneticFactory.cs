namespace Encog.ML.Factory.Train
{
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Genetic;
    using Encog.Util;
    using System;

    public class GeneticFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            int num;
            double num3;
            IMLTrain train;
            if (!(method is BasicNetwork))
            {
                throw new TrainingError("Invalid method type, requires BasicNetwork");
            }
            ICalculateScore calculateScore = new TrainingSetScore(training);
            do
            {
                ParamsHolder holder = new ParamsHolder(ArchitectureParse.ParseParams(argsStr));
                num = holder.GetInt("population", false, 0x1388);
                double mutationPercent = holder.GetDouble("mutate", false, 0.1);
                num3 = holder.GetDouble("mate", false, 0.25);
                train = new NeuralGeneticAlgorithm((BasicNetwork) method, new RangeRandomizer(-1.0, 1.0), calculateScore, num, mutationPercent, num3);
            }
            while ((((uint) num) - ((uint) num3)) < 0);
            return train;
        }
    }
}

