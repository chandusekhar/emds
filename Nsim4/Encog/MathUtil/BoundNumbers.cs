namespace Encog.MathUtil
{
    using System;

    public static class BoundNumbers
    {
        public const double TooBig = 1E+20;
        public const double TooSmall = -1E+20;

        public static double Bound(double d)
        {
            if (d >= -1E+20)
            {
                do
                {
                    if (d <= 1E+20)
                    {
                        return d;
                    }
                }
                while (((((uint) d) + ((uint) d)) > uint.MaxValue) && (-1 == 0));
            }
            else
            {
                return -1E+20;
            }
            return 1E+20;
        }
    }
}

