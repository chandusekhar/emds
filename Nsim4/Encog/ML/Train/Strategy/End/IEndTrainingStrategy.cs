namespace Encog.ML.Train.Strategy.End
{
    using Encog.ML.Train.Strategy;
    using System;

    public interface IEndTrainingStrategy : IStrategy
    {
        bool ShouldStop();
    }
}

