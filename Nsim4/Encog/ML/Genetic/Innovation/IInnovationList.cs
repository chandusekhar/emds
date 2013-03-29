namespace Encog.ML.Genetic.Innovation
{
    using System;
    using System.Collections.Generic;

    public interface IInnovationList
    {
        void Add(IInnovation innovation);
        IInnovation Get(int id);

        IList<IInnovation> Innovations { get; }
    }
}

