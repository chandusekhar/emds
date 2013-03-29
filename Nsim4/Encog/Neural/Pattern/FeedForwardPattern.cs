namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Layers;
    using System;
    using System.Collections.Generic;

    public class FeedForwardPattern : INeuralNetworkPattern
    {
        private IActivationFunction _x34a5e0736d060c9c;
        private int _x8f581d694fca0474;
        private readonly IList<int> _xab3ddaff42dd298a = new List<int>();
        private int _xcfe830a7176c14e5;
        private IActivationFunction _xff166cbf56128ec5;

        public void AddHiddenLayer(int count)
        {
            this._xab3ddaff42dd298a.Add(count);
        }

        public void Clear()
        {
            this._xab3ddaff42dd298a.Clear();
        }

        public IMLMethod Generate()
        {
            ILayer layer;
            BasicNetwork network;
            int num;
            if (this._x34a5e0736d060c9c != null)
            {
                goto Label_00C0;
            }
            if (0xff != 0)
            {
                goto Label_00B4;
            }
        Label_0015:
            network.Reset();
            if (0 != 0)
            {
                goto Label_00CE;
            }
            if ((((uint) num) | 0x7fffffff) != 0)
            {
                return network;
            }
        Label_00B4:
            this._x34a5e0736d060c9c = this._xff166cbf56128ec5;
        Label_00C0:
            layer = new BasicLayer(null, true, this._xcfe830a7176c14e5);
        Label_00CE:
            network = new BasicNetwork();
            network.AddLayer(layer);
            foreach (int num in this._xab3ddaff42dd298a)
            {
                ILayer layer2 = new BasicLayer(this._xff166cbf56128ec5, true, num);
                network.AddLayer(layer2);
            }
            ILayer layer3 = new BasicLayer(this._x34a5e0736d060c9c, false, this._x8f581d694fca0474);
            network.AddLayer(layer3);
            network.Structure.FinalizeStructure();
            if (0x7fffffff != 0)
            {
                goto Label_0015;
            }
            return network;
        }

        public IActivationFunction ActivationFunction
        {
            set
            {
                this._xff166cbf56128ec5 = value;
            }
        }

        public IActivationFunction ActivationOutput
        {
            get
            {
                return this._x34a5e0736d060c9c;
            }
            set
            {
                this._x34a5e0736d060c9c = value;
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

