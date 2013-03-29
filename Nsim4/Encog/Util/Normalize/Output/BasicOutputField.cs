namespace Encog.Util.Normalize.Output
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class BasicOutputField : IOutputField
    {
        protected BasicOutputField()
        {
        }

        public abstract double Calculate(int subfield);
        public static double Calculate(double value, double min, double max, double hi, double lo)
        {
            return ((((value - min) / (max - min)) * (hi - lo)) + lo);
        }

        public abstract void RowInit();

        public bool Ideal { get; set; }

        public abstract int SubfieldCount { get; }
    }
}

