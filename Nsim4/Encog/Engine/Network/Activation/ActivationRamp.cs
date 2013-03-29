namespace Encog.Engine.Network.Activation
{
    using System;

    [Serializable]
    public class ActivationRamp : IActivationFunction, ICloneable
    {
        private readonly double[] _paras;
        public const int ParamRampHigh = 2;
        public const int ParamRampHighThreshold = 0;
        public const int ParamRampLow = 3;
        public const int ParamRampLowThreshold = 1;

        public ActivationRamp() : this(1.0, 0.0, 1.0, 0.0)
        {
        }

        public ActivationRamp(double thresholdHigh, double thresholdLow, double high, double low)
        {
            this._paras = new double[4];
            this._paras[0] = thresholdHigh;
            this._paras[1] = thresholdLow;
            if ((((uint) thresholdLow) + ((uint) high)) <= uint.MaxValue)
            {
                this._paras[2] = high;
                this._paras[3] = low;
            }
        }

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            double num = (this._paras[0] - this._paras[1]) / (this._paras[2] - this._paras[3]);
            int index = start;
            goto Label_002D;
        Label_0029:
            index++;
        Label_002D:
            if (index < (start + size))
            {
                if (x[index] >= this._paras[1])
                {
                Label_0078:
                    if (x[index] > this._paras[0])
                    {
                        x[index] = this._paras[2];
                    }
                    else
                    {
                        if ((((uint) size) + ((uint) start)) < 0)
                        {
                            if ((((uint) index) & 0) != 0)
                            {
                                goto Label_0029;
                            }
                            goto Label_0078;
                        }
                        x[index] = num * x[index];
                    }
                }
                else
                {
                    x[index] = this._paras[3];
                }
                goto Label_0029;
            }
        }

        public object Clone()
        {
            return new ActivationRamp(this._paras[0], this._paras[1], this._paras[2], this._paras[3]);
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            return 1.0;
        }

        public virtual bool HasDerivative()
        {
            return true;
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
                return this._paras[3];
            }
            set
            {
                this._paras[3] = value;
            }
        }

        public virtual string[] ParamNames
        {
            get
            {
                string[] strArray2 = new string[4];
                strArray2[0] = "thresholdHigh";
                strArray2[1] = "thresholdLow";
                strArray2[2] = "high";
                if (0 == 0)
                {
                    strArray2[3] = "low";
                }
                return strArray2;
            }
        }

        public virtual double[] Params
        {
            get
            {
                return this._paras;
            }
        }

        public double ThresholdHigh
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

        public double ThresholdLow
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
    }
}

