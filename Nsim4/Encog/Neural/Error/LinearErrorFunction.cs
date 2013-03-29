namespace Encog.Neural.Error
{
    using System;

    public class LinearErrorFunction : IErrorFunction
    {
        public void CalculateError(double[] ideal, double[] actual, double[] error)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                error[i] = ideal[i] - actual[i];
            }
        }
    }
}

