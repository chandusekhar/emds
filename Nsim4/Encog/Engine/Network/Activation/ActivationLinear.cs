namespace Encog.Engine.Network.Activation
{
    using System;

    [Serializable]
    public class ActivationLinear : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                x[i] = x[i];
            }
        }

        public object Clone()
        {
            return new ActivationLinear();
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

