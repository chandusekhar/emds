namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.ML.Data.Basic;
    using System;

    public class ClusterRow : BasicMLDataPair
    {
        private readonly LoadedRow _xa806b754814b9ae0;

        public ClusterRow(double[] input, LoadedRow theRow) : base(new BasicMLData(input))
        {
            this._xa806b754814b9ae0 = theRow;
        }

        public LoadedRow Row
        {
            get
            {
                return this._xa806b754814b9ae0;
            }
        }
    }
}

