namespace Encog.ML.Data.Temporal
{
    using Encog;
    using System;

    public class TemporalError : EncogError
    {
        public TemporalError(Exception e) : base(e)
        {
        }

        public TemporalError(string str) : base(str)
        {
        }
    }
}

