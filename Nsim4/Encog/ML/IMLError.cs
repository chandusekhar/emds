namespace Encog.ML
{
    using Encog.ML.Data;
    using System;

    public interface IMLError : IMLMethod
    {
        double CalculateError(IMLDataSet data);
    }
}

