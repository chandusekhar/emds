namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.Thermal;
    using System;

    public class BoltzmannPattern : INeuralNetworkPattern
    {
        private int _x23c7ac256e5e3845 = 100;
        private int _x42fdac5966b8d383;
        private int _x48aed3a88112fd87 = 0x3e8;
        private double _x745edd755505b88b = 0.0;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A Boltzmann network has no hidden layers.");
        }

        public void Clear()
        {
            this._x42fdac5966b8d383 = 0;
        }

        public IMLMethod Generate()
        {
            return new BoltzmannMachine(this._x42fdac5966b8d383) { Temperature = this._x745edd755505b88b, RunCycles = this._x48aed3a88112fd87, AnnealCycles = this._x23c7ac256e5e3845 };
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A Boltzmann network will use the BiPolar activation function, no activation function needs to be specified.");
            }
        }

        public int AnnealCycles
        {
            get
            {
                return this._x23c7ac256e5e3845;
            }
            set
            {
                this._x23c7ac256e5e3845 = value;
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
                this._x42fdac5966b8d383 = value;
            }
        }

        public int RunCycles
        {
            get
            {
                return this._x48aed3a88112fd87;
            }
            set
            {
                this._x48aed3a88112fd87 = value;
            }
        }

        public double Temperature
        {
            get
            {
                return this._x745edd755505b88b;
            }
            set
            {
                this._x745edd755505b88b = value;
            }
        }
    }
}

