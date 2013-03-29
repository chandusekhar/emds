namespace Encog.Util.Normalize.Output.Multiplicative
{
    using Encog.Util.Normalize.Output;
    using System;
    using System.Linq;

    [Serializable]
    public class MultiplicativeGroup : BasicOutputFieldGroup
    {
        private double _length;

        public override void RowInit()
        {
            double d = base.GroupedFields.Sum<OutputFieldGrouped>(field => field.SourceField.CurrentValue * field.SourceField.CurrentValue);
            this._length = Math.Sqrt(d);
        }

        public double Length
        {
            get
            {
                return this._length;
            }
        }
    }
}

