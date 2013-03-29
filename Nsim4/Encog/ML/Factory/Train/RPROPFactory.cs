namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation.Resilient;
    using Encog.Util;
    using System;

    public class RPROPFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            if (method is IContainsFlat)
            {
                ParamsHolder holder = new ParamsHolder(ArchitectureParse.ParseParams(argsStr));
                double initialUpdate = holder.GetDouble("INIT_UPDATE", false, 0.1);
                double maxStep = holder.GetDouble("MAX_STEP", false, 50.0);
                if ((((uint) initialUpdate) - ((uint) maxStep)) >= 0)
                {
                    return new ResilientPropagation((IContainsFlat) method, training, initialUpdate, maxStep);
                }
            }
            throw new EncogError("RPROP training cannot be used on a method of type: " + method.GetType().FullName);
        }
    }
}

