namespace Encog.MathUtil.RBF
{
    using System;

    [Serializable]
    public class GaussianFunction : BasicRBF
    {
        public GaussianFunction()
        {
            base.Centers = new double[1];
            base.Peak = 1.0;
            base.Width = 1.0;
        }

        public GaussianFunction(int dimensions)
        {
            base.Centers = new double[dimensions];
            base.Peak = 1.0;
            base.Width = 1.0;
        }

        public GaussianFunction(double peak, double[] center, double width)
        {
            base.Centers = center;
            base.Peak = peak;
            base.Width = width;
        }

        public GaussianFunction(double center, double peak, double width)
        {
            base.Centers = new double[] { center };
            base.Peak = peak;
            base.Width = width;
        }

        public override double Calculate(double[] x)
        {
            int num3;
            double num = 0.0;
            double[] centers = base.Centers;
            double width = base.Width;
            do
            {
                num3 = 0;
            }
            while (((uint) num) > uint.MaxValue);
            while (true)
            {
                if (num3 < centers.Length)
                {
                    num += Math.Pow(x[num3] - centers[num3], 2.0) / ((2.0 * width) * width);
                }
                else
                {
                    return (base.Peak * Math.Exp(-num));
                }
                num3++;
            }
        }
    }
}

