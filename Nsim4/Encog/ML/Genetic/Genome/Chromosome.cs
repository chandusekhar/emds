namespace Encog.ML.Genetic.Genome
{
    using Encog.ML.Genetic.Genes;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Chromosome
    {
        private readonly List<IGene> _genes = new List<IGene>();

        public void Add(IGene gene)
        {
            this._genes.Add(gene);
        }

        public IGene Get(int i)
        {
            return this._genes[i];
        }

        public IGene GetGene(int gene)
        {
            return this._genes[gene];
        }

        public int Size()
        {
            return this._genes.Count;
        }

        public List<IGene> Genes
        {
            get
            {
                return this._genes;
            }
        }
    }
}

