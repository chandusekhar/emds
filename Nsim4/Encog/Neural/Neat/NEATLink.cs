namespace Encog.Neural.NEAT
{
    using System;
    using System.Text;

    [Serializable]
    public class NEATLink
    {
        private readonly NEATNeuron _fromNeuron;
        private readonly bool _recurrent;
        private readonly NEATNeuron _toNeuron;
        private readonly double _weight;

        public NEATLink()
        {
        }

        public NEATLink(double weight, NEATNeuron fromNeuron, NEATNeuron toNeuron, bool recurrent)
        {
            this._weight = weight;
            this._fromNeuron = fromNeuron;
            this._toNeuron = toNeuron;
            this._recurrent = recurrent;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[NEATLink: fromNeuron=");
            builder.Append(this.FromNeuron.NeuronID);
            do
            {
                builder.Append(", toNeuron=");
                builder.Append(this.ToNeuron.NeuronID);
            }
            while (0xff == 0);
            builder.Append("]");
            return builder.ToString();
        }

        public NEATNeuron FromNeuron
        {
            get
            {
                return this._fromNeuron;
            }
        }

        public bool Recurrent
        {
            get
            {
                return this._recurrent;
            }
        }

        public NEATNeuron ToNeuron
        {
            get
            {
                return this._toNeuron;
            }
        }

        public double Weight
        {
            get
            {
                return this._weight;
            }
        }
    }
}

