namespace Encog.Neural
{
    using Encog;
    using System;

    public class NeuralNetworkError : EncogError
    {
        public NeuralNetworkError(Exception e) : base(e)
        {
        }

        public NeuralNetworkError(string str) : base(str)
        {
        }

        public NeuralNetworkError(string msg, Exception e) : base(msg, e)
        {
        }
    }
}

