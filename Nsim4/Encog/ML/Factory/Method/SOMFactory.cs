namespace Encog.ML.Factory.Method
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Factory.Parse;
    using Encog.Neural.Pattern;
    using System;
    using System.Collections.Generic;

    public class SOMFactory
    {
        public IMLMethod Create(string architecture, int input, int output)
        {
            int count;
            int num2;
            SOMPattern pattern2;
            IList<string> list = ArchitectureParse.ParseLayers(architecture);
            if ((((uint) count) - ((uint) input)) >= 0)
            {
                while (list.Count != 2)
                {
                    throw new EncogError("SOM's must have exactly two elements, separated by ->.");
                }
                if ((((uint) input) + ((uint) input)) <= uint.MaxValue)
                {
                    ArchitectureLayer layer = ArchitectureParse.ParseLayer(list[0], input);
                    ArchitectureLayer layer2 = ArchitectureParse.ParseLayer(list[1], output);
                    if ((((uint) count) + ((uint) count)) >= 0)
                    {
                        count = layer.Count;
                        num2 = layer2.Count;
                        pattern2 = new SOMPattern();
                    }
                }
                else
                {
                    goto Label_00B9;
                }
                pattern2.InputNeurons = count;
            }
            pattern2.OutputNeurons = num2;
            SOMPattern pattern = pattern2;
        Label_00B9:
            return pattern.Generate();
        }
    }
}

