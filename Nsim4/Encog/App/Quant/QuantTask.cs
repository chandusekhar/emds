namespace Encog.App.Quant
{
    using System;

    public interface QuantTask
    {
        void RequestStop();
        bool ShouldStop();
    }
}

