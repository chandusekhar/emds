namespace Encog.Util.Normalize.Output
{
    using System;
    using System.Collections.Generic;

    public interface IOutputFieldGroup
    {
        void AddField(OutputFieldGrouped field);
        void RowInit();

        ICollection<OutputFieldGrouped> GroupedFields { get; }
    }
}

