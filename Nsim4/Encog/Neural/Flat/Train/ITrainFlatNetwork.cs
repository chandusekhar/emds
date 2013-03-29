namespace Encog.Neural.Flat.Train
{
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using System;

    public interface ITrainFlatNetwork
    {
        void FinishTraining();
        void Iteration();
        void Iteration(int count);

        double Error { get; }

        int IterationNumber { get; set; }

        FlatNetwork Network { get; }

        int NumThreads { get; set; }

        IMLDataSet Training { get; }
    }
}

