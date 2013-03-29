namespace Encog.Neural.Networks.Training
{
    using Encog.ML;
    using System;

    public interface ICalculateScore
    {
        double CalculateScore(IMLRegression network);

        bool ShouldMinimize { get; }
    }
}

