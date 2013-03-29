namespace Encog.Neural.Networks.Training.Lma
{
    using System;

    public interface IComputeJacobian
    {
        double Calculate(double[] weights);

        double[][] Jacobian { get; }

        double[] RowErrors { get; }
    }
}

