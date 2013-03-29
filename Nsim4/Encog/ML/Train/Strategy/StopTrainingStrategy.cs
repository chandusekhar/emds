namespace Encog.ML.Train.Strategy
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy.End;
    using System;

    public class StopTrainingStrategy : IStrategy, IEndTrainingStrategy
    {
        private int _x0d60065f91a9e9e6;
        private readonly int _x26b3661872e072b7;
        private bool _x33b5f28b377bcb1a;
        private bool _x6c7711ed04d2ac90;
        private readonly double _x75deb38bfba59a18;
        private double _x8bfd70ace96b5df9;
        private double _xaf54fba65f108955;
        private IMLTrain _xd87f6a9c53c2ed9f;
        public const double DefaultMinImprovement = 1E-07;
        public const int DefaultTolerateCycles = 100;

        public StopTrainingStrategy() : this(1E-07, 100)
        {
        }

        public StopTrainingStrategy(double minImprovement, int toleratedCycles)
        {
            this._x75deb38bfba59a18 = minImprovement;
            this._x26b3661872e072b7 = toleratedCycles;
            this._x0d60065f91a9e9e6 = 0;
            this._x8bfd70ace96b5df9 = double.MaxValue;
        }

        public virtual void Init(IMLTrain train)
        {
            this._xd87f6a9c53c2ed9f = train;
            this._x33b5f28b377bcb1a = false;
            this._x6c7711ed04d2ac90 = false;
        }

        public virtual void PostIteration()
        {
            if (!this._x6c7711ed04d2ac90)
            {
                this._x6c7711ed04d2ac90 = true;
                if (0 != 0)
                {
                    return;
                }
            }
            else if (3 != 0)
            {
                if (Math.Abs((double) (this._x8bfd70ace96b5df9 - this._xd87f6a9c53c2ed9f.Error)) >= this._x75deb38bfba59a18)
                {
                    if (-2 != 0)
                    {
                        this._x0d60065f91a9e9e6 = 0;
                    }
                }
                else
                {
                    this._x0d60065f91a9e9e6++;
                    if (0 == 0)
                    {
                    }
                    if (this._x0d60065f91a9e9e6 > this._x26b3661872e072b7)
                    {
                        this._x33b5f28b377bcb1a = true;
                    }
                }
            }
            this._xaf54fba65f108955 = this._xd87f6a9c53c2ed9f.Error;
            this._x8bfd70ace96b5df9 = Math.Min(this._xaf54fba65f108955, this._x8bfd70ace96b5df9);
        }

        public virtual void PreIteration()
        {
        }

        public virtual bool ShouldStop()
        {
            return this._x33b5f28b377bcb1a;
        }
    }
}

