namespace Encog.Neural.Data.Basic
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.NeuralData;
    using System;

    public class BasicNeuralData : BasicMLData, IMLData, ICloneable, INeuralData
    {
        public BasicNeuralData(double[] d) : base(d)
        {
        }

        public BasicNeuralData(int size) : base(size)
        {
        }
    }
}

