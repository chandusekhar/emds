namespace Encog.Persist
{
    using Encog;
    using System;

    [Serializable]
    public class PersistError : EncogError
    {
        public PersistError(Exception t) : base(t)
        {
        }

        public PersistError(string msg) : base(msg)
        {
        }

        public PersistError(string msg, Exception t) : base(msg, t)
        {
        }
    }
}

