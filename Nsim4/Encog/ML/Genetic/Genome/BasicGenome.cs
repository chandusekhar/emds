namespace Encog.ML.Genetic.Genome
{
    using Encog.MathUtil;
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Population;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Serializable]
    public abstract class BasicGenome : IGenome, IComparable<IGenome>
    {
        private double _adjustedScore;
        private double _amountToSpawn;
        private readonly IList<Chromosome> _chromosomes = new List<Chromosome>();
        [NonSerialized]
        private GeneticAlgorithm _ga;
        private long _genomeID;
        [NonSerialized]
        private object _organism;
        private IPopulation _population;
        private double _score = 0.0;

        protected BasicGenome()
        {
        }

        public int CalculateGeneCount()
        {
            return this._chromosomes.Sum<Chromosome>(chromosome => chromosome.Genes.Count);
        }

        public int CompareTo(IGenome other)
        {
            if (this._ga != null)
            {
                if (!this._ga.CalculateScore.ShouldMinimize)
                {
                    if (Math.Abs((double) (this.Score - other.Score)) < 1E-07)
                    {
                        return 0;
                    }
                    if (this.Score <= other.Score)
                    {
                        return 1;
                    }
                    return -1;
                }
                if (Math.Abs((double) (this.Score - other.Score)) >= 1E-07)
                {
                    if (this.Score > other.Score)
                    {
                        return 1;
                    }
                    return -1;
                }
                return 0;
            }
            return 0;
        }

        public abstract void Decode();
        public abstract void Encode();
        public void Mate(IGenome father, IGenome child1, IGenome child2)
        {
            int num2;
            int num3;
            object[] objArray;
            int count = this.Chromosomes.Count;
            if (0 == 0)
            {
                goto Label_022F;
            }
        Label_0156:
            if ((((uint) count) + ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num2) + ((uint) count)) > uint.MaxValue)
                {
                    return;
                }
                while (num3 < num2)
                {
                    Chromosome chromosome3;
                    Chromosome chromosome4;
                    Chromosome mother = this._chromosomes[num3];
                    Chromosome chromosome2 = father.Chromosomes[num3];
                    if ((((uint) num2) - ((uint) count)) >= 0)
                    {
                        if ((((uint) num2) + ((uint) num3)) > uint.MaxValue)
                        {
                            goto Label_0218;
                        }
                        chromosome3 = child1.Chromosomes[num3];
                        chromosome4 = child2.Chromosomes[num3];
                        this._ga.Crossover.Mate(mother, chromosome2, chromosome3, chromosome4);
                    }
                    do
                    {
                        if (ThreadSafeRandom.NextDouble() < this._ga.MutationPercent)
                        {
                            this._ga.Mutate.PerformMutation(chromosome3);
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (((uint) num3) > uint.MaxValue);
                    if (ThreadSafeRandom.NextDouble() < this._ga.MutationPercent)
                    {
                        this._ga.Mutate.PerformMutation(chromosome4);
                    }
                    num3++;
                }
            }
            child1.Decode();
            child2.Decode();
            this._ga.PerformCalculateScore(child1);
            this._ga.PerformCalculateScore(child2);
            if ((((uint) num3) + ((uint) count)) >= 0)
            {
                if ((((uint) num2) - ((uint) count)) <= uint.MaxValue)
                {
                    return;
                }
                if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_022F;
                }
                goto Label_020E;
            }
            goto Label_0156;
            do
            {
                if (1 == 0)
                {
                    goto Label_0227;
                }
                if (((uint) count) < 0)
                {
                    goto Label_025D;
                }
            }
            while (((uint) num2) < 0);
        Label_020A:
            num3 = 0;
            goto Label_0156;
        Label_020E:
            objArray[3] = num2;
        Label_0218:
            throw new GeneticError(string.Concat(objArray));
        Label_0227:
            if (count != num2)
            {
                goto Label_0242;
            }
            goto Label_020A;
        Label_022F:
            num2 = father.Chromosomes.Count;
            if (4 != 0)
            {
                goto Label_0227;
            }
        Label_0242:
            objArray = new object[4];
            objArray[0] = "Mother and father must have same chromosome count, Mother:";
            objArray[1] = count;
        Label_025D:
            objArray[2] = ",Father:";
            goto Label_020E;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append(base.GetType().Name);
            builder.Append(": score=");
            builder.Append(this.Score);
            return builder.ToString();
        }

        public double AdjustedScore
        {
            get
            {
                return this._adjustedScore;
            }
            set
            {
                this._adjustedScore = value;
            }
        }

        public double AmountToSpawn
        {
            get
            {
                return this._amountToSpawn;
            }
            set
            {
                this._amountToSpawn = value;
            }
        }

        public IList<Chromosome> Chromosomes
        {
            get
            {
                return this._chromosomes;
            }
        }

        public GeneticAlgorithm GA
        {
            get
            {
                return this._ga;
            }
            set
            {
                this._ga = value;
            }
        }

        public long GenomeID
        {
            get
            {
                return this._genomeID;
            }
            set
            {
                this._genomeID = value;
            }
        }

        public object Organism
        {
            get
            {
                return this._organism;
            }
            set
            {
                this._organism = value;
            }
        }

        public IPopulation Population
        {
            get
            {
                return this._population;
            }
            set
            {
                this._population = value;
            }
        }

        public double Score
        {
            get
            {
                return this._score;
            }
            set
            {
                this._score = value;
            }
        }
    }
}

