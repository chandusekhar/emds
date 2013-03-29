namespace Encog.MathUtil
{
    using System;

    public static class BoundMath
    {
        public static double Cos(double a)
        {
            return BoundNumbers.Bound(Math.Cos(a));
        }

        public static double Exp(double a)
        {
            return BoundNumbers.Bound(Math.Exp(a));
        }

        public static double Log(double a)
        {
            return BoundNumbers.Bound(Math.Log(a));
        }

        public static double Pow(double a, double b)
        {
            return BoundNumbers.Bound(Math.Pow(a, b));
        }

        public static double Sin(double a)
        {
            return BoundNumbers.Bound(Math.Sin(a));
        }

        public static double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }
    }
}

