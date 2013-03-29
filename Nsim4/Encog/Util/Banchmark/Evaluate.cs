namespace Encog.Util.Banchmark
{
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation.Resilient;
    using Encog.Util.Simple;
    using System;
    using System.Diagnostics;

    public class Evaluate
    {
        public const int Milis = 0x3e8;

        public static int EvaluateTrain(BasicNetwork network, IMLDataSet training)
        {
            int num;
            IMLTrain train = new ResilientPropagation(network, training);
            if (0 == 0)
            {
                num = 0;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 0x2710L)
            {
                num++;
                train.Iteration();
            }
            return num;
        }

        public static int EvaluateTrain(int input, int hidden1, int hidden2, int output)
        {
            BasicNetwork network = EncogUtility.SimpleFeedForward(input, hidden1, hidden2, output, true);
            IMLDataSet training = RandomTrainingFactory.Generate(0x3e8L, 0x2710, input, output, -1.0, 1.0);
            return EvaluateTrain(network, training);
        }
    }
}

