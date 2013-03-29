namespace Encog.ML.Data.Buffer
{
    using Encog;
    using System;

    public class BufferedDataError : EncogError
    {
        public BufferedDataError(Exception e) : base(e)
        {
        }

        public BufferedDataError(string str) : base(str)
        {
        }
    }
}

