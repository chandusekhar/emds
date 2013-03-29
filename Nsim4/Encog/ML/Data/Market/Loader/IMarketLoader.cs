namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using System;
    using System.Collections.Generic;

    public interface IMarketLoader
    {
        string GetFile(string file);
        ICollection<LoadedMarketData> Load(TickerSymbol ticker, IList<MarketDataType> dataNeeded, DateTime from, DateTime to);
    }
}

