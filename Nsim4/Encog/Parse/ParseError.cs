namespace Encog.Parse
{
    using Encog;
    using System;

    public class ParseError : EncogError
    {
        public ParseError(Exception e) : base(e)
        {
        }

        public ParseError(string str) : base(str)
        {
        }
    }
}

