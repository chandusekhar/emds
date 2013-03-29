namespace Encog.Neural.Networks.Training
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.Util.Error;
    using System;

    public class TrainingSetScore : ICalculateScore
    {
        private readonly IMLDataSet _x823a2b9c8bf459c5;

        public TrainingSetScore(IMLDataSet training)
        {
            this._x823a2b9c8bf459c5 = training;
        }

        public double CalculateScore(IMLRegression method)
        {
            return CalculateRegressionError.CalculateError(method, this._x823a2b9c8bf459c5);
        }

        public bool ShouldMinimize
        {
            get
            {
                return true;
            }
        }
    }
}

