namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.Thermal;
    using System;

    public class HopfieldPattern : INeuralNetworkPattern
    {
        private int _x42fdac5966b8d383 = -1;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A Hopfield network has no hidden layers.");
        }

        public virtual void Clear()
        {
        }

        public IMLMethod Generate()
        {
            return new HopfieldNetwork(this._x42fdac5966b8d383);
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A Hopfield network will use the BiPolar activation function, no activation function needs to be specified.");
            }
        }

        public int InputNeurons
        {
            set
            {
                this._x42fdac5966b8d383 = value;
            }
        }

        public int OutputNeurons
        {
            set
            {
                throw new PatternError("A Hopfield network has a single layer, so no need to specify the output count.");
            }
        }
    }
}

