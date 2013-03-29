namespace Encog.ML.Data.Market
{
    using Encog.ML.Data.Market.Loader;
    using Encog.ML.Data.Temporal;
    using Encog.Util.Time;
    using System;
    using System.Collections.Generic;

    public sealed class MarketMLDataSet : TemporalMLDataSet
    {
        private readonly IMarketLoader _x5cd320770c3df353;
        private readonly IDictionary<int, TemporalPoint> _xa2ee854ac63ea89c;

        public MarketMLDataSet(IMarketLoader loader, int inputWindowSize, int predictWindowSize) : base(inputWindowSize, predictWindowSize)
        {
            this._xa2ee854ac63ea89c = new Dictionary<int, TemporalPoint>();
            this._x5cd320770c3df353 = loader;
            this.SequenceGrandularity = TimeUnit.Days;
        }

        public MarketMLDataSet(IMarketLoader loader, int inputWindowSize, int predictWindowSize, TimeUnit unit) : base(inputWindowSize, predictWindowSize)
        {
            this._xa2ee854ac63ea89c = new Dictionary<int, TemporalPoint>();
            this._x5cd320770c3df353 = loader;
            this.SequenceGrandularity = unit;
        }

        public override void AddDescription(TemporalDataDescription desc)
        {
            if (!(desc is MarketDataDescription))
            {
                throw new MarketError("Only MarketDataDescription objects may be used with the MarketNeuralDataSet container.");
            }
            base.AddDescription(desc);
        }

        public override TemporalPoint CreatePoint(DateTime when)
        {
            int sequenceFromDate = this.GetSequenceFromDate(when);
            while (!this._xa2ee854ac63ea89c.ContainsKey(sequenceFromDate))
            {
                TemporalPoint point = base.CreatePoint(when);
                this._xa2ee854ac63ea89c[point.Sequence] = point;
                return point;
            }
            return this._xa2ee854ac63ea89c[sequenceFromDate];
        }

        public void Load(DateTime begin, DateTime end)
        {
            IDictionary<TickerSymbol, object> dictionary;
            if (!(this.StartingPoint == DateTime.MinValue))
            {
                goto Label_00A5;
            }
            if (0 == 0)
            {
                this.StartingPoint = begin;
                goto Label_00A5;
            }
        Label_005C:
            foreach (TickerSymbol symbol in dictionary.Keys)
            {
                this.xb45ce8e0e2f1da44(symbol, begin, end);
            }
            this.SortPoints();
            return;
        Label_00A5:
            this.Points.Clear();
            dictionary = new Dictionary<TickerSymbol, object>();
            foreach (TemporalDataDescription description in this.Descriptions)
            {
                MarketDataDescription description2 = (MarketDataDescription) description;
                dictionary[description2.Ticker] = null;
            }
            goto Label_005C;
        }

        private void xb45ce8e0e2f1da44(TickerSymbol x96e4701dec47675e, DateTime x7f8a886f51b477eb, DateTime x3ed4f4f0195b98d7)
        {
            foreach (LoadedMarketData data in this.Loader.Load(x96e4701dec47675e, null, x7f8a886f51b477eb, x3ed4f4f0195b98d7))
            {
                TemporalPoint point = this.CreatePoint(data.When);
                this.xd619c0bf81b12658(x96e4701dec47675e, point, data);
            }
        }

        private void xd619c0bf81b12658(TickerSymbol x96e4701dec47675e, TemporalPoint x2f7096dac971d6ec, LoadedMarketData xccb63ca5f63dc470)
        {
            foreach (TemporalDataDescription description in this.Descriptions)
            {
                MarketDataDescription description2 = (MarketDataDescription) description;
                if (description2.Ticker.Equals(x96e4701dec47675e))
                {
                    x2f7096dac971d6ec.Data[description2.Index] = xccb63ca5f63dc470.Data[description2.DataType];
                }
            }
        }

        public IMarketLoader Loader
        {
            get
            {
                return this._x5cd320770c3df353;
            }
        }
    }
}

