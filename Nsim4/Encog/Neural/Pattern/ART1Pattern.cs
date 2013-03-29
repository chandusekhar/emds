namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.ART;
    using System;

    public class ART1Pattern : INeuralNetworkPattern
    {
        private double _x01ec8535a377ff25 = 1.5;
        private double _x109822751b15259c;
        private double _x17a676523ef9e177 = 5.0;
        private double _x34f4b4706ab9e6e0 = 1.0;
        private int _x8f581d694fca0474;
        private double _x9fc3ee03a439f6f0;
        private double _xb071c5fc56907f5d = 0.9;
        private int _xcfe830a7176c14e5;

        public ART1Pattern()
        {
            if (0 == 0)
            {
                this._x9fc3ee03a439f6f0 = 3.0;
                if (0 == 0)
                {
                    this._x109822751b15259c = 0.9;
                }
            }
        }

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A ART1 network has no hidden layers.");
        }

        public void Clear()
        {
            this._xcfe830a7176c14e5 = 0;
            this._x8f581d694fca0474 = 0;
        }

        public IMLMethod Generate()
        {
            ART1 art2 = new ART1(this._xcfe830a7176c14e5, this._x8f581d694fca0474);
            do
            {
                art2.A1 = this._x34f4b4706ab9e6e0;
                art2.B1 = this._x01ec8535a377ff25;
            }
            while (4 == 0);
            art2.C1 = this._x17a676523ef9e177;
            art2.D1 = this._xb071c5fc56907f5d;
            art2.L = this._x9fc3ee03a439f6f0;
            art2.Vigilance = this._x109822751b15259c;
            return art2;
        }

        public double A1
        {
            get
            {
                return this._x34f4b4706ab9e6e0;
            }
            set
            {
                this._x34f4b4706ab9e6e0 = value;
            }
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("Can't set the activation function for an ART1.");
            }
        }

        public double B1
        {
            get
            {
                return this._x01ec8535a377ff25;
            }
            set
            {
                this._x01ec8535a377ff25 = value;
            }
        }

        public double C1
        {
            get
            {
                return this._x17a676523ef9e177;
            }
            set
            {
                this._x17a676523ef9e177 = value;
            }
        }

        public double D1
        {
            get
            {
                return this._xb071c5fc56907f5d;
            }
            set
            {
                this._xb071c5fc56907f5d = value;
            }
        }

        public int InputNeurons
        {
            set
            {
                this._xcfe830a7176c14e5 = value;
            }
        }

        public double L
        {
            get
            {
                return this._x9fc3ee03a439f6f0;
            }
            set
            {
                this._x9fc3ee03a439f6f0 = value;
            }
        }

        public int OutputNeurons
        {
            set
            {
                this._x8f581d694fca0474 = value;
            }
        }

        public double Vigilance
        {
            get
            {
                return this._x109822751b15259c;
            }
            set
            {
                this._x109822751b15259c = value;
            }
        }
    }
}

