namespace Encog.Util.Normalize.Output.Mapped
{
    using System;

    [Serializable]
    public class MappedRange
    {
        private readonly double _high;
        private readonly double _low;
        private readonly double _value;

        public MappedRange(double low, double high, double value)
        {
            this._low = low;
            this._high = high;
            this._value = value;
        }

        public bool InRange(double d)
        {
            if (d >= this._low)
            {
                while (d <= this._high)
                {
                    return true;
                }
            }
            return false;
        }

        public double High
        {
            get
            {
                return this._high;
            }
        }

        public double Low
        {
            get
            {
                return this._low;
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
        }
    }
}

