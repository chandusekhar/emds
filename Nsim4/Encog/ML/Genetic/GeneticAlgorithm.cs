namespace Encog.ML.Genetic
{
    using Encog.ML;
    using Encog.ML.Genetic.Crossover;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Mutate;
    using Encog.ML.Genetic.Population;
    using Encog.ML.Genetic.Species;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class GeneticAlgorithm : IMultiThreadable
    {
        private ICalculateGenomeScore _x2308f8c4f898a271;
        [CompilerGenerated]
        private IMutate x190c7daa1078a7bc;
        [CompilerGenerated]
        private double x350e99e0d556475d;
        [CompilerGenerated]
        private GenomeComparator x6a98b8f95b4f737a;
        [CompilerGenerated]
        private IPopulation x79b1f4547cb78d52;
        [CompilerGenerated]
        private double xae0cbc8e9b63245c;
        [CompilerGenerated]
        private ICrossover xba0c0c9da183d9b7;
        [CompilerGenerated]
        private double xc9f0e9665c6230bf;
        [CompilerGenerated]
        private int xd52bb976708dc8fe;

        protected GeneticAlgorithm()
        {
        }

        public void AddSpeciesMember(ISpecies species, IGenome genome)
        {
            if (this.Comparator.IsBetterThan(genome.Score, species.BestScore))
            {
                species.BestScore = genome.Score;
                species.GensNoImprovement = 0;
                species.Leader = genome;
            }
            species.Members.Add(genome);
        }

        public abstract void Iteration();
        public void PerformCalculateScore(IGenome g)
        {
            if (g.Organism is IMLContext)
            {
                ((IMLContext) g.Organism).ClearContext();
            }
            double num = this._x2308f8c4f898a271.CalculateScore(g);
            g.Score = num;
        }

        public ICalculateGenomeScore CalculateScore
        {
            get
            {
                return this._x2308f8c4f898a271;
            }
            set
            {
                this._x2308f8c4f898a271 = value;
            }
        }

        public GenomeComparator Comparator
        {
            [CompilerGenerated]
            get
            {
                return this.x6a98b8f95b4f737a;
            }
            [CompilerGenerated]
            set
            {
                this.x6a98b8f95b4f737a = value;
            }
        }

        public ICrossover Crossover
        {
            [CompilerGenerated]
            get
            {
                return this.xba0c0c9da183d9b7;
            }
            [CompilerGenerated]
            set
            {
                this.xba0c0c9da183d9b7 = value;
            }
        }

        public double MatingPopulation
        {
            [CompilerGenerated]
            get
            {
                return this.x350e99e0d556475d;
            }
            [CompilerGenerated]
            set
            {
                this.x350e99e0d556475d = value;
            }
        }

        public IMutate Mutate
        {
            [CompilerGenerated]
            get
            {
                return this.x190c7daa1078a7bc;
            }
            [CompilerGenerated]
            set
            {
                this.x190c7daa1078a7bc = value;
            }
        }

        public double MutationPercent
        {
            [CompilerGenerated]
            get
            {
                return this.xae0cbc8e9b63245c;
            }
            [CompilerGenerated]
            set
            {
                this.xae0cbc8e9b63245c = value;
            }
        }

        public double PercentToMate
        {
            [CompilerGenerated]
            get
            {
                return this.xc9f0e9665c6230bf;
            }
            [CompilerGenerated]
            set
            {
                this.xc9f0e9665c6230bf = value;
            }
        }

        public IPopulation Population
        {
            [CompilerGenerated]
            get
            {
                return this.x79b1f4547cb78d52;
            }
            [CompilerGenerated]
            set
            {
                this.x79b1f4547cb78d52 = value;
            }
        }

        public int ThreadCount
        {
            [CompilerGenerated]
            get
            {
                return this.xd52bb976708dc8fe;
            }
            [CompilerGenerated]
            set
            {
                this.xd52bb976708dc8fe = value;
            }
        }
    }
}

