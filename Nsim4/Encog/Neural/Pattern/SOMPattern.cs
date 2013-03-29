namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.SOM;
    using System;

    public class SOMPattern : INeuralNetworkPattern
    {
        private int _x8f581d694fca0474;
        private int _xcfe830a7176c14e5;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A SOM network does not have hidden layers.");
        }

        public virtual void Clear()
        {
        }

        public IMLMethod Generate()
        {
            SOMNetwork network = new SOMNetwork(this._xcfe830a7176c14e5, this._x8f581d694fca0474);
            network.Reset();
            return network;
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A SOM network can't define an activation function.");
            }
        }

        public int InputNeurons
        {
            set
            {
                this._xcfe830a7176c14e5 = value;
            }
        }

        public int OutputNeurons
        {
            set
            {
                this._x8f581d694fca0474 = value;
            }
        }
    }
}

