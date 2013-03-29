namespace Encog.Neural.Networks.Structure
{
    using Encog.MathUtil;
    using Encog.Neural.Networks;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnalyzeNetwork
    {
        private readonly int _x0dcd8230e4ec0670;
        private readonly NumericRange _x232c44e69c86297f;
        private readonly NumericRange _x2f33d779e5a20b28;
        private readonly int _x465229d781237721;
        private readonly double[] _x5933bfade0487265;
        private readonly double[] _x7cd672b98e9d2817;
        private readonly double[] _x8158512e31b17fc4;
        private readonly NumericRange _xd16d54155d6ebc35;

        public AnalyzeNetwork(BasicNetwork network)
        {
            int num3;
            int num4;
            int layerTotalNeuronCount;
            int layerNeuronCount;
            int num7;
            int num8;
            double num9;
            int num10;
            int num11;
            double num12;
            int num = 0;
            int num2 = 0;
            IList<double> list = new List<double>();
            IList<double> list2 = new List<double>();
            if (0 != 0)
            {
                goto Label_0115;
            }
            IList<double> values = new List<double>();
            if ((((uint) num2) | 1) != 0)
            {
                num3 = 0;
                goto Label_00C9;
            }
        Label_000B:
            this._xd16d54155d6ebc35 = new NumericRange(values);
            this._x8158512e31b17fc4 = EngineArray.ListToDouble(list2);
            this._x7cd672b98e9d2817 = EngineArray.ListToDouble(values);
            this._x5933bfade0487265 = EngineArray.ListToDouble(list);
        Label_003D:
            if (((uint) layerNeuronCount) >= 0)
            {
            }
            return;
        Label_0057:
            if ((((uint) num2) + ((uint) num2)) < 0)
            {
                goto Label_0317;
            }
            this._x465229d781237721 = num2;
            if (((uint) layerTotalNeuronCount) > uint.MaxValue)
            {
                goto Label_003D;
            }
            this._x2f33d779e5a20b28 = new NumericRange(list2);
            if ((((uint) num3) + ((uint) layerTotalNeuronCount)) > uint.MaxValue)
            {
                goto Label_01E8;
            }
            this._x232c44e69c86297f = new NumericRange(list);
            if ((((uint) num11) + ((uint) layerTotalNeuronCount)) <= uint.MaxValue)
            {
                goto Label_000B;
            }
            goto Label_01F2;
        Label_00C3:
            num3++;
        Label_00C9:
            if (num3 < (network.LayerCount - 1))
            {
                goto Label_0317;
            }
            this._x0dcd8230e4ec0670 = num;
            goto Label_0057;
        Label_00FF:
            if (num11 < layerNeuronCount)
            {
                num12 = network.GetWeight(num3, num10, num11);
                goto Label_0127;
            }
            goto Label_00C3;
        Label_0115:
            values.Add(num12);
            num2++;
            if (0 == 0)
            {
                num11++;
                if (((uint) num9) < 0)
                {
                    goto Label_02BF;
                }
                goto Label_00FF;
            }
            goto Label_0184;
        Label_0127:
            if (!network.Structure.ConnectionLimited)
            {
                goto Label_014B;
            }
        Label_0134:
            if (Math.Abs(num12) < network.Structure.ConnectionLimit)
            {
                num++;
                if ((((uint) num8) - ((uint) num12)) >= 0)
                {
                    goto Label_0167;
                }
                goto Label_000B;
            }
        Label_014B:
            list.Add(num12);
            if ((((uint) num7) & 0) == 0)
            {
                goto Label_0115;
            }
        Label_0167:
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_014B;
            }
            goto Label_0127;
        Label_0184:
            if (4 != 0)
            {
                goto Label_00C3;
            }
            goto Label_0057;
        Label_01E8:
            num11 = 0;
            goto Label_00FF;
        Label_01F2:
            num8++;
        Label_01F8:
            if (num8 < layerNeuronCount)
            {
                goto Label_02BF;
            }
            num7++;
        Label_0207:
            if (num7 < num4)
            {
                num8 = 0;
                goto Label_01F8;
            }
            if (((((uint) num8) | 1) != 0) && (num4 == layerTotalNeuronCount))
            {
                goto Label_0184;
            }
            num10 = num4;
            goto Label_01E8;
        Label_02BF:
            num9 = network.GetWeight(num3, num7, num8);
            if (0 == 0)
            {
                if (network.Structure.ConnectionLimited && (((((uint) num10) + ((uint) num)) < 0) || (Math.Abs(num9) < network.Structure.ConnectionLimit)))
                {
                    num++;
                }
                list2.Add(num9);
            }
            values.Add(num9);
            num2++;
            goto Label_01F2;
        Label_0317:
            num4 = network.GetLayerNeuronCount(num3);
            layerTotalNeuronCount = network.GetLayerTotalNeuronCount(num3);
            if (((uint) num7) > uint.MaxValue)
            {
                goto Label_0134;
            }
            layerNeuronCount = network.GetLayerNeuronCount(num3 + 1);
            num7 = 0;
            if ((((uint) layerTotalNeuronCount) + ((uint) layerTotalNeuronCount)) >= 0)
            {
            }
            goto Label_0207;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("All Values : ");
            goto Label_009E;
        Label_007C:
            builder.Append(this._x232c44e69c86297f.ToString());
        Label_0032:
            builder.Append("\n");
            builder.Append("Weights    : ");
            if (0 != 0)
            {
                goto Label_00BC;
            }
            builder.Append(this._x2f33d779e5a20b28.ToString());
            builder.Append("\n");
            builder.Append("Disabled   : ");
            if (0 == 0)
            {
                builder.Append(Format.FormatInteger(this._x0dcd8230e4ec0670));
                builder.Append("\n");
                if (0 == 0)
                {
                    if (0 == 0)
                    {
                        return builder.ToString();
                    }
                }
                else
                {
                    goto Label_0032;
                }
                goto Label_007C;
            }
        Label_009E:
            builder.Append(this._xd16d54155d6ebc35.ToString());
            builder.Append("\n");
        Label_00BC:
            builder.Append("Bias : ");
            goto Label_007C;
        }

        public double[] AllValues
        {
            get
            {
                return this._x7cd672b98e9d2817;
            }
        }

        public NumericRange Bias
        {
            get
            {
                return this._x232c44e69c86297f;
            }
        }

        public double[] BiasValues
        {
            get
            {
                return this._x5933bfade0487265;
            }
        }

        public int DisabledConnections
        {
            get
            {
                return this._x0dcd8230e4ec0670;
            }
        }

        public int TotalConnections
        {
            get
            {
                return this._x465229d781237721;
            }
        }

        public NumericRange Weights
        {
            get
            {
                return this._x2f33d779e5a20b28;
            }
        }

        public NumericRange WeightsAndBias
        {
            get
            {
                return this._xd16d54155d6ebc35;
            }
        }

        public double[] WeightValues
        {
            get
            {
                return this._x8158512e31b17fc4;
            }
        }
    }
}

