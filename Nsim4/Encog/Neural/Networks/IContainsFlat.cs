namespace Encog.Neural.Networks
{
    using Encog.ML;
    using Encog.Neural.Flat;

    public interface IContainsFlat : IMLMethod
    {
        FlatNetwork Flat { get; }
    }
}

