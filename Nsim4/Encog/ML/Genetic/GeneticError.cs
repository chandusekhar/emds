namespace Encog.ML.Genetic
{
    using Encog;
    using System;

    [Serializable]
    public class GeneticError : EncogError
    {
        public GeneticError(Exception t) : base(t)
        {
        }

        public GeneticError(string msg) : base(msg)
        {
        }

        public GeneticError(string msg, Exception t) : base(msg, t)
        {
        }
    }
}

