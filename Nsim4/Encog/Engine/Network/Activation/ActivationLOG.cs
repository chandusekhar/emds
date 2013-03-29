namespace Encog.Engine.Network.Activation
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class ActivationLOG : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                if (x[i] >= 0.0)
                {
                    x[i] = BoundMath.Log(1.0 + x[i]);
                }
                else
                {
                    x[i] = -BoundMath.Log(1.0 - x[i]);
                }
            }
        }

        public object Clone()
        {
            return new ActivationLOG();
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            if (b >= 0.0)
            {
                return (1.0 / (1.0 + b));
            }
            return (1.0 / (1.0 - b));
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

