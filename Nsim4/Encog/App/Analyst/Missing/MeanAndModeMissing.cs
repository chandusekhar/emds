namespace Encog.App.Analyst.Missing
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Script.Normalize;
    using System;

    public class MeanAndModeMissing : IHandleMissingValues
    {
        public double[] HandleMissing(EncogAnalyst analyst, AnalystField stat)
        {
            if (stat.Classify)
            {
                int classNumber = stat.DetermineMode(analyst);
                return stat.Encode(classNumber);
            }
            DataField field = analyst.Script.FindDataField(stat.Name);
            return new double[] { field.Mean };
        }
    }
}

