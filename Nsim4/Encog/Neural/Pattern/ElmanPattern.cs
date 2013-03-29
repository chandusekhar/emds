namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Layers;
    using System;

    public class ElmanPattern : INeuralNetworkPattern
    {
        private IActivationFunction _x2a5a4034520336f3;
        private int _x8f581d694fca0474 = -1;
        private int _xcfe830a7176c14e5 = -1;
        private int _xdf89f9cf9fc3d06f = -1;

        public void AddHiddenLayer(int count)
        {
            if (this._xdf89f9cf9fc3d06f != -1)
            {
                throw new PatternError("An Elman neural network should have only one hidden layer.");
            }
            this._xdf89f9cf9fc3d06f = count;
        }

        public void Clear()
        {
            this._xdf89f9cf9fc3d06f = -1;
        }

        public IMLMethod Generate()
        {
            BasicLayer layer;
            BasicLayer layer2;
            BasicNetwork network = new BasicNetwork();
            if ((0 != 0) || (0 == 0))
            {
                network.AddLayer(layer2 = new BasicLayer(this._x2a5a4034520336f3, true, this._xcfe830a7176c14e5));
            }
            network.AddLayer(layer = new BasicLayer(this._x2a5a4034520336f3, true, this._xdf89f9cf9fc3d06f));
            network.AddLayer(new BasicLayer(null, false, this._x8f581d694fca0474));
            layer2.ContextFedBy = layer;
            network.Structure.FinalizeStructure();
            network.Reset();
            return network;
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                this._x2a5a4034520336f3 = value;
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

