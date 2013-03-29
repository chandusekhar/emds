namespace Encog.Util.Normalize.Output
{
    using System;

    public interface IOutputField
    {
        double Calculate(int subfield);
        void RowInit();

        bool Ideal { get; set; }

        int SubfieldCount { get; }
    }
}

