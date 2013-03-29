namespace Encog.ML.Genetic.Crossover
{
    using Encog.ML.Genetic.Genome;
    using System;

    public interface ICrossover
    {
        void Mate(Chromosome mother, Chromosome father, Chromosome offspring1, Chromosome offspring2);
    }
}

