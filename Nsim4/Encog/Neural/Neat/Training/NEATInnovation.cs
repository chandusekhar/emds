namespace Encog.Neural.NEAT.Training
{
    using Encog.ML.Genetic.Innovation;
    using Encog.Neural.NEAT;
    using Encog.Neural.Neat.Training;
    using System;
    using System.Text;

    [Serializable]
    public class NEATInnovation : BasicInnovation
    {
        private long fromNeuronID;
        private NEATInnovationType innovationType;
        private long neuronID;
        private NEATNeuronType neuronType;
        private double splitX;
        private double splitY;
        private long toNeuronID;

        public NEATInnovation()
        {
        }

        public NEATInnovation(NEATNeuronGene neuronGene, long innovationID, long neuronID_0)
        {
            if (8 != 0)
            {
                this.neuronID = neuronID_0;
                base.InnovationID = innovationID;
                this.splitX = neuronGene.SplitX;
                if (0xff == 0)
                {
                    return;
                }
                this.splitY = neuronGene.SplitY;
                this.neuronType = neuronGene.NeuronType;
                this.innovationType = NEATInnovationType.NewNeuron;
            }
            this.fromNeuronID = -1L;
            this.toNeuronID = -1L;
        }

        public NEATInnovation(long fromNeuronID_0, long toNeuronID_1, NEATInnovationType innovationType_2, long innovationID)
        {
            if ((((uint) innovationID) + ((uint) fromNeuronID_0)) <= uint.MaxValue)
            {
                this.fromNeuronID = fromNeuronID_0;
                this.toNeuronID = toNeuronID_1;
                if (((uint) toNeuronID_1) > uint.MaxValue)
                {
                    return;
                }
                goto Label_003B;
            }
            if (0 == 0)
            {
                goto Label_003B;
            }
        Label_0021:
            if ((((uint) fromNeuronID_0) + ((uint) fromNeuronID_0)) < 0)
            {
                goto Label_0052;
            }
            return;
        Label_003B:
            this.innovationType = innovationType_2;
            base.InnovationID = innovationID;
            this.neuronID = -1L;
        Label_0052:
            this.splitX = 0.0;
            this.splitY = 0.0;
            this.neuronType = NEATNeuronType.None;
            goto Label_0021;
        }

        public NEATInnovation(long fromNeuronID_0, long toNeuronID_1, NEATInnovationType innovationType_2, long innovationID, NEATNeuronType neuronType_3, double x, double y)
        {
            goto Label_0057;
        Label_0023:
            this.innovationType = innovationType_2;
            base.InnovationID = innovationID;
            this.neuronType = neuronType_3;
            this.splitX = x;
            this.splitY = y;
            this.neuronID = 0L;
            if (0 == 0)
            {
                return;
            }
            if (-2147483648 != 0)
            {
                goto Label_0057;
            }
        Label_004C:
            this.fromNeuronID = fromNeuronID_0;
            this.toNeuronID = toNeuronID_1;
            goto Label_0023;
        Label_0057:
            if ((((uint) y) + ((uint) toNeuronID_1)) < 0)
            {
                goto Label_0023;
            }
            goto Label_004C;
        }

        public override string ToString()
        {
            NEATInnovationType innovationType;
            StringBuilder builder = new StringBuilder();
            builder.Append("[NeatInnovation:type=");
            if (1 != 0)
            {
                innovationType = this.innovationType;
            }
            switch (innovationType)
            {
                case NEATInnovationType.NewLink:
                    builder.Append("link");
                    break;

                case NEATInnovationType.NewNeuron:
                    builder.Append("neuron");
                    break;
            }
            builder.Append(",from=");
            builder.Append(this.fromNeuronID);
            builder.Append(",to=");
            builder.Append(this.toNeuronID);
            builder.Append(",splitX=");
            builder.Append(this.splitX);
            if (0 == 0)
            {
                builder.Append(",splitY=");
                builder.Append(this.splitY);
                builder.Append("]");
            }
            return builder.ToString();
        }

        public long FromNeuronID
        {
            get
            {
                return this.fromNeuronID;
            }
            set
            {
                this.fromNeuronID = value;
            }
        }

        public NEATInnovationType InnovationType
        {
            get
            {
                return this.innovationType;
            }
            set
            {
                this.innovationType = value;
            }
        }

        public long NeuronID
        {
            get
            {
                return this.neuronID;
            }
            set
            {
                this.neuronID = value;
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

        public long ToNeuronID
        {
            get
            {
                return this.toNeuronID;
            }
            set
            {
                this.toNeuronID = value;
            }
        }
    }
}

