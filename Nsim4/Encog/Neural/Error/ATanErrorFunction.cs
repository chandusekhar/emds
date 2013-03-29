namespace Encog.Neural.Error
{
    using System;

    public class ATanErrorFunction : IErrorFunction
    {
        public void CalculateError(double[] ideal, double[] actual, double[] error)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                error[i] = Math.Atan(ideal[i] - actual[i]);
            }
        }
    }
}

