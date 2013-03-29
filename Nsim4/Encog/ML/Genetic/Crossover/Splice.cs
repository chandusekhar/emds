namespace Encog.ML.Genetic.Crossover
{
    using Encog.MathUtil;
    using Encog.ML.Genetic.Genome;
    using System;

    public class Splice : ICrossover
    {
        private readonly int _x8bd2fc977ef263b3;

        public Splice(int theCutLength)
        {
            this._x8bd2fc977ef263b3 = theCutLength;
        }

        public void Mate(Chromosome mother, Chromosome father, Chromosome offspring1, Chromosome offspring2)
        {
            int num2;
            int num3;
            int num4;
            int count = mother.Genes.Count;
            goto Label_0116;
        Label_0097:
            num4++;
        Label_009B:
            if (num4 >= count)
            {
                int gene = 0;
                if ((((uint) count) & 0) != 0)
                {
                    if (((uint) num3) >= 0)
                    {
                        goto Label_00BB;
                    }
                    goto Label_0097;
                }
                while (true)
                {
                    if (gene >= count)
                    {
                        if ((((uint) num2) + ((uint) count)) < 0)
                        {
                            break;
                        }
                        if ((((uint) num2) - ((uint) num2)) >= 0)
                        {
                            return;
                        }
                        goto Label_0116;
                    }
                    if ((gene < num2) || (gene > num3))
                    {
                        offspring1.GetGene(gene).Copy(mother.GetGene(gene));
                        offspring2.GetGene(gene).Copy(father.GetGene(gene));
                    }
                    gene++;
                }
            }
        Label_00BB:
            if ((num4 >= num2) && (num4 <= num3))
            {
                offspring1.GetGene(num4).Copy(father.GetGene(num4));
                offspring2.GetGene(num4).Copy(mother.GetGene(num4));
                if ((((uint) count) & 0) != 0)
                {
                    goto Label_0116;
                }
            }
            goto Label_0097;
        Label_0116:
            num2 = (int) (ThreadSafeRandom.NextDouble() * (count - this._x8bd2fc977ef263b3));
            num3 = num2 + this._x8bd2fc977ef263b3;
            num4 = 0;
            goto Label_009B;
        }
    }
}

