namespace Encog.MathUtil.RBF
{
    using System;

    [Serializable]
    public class MexicanHatFunction : BasicRBF
    {
        public MexicanHatFunction(int dimensions)
        {
            base.Centers = new double[dimensions];
            base.Peak = 1.0;
            base.Width = 1.0;
        }

        public MexicanHatFunction(double peak, double[] center, double width)
        {
            base.Centers = center;
            base.Peak = peak;
            base.Width = width;
        }

        public MexicanHatFunction(double center, double peak, double width)
        {
            base.Centers = new double[] { center };
            base.Peak = peak;
            base.Width = width;
        }

        public override double Calculate(double[] x)
        {
            int num2;
            double[] centers = base.Centers;
            double num = 0.0;
            if (((uint) num2) >= 0)
            {
            }
            for (num2 = 0; num2 < centers.Length; num2++)
            {
                num += Math.Pow(x[num2] - centers[num2], 2.0);
            }
            return ((base.Peak * (1.0 - num)) * Math.Exp(-num / 2.0));
        }
    }
}

