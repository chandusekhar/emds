namespace Encog.ML.Data.Market
{
    using Encog.ML.Data.Temporal;
    using System;

    public class MarketPoint : TemporalPoint
    {
        private readonly DateTime _xfea77ecf4244fbaa;

        public MarketPoint(DateTime when, int size) : base(size)
        {
            this._xfea77ecf4244fbaa = when;
        }

        public DateTime When
        {
            get
            {
                return this._xfea77ecf4244fbaa;
            }
        }
    }
}

