namespace Encog.Util.Normalize.Segregate
{
    using System;

    [Serializable]
    public class SegregationRange
    {
        private readonly double _high;
        private readonly bool _include;
        private readonly double _low;

        public SegregationRange()
        {
        }

        public SegregationRange(double low, double high, bool include)
        {
            this._low = low;
            this._high = high;
            this._include = include;
        }

        public bool InRange(double value)
        {
            return ((value >= this._low) && (value <= this._high));
        }

        public double High
        {
            get
            {
                return this._high;
            }
        }

        public bool IsIncluded
        {
            get
            {
                return this._include;
            }
        }

        public double Low
        {
            get
            {
                return this._low;
            }
        }
    }
}

