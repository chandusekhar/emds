namespace Encog.Util.Normalize.Output
{
    using Encog.Util.Normalize.Input;
    using System;

    [Serializable]
    public class OutputFieldDirect : BasicOutputField
    {
        private readonly IInputField _sourceField;

        public OutputFieldDirect()
        {
        }

        public OutputFieldDirect(IInputField sourceField)
        {
            this._sourceField = sourceField;
        }

        public override double Calculate(int subfield)
        {
            return this._sourceField.CurrentValue;
        }

        public override void RowInit()
        {
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

