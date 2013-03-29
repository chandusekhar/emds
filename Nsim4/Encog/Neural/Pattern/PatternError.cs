namespace Encog.Neural.Pattern
{
    using Encog.Neural;
    using System;

    [Serializable]
    public class PatternError : NeuralNetworkError
    {
        public PatternError(Exception t) : base(t)
        {
        }

        public PatternError(string msg) : base(msg)
        {
        }
    }
}

