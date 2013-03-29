namespace Encog.ML.Factory.Method
{
    using Encog;
    using Encog.MathUtil.RBF;
    using Encog.ML;
    using Encog.ML.Factory.Parse;
    using Encog.Neural.RBF;
    using System;
    using System.Collections.Generic;

    public class SRNFactory
    {
        public const int MaxLayers = 3;

        public IMLMethod Create(string architecture, int input, int output)
        {
            ArchitectureLayer layer2;
            int count;
            int num2;
            RBFEnum gaussian;
            IList<string> list = ArchitectureParse.ParseLayers(architecture);
            if ((((uint) output) + ((uint) count)) >= 0)
            {
                if (list.Count != 3)
                {
                    throw new EncogError("SRN Networks must have exactly three elements, separated by ->.");
                }
                ArchitectureLayer layer = ArchitectureParse.ParseLayer(list[0], input);
                layer2 = ArchitectureParse.ParseLayer(list[1], -1);
                ArchitectureLayer layer3 = ArchitectureParse.ParseLayer(list[2], output);
                count = layer.Count;
                do
                {
                    num2 = layer3.Count;
                }
                while ((((uint) count) - ((uint) output)) < 0);
                if (layer2.Name.Equals("Gaussian", StringComparison.InvariantCultureIgnoreCase))
                {
                    gaussian = RBFEnum.Gaussian;
                    goto Label_003E;
                }
                if (layer2.Name.Equals("Multiquadric", StringComparison.InvariantCultureIgnoreCase))
                {
                    gaussian = RBFEnum.Multiquadric;
                    goto Label_003E;
                }
                while (layer2.Name.Equals("InverseMultiquadric", StringComparison.InvariantCultureIgnoreCase))
                {
                    gaussian = RBFEnum.InverseMultiquadric;
                    if (0 == 0)
                    {
                        goto Label_003E;
                    }
                    if (2 == 0)
                    {
                        goto Label_0055;
                    }
                }
                goto Label_005A;
            }
            if (((uint) num2) >= 0)
            {
                goto Label_005A;
            }
        Label_0034:
            if (0x7fffffff != 0)
            {
            }
        Label_003E:
            return new RBFNetwork(count, layer2.Count, num2, gaussian);
        Label_0055:
            gaussian = RBFEnum.MexicanHat;
            goto Label_003E;
        Label_005A:
            if (layer2.Name.Equals("MexicanHat", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_0055;
            }
            gaussian = RBFEnum.Gaussian;
            goto Label_0034;
        }
    }
}

