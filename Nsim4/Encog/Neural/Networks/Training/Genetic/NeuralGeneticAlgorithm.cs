namespace Encog.Neural.Networks.Training.Genetic
{
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Crossover;
    using Encog.ML.Genetic.Mutate;
    using Encog.ML.Genetic.Population;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util.Concurrency;
    using Encog.Util.Logging;
    using System;
    using System.Runtime.CompilerServices;

    public class NeuralGeneticAlgorithm : BasicTraining, IMultiThreadable
    {
        [CompilerGenerated]
        private NeuralGeneticAlgorithmHelper x24219dfa4f240cee;

        public NeuralGeneticAlgorithm(BasicNetwork network, IRandomizer randomizer, ICalculateScore calculateScore, int populationSize, double mutationPercent, double percentToMate) : base(TrainingImplementationType.Iterative)
        {
            NeuralGeneticAlgorithmHelper helper;
        Label_012F:
            helper = new NeuralGeneticAlgorithmHelper();
            helper.CalculateScore = new GeneticScoreAdapter(calculateScore);
            this.Genetic = helper;
            IPopulation population = new BasicPopulation(populationSize);
            this.Genetic.MutationPercent = mutationPercent;
            this.Genetic.MatingPopulation = percentToMate * 2.0;
            this.Genetic.PercentToMate = percentToMate;
            this.Genetic.Crossover = new Splice(network.Structure.CalculateSize() / 3);
            this.Genetic.Mutate = new MutatePerturb(4.0);
            this.Genetic.Population = population;
            int num = 0;
            while (true)
            {
                NeuralGenome genome2;
                if (num < population.PopulationSize)
                {
                    BasicNetwork network2 = (BasicNetwork) network.Clone();
                    randomizer.Randomize(network2);
                    if ((((uint) percentToMate) + ((uint) populationSize)) >= 0)
                    {
                        genome2 = new NeuralGenome(network2) {
                            GA = this.Genetic
                        };
                    }
                }
                else
                {
                    population.Sort();
                    if (((uint) populationSize) <= uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_012F;
                }
                if ((((uint) num) + ((uint) populationSize)) >= 0)
                {
                    NeuralGenome g = genome2;
                    this.Genetic.PerformCalculateScore(g);
                    if (((uint) populationSize) > uint.MaxValue)
                    {
                        goto Label_012F;
                    }
                    this.Genetic.Population.Add(g);
                    num++;
                }
            }
        }

        public sealed override void Iteration()
        {
            EncogLogging.Log(1, "Performing Genetic iteration.");
            base.PreIteration();
            this.Genetic.Iteration();
            this.Error = this.Genetic.Error;
            base.PostIteration();
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public NeuralGeneticAlgorithmHelper Genetic
        {
            [CompilerGenerated]
            get
            {
                return this.x24219dfa4f240cee;
            }
            [CompilerGenerated]
            set
            {
                this.x24219dfa4f240cee = value;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this.Genetic.Method;
            }
        }

        public int ThreadCount
        {
            get
            {
                return this.Genetic.ThreadCount;
            }
            set
            {
                this.Genetic.ThreadCount = value;
            }
        }

        public class NeuralGeneticAlgorithmHelper : BasicGeneticAlgorithm
        {
            public double Error
            {
                get
                {
                    return base.Population.Best.Score;
                }
            }

            public IMLMethod Method
            {
                get
                {
                    return (BasicNetwork) base.Population.Best.Organism;
                }
            }
        }
    }
}

