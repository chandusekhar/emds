namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.SVM;
    using Encog.ML.SVM.Training;
    using Encog.ML.Train;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class SVMFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            if (!(method is SupportVectorMachine))
            {
                throw new EncogError("SVM Train training cannot be used on a method of type: " + method.GetType().FullName);
            }
            double defaultValue = 1.0 / ((double) ((SupportVectorMachine) method).InputCount);
            while (true)
            {
                double num4;
                SVMTrain train;
                double num2 = 1.0;
                IDictionary<string, string> theParams = ArchitectureParse.ParseParams(argsStr);
                ParamsHolder holder = new ParamsHolder(theParams);
                double num3 = holder.GetDouble("GAMMA", false, defaultValue);
                do
                {
                    num4 = holder.GetDouble("C", false, num2);
                    train = new SVMTrain((SupportVectorMachine) method, training) {
                        Gamma = num3
                    };
                }
                while (((uint) defaultValue) > uint.MaxValue);
                if ((((uint) num2) + ((uint) num3)) <= uint.MaxValue)
                {
                    train.C = num4;
                    return train;
                }
            }
        }
    }
}

