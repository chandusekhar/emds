namespace Encog.MathUtil.RBF
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class InverseMultiquadricFunction : BasicRBF
    {
        public InverseMultiquadricFunction(int dimensions)
        {
            base.Centers = new double[dimensions];
            base.Peak = 1.0;
            base.Width = 1.0;
        }

        public InverseMultiquadricFunction(double peak, double[] center, double width)
        {
            base.Centers = center;
            base.Peak = peak;
            base.Width = width;
        }

        public InverseMultiquadricFunction(double center, double peak, double width)
        {
            base.Centers = new double[] { center };
            base.Peak = peak;
            base.Width = width;
        }

        public override double Calculate(double[] x)
        {
            double a = 0.0;
            double[] centers = base.Centers;
            double width = base.Width;
            int index = 0;
            goto Label_0010;
        Label_000C:
            index++;
        Label_0010:
            if (index < centers.Length)
            {
                a += Math.Pow(x[index] - centers[index], 2.0) + (width * width);
                goto Label_000C;
            }
            if ((((uint) index) - ((uint) width)) < 0)
            {
                goto Label_000C;
            }
            return (base.Peak / BoundMath.Sqrt(a));
        }
    }
}

