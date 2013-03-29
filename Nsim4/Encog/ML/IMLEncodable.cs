namespace Encog.ML
{
    using System;

    public interface IMLEncodable : IMLMethod
    {
        void DecodeFromArray(double[] encoded);
        int EncodedArrayLength();
        void EncodeToArray(double[] encoded);
    }
}

