namespace Encog.Util.Normalize.Output.ZAxis
{
    using Encog.Util.Normalize.Output;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class ZAxisGroup : BasicOutputFieldGroup
    {
        private double _length;
        private double _multiplier;

        public override void RowInit()
        {
            double d = ((IEnumerable<double>) (from field in base.GroupedFields
                where !(field is OutputFieldZAxisSynthetic)
                where field.SourceField != null
                select field.SourceField.CurrentValue * field.SourceField.CurrentValue)).Sum();
            this._length = Math.Sqrt(d);
            this._multiplier = 1.0 / Math.Sqrt((double) base.GroupedFields.Count);
        }

        public double Length
        {
            get
            {
                return this._length;
            }
        }

        public double Multiplier
        {
            get
            {
                return this._multiplier;
            }
        }
    }
}

