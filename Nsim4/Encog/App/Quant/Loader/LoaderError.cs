namespace Encog.App.Quant.Loader
{
    using Encog.App.Quant;
    using System;

    [Serializable]
    public class LoaderError : QuantError
    {
        public LoaderError(Exception t) : base(t)
        {
        }

        public LoaderError(string msg) : base(msg)
        {
        }
    }
}

