namespace Encog.ML.Train.Strategy.End
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using System;

    public class EndMaxErrorStrategy : IStrategy, IEndTrainingStrategy
    {
        private readonly double _x1c76dfc7a53e1f5e;
        private bool _xaca68f1d554d41ca;
        private IMLTrain _xd87f6a9c53c2ed9f;

        public EndMaxErrorStrategy(double maxError)
        {
            this._x1c76dfc7a53e1f5e = maxError;
            this._xaca68f1d554d41ca = false;
        }

        public virtual void Init(IMLTrain train_0)
        {
            this._xd87f6a9c53c2ed9f = train_0;
            this._xaca68f1d554d41ca = false;
        }

        public virtual void PostIteration()
        {
            this._xaca68f1d554d41ca = true;
        }

        public virtual void PreIteration()
        {
        }

        public virtual bool ShouldStop()
        {
            return (this._xaca68f1d554d41ca && (this._xd87f6a9c53c2ed9f.Error < this._x1c76dfc7a53e1f5e));
        }
    }
}

