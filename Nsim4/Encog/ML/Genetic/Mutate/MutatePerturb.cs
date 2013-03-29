namespace Encog.ML.Genetic.Mutate
{
    using Encog.MathUtil;
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using System;
    using System.Collections.Generic;

    public class MutatePerturb : IMutate
    {
        private readonly double _x0133fea5e9a09a63;

        public MutatePerturb(double thePerturbAmount)
        {
            this._x0133fea5e9a09a63 = thePerturbAmount;
        }

        public void PerformMutation(Chromosome chromosome)
        {
            using (List<IGene>.Enumerator enumerator = chromosome.Genes.GetEnumerator())
            {
                IGene gene;
                DoubleGene gene2;
                double num;
                goto Label_0031;
            Label_000E:
                if (0 != 0)
                {
                    goto Label_003C;
                }
                if (0 != 0)
                {
                    goto Label_009D;
                }
                goto Label_0031;
            Label_0019:
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_000E;
                }
            Label_0031:
                if (enumerator.MoveNext())
                {
                    goto Label_008C;
                }
                goto Label_0046;
            Label_003C:
                if (gene is DoubleGene)
                {
                    goto Label_0096;
                }
                goto Label_0019;
            Label_0046:
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    return;
                }
                goto Label_008C;
            Label_0060:
                num += this._x0133fea5e9a09a63 - ((ThreadSafeRandom.NextDouble() * this._x0133fea5e9a09a63) * 2.0);
                gene2.Value = num;
                goto Label_000E;
            Label_008C:
                gene = enumerator.Current;
                goto Label_003C;
            Label_0096:
                gene2 = (DoubleGene) gene;
            Label_009D:
                num = gene2.Value;
                goto Label_0060;
            }
        }
    }
}

