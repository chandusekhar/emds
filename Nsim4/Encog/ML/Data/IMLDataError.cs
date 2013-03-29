namespace Encog.ML.Data
{
    using Encog;
    using System;

    public class IMLDataError : EncogError
    {
        public IMLDataError(Exception e) : base(e)
        {
        }

        public IMLDataError(string str) : base(str)
        {
        }
    }
}

