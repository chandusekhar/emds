namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Layers;
    using System;

    public class ADALINEPattern : INeuralNetworkPattern
    {
        private int _x8f581d694fca0474;
        private int _xcfe830a7176c14e5;

        public void AddHiddenLayer(int count)
        {
            throw new PatternError("An ADALINE network has no hidden layers.");
        }

        public void Clear()
        {
            this._xcfe830a7176c14e5 = 0;
            this._x8f581d694fca0474 = 0;
        }

        public IMLMethod Generate()
        {
            BasicNetwork method = new BasicNetwork();
            ILayer layer = new BasicLayer(new ActivationLinear(), true, this._xcfe830a7176c14e5);
            ILayer layer2 = new BasicLayer(new ActivationLinear(), false, this._x8f581d694fca0474);
            if (0 == 0)
            {
                method.AddLayer(layer);
                method.AddLayer(layer2);
                method.Structure.FinalizeStructure();
                new RangeRandomizer(-0.5, 0.5).Randomize(method);
                return method;
            }
            return method;
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                throw new PatternError("A ADALINE network can't specify a custom activation function.");
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

