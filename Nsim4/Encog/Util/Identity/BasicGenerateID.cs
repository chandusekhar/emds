namespace Encog.Util.Identity
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class BasicGenerateID : IGenerateID
    {
        public BasicGenerateID()
        {
            this.CurrentID = 1L;
        }

        public long Generate()
        {
            lock (this)
            {
                long num2;
                this.CurrentID = (num2 = this.CurrentID) + 1L;
                return num2;
            }
        }

        public long CurrentID { get; set; }
    }
}

