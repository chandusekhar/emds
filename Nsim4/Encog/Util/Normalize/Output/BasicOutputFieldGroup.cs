namespace Encog.Util.Normalize.Output
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public abstract class BasicOutputFieldGroup : IOutputFieldGroup
    {
        private readonly ICollection<OutputFieldGrouped> _fields = new List<OutputFieldGrouped>();

        protected BasicOutputFieldGroup()
        {
        }

        public void AddField(OutputFieldGrouped field)
        {
            this._fields.Add(field);
        }

        public abstract void RowInit();

        public ICollection<OutputFieldGrouped> GroupedFields
        {
            get
            {
                return this._fields;
            }
        }
    }
}

