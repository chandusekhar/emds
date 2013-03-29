namespace Encog.Util.Normalize.Segregate
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Input;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class RangeSegregator : ISegregator
    {
        private readonly bool _include;
        private DataNormalization _normalization;
        private readonly ICollection<SegregationRange> _ranges;
        private readonly IInputField _sourceField;

        public RangeSegregator()
        {
            this._ranges = new List<SegregationRange>();
        }

        public RangeSegregator(IInputField sourceField, bool include)
        {
            this._ranges = new List<SegregationRange>();
            this._sourceField = sourceField;
            this._include = include;
        }

        public void AddRange(SegregationRange range)
        {
            this._ranges.Add(range);
        }

        public void AddRange(double low, double high, bool include)
        {
            SegregationRange range = new SegregationRange(low, high, include);
            this.AddRange(range);
        }

        public void Init(DataNormalization normalization)
        {
            this._normalization = normalization;
        }

        public void PassInit()
        {
        }

        public bool ShouldInclude()
        {
            double currentValue = this._sourceField.CurrentValue;
            using (IEnumerator<SegregationRange> enumerator = this._ranges.GetEnumerator())
            {
                SegregationRange current;
                bool flag;
                goto Label_0058;
            Label_001A:
                flag = current.IsIncluded;
                if ((((uint) currentValue) & 0) != 0)
                {
                    goto Label_0077;
                }
                return flag;
                if ((((uint) flag) + ((uint) currentValue)) >= 0)
                {
                    goto Label_0058;
                }
            Label_004F:
                if (current.InRange(currentValue))
                {
                    goto Label_001A;
                }
            Label_0058:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    goto Label_004F;
                }
            }
        Label_0077:
            return this._include;
        }

        public DataNormalization Owner
        {
            get
            {
                return this._normalization;
            }
        }

        public IInputField SourceField
        {
            get
            {
                return this._sourceField;
            }
        }
    }
}

