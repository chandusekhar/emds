namespace Encog.MathUtil.Randomize
{
    using System;

    public class Distort : BasicRandomizer
    {
        private readonly double _xa00f04d8b3a6664c;

        public Distort(double f)
        {
            this._xa00f04d8b3a6664c = f;
        }

        public override double Randomize(double d)
        {
            return (d + (this._xa00f04d8b3a6664c - ((base.NextDouble() * this._xa00f04d8b3a6664c) * 2.0)));
        }
    }
}

