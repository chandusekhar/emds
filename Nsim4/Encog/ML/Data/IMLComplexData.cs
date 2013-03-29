namespace Encog.ML.Data
{
    using Encog.MathUtil;
    using System;

    public interface IMLComplexData : IMLData, ICloneable
    {
        ComplexNumber GetComplexData(int index);
        void SetComplexData(ComplexNumber[] theData);
        void SetComplexData(int index, ComplexNumber d);

        ComplexNumber[] ComplexData { get; }
    }
}

