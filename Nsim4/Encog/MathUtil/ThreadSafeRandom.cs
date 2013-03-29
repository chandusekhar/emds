namespace Encog.MathUtil
{
    using System;

    public class ThreadSafeRandom
    {
        private static readonly Random x6ba122ce47559152 = new Random();

        public static double NextDouble()
        {
            lock (x6ba122ce47559152)
            {
                return x6ba122ce47559152.NextDouble();
            }
        }
    }
}

