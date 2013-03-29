namespace Encog.Engine.Network.Activation
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class ActivationSoftMax : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            int num3;
            double num = 0.0;
            int index = start;
            if ((((uint) num3) - ((uint) size)) > uint.MaxValue)
            {
                goto Label_0026;
            }
            while (index < (start + size))
            {
                x[index] = BoundMath.Exp(x[index]);
                num += x[index];
                index++;
            }
            num3 = start;
        Label_0010:
            if (num3 >= (start + size))
            {
                return;
            }
        Label_0026:
            x[num3] /= num;
            num3++;
            goto Label_0010;
        }

        public object Clone()
        {
            return new ActivationSoftMax();
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return 1.0;
        }

        public virtual bool HasDerivative()
        {
            return true;
        }

        public virtual string[] ParamNames
        {
            get
            {
                return new string[0];
            }
        }

        public virtual double[] Params
        {
            get
            {
                return this._paras;
            }
        }
    }
}

