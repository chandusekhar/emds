namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.RBF;
    using Encog.ML;
    using Encog.Neural.RBF;
    using System;

    public class RadialBasisPattern : INeuralNetworkPattern
    {
        private RBFEnum _x7f0032ed2c1f3c80 = RBFEnum.Gaussian;
        private int _x8f581d694fca0474 = -1;
        private int _xcfe830a7176c14e5 = -1;
        private int _xdf89f9cf9fc3d06f = -1;

        public void AddHiddenLayer(int count)
        {
            if (this._xdf89f9cf9fc3d06f != -1)
            {
                throw new PatternError("A RBF network usually has a single hidden layer.");
            }
            this._xdf89f9cf9fc3d06f = count;
        }

        public void Clear()
        {
            this._xdf89f9cf9fc3d06f = -1;
        }

        public IMLMethod Generate()
        {
            return new RBFNetwork(this._xcfe830a7176c14e5, this._xdf89f9cf9fc3d06f, this._x8f581d694fca0474, this._x7f0032ed2c1f3c80);
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("Can't set the activation function for a radial basis function network.");
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

        public RBFEnum RBF
        {
            set
            {
                this._x7f0032ed2c1f3c80 = value;
            }
        }
    }
}

