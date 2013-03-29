namespace Encog.Neural.Flat
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.RBF;
    using Encog.Util;
    using System;

    [Serializable]
    public class FlatNetworkRBF : FlatNetwork
    {
        private IRadialBasisFunction[] _rbf;

        public FlatNetworkRBF()
        {
        }

        public FlatNetworkRBF(int inputCount, int hiddenCount, int outputCount, IRadialBasisFunction[] rbf)
        {
            FlatLayer[] layers = new FlatLayer[3];
            this._rbf = rbf;
            layers[0] = new FlatLayer(new ActivationLinear(), inputCount, 0.0);
            do
            {
                layers[1] = new FlatLayer(new ActivationLinear(), hiddenCount, 0.0);
            }
            while ((((uint) hiddenCount) & 0) != 0);
            if (2 != 0)
            {
                layers[2] = new FlatLayer(new ActivationLinear(), outputCount, 0.0);
                base.Init(layers);
            }
        }

        public sealed override object Clone()
        {
            FlatNetworkRBF result = new FlatNetworkRBF();
            base.CloneFlatNetwork(result);
            result._rbf = this._rbf;
            return result;
        }

        public sealed override void Compute(double[] x, double[] output)
        {
            int num2;
            double num3;
            int num = base.LayerIndex[1];
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                goto Label_00B0;
            }
            goto Label_0087;
        Label_0035:
            if (num2 >= this._rbf.Length)
            {
                base.ComputeLayer(1);
                do
                {
                    EngineArray.ArrayCopy(base.LayerOutput, 0, output, 0, base.OutputCount);
                }
                while ((((uint) num3) & 0) != 0);
                if ((((uint) num) | 0x80000000) != 0)
                {
                    if ((((uint) num3) - ((uint) num2)) >= 0)
                    {
                        return;
                    }
                    goto Label_00B0;
                }
            }
        Label_0087:
            num3 = this._rbf[num2].Calculate(x);
            base.LayerOutput[num + num2] = num3;
            num2++;
            goto Label_0035;
        Label_00B0:
            num2 = 0;
            goto Label_0035;
        }

        public IRadialBasisFunction[] RBF
        {
            get
            {
                return this._rbf;
            }
            set
            {
                this._rbf = value;
            }
        }
    }
}

