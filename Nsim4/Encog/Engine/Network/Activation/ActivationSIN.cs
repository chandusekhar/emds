namespace Encog.Engine.Network.Activation
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class ActivationSIN : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                x[i] = BoundMath.Sin(x[i]);
            }
        }

        public object Clone()
        {
            return new ActivationSIN();
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return BoundMath.Cos(b);
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

