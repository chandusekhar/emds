namespace Encog.ML
{
    using Encog.ML.Data;
    using System;

    public interface IMLClassification : IMLMethod, IMLInputOutput, IMLInput, IMLOutput
    {
        int Classify(IMLData input);
    }
}

