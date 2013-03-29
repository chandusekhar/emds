namespace Encog.Util.Normalize.Output.Nominal
{
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class OutputOneOf : BasicOutputField
    {
        private readonly double _falseValue;
        private readonly IList<NominalItem> _items;
        private readonly double _trueValue;

        public OutputOneOf() : this(1.0, -1.0)
        {
        }

        public OutputOneOf(double trueValue, double falseValue)
        {
            this._items = new List<NominalItem>();
            this._trueValue = trueValue;
            this._falseValue = falseValue;
        }

        public void AddItem(IInputField inputField, double value)
        {
            this.AddItem(inputField, value - 0.5, value + 0.5);
        }

        public void AddItem(IInputField inputField, double low, double high)
        {
            NominalItem item = new NominalItem(inputField, low, high);
            this._items.Add(item);
        }

        public override double Calculate(int subfield)
        {
            NominalItem item = this._items[subfield];
            while (!item.IsInRange())
            {
                return this._falseValue;
            }
            return this._trueValue;
        }

        public override void RowInit()
        {
        }

        public double FalseValue
        {
            get
            {
                return this._falseValue;
            }
        }

        public override int SubfieldCount
        {
            get
            {
                return this._items.Count;
            }
        }

        public double TrueValue
        {
            get
            {
                return this._trueValue;
            }
        }
    }
}

