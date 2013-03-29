namespace Encog.Util.Normalize.Segregate
{
    using Encog.Util.Normalize;
    using System;

    public interface ISegregator
    {
        void Init(DataNormalization normalization);
        void PassInit();
        bool ShouldInclude();

        DataNormalization Owner { get; }
    }
}

