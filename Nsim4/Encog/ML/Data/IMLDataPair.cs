namespace Encog.ML.Data
{
    using System;

    public interface IMLDataPair : ICloneable
    {
        IMLData Calced { get; }

        double[] CalcedArray { get; set; }

        IMLData Error { get; }

        double[] ErrorArray { get; set; }

        IMLData Ideal { get; }

        double[] IdealArray { get; set; }

        IMLData Input { get; }

        double[] InputArray { get; set; }

        double Significance { get; set; }

        bool Supervised { get; }
    }
}

