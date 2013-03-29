namespace Encog.App.Analyst
{
    using Encog;
    using System;

    [Serializable]
    public class AnalystError : EncogError
    {
        public AnalystError(Exception t) : base(t)
        {
        }

        public AnalystError(string msg) : base(msg)
        {
        }
    }
}

