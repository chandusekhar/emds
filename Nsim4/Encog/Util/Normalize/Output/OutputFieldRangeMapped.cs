namespace Encog.Util.Normalize.Output
{
    using Encog.Util.Normalize.Input;
    using System;

    [Serializable]
    public class OutputFieldRangeMapped : BasicOutputField, IRequireTwoPass
    {
        private readonly IInputField _field;
        private readonly double _high;
        private readonly double _low;

        public OutputFieldRangeMapped()
        {
        }

        public OutputFieldRangeMapped(IInputField f) : this(f, -1.0, 1.0)
        {
        }

        public OutputFieldRangeMapped(IInputField field, double low, double high)
        {
            this._field = field;
            this._low = low;
            this._high = high;
        }

        public override double Calculate(int subfield)
        {
            return ((((this._field.CurrentValue - this._field.Min) / (this._field.Max - this._field.Min)) * (this._high - this._low)) + this._low);
        }

        public double ConvertBack(double data)
        {
            return (((((this._field.Min - this._field.Max) * data) - (this._high * this._field.Min)) + (this._field.Max * this._low)) / (this._low - this._high));
        }

        public override void RowInit()
        {
        }

        public IInputField Field
        {
            get
            {
                return this._field;
            }
        }

        public double High
        {
            get
            {
                return this._high;
            }
        }

        public double Low
        {
            get
            {
                return this._low;
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

