namespace Encog.ML.Factory.Train
{
    using Encog;
    using Encog.MathUtil.RBF;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Parse;
    using Encog.ML.SVM;
    using Encog.ML.Train;
    using Encog.Neural.SOM;
    using Encog.Neural.SOM.Training.Neighborhood;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;

    public class NeighborhoodSOMFactory
    {
        public IMLTrain Create(IMLMethod method, IMLDataSet training, string argsStr)
        {
            IDictionary<string, string> dictionary;
            ParamsHolder holder;
            double num;
            string str;
            string str2;
            RBFEnum mexicanHat;
            INeighborhoodFunction function;
            string str3;
            int[] numArray;
            BasicTrainSOM nsom;
            int num2;
            double num3;
            double num4;
            double num6;
            if (method is SupportVectorMachine)
            {
                dictionary = ArchitectureParse.ParseParams(argsStr);
                holder = new ParamsHolder(dictionary);
                num = holder.GetDouble("LR", false, 0.7);
                str = holder.GetString("NEIGHBORHOOD", false, "rbf");
                if (2 != 0)
                {
                    goto Label_03DF;
                }
                goto Label_039F;
            }
            goto Label_03F4;
        Label_0083:
            num4 = holder.GetDouble("END_LR", false, 0.05);
            double startRadius = holder.GetDouble("START_RADIUS", false, 10.0);
            if ((((uint) num4) + ((uint) num4)) > uint.MaxValue)
            {
                return nsom;
            }
            if ((((uint) num3) + ((uint) num2)) <= uint.MaxValue)
            {
                num6 = holder.GetDouble("END_RADIUS", false, 1.0);
                nsom.SetAutoDecay(num2, num3, num4, startRadius, num6);
                return nsom;
            }
        Label_00E4:
            if (4 == 0)
            {
                if ((((uint) num3) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0292;
                }
                goto Label_02F8;
            }
        Label_00EE:
            nsom = new BasicTrainSOM((SOMNetwork) method, num, training, function);
            do
            {
                if (dictionary.ContainsKey("ITERATIONS"))
                {
                    do
                    {
                        num2 = holder.GetInt("ITERATIONS", false, 0x3e8);
                        num3 = holder.GetDouble("START_LR", false, 0.05);
                    }
                    while ((((uint) num3) | 15) == 0);
                    goto Label_0083;
                }
            }
            while ((((uint) num6) | 0xff) == 0);
            if (0 == 0)
            {
                if ((((uint) num3) + ((uint) num3)) >= 0)
                {
                    return nsom;
                }
                goto Label_03F4;
            }
            if ((((uint) num2) - ((uint) startRadius)) <= uint.MaxValue)
            {
                goto Label_00E4;
            }
            goto Label_0083;
        Label_0184:
            if (!str.Equals("single", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_00EE;
            }
            function = new NeighborhoodSingle();
            if ((((uint) num6) - ((uint) num3)) >= 0)
            {
                if ((((uint) num) - ((uint) startRadius)) >= 0)
                {
                    goto Label_00E4;
                }
                goto Label_0324;
            }
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_0233;
            }
        Label_01E2:
            while (!str.Equals("rbf1d", StringComparison.InvariantCultureIgnoreCase))
            {
                if (0 == 0)
                {
                    if ((((uint) num3) - ((uint) num6)) >= 0)
                    {
                        goto Label_0184;
                    }
                    goto Label_0233;
                }
            }
            function = new NeighborhoodRBF1D(mexicanHat);
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                if (((uint) num6) < 0)
                {
                    goto Label_01E2;
                }
                goto Label_0184;
            }
            if (((uint) num2) < 0)
            {
                goto Label_03DF;
            }
            goto Label_01E2;
        Label_0233:
            function = new NeighborhoodRBF(numArray, mexicanHat);
            goto Label_0184;
        Label_0243:
            if (!str.Equals("rbf", StringComparison.InvariantCultureIgnoreCase))
            {
                if ((((uint) num2) & 0) != 0)
                {
                    goto Label_03DF;
                }
                goto Label_01E2;
            }
        Label_0292:
            str3 = holder.GetString("DIM", true, null);
            if ((((uint) num3) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0292;
            }
            numArray = NumberList.FromListInt(CSVFormat.EgFormat, str3);
            if ((((uint) num6) & 0) == 0)
            {
                goto Label_0233;
            }
            goto Label_0243;
        Label_02F8:
            if (str.Equals("bubble", StringComparison.InvariantCultureIgnoreCase))
            {
                function = new NeighborhoodBubble(1);
                goto Label_0184;
            }
            if ((((uint) num3) & 0) == 0)
            {
                goto Label_0243;
            }
            goto Label_0292;
        Label_0324:
            function = null;
            goto Label_02F8;
        Label_0362:
            mexicanHat = RBFEnum.Multiquadric;
            goto Label_0324;
        Label_039F:
            mexicanHat = RBFEnum.Gaussian;
            goto Label_0324;
        Label_03DF:
            str2 = holder.GetString("RBF_TYPE", false, "gaussian");
            if (str2.Equals("Gaussian", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_039F;
            }
            if (((uint) startRadius) <= uint.MaxValue)
            {
                if (str2.Equals("Multiquadric", StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_0362;
                }
                if (!str2.Equals("InverseMultiquadric", StringComparison.InvariantCultureIgnoreCase) || ((((uint) num2) + ((uint) num2)) < 0))
                {
                    if (str2.Equals("MexicanHat", StringComparison.InvariantCultureIgnoreCase))
                    {
                        mexicanHat = RBFEnum.MexicanHat;
                    }
                    else
                    {
                        mexicanHat = RBFEnum.Gaussian;
                    }
                    goto Label_0324;
                }
            }
            else if (((uint) num3) <= uint.MaxValue)
            {
                goto Label_0362;
            }
            if ((((uint) num3) - ((uint) num3)) <= uint.MaxValue)
            {
                mexicanHat = RBFEnum.InverseMultiquadric;
                goto Label_0324;
            }
            goto Label_00E4;
        Label_03F4:
            throw new EncogError("Neighborhood training cannot be used on a method of type: " + method.GetType().FullName);
        }
    }
}

