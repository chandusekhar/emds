namespace Encog.Neural.Error
{
    using System;

    public interface IErrorFunction
    {
        void CalculateError(double[] ideal, double[] actual, double[] error);
    }
}

