namespace Encog.ML.Genetic
{
    using Encog.MathUtil;
    using Encog.ML.Genetic.Genome;
    using Encog.Util.Concurrency;
    using System;

    public class BasicGeneticAlgorithm : GeneticAlgorithm
    {
        private bool _x62584df2cb5d40dd = true;

        public sealed override void Iteration()
        {
            int num;
            int num2;
            int num3;
            int num4;
            TaskGroup group;
            int num5;
            IGenome genome;
            IGenome genome2;
            IGenome genome3;
            IGenome genome4;
            if (!this._x62584df2cb5d40dd)
            {
                goto Label_016F;
            }
            if ((((uint) num3) + ((uint) num2)) >= 0)
            {
                EngineConcurrency.Instance.ThreadCount = base.ThreadCount;
                base.Population.Claim(this);
                this._x62584df2cb5d40dd = false;
                goto Label_016F;
            }
            goto Label_008B;
        Label_0083:
            if (num5 < num)
            {
                int num6;
                genome = base.Population.Genomes[num5];
                do
                {
                    num6 = (int) (ThreadSafeRandom.NextDouble() * num4);
                }
                while ((((uint) num) + ((uint) num6)) < 0);
                genome2 = base.Population.Genomes[num6];
                goto Label_00FB;
            }
            if (0 == 0)
            {
                group.WaitForComplete();
                base.Population.Sort();
                return;
            }
        Label_008B:
            genome4 = base.Population.Genomes[num3 + 1];
            MateWorker task = new MateWorker(genome, genome2, genome3, genome4);
            EngineConcurrency.Instance.ProcessTask(task, group);
            num3 += 2;
            num5++;
            if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_0184;
            }
            goto Label_0083;
        Label_00FB:
            genome3 = base.Population.Genomes[num3];
            goto Label_008B;
        Label_016F:
            num = (int) (base.Population.PopulationSize * base.PercentToMate);
        Label_0184:
            num2 = num * 2;
            num3 = base.Population.PopulationSize - num2;
            num4 = (int) (base.Population.PopulationSize * base.MatingPopulation);
            if (0 != 0)
            {
                goto Label_00FB;
            }
            group = EngineConcurrency.Instance.CreateTaskGroup();
            num5 = 0;
            goto Label_0083;
        }
    }
}

