namespace Encog.ML
{
    using System;

    public interface IMLOutput : IMLMethod
    {
        int OutputCount { get; }
    }
}

