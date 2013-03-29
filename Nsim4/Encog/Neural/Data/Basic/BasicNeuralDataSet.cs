namespace Encog.Neural.Data.Basic
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.NeuralData;
    using System;

    public class BasicNeuralDataSet : BasicMLDataSet, IMLDataSet, INeuralDataSet
    {
        public BasicNeuralDataSet(double[][] input, double[][] ideal) : base(input, ideal)
        {
        }
    }
}

