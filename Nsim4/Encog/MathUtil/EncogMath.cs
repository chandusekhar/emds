namespace Encog.MathUtil
{
    using System;

    public class EncogMath
    {
        public static double Deg2Rad(double deg)
        {
            return (deg * 0.017453292519943295);
        }

        public static double Hypot(double a, double b)
        {
            double num;
            if (Math.Abs(a) > Math.Abs(b))
            {
                num = b / a;
                num = Math.Abs(a) * Math.Sqrt(1.0 + (num * num));
                if ((((uint) a) & 0) == 0)
                {
                    return num;
                }
            }
            if (b == 0.0)
            {
                return 0.0;
            }
            num = a / b;
            return (Math.Abs(b) * Math.Sqrt(1.0 + (num * num)));
        }

        public static double Rad2Deg(double rad)
        {
            return (rad * 57.295779513082323);
        }
    }
}

