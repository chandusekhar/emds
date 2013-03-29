namespace Encog.Util.Normalize.Input
{
    using Encog.Util.Normalize;
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class BasicInputField : IInputField
    {
        private double _max = double.NegativeInfinity;
        private double _min = double.PositiveInfinity;
        private bool _usedForNetworkInput = true;

        public void ApplyMinMax(double d)
        {
            this._min = Math.Min(this._min, d);
            this._max = Math.Max(this._max, d);
        }

        public virtual double GetValue(int i)
        {
            throw new NormalizationError("Can't call getValue on " + base.GetType().Name);
        }

        public double CurrentValue { get; set; }

        public double Max
        {
            get
            {
                return this._max;
            }
            set
            {
                this._max = value;
            }
        }

        public double Min
        {
            get
            {
                return this._min;
            }
            set
            {
                this._min = value;
            }
        }

        public bool UsedForNetworkInput
        {
            get
            {
                return this._usedForNetworkInput;
            }
            set
            {
                this._usedForNetworkInput = value;
            }
        }
    }
}

