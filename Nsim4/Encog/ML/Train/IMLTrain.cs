namespace Encog.ML.Train
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train.Strategy;
    using Encog.Neural.Networks.Training.Propagation;
    using System;
    using System.Collections.Generic;

    public interface IMLTrain
    {
        void AddStrategy(IStrategy strategy);
        void FinishTraining();
        void Iteration();
        void Iteration(int count);
        TrainingContinuation Pause();
        void Resume(TrainingContinuation state);

        bool CanContinue { get; }

        double Error { get; set; }

        TrainingImplementationType ImplementationType { get; }

        int IterationNumber { get; set; }

        IMLMethod Method { get; }

        IList<IStrategy> Strategies { get; }

        IMLDataSet Training { get; }

        bool TrainingDone { get; }
    }
}

