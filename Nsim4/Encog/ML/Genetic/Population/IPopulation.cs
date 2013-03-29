namespace Encog.ML.Genetic.Population
{
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Innovation;
    using System;
    using System.Collections.Generic;

    public interface IPopulation
    {
        void Add(IGenome genome);
        long AssignGeneID();
        long AssignGenomeID();
        long AssignInnovationID();
        long AssignSpeciesID();
        void Claim(GeneticAlgorithm ga);
        void Clear();
        IGenome Get(int i);
        int Size();
        void Sort();

        IGenome Best { get; }

        IList<IGenome> Genomes { get; }

        IInnovationList Innovations { get; set; }

        double OldAgePenalty { get; set; }

        int OldAgeThreshold { get; set; }

        int PopulationSize { get; set; }

        IList<ISpecies> Species { get; }

        double SurvivalRate { get; set; }

        int YoungBonusAgeThreshhold { set; }

        int YoungBonusAgeThreshold { get; }

        double YoungScoreBonus { get; set; }
    }
}

