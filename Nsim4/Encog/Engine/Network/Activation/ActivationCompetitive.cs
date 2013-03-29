namespace Encog.Engine.Network.Activation
{
    using Encog.Neural;
    using System;

    [Serializable]
    public class ActivationCompetitive : IActivationFunction, ICloneable
    {
        private readonly double[] _paras;
        public const int ParamCompetitiveMaxWinners = 0;

        public ActivationCompetitive() : this(1)
        {
        }

        public ActivationCompetitive(int winners)
        {
            this._paras = new double[] { (double) winners };
        }

        public virtual void ActivationFunction(double[] x, int start, int size)
        {
            double num;
            int num2;
            double negativeInfinity;
            int num4;
            int num5;
            int num6;
            bool[] flagArray = new bool[x.Length];
            if (0 == 0)
            {
                goto Label_0187;
            }
            goto Label_00C9;
        Label_0014:
            num6++;
            if ((((uint) size) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_0154;
            }
        Label_0035:
            if (num6 < (start + size))
            {
                if (flagArray[num6])
                {
                    x[num6] /= num;
                    goto Label_0014;
                }
                x[num6] = 0.0;
                if (((uint) num) >= 0)
                {
                    goto Label_0014;
                }
            }
            return;
        Label_0056:
            if (num2 < this._paras[0])
            {
                negativeInfinity = double.NegativeInfinity;
                goto Label_0154;
            }
        Label_0065:
            num6 = start;
            goto Label_0035;
        Label_00C9:
            if (num5 < (start + size))
            {
                goto Label_00FB;
            }
            if ((((uint) num) + ((uint) num6)) >= 0)
            {
                goto Label_012B;
            }
            goto Label_00C9;
        Label_00F1:
            num5++;
            if (-2147483648 != 0)
            {
                goto Label_00C9;
            }
            goto Label_012B;
        Label_00FB:
            if (flagArray[num5] || (((((uint) num5) - ((uint) start)) <= uint.MaxValue) && (x[num5] <= negativeInfinity)))
            {
                goto Label_00F1;
            }
        Label_0119:
            num4 = num5;
            negativeInfinity = x[num5];
            goto Label_00F1;
        Label_012B:
            if (((uint) num2) <= uint.MaxValue)
            {
                num += negativeInfinity;
                if (((uint) size) < 0)
                {
                    goto Label_0065;
                }
                if (((uint) num5) < 0)
                {
                    goto Label_00FB;
                }
                flagArray[num4] = true;
                num2++;
                goto Label_0056;
            }
            return;
        Label_0154:
            num4 = -1;
            num5 = start;
            if (((uint) negativeInfinity) > uint.MaxValue)
            {
                goto Label_0056;
            }
            if ((((uint) size) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_00C9;
            }
        Label_0187:
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_0119;
            }
            num = 0.0;
            num2 = 0;
            if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0056;
            }
            goto Label_00C9;
        }

        public virtual double DerivativeFunction(double b, double a)
        {
            throw new NeuralNetworkError("Can't use the competitive activation function where a derivative is required.");
        }

        public virtual bool HasDerivative()
        {
            return false;
        }

        object ICloneable.Clone()
        {
            return new ActivationCompetitive((int) this._paras[0]);
        }

        public int MaxWinners
        {
            get
            {
                return (int) this._paras[0];
            }
        }

        public virtual string[] ParamNames
        {
            get
            {
                return new string[] { "maxWinners" };
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

