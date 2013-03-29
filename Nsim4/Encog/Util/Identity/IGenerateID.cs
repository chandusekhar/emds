namespace Encog.Util.Identity
{
    using System;

    public interface IGenerateID
    {
        long Generate();

        long CurrentID { get; set; }
    }
}

