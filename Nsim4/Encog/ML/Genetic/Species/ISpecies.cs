namespace Encog.ML.Genetic.Species
{
    using Encog.ML.Genetic.Genome;
    using System;
    using System.Collections.Generic;

    public interface ISpecies
    {
        void CalculateSpawnAmount();
        IGenome ChooseParent();
        void Purge();

        int Age { get; set; }

        double BestScore { get; set; }

        int GensNoImprovement { get; set; }

        IGenome Leader { get; set; }

        IList<IGenome> Members { get; }

        double NumToSpawn { get; }

        double SpawnsRequired { get; set; }

        long SpeciesID { get; }
    }
}

