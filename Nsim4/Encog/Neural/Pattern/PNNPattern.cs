namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.PNN;
    using System;

    public class PNNPattern : INeuralNetworkPattern
    {
        private int _x8f581d694fca0474;
        private PNNOutputMode _xb2ee160a618b6146 = PNNOutputMode.Regression;
        private int _xcfe830a7176c14e5;
        private PNNKernelType _xec3b9fd87e7b3852 = PNNKernelType.Gaussian;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A PNN network does not have hidden layers.");
        }

        public virtual void Clear()
        {
        }

        public IMLMethod Generate()
        {
            return new BasicPNN(this._xec3b9fd87e7b3852, this._xb2ee160a618b6146, this._xcfe830a7176c14e5, this._x8f581d694fca0474);
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
            get
            {
                return this._xcfe830a7176c14e5;
            }
            set
            {
                this._xcfe830a7176c14e5 = value;
            }
        }

        public PNNKernelType Kernel
        {
            get
            {
                return this._xec3b9fd87e7b3852;
            }
            set
            {
                this._xec3b9fd87e7b3852 = value;
            }
        }

        public PNNOutputMode Outmodel
        {
            get
            {
                return this._xb2ee160a618b6146;
            }
            set
            {
                this._xb2ee160a618b6146 = value;
            }
        }

        public int OutputNeurons
        {
            get
            {
                return this._x8f581d694fca0474;
            }
            set
            {
                this._x8f581d694fca0474 = value;
            }
        }
    }
}

