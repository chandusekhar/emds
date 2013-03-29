namespace Encog.ML.Train.Strategy
{
    using Encog.ML.Train;
    using System;

    public interface IStrategy
    {
        void Init(IMLTrain train);
        void PostIteration();
        void PreIteration();
    }
}

