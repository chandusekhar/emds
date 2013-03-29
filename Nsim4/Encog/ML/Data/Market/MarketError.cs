namespace Encog.ML.Data.Market
{
    using Encog;
    using System;

    public class MarketError : EncogError
    {
        public MarketError(Exception e) : base(e)
        {
        }

        public MarketError(string str) : base(str)
        {
        }
    }
}

