namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class LoadedMarketData : IComparable<LoadedMarketData>
    {
        private readonly IDictionary<MarketDataType, double> _x4a3f0a05c02f235f;
        private readonly TickerSymbol _x96e4701dec47675e;
        [CompilerGenerated]
        private DateTime xad5bc8a49bfb9bcf;

        public LoadedMarketData(DateTime when, TickerSymbol ticker)
        {
            this.When = when;
            this._x96e4701dec47675e = ticker;
            this._x4a3f0a05c02f235f = new Dictionary<MarketDataType, double>();
        }

        public int CompareTo(LoadedMarketData other)
        {
            return this.When.CompareTo(other.When);
        }

        public double GetData(MarketDataType t)
        {
            return this._x4a3f0a05c02f235f[t];
        }

        public void SetData(MarketDataType t, double d)
        {
            this._x4a3f0a05c02f235f[t] = d;
        }

        public IDictionary<MarketDataType, double> Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
        }

        public TickerSymbol Ticker
        {
            get
            {
                return this._x96e4701dec47675e;
            }
        }

        public DateTime When
        {
            [CompilerGenerated]
            get
            {
                return this.xad5bc8a49bfb9bcf;
            }
            [CompilerGenerated]
            set
            {
                this.xad5bc8a49bfb9bcf = value;
            }
        }
    }
}

