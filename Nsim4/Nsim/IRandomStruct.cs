namespace Nsim
{
    using Encog.MathUtil.Randomize;

    public interface IRandomStruct : IConfigurable
    {
        IRandomizer GetRandom();
    }
}

