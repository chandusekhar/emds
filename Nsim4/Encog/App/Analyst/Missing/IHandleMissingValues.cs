namespace Encog.App.Analyst.Missing
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using System;

    public interface IHandleMissingValues
    {
        double[] HandleMissing(EncogAnalyst analyst, AnalystField stat);
    }
}

