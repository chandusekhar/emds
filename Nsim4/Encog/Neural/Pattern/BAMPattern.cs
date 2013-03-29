namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.BAM;
    using System;

    public class BAMPattern : INeuralNetworkPattern
    {
        private int _x86da356984166b21;
        private int _xd1d8a61604c90a5b;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A BAM network has no hidden layers.");
        }

        public void Clear()
        {
            this._xd1d8a61604c90a5b = 0;
            this._x86da356984166b21 = 0;
        }

        public IMLMethod Generate()
        {
            return new BAMNetwork(this._xd1d8a61604c90a5b, this._x86da356984166b21);
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A BAM network can't specify a custom activation function.");
            }
        }

        public int F1Neurons
        {
            set
            {
                this._xd1d8a61604c90a5b = value;
            }
        }

        public int F2Neurons
        {
            set
            {
                this._x86da356984166b21 = value;
            }
        }

        public int InputNeurons
        {
            set
            {
                throw new PatternError("A BAM network has no input layer, consider setting F1 layer.");
            }
        }

        public int OutputNeurons
        {
            set
            {
                throw new PatternError("A BAM network has no output layer, consider setting F2 layer.");
            }
        }
    }
}

