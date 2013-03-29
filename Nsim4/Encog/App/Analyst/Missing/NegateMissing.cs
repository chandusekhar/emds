namespace Encog.App.Analyst.Missing
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using System;

    public class NegateMissing : IHandleMissingValues
    {
        public double[] HandleMissing(EncogAnalyst analyst, AnalystField stat)
        {
            double num;
            int num2;
            double[] numArray = new double[stat.ColumnsNeeded];
            if (2 != 0)
            {
                num = stat.NormalizedHigh - (stat.NormalizedHigh - (stat.NormalizedLow / 2.0));
                num2 = 0;
                goto Label_001A;
            }
        Label_0012:
            numArray[num2] = num;
            num2++;
        Label_001A:
            if (num2 < numArray.Length)
            {
                goto Label_0012;
            }
            return numArray;
        }
    }
}

