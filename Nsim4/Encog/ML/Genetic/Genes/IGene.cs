namespace Encog.ML.Genetic.Genes
{
    using System;

    public interface IGene : IComparable<IGene>
    {
        void Copy(IGene gene);

        bool Enabled { get; set; }

        long Id { get; }

        long InnovationId { get; }
    }
}

