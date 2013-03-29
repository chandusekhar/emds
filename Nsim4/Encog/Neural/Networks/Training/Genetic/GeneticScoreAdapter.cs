namespace Encog.Neural.Networks.Training.Genetic
{
    using Encog.ML;
    using Encog.ML.Genetic.Genome;
    using Encog.Neural.Networks.Training;
    using System;

    public class GeneticScoreAdapter : ICalculateGenomeScore
    {
        private readonly ICalculateScore _x2308f8c4f898a271;

        public GeneticScoreAdapter(ICalculateScore calculateScore)
        {
            this._x2308f8c4f898a271 = calculateScore;
        }

        public double CalculateScore(IGenome genome)
        {
            IMLRegression organism = (IMLRegression) genome.Organism;
            return this._x2308f8c4f898a271.CalculateScore(organism);
        }

        public bool ShouldMinimize
        {
            get
            {
                return this._x2308f8c4f898a271.ShouldMinimize;
            }
        }
    }
}

