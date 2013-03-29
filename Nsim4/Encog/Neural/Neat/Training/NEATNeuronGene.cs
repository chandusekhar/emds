namespace Encog.Neural.Neat.Training
{
    using Encog.ML.Genetic.Genes;
    using Encog.Neural.NEAT;
    using System;
    using System.Text;

    [Serializable]
    public class NEATNeuronGene : BasicGene
    {
        private double activationResponse;
        private NEATNeuronType neuronType;
        public const string PROPERTY_ACT_RESPONSE = "aResp";
        public const string PROPERTY_RECURRENT = "recurrent";
        public const string PROPERTY_SPLIT_X = "splitX";
        public const string PROPERTY_SPLIT_Y = "splitY";
        private bool recurrent;
        private double splitX;
        private double splitY;

        public NEATNeuronGene()
        {
        }

        public NEATNeuronGene(NEATNeuronType type, long id, double splitY_0, double splitX_1) : this(type, id, splitY_0, splitX_1, false, 1.0)
        {
        }

        public NEATNeuronGene(NEATNeuronType type, long id, double splitY_0, double splitX_1, bool recurrent_2, double act)
        {
            while (true)
            {
                this.neuronType = type;
                if (3 != 0)
                {
                    base.Id = id;
                    this.splitX = splitX_1;
                    this.splitY = splitY_0;
                    this.recurrent = recurrent_2;
                    this.activationResponse = act;
                    if ((((uint) act) - ((uint) splitX_1)) >= 0)
                    {
                        return;
                    }
                }
            }
        }

        public override void Copy(IGene gene)
        {
            NEATNeuronGene gene2 = (NEATNeuronGene) gene;
            if (0 == 0)
            {
                this.activationResponse = gene2.activationResponse;
                base.Id = gene2.Id;
                if (0 == 0)
                {
                    this.neuronType = gene2.neuronType;
                    this.recurrent = gene2.recurrent;
                    if (0 == 0)
                    {
                        goto Label_000A;
                    }
                }
                return;
            }
        Label_000A:
            this.splitX = gene2.splitX;
            this.splitY = gene2.splitY;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[NEATNeuronGene: id=");
            builder.Append(base.Id);
            if (0 == 0)
            {
                builder.Append(", type=");
                builder.Append(this.NeuronType);
                builder.Append("]");
            }
            return builder.ToString();
        }

        public double ActivationResponse
        {
            get
            {
                return this.activationResponse;
            }
            set
            {
                this.activationResponse = value;
            }
        }

        public NEATNeuronType NeuronType
        {
            get
            {
                return this.neuronType;
            }
            set
            {
                this.neuronType = value;
            }
        }

        public bool Recurrent
        {
            get
            {
                return this.recurrent;
            }
            set
            {
                this.recurrent = value;
            }
        }

        public double SplitX
        {
            get
            {
                return this.splitX;
            }
            set
            {
                this.splitX = value;
            }
        }

        public double SplitY
        {
            get
            {
                return this.splitY;
            }
            set
            {
                this.splitY = value;
            }
        }
    }
}

