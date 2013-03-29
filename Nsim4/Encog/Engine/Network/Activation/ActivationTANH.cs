namespace Encog.Engine.Network.Activation
{
    using System;

    [Serializable]
    public class ActivationTANH : IActivationFunction, ICloneable
    {
        private readonly double[] _paras = new double[0];

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                x[i] = Math.Tanh(x[i]);
            }
        }

        public object Clone()
        {
            return new ActivationTANH();
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return (1.0 - (a * a));
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

