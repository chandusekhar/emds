namespace Encog.MathUtil.Randomize
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using System;

    public interface IRandomizer
    {
        void Randomize(IMLMethod network);
        double Randomize(double d);
        void Randomize(double[] d);
        void Randomize(double[][] d);
        void Randomize(Matrix m);
        void Randomize(double[] d, int begin, int size);
    }
}

