namespace Encog.Engine.Network.Activation
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class ActivationGaussian : IActivationFunction, ICloneable
    {
        private readonly double[] _paras;
        public const int ParamGaussianCenter = 0;
        public const int ParamGaussianPeak = 1;
        public const int ParamGaussianWidth = 2;

        public ActivationGaussian()
        {
        }

        public ActivationGaussian(double center, double peak, double width)
        {
            this._paras = new double[] { center, peak, width };
        }

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            for (int i = start; i < (start + size); i++)
            {
                x[i] = this._paras[1] * BoundMath.Exp(-Math.Pow(x[i] - this._paras[0], 2.0) / ((2.0 * this._paras[2]) * this._paras[2]));
            }
        }

        public object Clone()
        {
            return new ActivationGaussian(this.Center, this.Peak, this.Width);
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            double num = this._paras[2];
            double num2 = this._paras[1];
            return ((((Math.Exp((((-0.5 * num) * num) * b) * b) * num2) * num) * num) * ((((num * num) * b) * b) - 1.0));
        }

        public virtual bool HasDerivative()
        {
            return true;
        }

        private double Center
        {
            get
            {
                return this.Params[0];
            }
        }

        public virtual string[] ParamNames
        {
            get
            {
                return new string[] { "center", "peak", "width" };
            }
        }

        public virtual double[] Params
        {
            get
            {
                return this._paras;
            }
        }

        private double Peak
        {
            get
            {
                return this.Params[1];
            }
        }

        private double Width
        {
            get
            {
                return this.Params[2];
            }
        }
    }
}

