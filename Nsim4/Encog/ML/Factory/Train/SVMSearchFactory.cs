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

    public class SVMSearchFactory
    {
        public const string PropertyC1 = "C1";
        public const string PropertyC2 = "C2";
        public const string PropertyCStep = "CSTEP";
        public const string PropertyGamma1 = "GAMMA1";
        public const string PropertyGamma2 = "GAMMA2";
        public const string PropertyGammaStep = "GAMMASTEP";

        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            ParamsHolder holder;
            double num;
            double num2;
            double num3;
            double num4;
            double num5;
            double num6;
            SVMSearchTrain train2;
            if (method is SupportVectorMachine)
            {
                IDictionary<string, string> theParams = ArchitectureParse.ParseParams(argsStr);
                new ParamsHolder(theParams);
                if ((((uint) num3) - ((uint) num4)) < 0)
                {
                    goto Label_0053;
                }
                if ((((uint) num2) + ((uint) num6)) <= uint.MaxValue)
                {
                    holder = new ParamsHolder(theParams);
                    num = holder.GetDouble("GAMMA1", false, -10.0);
                    num2 = holder.GetDouble("C1", false, -5.0);
                    goto Label_0101;
                }
                goto Label_016E;
            }
            goto Label_0185;
        Label_0053:
            train2.GammaEnd = num3;
            if ((((uint) num5) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0185;
            }
            train2.GammaStep = num5;
            if (((uint) num3) >= 0)
            {
                train2.ConstBegin = num2;
                train2.ConstEnd = num4;
                if ((((uint) num4) | 3) != 0)
                {
                    train2.ConstStep = num6;
                    return train2;
                }
            }
            else
            {
                return train2;
            }
        Label_0101:
            num3 = holder.GetDouble("GAMMA2", false, 10.0);
            num4 = holder.GetDouble("C2", false, 15.0);
        Label_016E:
            if (((uint) num4) <= uint.MaxValue)
            {
                num5 = holder.GetDouble("GAMMASTEP", false, 1.0);
                num6 = holder.GetDouble("CSTEP", false, 2.0);
                train2 = new SVMSearchTrain((SupportVectorMachine) method, training) {
                    GammaBegin = num
                };
            }
            goto Label_0053;
        Label_0185:
            throw new EncogError("SVM Train training cannot be used on a method of type: " + method.GetType().FullName);
        }
    }
}

