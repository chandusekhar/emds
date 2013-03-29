namespace Encog.ML.Genetic.Population
{
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Innovation;
    using Encog.Util.Identity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class BasicPopulation : IPopulation
    {
        private readonly IGenerateID _geneIDGenerate;
        private readonly IGenerateID _genomeIDGenerate;
        private readonly List<IGenome> _genomes;
        private readonly IGenerateID _innovationIDGenerate;
        private readonly IGenerateID _speciesIDGenerate;
        private int _youngBonusAgeThreshold;
        public const double DefaultOldAgePenalty = 0.3;
        public const int DefaultOldAgeThreshold = 50;
        public const double DefaultSurvivalRate = 0.2;
        public const double DefaultYouthBonus = 0.3;
        public const int DefaultYouthThreshold = 10;

        public BasicPopulation()
        {
            goto Label_0091;
        Label_0013:
            this.YoungScoreBonus = 0.3;
            this.PopulationSize = 0;
            return;
        Label_0091:
            this._geneIDGenerate = new BasicGenerateID();
            this._genomeIDGenerate = new BasicGenerateID();
            this._genomes = new List<IGenome>();
        Label_0079:
            if (4 != 0)
            {
                if (0 != 0)
                {
                    goto Label_0013;
                }
                this._innovationIDGenerate = new BasicGenerateID();
                this.OldAgePenalty = 0.3;
            }
            this.OldAgeThreshold = 50;
            this.Species = new List<ISpecies>();
            this._speciesIDGenerate = new BasicGenerateID();
            this.SurvivalRate = 0.2;
            if (-2147483648 != 0)
            {
                if (4 != 0)
                {
                    this._youngBonusAgeThreshold = 10;
                    goto Label_0013;
                }
            }
            else
            {
                goto Label_0079;
            }
            goto Label_0091;
        }

        public BasicPopulation(int thePopulationSize)
        {
        Label_00B3:
            this._geneIDGenerate = new BasicGenerateID();
            this._genomeIDGenerate = new BasicGenerateID();
            do
            {
                this._genomes = new List<IGenome>();
            }
            while ((((uint) thePopulationSize) - ((uint) thePopulationSize)) > uint.MaxValue);
            this._innovationIDGenerate = new BasicGenerateID();
            if (0 == 0)
            {
                this.OldAgePenalty = 0.3;
                this.OldAgeThreshold = 50;
                this.Species = new List<ISpecies>();
                this._speciesIDGenerate = new BasicGenerateID();
                this.SurvivalRate = 0.2;
                if ((((uint) thePopulationSize) - ((uint) thePopulationSize)) >= 0)
                {
                    this._youngBonusAgeThreshold = 10;
                }
                else
                {
                    goto Label_00B3;
                }
            }
            this.YoungScoreBonus = 0.3;
            this.PopulationSize = thePopulationSize;
        }

        public void Add(IGenome genome)
        {
            this._genomes.Add(genome);
            genome.Population = this;
        }

        public long AssignGeneID()
        {
            return this._geneIDGenerate.Generate();
        }

        public long AssignGenomeID()
        {
            return this._genomeIDGenerate.Generate();
        }

        public long AssignInnovationID()
        {
            return this._innovationIDGenerate.Generate();
        }

        public long AssignSpeciesID()
        {
            return this._speciesIDGenerate.Generate();
        }

        public void Claim(GeneticAlgorithm ga)
        {
            foreach (IGenome genome in this._genomes)
            {
                genome.GA = ga;
            }
        }

        public void Clear()
        {
            this._genomes.Clear();
        }

        public IGenome Get(int i)
        {
            return this._genomes[i];
        }

        public int Size()
        {
            return this._genomes.Count;
        }

        public void Sort()
        {
            this._genomes.Sort();
        }

        public IGenome Best
        {
            get
            {
                if (this._genomes.Count != 0)
                {
                    return this._genomes[0];
                }
                return null;
            }
        }

        public IGenerateID GeneIDGenerate
        {
            get
            {
                return this._geneIDGenerate;
            }
        }

        public IGenerateID GenomeIDGenerate
        {
            get
            {
                return this._genomeIDGenerate;
            }
        }

        public IList<IGenome> Genomes
        {
            get
            {
                return this._genomes;
            }
        }

        public IGenerateID InnovationIDGenerate
        {
            get
            {
                return this._innovationIDGenerate;
            }
        }

        public IInnovationList Innovations { get; set; }

        public string Name { get; set; }

        public double OldAgePenalty { get; set; }

        public int OldAgeThreshold { get; set; }

        public int PopulationSize { get; set; }

        public IList<ISpecies> Species { get; set; }

        public IGenerateID SpeciesIDGenerate
        {
            get
            {
                return this._speciesIDGenerate;
            }
        }

        public double SurvivalRate { get; set; }

        public int YoungBonusAgeThreshhold
        {
            set
            {
                this._youngBonusAgeThreshold = value;
            }
        }

        public int YoungBonusAgeThreshold
        {
            get
            {
                return this._youngBonusAgeThreshold;
            }
            set
            {
                this._youngBonusAgeThreshold = value;
            }
        }

        public double YoungScoreBonus { get; set; }
    }
}

