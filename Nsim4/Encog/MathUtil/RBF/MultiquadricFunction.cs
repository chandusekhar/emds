namespace Encog.MathUtil.RBF
{
    using Encog.MathUtil;
    using System;

    [Serializable]
    public class MultiquadricFunction : BasicRBF
    {
        public MultiquadricFunction(int dimensions)
        {
            base.Centers = new double[dimensions];
            base.Peak = 1.0;
            base.Width = 1.0;
        }

        public MultiquadricFunction(double peak, double[] center, double width)
        {
            base.Centers = center;
            base.Peak = peak;
            base.Width = width;
        }

        public MultiquadricFunction(double center, double peak, double width)
        {
            base.Centers = new double[] { center };
            base.Peak = peak;
            base.Width = width;
        }

        public override double Calculate(double[] x)
        {
            double[] numArray;
            double width;
            int num3;
            double a = 0.0;
        Label_006B:
            numArray = base.Centers;
            if ((((uint) num3) & 0) == 0)
            {
                width = base.Width;
            }
            num3 = 0;
        Label_000C:
            if (num3 < numArray.Length)
            {
                a += Math.Pow(x[num3] - numArray[num3], 2.0) + (width * width);
                num3++;
                if ((((uint) a) - ((uint) a)) <= uint.MaxValue)
                {
                    goto Label_000C;
                }
                goto Label_006B;
            }
            return (base.Peak * BoundMath.Sqrt(a));
        }
    }
}

