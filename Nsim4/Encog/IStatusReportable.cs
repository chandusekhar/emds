namespace Encog
{
    using System;

    public interface IStatusReportable
    {
        void Report(int total, int current, string message);
    }
}

