namespace Encog.Mathutil.Randomize
{
    using Encog;
    using Encog.MathUtil.Matrices;
    using Encog.MathUtil.Randomize;
    using Encog.Neural.Networks;
    using System;

    public class FanInRandomizer : BasicRandomizer
    {
        private readonly double _x24324ae68083c4c8;
        private readonly bool _x3bf7ecf2688d32ee;
        private readonly double _x95b133adb6a0822b;
        private const double xc77596104b9c9f95 = 2.4;
        internal const string xdc1af3a17717bf0a = "To use FanInRandomizer you must present a Matrix or 2D array type value.";

        public FanInRandomizer() : this(-2.4, 2.4, false)
        {
        }

        public FanInRandomizer(double boundary, bool sqrt) : this(-boundary, boundary, sqrt)
        {
        }

        public FanInRandomizer(double aLowerBound, double anUpperBound, bool sqrt)
        {
            this._x24324ae68083c4c8 = aLowerBound;
            this._x95b133adb6a0822b = anUpperBound;
            this._x3bf7ecf2688d32ee = sqrt;
        }

        public override void Randomize(Matrix m)
        {
            int num2;
            int num = 0;
            goto Label_0015;
        Label_0004:
            num2++;
        Label_0008:
            if (num2 < m.Cols)
            {
                m[num, num2] = this.x7417261f548b2c9b(m.Rows);
                goto Label_0004;
            }
            num++;
        Label_0015:
            if (num >= m.Rows)
            {
                if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0004;
            }
            num2 = 0;
            goto Label_0008;
        }

        public override void Randomize(double[][] d)
        {
            int num2;
            double[][] numArray2 = d;
        Label_002F:
            num2 = 0;
            while (num2 < numArray2.Length)
            {
                double[] numArray = numArray2[num2];
                for (int i = 0; i < d[0].Length; i++)
                {
                    numArray[i] = this.x7417261f548b2c9b(d.Length);
                }
                num2++;
                if (8 == 0)
                {
                    goto Label_002F;
                }
            }
        }

        public override double Randomize(double d)
        {
            xa8257a438656deb5();
            return 0.0;
        }

        public override void Randomize(double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = this.x7417261f548b2c9b(1);
            }
        }

        public override void Randomize(BasicNetwork network, int fromLayer)
        {
            int num4;
            double num5;
            int layerTotalNeuronCount = network.GetLayerTotalNeuronCount(fromLayer);
            int layerNeuronCount = network.GetLayerNeuronCount(fromLayer + 1);
            int fromNeuron = 0;
            if (((uint) fromLayer) < 0)
            {
                goto Label_0012;
            }
        Label_000E:
            if (fromNeuron < layerTotalNeuronCount)
            {
                num4 = 0;
                goto Label_0054;
            }
        Label_0012:
            if (((uint) num5) > uint.MaxValue)
            {
                goto Label_0054;
            }
            if ((((uint) fromNeuron) + ((uint) fromNeuron)) >= 0)
            {
                return;
            }
        Label_003C:
            num5 = this.x7417261f548b2c9b(layerNeuronCount);
            network.SetWeight(fromLayer, fromNeuron, num4, num5);
            num4++;
        Label_0054:
            if (num4 < layerNeuronCount)
            {
                goto Label_003C;
            }
            fromNeuron++;
            goto Label_000E;
        }

        private double x7417261f548b2c9b(int x2eb5785cf1641b8b)
        {
            double num = this._x3bf7ecf2688d32ee ? Math.Sqrt((double) x2eb5785cf1641b8b) : ((double) x2eb5785cf1641b8b);
            return ((this._x24324ae68083c4c8 / num) + (base.NextDouble() * ((this._x95b133adb6a0822b - this._x24324ae68083c4c8) / num)));
        }

        private static void xa8257a438656deb5()
        {
            throw new EncogError("To use FanInRandomizer you must present a Matrix or 2D array type value.");
        }
    }
}

