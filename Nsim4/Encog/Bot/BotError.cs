namespace Encog.Bot
{
    using Encog;
    using System;

    public class BotError : EncogError
    {
        public BotError(Exception e) : base(e)
        {
        }

        public BotError(string str) : base(str)
        {
        }
    }
}

