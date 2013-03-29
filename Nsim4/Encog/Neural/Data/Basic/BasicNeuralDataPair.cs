namespace Encog.Neural.Data.Basic
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.NeuralData;
    using System;

    public class BasicNeuralDataPair : BasicMLDataPair, INeuralDataPair
    {
        public BasicNeuralDataPair(IMLData input) : base(input)
        {
        }

        public BasicNeuralDataPair(IMLData input, IMLData ideal) : base(input, ideal)
        {
        }
    }
}

