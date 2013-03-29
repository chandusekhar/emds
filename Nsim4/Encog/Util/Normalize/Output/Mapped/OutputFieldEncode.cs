namespace Encog.Util.Normalize.Output.Mapped
{
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class OutputFieldEncode : BasicOutputField
    {
        private double _catchAll;
        private readonly IList<MappedRange> _ranges = new List<MappedRange>();
        private readonly IInputField _sourceField;

        public OutputFieldEncode(IInputField sourceField)
        {
            this._sourceField = sourceField;
        }

        public void AddRange(double low, double high, double value)
        {
            MappedRange item = new MappedRange(low, high, value);
            this._ranges.Add(item);
        }

        public override double Calculate(int subfield)
        {
            foreach (MappedRange range in this._ranges)
            {
                double num;
                do
                {
                    if (!range.InRange(this._sourceField.CurrentValue))
                    {
                        continue;
                    }
                }
                while ((((uint) num) + ((uint) num)) < 0);
                return range.Value;
            }
            return this._catchAll;
        }

        public override void RowInit()
        {
        }

        public double CatchAll
        {
            get
            {
                return this._catchAll;
            }
            set
            {
                this._catchAll = value;
            }
        }

        public IInputField SourceField
        {
            get
            {
                return this._sourceField;
            }
        }

        public override int SubfieldCount
        {
            get
            {
                return 1;
            }
        }
    }
}

