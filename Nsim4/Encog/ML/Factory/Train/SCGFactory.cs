namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation.SCG;
    using System;

    public class SCGFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string args)
        {
            if (!(method is BasicNetwork))
            {
                throw new EncogError("SCG training cannot be used on a method of type: " + method.GetType().FullName);
            }
            return new ScaledConjugateGradient((BasicNetwork) method, training);
        }
    }
}

