namespace Encog.ML.Train.Strategy.End
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using System;

    public class EndIterationsStrategy : IStrategy, IEndTrainingStrategy
    {
        private readonly int _x01774d3bfa2a5e50;
        private int _xce9a57609beca158;
        private IMLTrain _xd87f6a9c53c2ed9f;

        public EndIterationsStrategy(int maxIterations)
        {
            this._x01774d3bfa2a5e50 = maxIterations;
            this._xce9a57609beca158 = 0;
        }

        public virtual void Init(IMLTrain train_0)
        {
            this._xd87f6a9c53c2ed9f = train_0;
        }

        public virtual void PostIteration()
        {
            this._xce9a57609beca158 = this._xd87f6a9c53c2ed9f.IterationNumber;
        }

        public virtual void PreIteration()
        {
        }

        public virtual bool ShouldStop()
        {
            return (this._xce9a57609beca158 >= this._x01774d3bfa2a5e50);
        }
    }
}

