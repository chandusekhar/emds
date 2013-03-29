namespace Encog.MathUtil.Randomize
{
    using Encog.MathUtil;
    using Encog.Neural.Networks;
    using System;

    public class ConsistentRandomizer : BasicRandomizer
    {
        private readonly int _x5f33b0fc94247cc0;
        private readonly LinearCongruentialGenerator _xc25f3ba15c9fba69;
        private readonly double _xd088075e67f6ea91;
        private readonly double _xffd6352b2e5d70e3;

        public ConsistentRandomizer(double min, double max) : this(min, max, 0x3e8)
        {
        }

        public ConsistentRandomizer(double min, double max, int seed)
        {
            this._xffd6352b2e5d70e3 = max;
            this._xd088075e67f6ea91 = min;
            this._x5f33b0fc94247cc0 = seed;
            this._xc25f3ba15c9fba69 = new LinearCongruentialGenerator((long) seed);
        }

        public void Randomize(BasicNetwork network)
        {
            this._xc25f3ba15c9fba69.Seed = this._x5f33b0fc94247cc0;
            base.Randomize(network);
        }

        public override double Randomize(double d)
        {
            return this._xc25f3ba15c9fba69.Range(this._xd088075e67f6ea91, this._xffd6352b2e5d70e3);
        }
    }
}

