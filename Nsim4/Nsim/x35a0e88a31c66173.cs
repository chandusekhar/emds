namespace Nsim
{
    using System;

    internal interface x35a0e88a31c66173 : IConfigurable
    {
        int Iterations { get; }

        double TeachError { get; }

        double TestError { get; }

        bool UseIterations { get; }

        bool UseTeachError { get; }

        bool UseTestError { get; }
    }
}

