namespace Encog.App.Analyst.Util
{
    using Encog;
    using Encog.App.Analyst;
    using System;

    public class AnalystReportBridge : IStatusReportable
    {
        private readonly EncogAnalyst _x554f16462d8d4675;

        public AnalystReportBridge(EncogAnalyst theAnalyst)
        {
            this._x554f16462d8d4675 = theAnalyst;
        }

        public void Report(int total, int current, string message)
        {
            foreach (IAnalystListener listener in this._x554f16462d8d4675.Listeners)
            {
                listener.Report(total, current, message);
            }
        }
    }
}

