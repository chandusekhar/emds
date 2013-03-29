namespace Encog.MathUtil.Randomize
{
    using System;

    public class ConstRandomizer : BasicRandomizer
    {
        private readonly double xbcea506a33cf9111;

        public ConstRandomizer(double v)
        {
            this.xbcea506a33cf9111 = v;
        }

        public override double Randomize(double d)
        {
            return this.xbcea506a33cf9111;
        }
    }
}

