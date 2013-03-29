namespace Encog.Util
{
    using System;

    public class ObjectPair<TA, TB>
    {
        private readonly TA _x19218ffab70283ef;
        private readonly TB _xe7ebe10fa44d8d49;

        public ObjectPair(TA a, TB b)
        {
            this._x19218ffab70283ef = a;
            this._xe7ebe10fa44d8d49 = b;
        }

        public TA A
        {
            get
            {
                return this._x19218ffab70283ef;
            }
        }

        public TB B
        {
            get
            {
                return this._xe7ebe10fa44d8d49;
            }
        }
    }
}

