namespace Encog.Engine.Network.Activation
{
    using System;

    [Serializable]
    public class ActivationStep : IActivationFunction, ICloneable
    {
        private readonly double[] _paras;
        public const int ParamStepCenter = 0;
        public const int ParamStepHigh = 2;
        public const int ParamStepLow = 1;

        public ActivationStep() : this(0.0, 0.0, 1.0)
        {
        }

        public ActivationStep(double low, double center, double high)
        {
            this._paras = new double[] { center, low, high };
        }

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            int index = start;
            if ((((uint) size) + ((uint) start)) <= uint.MaxValue)
            {
                goto Label_002B;
            }
            goto Label_0033;
        Label_0027:
            index++;
        Label_002B:
            if (index < (start + size))
            {
                if (x[index] >= this._paras[0])
                {
                    goto Label_0033;
                }
                x[index] = this._paras[1];
                goto Label_0027;
            }
            return;
        Label_0033:
            x[index] = this._paras[2];
            goto Label_0027;
        }

        public object Clone()
        {
            return new ActivationStep(this.Low, this.Center, this.High);
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return 1.0;
        }

        public virtual bool HasDerivative()
        {
            return true;
        }

        public double Center
        {
            get
            {
                return this._paras[0];
            }
            set
            {
                this._paras[0] = value;
            }
        }

        public double High
        {
            get
            {
                return this._paras[2];
            }
            set
            {
                this._paras[2] = value;
            }
        }

        public double Low
        {
            get
            {
                return this._paras[1];
            }
            set
            {
                this._paras[1] = value;
            }
        }

        public virtual string[] ParamNames
        {
            get
            {
                return new string[] { "center", "low", "high" };
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

