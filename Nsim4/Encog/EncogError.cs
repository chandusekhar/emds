namespace Encog
{
    using System;

    public class EncogError : Exception
    {
        public EncogError(Exception e) : base("Nested Exception", e)
        {
        }

        public EncogError(string str) : base(str)
        {
        }

        public EncogError(string msg, Exception e) : base(msg, e)
        {
        }
    }
}

