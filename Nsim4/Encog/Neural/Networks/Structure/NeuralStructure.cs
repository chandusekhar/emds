namespace Encog.Neural.Networks.Structure
{
    using Encog.Engine.Network.Activation;
    using Encog.Neural;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Layers;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class NeuralStructure
    {
        private double _connectionLimit;
        private bool _connectionLimited;
        private FlatNetwork _flat;
        private readonly IList<ILayer> _layers = new List<ILayer>();
        private readonly BasicNetwork _network;

        public NeuralStructure(BasicNetwork network)
        {
            this._network = network;
        }

        public int CalculateSize()
        {
            return NetworkCODEC.NetworkSize(this._network);
        }

        public void EnforceLimit()
        {
            double[] weights;
            int num;
            if (this._connectionLimited)
            {
                weights = this._flat.Weights;
                num = 0;
            }
            else
            {
                return;
            }
            while (num < weights.Length)
            {
                if (Math.Abs(weights[num]) < this._connectionLimit)
                {
                    weights[num] = 0.0;
                }
                num++;
            }
        }

        public void FinalizeLimit()
        {
            string propertyString = this._network.GetPropertyString("CONNECTION_LIMIT");
            if (propertyString != null)
            {
                try
                {
                    this._connectionLimited = true;
                    this._connectionLimit = CSVFormat.EgFormat.Parse(propertyString);
                    this.EnforceLimit();
                    return;
                }
                catch (FormatException)
                {
                    throw new NeuralNetworkError("Invalid property(CONNECTION_LIMIT):" + propertyString);
                }
            }
            this._connectionLimited = false;
            this._connectionLimit = 0.0;
        }

        public void FinalizeStructure()
        {
            FlatLayer[] layerArray;
            int num;
            BasicLayer layer;
            if (this._layers.Count >= 2)
            {
                goto Label_00D4;
            }
            throw new NeuralNetworkError("There must be at least two layers before the structure is finalized.");
        Label_001A:
            if (num < this._layers.Count)
            {
                goto Label_009A;
            }
            this._flat = new FlatNetwork(layerArray);
            this.FinalizeLimit();
        Label_003D:
            this._layers.Clear();
            this.EnforceLimit();
            return;
        Label_0062:
            layerArray[num] = layer;
            num++;
            goto Label_001A;
        Label_006F:
            if (2 != 0)
            {
                goto Label_0062;
            }
        Label_0088:
            while (layer.Activation == null)
            {
                layer.Activation = new ActivationLinear();
                if (0 == 0)
                {
                    goto Label_006F;
                }
            }
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_006F;
            }
            goto Label_0062;
        Label_009A:
            layer = (BasicLayer) this._layers[num];
            goto Label_0088;
            if ((((uint) num) - ((uint) num)) < 0)
            {
                goto Label_003D;
            }
        Label_00D4:
            layerArray = new FlatLayer[this._layers.Count];
            num = 0;
            if (((uint) num) < 0)
            {
                goto Label_009A;
            }
            if (0 != 0)
            {
                goto Label_006F;
            }
            goto Label_001A;
        }

        public void RequireFlat()
        {
            if (this._flat == null)
            {
                throw new NeuralNetworkError("Must call finalizeStructure before using this network.");
            }
        }

        public void UpdateProperties()
        {
            if (!this._network.Properties.ContainsKey("CONNECTION_LIMIT"))
            {
                this._connectionLimited = false;
                this._connectionLimit = 0.0;
                if (2 != 0)
                {
                    goto Label_0035;
                }
                goto Label_0058;
            }
            goto Label_006B;
        Label_0026:
            if (0 == 0)
            {
                do
                {
                    if (0 != 0)
                    {
                        goto Label_0035;
                    }
                }
                while (1 == 0);
                return;
            }
        Label_0035:
            if (this._flat == null)
            {
                if (0 == 0)
                {
                    if (4 != 0)
                    {
                        return;
                    }
                    goto Label_0026;
                }
                goto Label_006B;
            }
        Label_0058:
            this._flat.ConnectionLimit = this._connectionLimit;
            goto Label_0026;
        Label_006B:
            this._connectionLimit = this._network.GetPropertyDouble("CONNECTION_LIMIT");
            this._connectionLimited = true;
            goto Label_0035;
        }

        public double ConnectionLimit
        {
            get
            {
                return this._connectionLimit;
            }
        }

        public bool ConnectionLimited
        {
            get
            {
                return this._connectionLimited;
            }
        }

        public FlatNetwork Flat
        {
            get
            {
                this.RequireFlat();
                return this._flat;
            }
            set
            {
                this._flat = value;
            }
        }

        public IList<ILayer> Layers
        {
            get
            {
                return this._layers;
            }
        }

        public BasicNetwork Network
        {
            get
            {
                return this._network;
            }
        }
    }
}

