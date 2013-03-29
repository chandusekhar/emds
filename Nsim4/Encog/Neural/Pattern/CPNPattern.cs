namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.CPN;
    using System;

    public class CPNPattern : INeuralNetworkPattern
    {
        private int _x43f451310e815b76;
        private int _xaa91416d164ed125;
        private int _xd547583269d6718f;
        public const string TagInstar = "INSTAR";
        public const string TagOutstar = "OUTSTAR";

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("A CPN already has a predefined hidden layer.  No additionalspecification is needed.");
        }

        public void Clear()
        {
            this._x43f451310e815b76 = 0;
            this._xaa91416d164ed125 = 0;
            this._xd547583269d6718f = 0;
        }

        public IMLMethod Generate()
        {
            return new CPNNetwork(this._x43f451310e815b76, this._xaa91416d164ed125, this._xd547583269d6718f, 1);
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A CPN network will use the BiPolar & competitive activation functions, no activation function needs to be specified.");
            }
        }

        public int InputNeurons
        {
            set
            {
                this._x43f451310e815b76 = value;
            }
        }

        public int InstarCount
        {
            set
            {
                this._xaa91416d164ed125 = value;
            }
        }

        public int OutputNeurons
        {
            set
            {
                this._xd547583269d6718f = value;
            }
        }

        public int OutstarCount
        {
            set
            {
                this._xd547583269d6718f = value;
            }
        }
    }
}

