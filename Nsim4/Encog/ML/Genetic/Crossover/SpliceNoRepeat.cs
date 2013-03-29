namespace Encog.ML.Genetic.Crossover
{
    using Encog.MathUtil;
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpliceNoRepeat : ICrossover
    {
        private readonly int _x8bd2fc977ef263b3;

        public SpliceNoRepeat(int cutLength)
        {
            this._x8bd2fc977ef263b3 = cutLength;
        }

        public void Mate(Chromosome mother, Chromosome father, Chromosome offspring1, Chromosome offspring2)
        {
            int num2;
            int num3;
            IList<IGene> list;
            IList<IGene> list2;
            int num4;
            int num5;
            int count = father.Genes.Count;
            goto Label_0148;
        Label_002C:
            num5++;
        Label_0032:
            if (num5 < count)
            {
                if (num5 < num2)
                {
                    goto Label_0047;
                }
                if ((((uint) num2) + ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_0162;
                }
            }
            else
            {
                if (0 == 0)
                {
                    return;
                }
                goto Label_0148;
            }
        Label_0042:
            if (num5 <= num3)
            {
                goto Label_002C;
            }
        Label_0047:
            offspring1.Genes[num5].Copy(x1a4a8d31470092e5(mother, list));
            if (-1 != 0)
            {
                offspring2.Genes[num5].Copy(x1a4a8d31470092e5(father, list2));
                goto Label_002C;
            }
            return;
        Label_00A6:
            if (num4 >= count)
            {
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_00CE;
                }
                num5 = 0;
                if ((((uint) num3) + ((uint) count)) < 0)
                {
                    goto Label_0042;
                }
                goto Label_0032;
            }
            if ((num4 >= num2) && (num4 <= num3))
            {
                offspring1.Genes[num4].Copy(father.Genes[num4]);
                offspring2.Genes[num4].Copy(mother.Genes[num4]);
                list.Add(offspring1.Genes[num4]);
                list2.Add(offspring2.Genes[num4]);
            }
        Label_00CE:
            num4++;
            goto Label_00A6;
        Label_0148:
            num2 = (int) (ThreadSafeRandom.NextDouble() * (count - this._x8bd2fc977ef263b3));
            num3 = num2 + this._x8bd2fc977ef263b3;
        Label_0162:
            list = new List<IGene>();
            list2 = new List<IGene>();
            num4 = 0;
            goto Label_00A6;
        }

        private static IGene x1a4a8d31470092e5(Chromosome x337e217cb3ba0627, IList<IGene> xa41924b42e357ba2)
        {
            IGene gene;
            int count = x337e217cb3ba0627.Genes.Count;
            int num2 = 0;
        Label_0030:
            if (num2 < count)
            {
                gene = x337e217cb3ba0627.Genes[num2];
            }
            else if ((((uint) num2) | 1) != 0)
            {
                goto Label_0081;
            }
            bool flag = xa41924b42e357ba2.Contains<IGene>(gene);
            if ((((uint) flag) + ((uint) count)) <= uint.MaxValue)
            {
                if (((uint) count) >= 0)
                {
                }
                if (!flag)
                {
                    xa41924b42e357ba2.Add(gene);
                    return gene;
                }
                num2++;
                goto Label_0030;
            }
        Label_0081:
            return null;
        }
    }
}

