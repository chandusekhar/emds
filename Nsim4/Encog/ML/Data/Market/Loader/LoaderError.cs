namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using System;

    public class LoaderError : MarketError
    {
        public LoaderError(Exception e) : base(e)
        {
        }

        public LoaderError(string str) : base(str)
        {
        }
    }
}

