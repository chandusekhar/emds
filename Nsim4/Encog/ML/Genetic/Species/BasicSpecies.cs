namespace Encog.ML.Genetic.Species
{
    using Encog.MathUtil.Randomize;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Population;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class BasicSpecies : ISpecies
    {
        private int _age;
        private double _bestScore;
        private int _gensNoImprovement;
        private IGenome _leader;
        [NonSerialized]
        private long _leaderID;
        private readonly IList<IGenome> _members;
        private IPopulation _population;
        private double _spawnsRequired;
        private long _speciesID;

        public BasicSpecies()
        {
            this._members = new List<IGenome>();
        }

        public BasicSpecies(IPopulation thePopulation, IGenome theFirst, long theSpeciesID)
        {
            this._members = new List<IGenome>();
            this._population = thePopulation;
        Label_005F:
            this._speciesID = theSpeciesID;
            if (0xff != 0)
            {
                this._bestScore = theFirst.Score;
                this._gensNoImprovement = 0;
                if (0 != 0)
                {
                    goto Label_005F;
                }
                this._age = 0;
            }
            if (((uint) theSpeciesID) >= 0)
            {
                this._leader = theFirst;
            }
            this._spawnsRequired = 0.0;
            this._members.Add(theFirst);
        }

        public void CalculateSpawnAmount()
        {
            this._spawnsRequired = 0.0;
            foreach (IGenome genome in this._members)
            {
                this._spawnsRequired += genome.AmountToSpawn;
            }
        }

        public IGenome ChooseParent()
        {
            if (this._members.Count == 1)
            {
                return this._members[0];
            }
            int num = ((int) (this._population.SurvivalRate * this._members.Count)) + 1;
            int num2 = (int) RangeRandomizer.Randomize(0.0, (double) num);
            return this._members[num2];
        }

        public void Purge()
        {
            this._members.Clear();
            this._age++;
            this._gensNoImprovement++;
            this._spawnsRequired = 0.0;
        }

        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }

        public double BestScore
        {
            get
            {
                return this._bestScore;
            }
            set
            {
                this._bestScore = value;
            }
        }

        public int GensNoImprovement
        {
            get
            {
                return this._gensNoImprovement;
            }
            set
            {
                this._gensNoImprovement = value;
            }
        }

        public IGenome Leader
        {
            get
            {
                return this._leader;
            }
            set
            {
                this._leader = value;
            }
        }

        public IList<IGenome> Members
        {
            get
            {
                return this._members;
            }
        }

        public double NumToSpawn
        {
            get
            {
                return this._spawnsRequired;
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

        public double SpawnsRequired
        {
            get
            {
                return this._spawnsRequired;
            }
            set
            {
                this._spawnsRequired = value;
            }
        }

        public long SpeciesID
        {
            get
            {
                return this._speciesID;
            }
            set
            {
                this._speciesID = value;
            }
        }

        public long TempLeaderID
        {
            get
            {
                return this._leaderID;
            }
            set
            {
                this._leaderID = value;
            }
        }
    }
}

