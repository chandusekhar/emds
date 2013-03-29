namespace Encog.ML.Genetic.Genome
{
    using System;

    public interface ICalculateGenomeScore
    {
        double CalculateScore(IGenome genome);

        bool ShouldMinimize { get; }
    }
}

