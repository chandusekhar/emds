namespace Encog.App.Quant
{
    using Encog;
    using System;

    [Serializable]
    public class QuantError : EncogError
    {
        public QuantError(Exception t) : base(t)
        {
        }

        public QuantError(string msg) : base(msg)
        {
        }
    }
}

