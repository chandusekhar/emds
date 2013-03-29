namespace Encog.ML.Data
{
    using System;
    using System.Reflection;

    public interface IMLData : ICloneable
    {
        void Clear();

        int Count { get; }

        double[] Data { get; set; }

        double this[int x] { get; set; }
    }
}

