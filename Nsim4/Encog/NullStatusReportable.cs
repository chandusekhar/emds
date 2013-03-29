namespace Encog
{
    using System;

    public class NullStatusReportable : IStatusReportable
    {
        public void Report(int total, int current, string message)
        {
        }
    }
}

