namespace Encog.Neural.Networks.Training
{
    using Encog.Neural;
    using System;

    [Serializable]
    public class TrainingError : NeuralNetworkError
    {
        public TrainingError(Exception t) : base(t)
        {
        }

        public TrainingError(string msg) : base(msg)
        {
        }
    }
}

