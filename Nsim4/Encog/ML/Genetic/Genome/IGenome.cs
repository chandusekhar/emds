namespace Encog.ML.Genetic.Genome
{
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Population;
    using System;
    using System.Collections.Generic;

    public interface IGenome : IComparable<IGenome>
    {
        int CalculateGeneCount();
        void Decode();
        void Encode();
        void Mate(IGenome father, IGenome child1, IGenome child2);

        double AdjustedScore { get; set; }

        double AmountToSpawn { get; set; }

        IList<Chromosome> Chromosomes { get; }

        GeneticAlgorithm GA { get; set; }

        long GenomeID { get; set; }

        object Organism { get; }

        IPopulation Population { get; set; }

        double Score { get; set; }
    }
}

