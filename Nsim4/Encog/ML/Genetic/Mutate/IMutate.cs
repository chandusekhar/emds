namespace Encog.ML.Genetic.Mutate
{
    using Encog.ML.Genetic.Genome;
    using System;

    public interface IMutate
    {
        void PerformMutation(Chromosome chromosome);
    }
}

