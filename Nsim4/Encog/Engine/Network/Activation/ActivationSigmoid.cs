namespace Encog.Engine.Network.Activation
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class ActivationSigmoid : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                x[i] = 1.0 / (1.0 + BoundMath.Exp(-1.0 * x[i]));
            }
        }

        public object Clone()
        {
            return new ActivationSigmoid();
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return (a * (1.0 - a));
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

