namespace Encog.ML.Train.Strategy.End
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using System;

    public class EndMinutesStrategy : IStrategy, IEndTrainingStrategy
    {
        private long _x6befdef5133de63a;
        private bool _xaca68f1d554d41ca;
        private int _xbce71dc8f2ba0ce3;
        private readonly int _xd1f6c6f4f40b65fc;

        public EndMinutesStrategy(int minutes)
        {
            this._xd1f6c6f4f40b65fc = minutes;
            this._xaca68f1d554d41ca = false;
            this._xbce71dc8f2ba0ce3 = minutes;
        }

        public virtual void Init(IMLTrain train)
        {
            this._xaca68f1d554d41ca = true;
            this._x6befdef5133de63a = DateTime.Now.Millisecond;
        }

        public virtual void PostIteration()
        {
            lock (this)
            {
                long millisecond = DateTime.Now.Millisecond;
                this._xbce71dc8f2ba0ce3 = (int) ((millisecond - this._x6befdef5133de63a) / 0xea60L);
            }
        }

        public virtual void PreIteration()
        {
        }

        public virtual bool ShouldStop()
        {
            lock (this)
            {
                return (this._xaca68f1d554d41ca && (this._xbce71dc8f2ba0ce3 >= 0));
            }
        }

        public int Minutes
        {
            get
            {
                return this._xd1f6c6f4f40b65fc;
            }
        }

        public int MinutesLeft
        {
            get
            {
                lock (this)
                {
                    return this._xbce71dc8f2ba0ce3;
                }
            }
        }
    }
}

