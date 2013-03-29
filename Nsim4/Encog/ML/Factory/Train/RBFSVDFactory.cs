namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.RBF;
    using Encog.Neural.Rbf.Training;
    using System;

    public class RBFSVDFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string args)
        {
            if (!(method is RBFNetwork))
            {
                throw new EncogError("RBF-SVD training cannot be used on a method of type: " + method.GetType().FullName);
            }
            return new SVDTraining((RBFNetwork) method, training);
        }
    }
}

