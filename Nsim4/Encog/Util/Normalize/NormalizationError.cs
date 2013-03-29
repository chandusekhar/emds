namespace Encog.Util.Normalize
{
    using Encog;
    using System;

    public class NormalizationError : EncogError
    {
        public NormalizationError(Exception e) : base(e)
        {
        }

        public NormalizationError(string str) : base(str)
        {
        }
    }
}

