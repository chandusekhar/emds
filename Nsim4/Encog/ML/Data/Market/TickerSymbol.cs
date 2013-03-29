namespace Encog.ML.Data.Market
{
    using System;

    public class TickerSymbol
    {
        private readonly string _x99caf8ddd087f694;
        private readonly string _xc1db5dbaf009ebd2;

        public TickerSymbol(string symbol)
        {
            this._xc1db5dbaf009ebd2 = symbol;
            this._x99caf8ddd087f694 = null;
        }

        public TickerSymbol(string symbol, string exchange)
        {
            this._xc1db5dbaf009ebd2 = symbol;
            this._x99caf8ddd087f694 = exchange;
        }

        public bool Equals(TickerSymbol other)
        {
            if (other.Symbol.Equals(this.Symbol))
            {
                if ((other.Exchange == null) && (other.Exchange == null))
                {
                    return true;
                }
                goto Label_001B;
            }
            return false;
        Label_0017:
            return false;
        Label_001B:
            if (other.Exchange == null)
            {
                goto Label_0017;
            }
            do
            {
                if (this.Exchange == null)
                {
                    goto Label_0017;
                }
                if (3 != 0)
                {
                    return other.Exchange.Equals(this.Exchange);
                }
            }
            while (0 != 0);
            goto Label_001B;
        }

        public string Exchange
        {
            get
            {
                return this._x99caf8ddd087f694;
            }
        }

        public string Symbol
        {
            get
            {
                return this._xc1db5dbaf009ebd2;
            }
        }
    }
}

