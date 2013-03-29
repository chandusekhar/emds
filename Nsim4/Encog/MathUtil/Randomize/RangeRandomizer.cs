namespace Encog.MathUtil.Randomize
{
    using Encog.MathUtil;
    using System;

    public class RangeRandomizer : BasicRandomizer
    {
        private readonly double _xd088075e67f6ea91;
        private readonly double _xffd6352b2e5d70e3;

        public RangeRandomizer(double min, double max)
        {
            this._xffd6352b2e5d70e3 = max;
            this._xd088075e67f6ea91 = min;
        }

        public static int RandomInt(int min, int max)
        {
            return (int) Randomize((double) min, (double) (max + 1));
        }

        public override double Randomize(double d)
        {
            return base.NextDouble(this._xd088075e67f6ea91, this._xffd6352b2e5d70e3);
        }

        public static double Randomize(double min, double max)
        {
            double num = max - min;
            return ((num * ThreadSafeRandom.NextDouble()) + min);
        }

        public double Max
        {
            get
            {
                return this._xffd6352b2e5d70e3;
            }
        }

        public double Min
        {
            get
            {
                return this._xd088075e67f6ea91;
            }
        }
    }
}

