namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.SOM;
    using Encog.Neural.Som.Training.Clustercopy;
    using System;

    public class ClusterSOMFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            if (!(method is SOMNetwork))
            {
                throw new EncogError("Cluster SOM training cannot be used on a method of type: " + method.GetType().FullName);
            }
            return new SOMClusterCopyTraining((SOMNetwork) method, training);
        }
    }
}

