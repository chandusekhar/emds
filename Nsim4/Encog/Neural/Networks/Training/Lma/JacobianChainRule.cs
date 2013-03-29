namespace Encog.Neural.Networks.Training.Lma
{
    using Encog.Engine.Network.Activation;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.Networks;
    using Encog.Util;
    using System;

    public class JacobianChainRule : IComputeJacobian
    {
        private int _x4c51ad74d6bcc9e9;
        private readonly int _x530ae94d583e0ea1;
        private readonly IMLDataPair _x61830ac74d65acc3;
        private int _x82d75873c9eb7116;
        private readonly BasicNetwork _x87a7fc6a72741c2e;
        private readonly int _xabb126b401219ba2;
        private readonly IMLDataSet _xb12276308f0fa6d9;
        private readonly double[][] _xbdeab667c25bbc32;
        private readonly double[] _xc8a462f994253347;

        public JacobianChainRule(BasicNetwork network, IMLDataSet indexableTraining)
        {
            BasicMLData data;
            BasicMLData data2;
            if (0 == 0)
            {
                goto Label_0055;
            }
        Label_0009:
            this._x61830ac74d65acc3 = new BasicMLDataPair(data, data2);
            return;
        Label_0055:
            this._xb12276308f0fa6d9 = indexableTraining;
            if (0 == 0)
            {
            }
            this._x87a7fc6a72741c2e = network;
            this._xabb126b401219ba2 = network.Structure.CalculateSize();
            this._x530ae94d583e0ea1 = (int) this._xb12276308f0fa6d9.Count;
            this._xbdeab667c25bbc32 = EngineArray.AllocateDouble2D(this._x530ae94d583e0ea1, this._xabb126b401219ba2);
            this._xc8a462f994253347 = new double[this._x530ae94d583e0ea1];
            data = new BasicMLData(this._xb12276308f0fa6d9.InputSize);
            data2 = new BasicMLData(this._xb12276308f0fa6d9.IdealSize);
            if (-2147483648 != 0)
            {
                goto Label_0009;
            }
            goto Label_0055;
        }

        public virtual double Calculate(double[] weights)
        {
            double num = 0.0;
            int index = 0;
        Label_000C:
            if (index < this._x530ae94d583e0ea1)
            {
                this._x4c51ad74d6bcc9e9 = index;
                this._x82d75873c9eb7116 = 0;
                if ((((uint) index) - ((uint) num)) >= 0)
                {
                    this._xb12276308f0fa6d9.GetRecord((long) index, this._x61830ac74d65acc3);
                    double num3 = this.xddf5c75e1d743e26(this._x61830ac74d65acc3);
                    this._xc8a462f994253347[index] = num3;
                    if (3 != 0)
                    {
                        num += num3 * num3;
                    }
                    index++;
                    goto Label_000C;
                }
            }
            return (num / 2.0);
        }

        private static double xbc17cb206c45d25e(IActivationFunction x19218ffab70283ef, double x73f821c71fe1e676)
        {
            double[] d = new double[] { x73f821c71fe1e676 };
            x19218ffab70283ef.ActivationFunction(d, 0, d.Length);
            d[0] = x19218ffab70283ef.DerivativeFunction(d[0], d[0]);
            return d[0];
        }

        private static double xd3eb00c1c38e3a49(IActivationFunction x19218ffab70283ef, double x73f821c71fe1e676)
        {
            return x19218ffab70283ef.DerivativeFunction(x73f821c71fe1e676, x73f821c71fe1e676);
        }

        private double xddf5c75e1d743e26(IMLDataPair x61830ac74d65acc3)
        {
            double num2;
            int num3;
            int num4;
            int layerTotalNeuronCount;
            int layerNeuronCount;
            double layerOutput;
            int num8;
            int num10;
            double num12;
            int num13;
            int num14;
            int num15;
            int num17;
            double num = 0.0;
            if ((((uint) num17) + ((uint) num8)) >= 0)
            {
                goto Label_030C;
            }
            goto Label_0039;
        Label_0030:
            if (num10 < layerNeuronCount)
            {
                IActivationFunction activation;
                double num11;
                layerOutput = this._x87a7fc6a72741c2e.GetLayerOutput(num4, num10);
                do
                {
                    activation = this._x87a7fc6a72741c2e.GetActivation(num4);
                    num11 = this._x87a7fc6a72741c2e.GetWeight(num4, num10, 0);
                }
                while ((((uint) num10) | uint.MaxValue) == 0);
                num12 = (xd3eb00c1c38e3a49(activation, layerOutput) * xbc17cb206c45d25e(activation, num2)) * num11;
                if (((uint) num) >= 0)
                {
                    goto Label_0106;
                }
                goto Label_00B3;
            }
        Label_0039:
            if (num3 > 0)
            {
                num3--;
                num4--;
                if ((((uint) layerOutput) - ((uint) layerNeuronCount)) <= uint.MaxValue)
                {
                    layerTotalNeuronCount = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(num3);
                    layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num4);
                    if ((((uint) num8) + ((uint) layerTotalNeuronCount)) > uint.MaxValue)
                    {
                        goto Label_0095;
                    }
                    if (2 == 0)
                    {
                        goto Label_0115;
                    }
                    if ((((uint) num3) + ((uint) layerNeuronCount)) < 0)
                    {
                        goto Label_0352;
                    }
                    num10 = 0;
                }
                goto Label_0030;
            }
            if ((((uint) num12) - ((uint) num17)) >= 0)
            {
                if ((((uint) num15) & 0) == 0)
                {
                    return num;
                }
                goto Label_0039;
            }
            goto Label_00B3;
        Label_005D:
            if (num14 < layerNeuronCount)
            {
                goto Label_00B3;
            }
            this._xbdeab667c25bbc32[this._x4c51ad74d6bcc9e9][this._x82d75873c9eb7116++] = num12 * this._x87a7fc6a72741c2e.GetLayerOutput(num3, num13);
        Label_0095:
            num13++;
        Label_009B:
            if (num13 < layerTotalNeuronCount)
            {
                num2 = 0.0;
                goto Label_0115;
            }
            if (((uint) num10) <= uint.MaxValue)
            {
                num10++;
                goto Label_0030;
            }
        Label_00B3:
            num15 = 0;
            while (num15 < layerTotalNeuronCount)
            {
                num2 += this._x87a7fc6a72741c2e.GetWeight(num3, num15, num14) * layerOutput;
            Label_00CE:
                num15++;
            }
            num14++;
            goto Label_005D;
        Label_0106:
            num13 = 0;
            goto Label_009B;
        Label_0115:
            num14 = 0;
            goto Label_005D;
        Label_030C:
            num2 = 0.0;
            this._x87a7fc6a72741c2e.Compute(x61830ac74d65acc3.Input);
            num3 = this._x87a7fc6a72741c2e.LayerCount - 2;
            num4 = this._x87a7fc6a72741c2e.LayerCount - 1;
            layerTotalNeuronCount = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(num3);
        Label_0352:
            layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num4);
            layerOutput = this._x87a7fc6a72741c2e.Structure.Flat.LayerOutput[0];
            num = x61830ac74d65acc3.Ideal[0] - layerOutput;
            num8 = 0;
            while (true)
            {
                while (num8 >= layerTotalNeuronCount)
                {
                    if (((uint) layerOutput) > uint.MaxValue)
                    {
                        goto Label_00CE;
                    }
                    if ((((uint) num2) + ((uint) num10)) >= 0)
                    {
                        goto Label_0039;
                    }
                    if ((((uint) num14) & 0) == 0)
                    {
                        goto Label_030C;
                    }
                }
                double num9 = this._x87a7fc6a72741c2e.GetLayerOutput(num3, num8);
                if (((uint) layerOutput) > uint.MaxValue)
                {
                    goto Label_0106;
                }
                this._xbdeab667c25bbc32[this._x4c51ad74d6bcc9e9][this._x82d75873c9eb7116++] = xd3eb00c1c38e3a49(this._x87a7fc6a72741c2e.GetActivation(num4), layerOutput) * num9;
                num8++;
            }
        }

        public virtual double[][] Jacobian
        {
            get
            {
                return this._xbdeab667c25bbc32;
            }
        }

        public virtual double[] RowErrors
        {
            get
            {
                return this._xc8a462f994253347;
            }
        }
    }
}

