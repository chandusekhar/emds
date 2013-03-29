namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using System;
    using System.Runtime.CompilerServices;

    public class TrainFlatNetworkQPROP : TrainFlatNetworkProp
    {
        [CompilerGenerated]
        private double x2acdacabec9ca33b;
        [CompilerGenerated]
        private double x31c45a17e048e101;
        [CompilerGenerated]
        private double x3766481f03fcb7b1;
        [CompilerGenerated]
        private double x754c60f59f0bf767;
        [CompilerGenerated]
        private double xc880da18ce2a002b;
        [CompilerGenerated]
        private double[] xf006e464f6c43867;

        public TrainFlatNetworkQPROP(FlatNetwork network, IMLDataSet training, double theLearningRate) : base(network, training)
        {
            this.LearningRate = theLearningRate;
            this.LastDelta = new double[base.Network.Weights.Length];
            this.Decay = 0.0001;
            this.OutputEpsilon = 0.35;
        }

        public override void InitOthers()
        {
            this.EPS = this.OutputEpsilon / ((double) base.Training.Count);
            this.Shrink = this.LearningRate / (1.0 + this.LearningRate);
        }

        public override double UpdateWeight(double[] gradients, double[] lastGradient, int index)
        {
            double num = base.Network.Weights[index];
            double num2 = this.LastDelta[index];
            double num3 = -base.Gradients[index] + (this.Decay * num);
            double num4 = -lastGradient[index];
            double num5 = 0.0;
            if (num2 < 0.0)
            {
                if (num3 > 0.0)
                {
                    num5 -= this.EPS * num3;
                    goto Label_00B9;
                }
                if ((((uint) num5) + ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_00B9;
                }
                goto Label_0131;
            }
        Label_0025:
            if (num2 > 0.0)
            {
                if (num3 < 0.0)
                {
                    num5 -= this.EPS * num3;
                }
                if (num3 > (this.Shrink * num4))
                {
                    num5 += (num2 * num3) / (num4 - num3);
                }
                else
                {
                    num5 += this.LearningRate * num2;
                }
            }
            else
            {
                num5 -= this.EPS * num3;
            }
        Label_003E:
            this.LastDelta[index] = num5;
            base.LastGradient[index] = gradients[index];
            return num5;
        Label_00B9:
            if (num3 >= (this.Shrink * num4))
            {
                if ((((uint) num) & 0) != 0)
                {
                    return num5;
                }
                num5 += this.LearningRate * num2;
                goto Label_003E;
            }
            num5 += (num2 * num3) / (num4 - num3);
        Label_0131:
            if (((uint) index) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                }
                goto Label_003E;
            }
            goto Label_0025;
        }

        public double Decay
        {
            [CompilerGenerated]
            get
            {
                return this.xc880da18ce2a002b;
            }
            [CompilerGenerated]
            set
            {
                this.xc880da18ce2a002b = value;
            }
        }

        public double EPS
        {
            [CompilerGenerated]
            get
            {
                return this.x754c60f59f0bf767;
            }
            [CompilerGenerated]
            set
            {
                this.x754c60f59f0bf767 = value;
            }
        }

        public double[] LastDelta
        {
            [CompilerGenerated]
            get
            {
                return this.xf006e464f6c43867;
            }
            [CompilerGenerated]
            set
            {
                this.xf006e464f6c43867 = value;
            }
        }

        public double LearningRate
        {
            [CompilerGenerated]
            get
            {
                return this.x3766481f03fcb7b1;
            }
            [CompilerGenerated]
            set
            {
                this.x3766481f03fcb7b1 = value;
            }
        }

        public double OutputEpsilon
        {
            [CompilerGenerated]
            get
            {
                return this.x31c45a17e048e101;
            }
            [CompilerGenerated]
            set
            {
                this.x31c45a17e048e101 = value;
            }
        }

        public double Shrink
        {
            [CompilerGenerated]
            get
            {
                return this.x2acdacabec9ca33b;
            }
            [CompilerGenerated]
            set
            {
                this.x2acdacabec9ca33b = value;
            }
        }
    }
}

