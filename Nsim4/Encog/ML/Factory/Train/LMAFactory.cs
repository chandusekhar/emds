namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Lma;
    using Encog.Util;
    using System;

    public class LMAFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            bool flag;
            LevenbergMarquardtTraining training3;
            if (method is BasicNetwork)
            {
                flag = new ParamsHolder(ArchitectureParse.ParseParams(argsStr)).GetBoolean("BAYES_REG", false, false);
                training3 = new LevenbergMarquardtTraining((BasicNetwork) method, training);
                if (3 == 0)
                {
                    LevenbergMarquardtTraining training2;
                    return training2;
                }
            }
            else if (0 == 0)
            {
                throw new EncogError("LMA training cannot be used on a method of type: " + method.GetType().FullName);
            }
            training3.UseBayesianRegularization = flag;
            if (0 == 0)
            {
            }
            return training3;
        }
    }
}

