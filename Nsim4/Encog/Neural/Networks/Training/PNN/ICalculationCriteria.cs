namespace Encog.Neural.Networks.Training.PNN
{
    using System;

    public interface ICalculationCriteria
    {
        double CalcErrorWithMultipleSigma(double[] x, double[] direc, double[] deriv2, bool b);
        double CalcErrorWithSingleSigma(double sigma);
    }
}

