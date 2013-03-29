namespace Encog.Util.Normalize.Output
{
    using Encog.Util.Normalize.Input;
    using System;

    [Serializable]
    public abstract class OutputFieldGrouped : BasicOutputField
    {
        private readonly IOutputFieldGroup _group;
        private readonly IInputField _sourceField;

        protected OutputFieldGrouped()
        {
        }

        protected OutputFieldGrouped(IOutputFieldGroup group, IInputField sourceField)
        {
            this._group = group;
            this._sourceField = sourceField;
            this._group.GroupedFields.Add(this);
        }

        public abstract override double Calculate(int subfield);
        public abstract override void RowInit();

        public IOutputFieldGroup Group
        {
            get
            {
                return this._group;
            }
        }

        public IInputField SourceField
        {
            get
            {
                return this._sourceField;
            }
        }

        public abstract override int SubfieldCount { get; }
    }
}

