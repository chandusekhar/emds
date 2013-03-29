namespace Encog.ML
{
    using Encog.ML.Data;

    public interface IMLRegression : IMLMethod, IMLInputOutput, IMLInput, IMLOutput
    {
        IMLData Compute(IMLData input);
    }
}

