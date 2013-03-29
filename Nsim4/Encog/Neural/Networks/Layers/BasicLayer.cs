namespace Encog.Neural.Networks.Layers
{
    using Encog.Engine.Network.Activation;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks;
    using System;

    [Serializable]
    public class BasicLayer : FlatLayer, ILayer
    {
        private BasicNetwork _network;

        public BasicLayer(int neuronCount) : this(new ActivationTANH(), true, neuronCount)
        {
        }

        public BasicLayer(IActivationFunction activationFunction, bool hasBias, int neuronCount) : base(activationFunction, neuronCount, hasBias ? 1.0 : 0.0)
        {
        }

        public virtual IActivationFunction ActivationFunction
        {
            get
            {
                return base.Activation;
            }
        }

        public virtual BasicNetwork Network
        {
            get
            {
                return this._network;
            }
            set
            {
                this._network = value;
            }
        }

        public virtual int NeuronCount
        {
            get
            {
                return base.Count;
            }
        }
    }
}

