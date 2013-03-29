namespace Encog.ML.Genetic.Mutate
{
    using Encog.MathUtil;
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using System;

    public class MutateShuffle : IMutate
    {
        public void PerformMutation(Chromosome chromosome)
        {
            int num2;
            int num3;
            int num4;
            IGene gene;
            IGene gene2;
            int count = chromosome.Genes.Count;
            if ((((uint) count) - ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_010A;
            }
        Label_0027:
            gene2 = chromosome.Genes[num3];
            chromosome.Genes.Remove(gene);
            chromosome.Genes.Remove(gene2);
            chromosome.Genes.Insert(num2, gene2);
        Label_005F:
            chromosome.Genes.Insert(num3, gene);
            if ((((uint) count) + ((uint) num4)) >= 0)
            {
                return;
            }
            goto Label_010A;
        Label_008F:
            if (num2 > num3)
            {
                num4 = num2;
                num2 = num3;
                num3 = num4;
                if (((uint) num4) < 0)
                {
                    goto Label_0027;
                }
            }
        Label_0093:
            gene = chromosome.Genes[num2];
            goto Label_0027;
        Label_00B9:
            num2++;
            if ((((uint) num4) + ((uint) num3)) >= 0)
            {
                goto Label_008F;
            }
        Label_010A:
            num2 = (int) (ThreadSafeRandom.NextDouble() * count);
            num3 = (int) (ThreadSafeRandom.NextDouble() * count);
            if (num2 == num3)
            {
                if (num2 > 0)
                {
                    num2--;
                    if ((((uint) num2) | 0x7fffffff) != 0)
                    {
                        if ((((uint) num4) & 0) != 0)
                        {
                            goto Label_005F;
                        }
                        goto Label_008F;
                    }
                }
                else
                {
                    goto Label_00B9;
                }
                if (((uint) num4) > uint.MaxValue)
                {
                    goto Label_0093;
                }
                if ((((uint) num3) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_00B9;
                }
            }
            goto Label_008F;
        }
    }
}

