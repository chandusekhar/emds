namespace Encog.MathUtil.RBF
{
    using System;

    public interface IRadialBasisFunction
    {
        double Calculate(double[] x);

        double[] Centers { get; set; }

        int Dimensions { get; }

        double Peak { get; set; }

        double Width { get; set; }
    }
}

