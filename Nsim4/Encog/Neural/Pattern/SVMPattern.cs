namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.ML.SVM;
    using System;
    using System.Runtime.CompilerServices;

    public class SVMPattern : INeuralNetworkPattern
    {
        private int _x8f581d694fca0474;
        private Encog.ML.SVM.SVMType _x925948417376354d;
        private int _xcfe830a7176c14e5;
        private Encog.ML.SVM.KernelType _xedaf9cba8f12a43d;
        [CompilerGenerated]
        private bool xbcdee6a7cff3bacb;

        public SVMPattern()
        {
            this.Regression = true;
            this._xedaf9cba8f12a43d = Encog.ML.SVM.KernelType.RadialBasisFunction;
            this._x925948417376354d = Encog.ML.SVM.SVMType.EpsilonSupportVectorRegression;
        }

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A SVM network has no hidden layers.");
        }

        public void Clear()
        {
            this._xcfe830a7176c14e5 = 0;
            this._x8f581d694fca0474 = 0;
        }

        public IMLMethod Generate()
        {
            if (this._x8f581d694fca0474 != 1)
            {
                throw new PatternError("A SVM may only have one output.");
            }
            return new SupportVectorMachine(this._xcfe830a7176c14e5, this._x925948417376354d, this._xedaf9cba8f12a43d);
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A SVM network can't specify a custom activation function.");
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

        public Encog.ML.SVM.KernelType KernelType
        {
            set
            {
                this._xedaf9cba8f12a43d = value;
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

        public bool Regression
        {
            [CompilerGenerated]
            get
            {
                return this.xbcdee6a7cff3bacb;
            }
            [CompilerGenerated]
            set
            {
                this.xbcdee6a7cff3bacb = value;
            }
        }

        public Encog.ML.SVM.SVMType SVMType
        {
            set
            {
                this._x925948417376354d = value;
            }
        }
    }
}

