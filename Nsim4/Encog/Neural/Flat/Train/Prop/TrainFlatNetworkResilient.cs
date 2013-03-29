namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks.Training;
    using System;
    using System.Runtime.CompilerServices;

    public class TrainFlatNetworkResilient : TrainFlatNetworkProp
    {
        private readonly double _x04273e480202ea1d;
        private readonly double[] _x3cb1c2ba1a55e11e;
        private readonly double[] _xa3001a0faa4f9279;
        private double _xaf54fba65f108955;
        private readonly double _xc63f21bb42b68cf5;
        private readonly double[] _xe4def4d471bbc130;
        [CompilerGenerated]
        private RPROPType x303861dc1b9029bb;

        public TrainFlatNetworkResilient(FlatNetwork flat, IMLDataSet trainingSet) : this(flat, trainingSet, 1E-17, 0.1, 50.0)
        {
        }

        public TrainFlatNetworkResilient(FlatNetwork network, IMLDataSet training, double zeroTolerance, double initialUpdate, double maxStep) : base(network, training)
        {
            if ((((uint) initialUpdate) + ((uint) initialUpdate)) <= uint.MaxValue)
            {
                this._x3cb1c2ba1a55e11e = new double[network.Weights.Length];
                this._x04273e480202ea1d = zeroTolerance;
                this._xc63f21bb42b68cf5 = maxStep;
                if ((((uint) zeroTolerance) + ((uint) initialUpdate)) >= 0)
                {
                    this._xa3001a0faa4f9279 = new double[base.Network.Weights.Length];
                    this._xe4def4d471bbc130 = new double[base.Network.Weights.Length];
                }
            }
            for (int i = 0; i < this._x3cb1c2ba1a55e11e.Length; i++)
            {
                this._x3cb1c2ba1a55e11e[i] = initialUpdate;
            }
        }

        public override void InitOthers()
        {
        }

        public double UpdateiWeightMinus(double[] gradients, double[] lastGradient, int index)
        {
            double num3;
            int num = this.x0428c55343267861(gradients[index] * lastGradient[index]);
            double num2 = 0.0;
            if ((((uint) num2) & 0) == 0)
            {
            Label_008C:
                if (num <= 0)
                {
                    if ((((uint) num) + ((uint) index)) < 0)
                    {
                        return num2;
                    }
                    num3 = this._xe4def4d471bbc130[index] * 0.5;
                    num3 = Math.Max(num3, 1E-06);
                    lastGradient[index] = 0.0;
                    if (0 != 0)
                    {
                        goto Label_008C;
                    }
                    goto Label_0050;
                }
            }
            else if (((uint) num3) < 0)
            {
                goto Label_0050;
            }
            num3 = this._xe4def4d471bbc130[index] * 1.2;
            num3 = Math.Min(num3, this._xc63f21bb42b68cf5);
        Label_0050:
            lastGradient[index] = gradients[index];
            num2 = this.x0428c55343267861(gradients[index]) * num3;
            if ((((uint) num2) - ((uint) index)) <= uint.MaxValue)
            {
                this._xe4def4d471bbc130[index] = num3;
                return num2;
            }
            return num2;
        }

        public double UpdateiWeightPlus(double[] gradients, double[] lastGradient, int index)
        {
            double num3;
            double num4;
            double num5;
            int num = this.x0428c55343267861(gradients[index] * lastGradient[index]);
            double num2 = 0.0;
            if (num > 0)
            {
                num3 = this._x3cb1c2ba1a55e11e[index] * 1.2;
                num3 = Math.Min(num3, this._xc63f21bb42b68cf5);
                if (0 == 0)
                {
                    if ((((uint) num3) - ((uint) num4)) >= 0)
                    {
                        num2 = this.x0428c55343267861(gradients[index]) * num3;
                        this._x3cb1c2ba1a55e11e[index] = num3;
                    }
                    lastGradient[index] = gradients[index];
                }
            }
            else
            {
                if ((0 == 0) && (num >= 0))
                {
                    goto Label_0033;
                }
                num4 = this.UpdateValues[index] * 0.5;
                num4 = Math.Max(num4, 1E-06);
                if ((((uint) num3) - ((uint) index)) < 0)
                {
                    goto Label_0033;
                }
                this.UpdateValues[index] = num4;
                if (base.CurrentError <= this._xaf54fba65f108955)
                {
                    goto Label_0063;
                }
                if ((((uint) num4) & 0) == 0)
                {
                    goto Label_0059;
                }
                goto Label_0013;
            }
            if (((uint) num5) > uint.MaxValue)
            {
            }
            return num2;
        Label_0013:
            if (-2147483648 == 0)
            {
                goto Label_0063;
            }
            num2 = this.x0428c55343267861(gradients[index]) * num5;
            lastGradient[index] = gradients[index];
            return num2;
        Label_0033:
            if (num != 0)
            {
                return num2;
            }
            num5 = this._x3cb1c2ba1a55e11e[index];
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_0013;
            }
        Label_0059:
            num2 = -this._xa3001a0faa4f9279[index];
        Label_0063:
            lastGradient[index] = 0.0;
            return num2;
        }

        public override double UpdateWeight(double[] gradients, double[] lastGradient, int index)
        {
            double num = 0.0;
            goto Label_009C;
        Label_0041:
            this._xa3001a0faa4f9279[index] = num;
            if (((uint) num) <= uint.MaxValue)
            {
                return num;
            }
            if ((((uint) num) | uint.MaxValue) != 0)
            {
                goto Label_009C;
            }
        Label_0090:
            num = this.UpdateWeightMinus(gradients, lastGradient, index);
            goto Label_0041;
        Label_009C:
            switch (this.RType)
            {
                case RPROPType.RPROPp:
                    num = this.UpdateWeightPlus(gradients, lastGradient, index);
                    goto Label_0041;

                case RPROPType.RPROPm:
                    goto Label_0090;

                case RPROPType.iRPROPp:
                    num = this.UpdateiWeightPlus(gradients, lastGradient, index);
                    goto Label_0041;

                case RPROPType.iRPROPm:
                    num = this.UpdateiWeightMinus(gradients, lastGradient, index);
                    goto Label_0041;
            }
            throw new TrainingError("Unknown RPROP type: " + this.RType);
        }

        public double UpdateWeightMinus(double[] gradients, double[] lastGradient, int index)
        {
            double num3;
            int num = this.x0428c55343267861(gradients[index] * lastGradient[index]);
            if (((uint) index) <= uint.MaxValue)
            {
                goto Label_00FA;
            }
            if ((((uint) index) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_00B1;
            }
            goto Label_0086;
        Label_0068:
            lastGradient[index] = gradients[index];
            double num2 = this.x0428c55343267861(gradients[index]) * num3;
        Label_007B:
            this._xe4def4d471bbc130[index] = num3;
            if (((uint) num2) >= 0)
            {
                if ((((uint) num2) | 0xfffffffe) != 0)
                {
                    return num2;
                }
                goto Label_00FA;
            }
            goto Label_00B1;
        Label_0086:
            if (num > 0)
            {
                num3 = this._xe4def4d471bbc130[index] * 1.2;
                num3 = Math.Min(num3, this._xc63f21bb42b68cf5);
            }
            else
            {
                num3 = this._xe4def4d471bbc130[index] * 0.5;
                num3 = Math.Max(num3, 1E-06);
                if ((((uint) num2) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_007B;
                }
            }
            goto Label_0068;
        Label_00B1:
            num2 = 0.0;
            goto Label_0086;
        Label_00FA:
            if (8 == 0)
            {
                goto Label_0068;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_00B1;
            }
            return num2;
        }

        public double UpdateWeightPlus(double[] gradients, double[] lastGradient, int index)
        {
            double num4;
            double num5;
            int num = this.x0428c55343267861(gradients[index] * lastGradient[index]);
            double num2 = 0.0;
            if (num > 0)
            {
                if ((((uint) num5) | 2) == 0)
                {
                    return num2;
                }
                double num3 = this.UpdateValues[index] * 1.2;
                num3 = Math.Min(num3, this._xc63f21bb42b68cf5);
                num2 = this.x0428c55343267861(gradients[index]) * num3;
                this.UpdateValues[index] = num3;
                if ((((uint) num4) & 0) == 0)
                {
                    lastGradient[index] = gradients[index];
                    return num2;
                }
                goto Label_006B;
            }
        Label_002C:
            if (num < 0)
            {
                num4 = this.UpdateValues[index] * 0.5;
                num4 = Math.Max(num4, 1E-06);
            }
            else
            {
                if (num == 0)
                {
                    num5 = this._x3cb1c2ba1a55e11e[index];
                    num2 = this.x0428c55343267861(gradients[index]) * num5;
                    lastGradient[index] = gradients[index];
                }
                return num2;
            }
        Label_006B:
            this.UpdateValues[index] = num4;
        Label_0074:
            num2 = -this._xa3001a0faa4f9279[index];
            if (((uint) index) <= uint.MaxValue)
            {
                if ((((uint) num5) - ((uint) num4)) >= 0)
                {
                    lastGradient[index] = 0.0;
                    return num2;
                }
                goto Label_0074;
            }
            goto Label_002C;
        }

        private int x0428c55343267861(double x9b4602d5e4f04fcb)
        {
            if (Math.Abs(x9b4602d5e4f04fcb) < this._x04273e480202ea1d)
            {
                return 0;
            }
            if (x9b4602d5e4f04fcb > 0.0)
            {
                return 1;
            }
            return -1;
        }

        public RPROPType RType
        {
            [CompilerGenerated]
            get
            {
                return this.x303861dc1b9029bb;
            }
            [CompilerGenerated]
            set
            {
                this.x303861dc1b9029bb = value;
            }
        }

        public double[] UpdateValues
        {
            get
            {
                return this._x3cb1c2ba1a55e11e;
            }
        }
    }
}

