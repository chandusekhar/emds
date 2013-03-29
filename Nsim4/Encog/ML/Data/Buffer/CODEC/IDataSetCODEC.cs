namespace Encog.ML.Data.Buffer.CODEC
{
    using System;

    public interface IDataSetCODEC
    {
        void Close();
        void PrepareRead();
        void PrepareWrite(int recordCount, int inputSize, int idealSize);
        bool Read(double[] input, double[] ideal, ref double significance);
        void Write(double[] input, double[] ideal, double significance);

        int IdealSize { get; }

        int InputSize { get; }
    }
}

