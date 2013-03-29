namespace Encog.ML.Factory.Method
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Factory.Parse;
    using Encog.Neural;
    using Encog.Neural.PNN;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class PNNFactory
    {
        public const int MaxLayers = 3;

        public IMLMethod Create(string architecture, int input, int output)
        {
            ArchitectureLayer layer3;
            int count;
            int num2;
            PNNKernelType reciprocal;
            PNNOutputMode classification;
            ParamsHolder holder;
            string str;
            IList<string> list = ArchitectureParse.ParseLayers(architecture);
            if (list.Count != 3)
            {
                throw new EncogError("PNN Networks must have exactly three elements, separated by ->.");
            }
            ArchitectureLayer layer = ArchitectureParse.ParseLayer(list[0], input);
            ArchitectureLayer layer2 = ArchitectureParse.ParseLayer(list[1], -1);
            goto Label_015F;
        Label_000C:
            if (str.Equals("reciprocal", StringComparison.InvariantCultureIgnoreCase))
            {
                reciprocal = PNNKernelType.Reciprocal;
            }
            else
            {
                throw new NeuralNetworkError("Unknown kernel: " + str);
            }
        Label_0032:
            return new BasicPNN(reciprocal, classification, count, num2);
        Label_0089:
            throw new NeuralNetworkError("Unknown model: " + layer2.Name);
        Label_009F:
            holder = new ParamsHolder(layer2.Params);
            str = holder.GetString("KERNEL", false, "gaussian");
            if ((((uint) num2) & 0) == 0)
            {
                if (str.Equals("gaussian", StringComparison.InvariantCultureIgnoreCase))
                {
                    reciprocal = PNNKernelType.Gaussian;
                    if ((((uint) num2) - ((uint) input)) > uint.MaxValue)
                    {
                        goto Label_0089;
                    }
                    goto Label_0032;
                }
                goto Label_000C;
            }
        Label_015F:
            layer3 = ArchitectureParse.ParseLayer(list[2], output);
            count = layer.Count;
            num2 = layer3.Count;
            if ((((uint) input) & 0) != 0)
            {
                goto Label_0089;
            }
            if (!layer2.Name.Equals("c", StringComparison.InvariantCultureIgnoreCase))
            {
                if (layer2.Name.Equals("r", StringComparison.InvariantCultureIgnoreCase))
                {
                    classification = PNNOutputMode.Regression;
                    if ((((uint) output) + ((uint) num2)) < 0)
                    {
                        goto Label_000C;
                    }
                    goto Label_009F;
                }
                if (layer2.Name.Equals("u", StringComparison.InvariantCultureIgnoreCase))
                {
                    classification = PNNOutputMode.Unsupervised;
                    goto Label_009F;
                }
                goto Label_0089;
            }
            classification = PNNOutputMode.Classification;
            goto Label_009F;
        }
    }
}

