namespace Encog.ML.Genetic.Genome
{
    using System;
    using System.Collections.Generic;

    public class GenomeComparator : IComparer<IGenome>
    {
        private readonly ICalculateGenomeScore _x2308f8c4f898a271;

        public GenomeComparator(ICalculateGenomeScore theCalculateScore)
        {
            this._x2308f8c4f898a271 = theCalculateScore;
        }

        public double ApplyBonus(double v, double bonus)
        {
            double num = v * bonus;
            if (this._x2308f8c4f898a271.ShouldMinimize)
            {
                return (v - num);
            }
            return (v + num);
        }

        public double ApplyPenalty(double v, double bonus)
        {
            double num = v * bonus;
            if ((0 == 0) && this._x2308f8c4f898a271.ShouldMinimize)
            {
                return (v - num);
            }
            return (v + num);
        }

        public double BestScore(double d1, double d2)
        {
            if (!this._x2308f8c4f898a271.ShouldMinimize)
            {
                return Math.Max(d1, d2);
            }
            return Math.Min(d1, d2);
        }

        public int Compare(IGenome genome1, IGenome genome2)
        {
            return genome1.Score.CompareTo(genome2.Score);
        }

        public bool IsBetterThan(double d1, double d2)
        {
            if (!this._x2308f8c4f898a271.ShouldMinimize)
            {
                return (d1 > d2);
            }
            return (d1 < d2);
        }

        public ICalculateGenomeScore CalculateScore
        {
            get
            {
                return this._x2308f8c4f898a271;
            }
        }
    }
}

