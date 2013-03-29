namespace Encog.ML.Data.Market
{
    using Encog.Engine.Network.Activation;
    using Encog.ML.Data.Temporal;
    using System;

    public class MarketDataDescription : TemporalDataDescription
    {
        private readonly TickerSymbol _x96e4701dec47675e;
        private readonly MarketDataType _xd2f3d36b96df4542;

        public MarketDataDescription(TickerSymbol ticker, MarketDataType dataType, bool input, bool predict) : this(ticker, dataType, TemporalDataDescription.Type.PercentChange, null, input, predict)
        {
        }

        public MarketDataDescription(TickerSymbol ticker, MarketDataType dataType, TemporalDataDescription.Type type, bool input, bool predict) : this(ticker, dataType, type, null, input, predict)
        {
        }

        public MarketDataDescription(TickerSymbol ticker, MarketDataType dataType, TemporalDataDescription.Type type, IActivationFunction activationFunction, bool input, bool predict) : base(activationFunction, type, input, predict)
        {
            this._x96e4701dec47675e = ticker;
            this._xd2f3d36b96df4542 = dataType;
        }

        public MarketDataType DataType
        {
            get
            {
                return this._xd2f3d36b96df4542;
            }
        }

        public TickerSymbol Ticker
        {
            get
            {
                return this._x96e4701dec47675e;
            }
        }
    }
}

