namespace Encog.ML
{
    using System;

    public interface IMLResettable : IMLMethod
    {
        void Reset();
        void Reset(int seed);
    }
}

