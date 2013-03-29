namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.MathUtil;
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using Encog.Util;
    using System;

    public class TrainFlatNetworkSCG : TrainFlatNetworkProp
    {
        private double _x20753e64c7ee4faf;
        private bool _x268cb8b20222b0dc;
        private readonly double[] _x2f33d779e5a20b28;
        private double _x31add3b0010a0a52;
        private double _x3271cefb1a159639;
        private int _x51ae3b338384d896;
        private readonly double[] _x9af996963d03fd21;
        private readonly double[] _x9c79b5ad7b769b12;
        private bool _xac19ed778412b7a3;
        private readonly double[] _xb55b340ae3a3e4e0;
        private readonly double[] _xb9f048818eee629c;
        private double _xd4d57078d70c1d3d;
        private bool _xd938fd32778a1c95;
        private double _xf7845a6fecd5afc3;
        protected internal const double FirstLambda = 1E-06;
        protected internal const double FirstSigma = 0.0001;

        public TrainFlatNetworkSCG(FlatNetwork network, IMLDataSet training) : base(network, training)
        {
            int num;
            if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
            {
                this._xd938fd32778a1c95 = true;
                if (((uint) num) < 0)
                {
                    goto Label_0069;
                }
                goto Label_0134;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_00BD;
            }
            goto Label_0094;
        Label_0069:
            this._xb55b340ae3a3e4e0 = new double[num];
            this._x268cb8b20222b0dc = true;
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                if (((uint) num) >= 0)
                {
                    return;
                }
                goto Label_00BD;
            }
        Label_0094:
            num = this._x2f33d779e5a20b28.Length;
            this._xb9f048818eee629c = new double[num];
            this._x9af996963d03fd21 = new double[num];
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_0134;
            }
            this._x9c79b5ad7b769b12 = new double[num];
            goto Label_0069;
        Label_00BD:
            this._x31add3b0010a0a52 = 0.0;
            this._x3271cefb1a159639 = 1E-06;
            this._xd4d57078d70c1d3d = 0.0;
            this._x20753e64c7ee4faf = 0.0;
            this._xac19ed778412b7a3 = false;
            this._x2f33d779e5a20b28 = EngineArray.ArrayCopy(network.Weights);
            goto Label_0094;
        Label_0134:
            this._xd938fd32778a1c95 = true;
            this._xf7845a6fecd5afc3 = 0.0;
            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
            {
                return;
            }
            goto Label_00BD;
        }

        public override void CalculateGradients()
        {
            double num2;
            int outputCount = base.Network.OutputCount;
            do
            {
                base.CalculateGradients();
                num2 = (-2.0 / ((double) base.Gradients.Length)) / ((double) outputCount);
                for (int i = 0; i < base.Gradients.Length; i++)
                {
                    base.Gradients[i] *= num2;
                }
            }
            while (((((uint) num2) + ((uint) outputCount)) <= uint.MaxValue) && ((((uint) num2) - ((uint) num2)) > uint.MaxValue));
        }

        public override void InitOthers()
        {
        }

        public override void Iteration()
        {
            int num;
            double num2;
            int num3;
            int num4;
            double num5;
            double num6;
            double num7;
            int num8;
            double num9;
            double num10;
            int num11;
            double num12;
            double num13;
            int num14;
            if (!this._x268cb8b20222b0dc)
            {
                goto Label_062C;
            }
            if (((uint) num3) >= 0)
            {
                this.xd586e0c16bdae7fc();
                if (((uint) num14) > uint.MaxValue)
                {
                    goto Label_0316;
                }
                goto Label_062C;
            }
            goto Label_02F7;
        Label_004E:
            if (num9 >= 0.75)
            {
                this._x3271cefb1a159639 *= 0.25;
            }
        Label_005E:
            if (num9 < 0.25)
            {
                this._x3271cefb1a159639 += (this._xf7845a6fecd5afc3 * (1.0 - num9)) / this._x20753e64c7ee4faf;
            }
            this._x3271cefb1a159639 = BoundNumbers.Bound(this._x3271cefb1a159639);
            if ((((uint) num2) + ((uint) num7)) > uint.MaxValue)
            {
                goto Label_004E;
            }
            if ((((uint) num13) + ((uint) num13)) < 0)
            {
                goto Label_01CB;
            }
            this._x51ae3b338384d896++;
            EngineArray.ArrayCopy(this._x2f33d779e5a20b28, base.Network.Weights);
            return;
        Label_00FB:
            if (num9 >= 0.0)
            {
                num10 = 0.0;
                num11 = 0;
                if ((((uint) num12) + ((uint) num5)) >= 0)
                {
                }
                while (true)
                {
                    if (num11 < num)
                    {
                        num12 = -base.Gradients[num11];
                    }
                    else
                    {
                        this._x31add3b0010a0a52 = 0.0;
                        this._xd938fd32778a1c95 = true;
                        goto Label_01A7;
                    }
                    num10 += num12 * this._xb55b340ae3a3e4e0[num11];
                    this._xb55b340ae3a3e4e0[num11] = num12;
                    if ((((uint) num12) + ((uint) num7)) < 0)
                    {
                        break;
                    }
                    num11++;
                }
            }
            if ((((uint) num5) - ((uint) num6)) >= 0)
            {
                EngineArray.ArrayCopy(this._xb9f048818eee629c, this._x2f33d779e5a20b28);
                base.CurrentError = this._xd4d57078d70c1d3d;
                this._x31add3b0010a0a52 = this._x3271cefb1a159639;
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_031C;
                }
                this._xd938fd32778a1c95 = false;
                goto Label_005E;
            }
        Label_0172:
            this._x9c79b5ad7b769b12[num14] = this._xb55b340ae3a3e4e0[num14] + (num13 * this._x9c79b5ad7b769b12[num14]);
            num14++;
        Label_0197:
            if (num14 < num)
            {
                goto Label_0172;
            }
            this._xac19ed778412b7a3 = false;
            goto Label_004E;
        Label_01A7:
            if (this._x51ae3b338384d896 >= num)
            {
                this._xac19ed778412b7a3 = true;
                EngineArray.ArrayCopy(this._xb55b340ae3a3e4e0, this._x9c79b5ad7b769b12);
                if ((((uint) num) - ((uint) num4)) < 0)
                {
                    goto Label_00FB;
                }
                goto Label_004E;
            }
            num13 = (EngineArray.VectorProduct(this._xb55b340ae3a3e4e0, this._xb55b340ae3a3e4e0) - num10) / num6;
        Label_01CB:
            num14 = 0;
            goto Label_0197;
        Label_0298:
            this.CalculateGradients();
            num9 = ((2.0 * this._xf7845a6fecd5afc3) * (this._xd4d57078d70c1d3d - base.Error)) / (num6 * num6);
            if ((((uint) num10) + ((uint) num8)) < 0)
            {
                goto Label_0401;
            }
            goto Label_00FB;
        Label_02F7:
            this._x2f33d779e5a20b28[num8] = this._xb9f048818eee629c[num8] + (num7 * this._x9c79b5ad7b769b12[num8]);
        Label_0316:
            num8++;
        Label_031C:
            if (4 == 0)
            {
                goto Label_0298;
            }
        Label_0326:
            if (num8 < num)
            {
                goto Label_02F7;
            }
        Label_032B:
            EngineArray.ArrayCopy(this._x2f33d779e5a20b28, base.Network.Weights);
            if (((uint) num12) >= 0)
            {
                goto Label_0298;
            }
            goto Label_01A7;
        Label_0373:
            num6 = EngineArray.VectorProduct(this._x9c79b5ad7b769b12, this._xb55b340ae3a3e4e0);
            num7 = num6 / this._xf7845a6fecd5afc3;
            num8 = 0;
            goto Label_0326;
        Label_03C0:
            this._x31add3b0010a0a52 = 2.0 * (this._x3271cefb1a159639 - (this._xf7845a6fecd5afc3 / this._x20753e64c7ee4faf));
            this._xf7845a6fecd5afc3 = (this._x3271cefb1a159639 * this._x20753e64c7ee4faf) - this._xf7845a6fecd5afc3;
            this._x3271cefb1a159639 = this._x31add3b0010a0a52;
            goto Label_0373;
        Label_0401:
            if (this._xd938fd32778a1c95)
            {
                goto Label_05B0;
            }
        Label_040C:
            this._xf7845a6fecd5afc3 += (this._x3271cefb1a159639 - this._x31add3b0010a0a52) * this._x20753e64c7ee4faf;
            if (this._xf7845a6fecd5afc3 <= 0.0)
            {
                goto Label_03C0;
            }
            goto Label_0373;
        Label_04B9:
            EngineArray.ArrayCopy(this._x2f33d779e5a20b28, base.Network.Weights);
            this.CalculateGradients();
            this._xf7845a6fecd5afc3 = 0.0;
            num4 = 0;
        Label_03E9:
            if (num4 < num)
            {
                num5 = (base.Gradients[num4] - this._x9af996963d03fd21[num4]) / num2;
                this._xf7845a6fecd5afc3 += this._x9c79b5ad7b769b12[num4] * num5;
                num4++;
                if ((((uint) num2) - ((uint) num14)) >= 0)
                {
                    goto Label_03E9;
                }
                goto Label_03C0;
            }
            goto Label_040C;
        Label_05B0:
            this._x20753e64c7ee4faf = EngineArray.VectorProduct(this._x9c79b5ad7b769b12, this._x9c79b5ad7b769b12);
            num2 = 0.0001 / Math.Sqrt(this._x20753e64c7ee4faf);
            EngineArray.ArrayCopy(base.Gradients, this._x9af996963d03fd21);
            EngineArray.ArrayCopy(this._x2f33d779e5a20b28, this._xb9f048818eee629c);
            this._xd4d57078d70c1d3d = base.Error;
            num3 = 0;
            if ((((uint) num5) + ((uint) num3)) > uint.MaxValue)
            {
                if (((uint) num13) < 0)
                {
                    goto Label_0326;
                }
                goto Label_0401;
            }
            while (num3 < num)
            {
                this._x2f33d779e5a20b28[num3] += num2 * this._x9c79b5ad7b769b12[num3];
                num3++;
            }
            goto Label_04B9;
        Label_062C:
            num = this._x2f33d779e5a20b28.Length;
            while (this._xac19ed778412b7a3)
            {
                this._x3271cefb1a159639 = 1E-06;
                this._x31add3b0010a0a52 = 0.0;
                this._x51ae3b338384d896 = 1;
                if (((uint) num2) < 0)
                {
                    goto Label_04B9;
                }
                this._xd938fd32778a1c95 = true;
                this._xac19ed778412b7a3 = false;
                if ((((uint) num14) + ((uint) num2)) >= 0)
                {
                    goto Label_0401;
                }
            }
            if ((((uint) num7) - ((uint) num7)) < 0)
            {
                goto Label_032B;
            }
            if ((((uint) num6) + ((uint) num11)) <= uint.MaxValue)
            {
                goto Label_0401;
            }
            goto Label_05B0;
        }

        public override double UpdateWeight(double[] gradients, double[] lastGradient, int index)
        {
            return 0.0;
        }

        private void xd586e0c16bdae7fc()
        {
            int num2;
            double num3;
            int length = this._x2f33d779e5a20b28.Length;
            if ((((uint) num2) | 0x80000000) != 0)
            {
                goto Label_0099;
            }
            if ((((uint) num3) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0045;
            }
        Label_003C:
            this._x268cb8b20222b0dc = false;
            return;
        Label_0045:
            if ((((uint) num2) + ((uint) length)) > uint.MaxValue)
            {
                goto Label_009F;
            }
            for (num2 = 0; num2 < length; num2++)
            {
                this._x9c79b5ad7b769b12[num2] = this._xb55b340ae3a3e4e0[num2] = -base.Gradients[num2];
            }
            if (((uint) length) >= 0)
            {
                goto Label_003C;
            }
        Label_0099:
            this.CalculateGradients();
        Label_009F:
            this._x51ae3b338384d896 = 1;
            goto Label_0045;
        }
    }
}

