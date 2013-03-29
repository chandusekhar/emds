namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.PNN;
    using Encog.Neural.PNN;
    using System;

    public class PNNTrainFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string args)
        {
            if (!(method is BasicPNN))
            {
                throw new EncogError("PNN training cannot be used on a method of type: " + method.GetType().FullName);
            }
            return new TrainBasicPNN((BasicPNN) method, training);
        }
    }
}

