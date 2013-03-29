namespace Encog.Util.Normalize.Output.Nominal
{
    using Encog.Util.Normalize.Input;
    using System;

    [Serializable]
    public class NominalItem
    {
        private readonly double _high;
        private readonly IInputField _inputField;
        private readonly double _low;

        public NominalItem()
        {
        }

        public NominalItem(IInputField inputField, double low, double high)
        {
            this._high = high;
            this._low = low;
            this._inputField = inputField;
        }

        public void BeginRow()
        {
        }

        public bool IsInRange()
        {
            double currentValue = this._inputField.CurrentValue;
            if (((((uint) currentValue) + ((uint) currentValue)) >= 0) && (currentValue < this._low))
            {
                return false;
            }
            return (currentValue <= this._high);
        }

        public double High
        {
            get
            {
                return this._high;
            }
        }

        public IInputField InputField
        {
            get
            {
                return this._inputField;
            }
        }

        public double Low
        {
            get
            {
                return this._low;
            }
        }
    }
}

