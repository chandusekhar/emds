namespace Encog.Bot.Browse
{
    using System;

    public class Address
    {
        private readonly Uri _xf50d6d3c10c0eac9;
        private readonly string _xfcad4c0a9c5890c6;

        public Address(Uri u)
        {
            this._xf50d6d3c10c0eac9 = u;
            this._xfcad4c0a9c5890c6 = u.ToString();
        }

        public Address(Uri b, string original)
        {
            this._xfcad4c0a9c5890c6 = original;
            this._xf50d6d3c10c0eac9 = (b == null) ? new Uri(new Uri("http://localhost/"), original) : new Uri(b, original);
        }

        public override string ToString()
        {
            if (this._xf50d6d3c10c0eac9 == null)
            {
                return this._xfcad4c0a9c5890c6;
            }
            return this._xf50d6d3c10c0eac9.ToString();
        }

        public string Original
        {
            get
            {
                return this._xfcad4c0a9c5890c6;
            }
        }

        public Uri Url
        {
            get
            {
                return this._xf50d6d3c10c0eac9;
            }
        }
    }
}

