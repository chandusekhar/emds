namespace Encog.Neural.NEAT.Training
{
    using Encog.ML.Genetic.Genes;
    using System;
    using System.Text;

    [Serializable]
    public class NEATLinkGene : BasicGene
    {
        private long fromNeuronID;
        private bool recurrent;
        private long toNeuronID;
        private double weight;

        public NEATLinkGene()
        {
        }

        public NEATLinkGene(long fromNeuronID_0, long toNeuronID_1, bool enabled, long innovationID, double weight_2, bool recurrent_3)
        {
            this.fromNeuronID = fromNeuronID_0;
            this.toNeuronID = toNeuronID_1;
            base.Enabled = enabled;
            if ((((uint) toNeuronID_1) - ((uint) toNeuronID_1)) <= uint.MaxValue)
            {
                base.InnovationId = innovationID;
            }
            this.weight = weight_2;
            this.recurrent = recurrent_3;
        }

        public override void Copy(IGene gene)
        {
            NEATLinkGene gene2 = (NEATLinkGene) gene;
            base.Enabled = gene2.Enabled;
            this.fromNeuronID = gene2.fromNeuronID;
            this.toNeuronID = gene2.toNeuronID;
            if (0 == 0)
            {
                base.InnovationId = gene2.InnovationId;
                this.recurrent = gene2.recurrent;
                this.weight = gene2.weight;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
        Label_003C:
            builder.Append("[NEATLinkGene:innov=");
            builder.Append(base.InnovationId);
            builder.Append(",enabled=");
            builder.Append(base.Enabled);
            builder.Append(",from=");
        Label_007A:
            builder.Append(this.fromNeuronID);
            if (-2147483648 != 0)
            {
                builder.Append(",to=");
                if (-2147483648 == 0)
                {
                    goto Label_003C;
                }
            }
            if (15 != 0)
            {
                builder.Append(this.toNeuronID);
                if (0 != 0)
                {
                    goto Label_007A;
                }
                builder.Append("]");
                if (0 != 0)
                {
                    goto Label_003C;
                }
            }
            return builder.ToString();
        }

        public int FromNeuronID
        {
            get
            {
                return (int) this.fromNeuronID;
            }
            set
            {
                this.fromNeuronID = value;
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

        public int ToNeuronID
        {
            get
            {
                return (int) this.toNeuronID;
            }
            set
            {
                this.toNeuronID = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
    }
}

