namespace Encog.Neural.Networks.Training.Genetic
{
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Structure;
    using System;

    public class NeuralGenome : BasicGenome
    {
        private readonly Chromosome _x8b1a2d051765aa13;

        public NeuralGenome(BasicNetwork network)
        {
            int num;
            int num2;
            goto Label_0058;
        Label_0008:
            if (num2 >= num)
            {
                if ((((uint) num2) & 0) == 0)
                {
                    base.Chromosomes.Add(this._x8b1a2d051765aa13);
                    this.Encode();
                    return;
                }
                goto Label_0058;
            }
            IGene item = new DoubleGene();
            this._x8b1a2d051765aa13.Genes.Add(item);
        Label_0052:
            num2++;
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0008;
            }
            return;
        Label_0058:
            base.Organism = network;
            this._x8b1a2d051765aa13 = new Chromosome();
            num = network.Structure.CalculateSize();
            num2 = 0;
            if (0 != 0)
            {
                goto Label_0052;
            }
            goto Label_0008;
        }

        public sealed override void Decode()
        {
            int num;
            double[] array = new double[this._x8b1a2d051765aa13.Genes.Count];
        Label_0041:
            num = 0;
        Label_0018:
            if (num < array.Length)
            {
                DoubleGene gene = (DoubleGene) this._x8b1a2d051765aa13.Genes[num];
                array[num] = gene.Value;
                num++;
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    if ((((uint) num) & 0) != 0)
                    {
                        return;
                    }
                    goto Label_0018;
                }
            }
            NetworkCODEC.ArrayToNetwork(array, (BasicNetwork) base.Organism);
            if (((uint) num) <= uint.MaxValue)
            {
                return;
            }
            goto Label_0041;
        }

        public sealed override void Encode()
        {
            double[] numArray = NetworkCODEC.NetworkToArray((BasicNetwork) base.Organism);
            int gene = 0;
            if ((((uint) gene) + ((uint) gene)) <= uint.MaxValue)
            {
            }
            while (gene < numArray.Length)
            {
                ((DoubleGene) this._x8b1a2d051765aa13.GetGene(gene)).Value = numArray[gene];
                gene++;
            }
        }
    }
}

