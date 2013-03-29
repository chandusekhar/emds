namespace Encog.Bot.Browse
{
    using Encog;
    using System;

    public class BrowseError : EncogError
    {
        public BrowseError(Exception e) : base(e)
        {
        }

        public BrowseError(string str) : base(str)
        {
        }
    }
}

