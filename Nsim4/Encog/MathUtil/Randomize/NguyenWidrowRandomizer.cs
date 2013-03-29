namespace Encog.MathUtil.Randomize
{
    using Encog;
    using Encog.ML;
    using Encog.Neural.Networks;
    using System;

    public class NguyenWidrowRandomizer : RangeRandomizer
    {
        private int _x43f451310e815b76;
        private double _xd7d571ecee49d1e4;

        public NguyenWidrowRandomizer(double min, double max) : base(min, max)
        {
        }

        public sealed override void Randomize(IMLMethod method)
        {
            if (!(method is BasicNetwork))
            {
                throw new EncogError("Ngyyen Widrow only works on BasicNetwork.");
            }
            BasicNetwork network = (BasicNetwork) method;
        Label_00B3:
            new RangeRandomizer(base.Min, base.Max).Randomize(network);
            int num = 0;
            int l = 1;
            while (true)
            {
                if (l >= (network.LayerCount - 1))
                {
                    if ((num >= 1) && ((((uint) num) + ((uint) l)) <= uint.MaxValue))
                    {
                        this._x43f451310e815b76 = network.InputCount;
                        this._xd7d571ecee49d1e4 = 0.7 * Math.Pow((double) num, 1.0 / ((double) network.InputCount));
                        base.Randomize(network);
                        return;
                    }
                    return;
                }
                num += network.GetLayerTotalNeuronCount(l);
                if (((uint) l) < 0)
                {
                    goto Label_00B3;
                }
                l++;
            }
        }

        public override void Randomize(BasicNetwork network, int fromLayer)
        {
            int num2;
            int num3;
            double num4;
            int num5;
            double num6;
            int num7;
            double num8;
            int layerTotalNeuronCount = network.GetLayerTotalNeuronCount(fromLayer);
            goto Label_00DF;
        Label_0011:
            if (num3 < num2)
            {
                num4 = 0.0;
                num5 = 0;
            }
            else if ((((uint) num8) - ((uint) layerTotalNeuronCount)) >= 0)
            {
                return;
            }
            while (true)
            {
                if (num5 >= layerTotalNeuronCount)
                {
                    num4 = Math.Sqrt(num4);
                    num7 = 0;
                    if ((((uint) num4) + ((uint) num2)) < 0)
                    {
                        break;
                    }
                    goto Label_0065;
                }
                num6 = network.GetWeight(fromLayer, num5, num3);
                num4 += num6 * num6;
                num5++;
            }
        Label_0044:
            if ((((uint) fromLayer) + ((uint) num6)) > uint.MaxValue)
            {
                goto Label_00DF;
            }
            num7++;
        Label_0065:
            if (num7 < layerTotalNeuronCount)
            {
                num8 = network.GetWeight(fromLayer, num7, num3);
            }
            else
            {
                num3++;
                goto Label_0011;
            }
        Label_009C:
            num8 = (this._xd7d571ecee49d1e4 * num8) / num4;
            network.SetWeight(fromLayer, num7, num3, num8);
            goto Label_0044;
        Label_00DF:
            num2 = network.GetLayerNeuronCount(fromLayer + 1);
            if (((uint) num8) > uint.MaxValue)
            {
                goto Label_009C;
            }
            num3 = 0;
            goto Label_0011;
        }
    }
}

