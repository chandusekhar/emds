namespace Encog.ML.Train
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train.Strategy;
    using Encog.ML.Train.Strategy.End;
    using Encog.Neural.Networks.Training.Propagation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public abstract class BasicTraining : IMLTrain
    {
        private int _x47b4ed2c32cb276e;
        private readonly IList<IStrategy> _x67ca01c85b0d2985 = new List<IStrategy>();
        private readonly TrainingImplementationType _xd15d8bd620479255;
        [CompilerGenerated]
        private static Func<IEndTrainingStrategy, bool> x31af784cbc72c68d;
        [CompilerGenerated]
        private IMLDataSet xa00923b9f7dd480e;
        [CompilerGenerated]
        private double xe063969ae230d439;

        protected BasicTraining(TrainingImplementationType implementationType)
        {
            this._xd15d8bd620479255 = implementationType;
        }

        public virtual void AddStrategy(IStrategy strategy)
        {
            strategy.Init(this);
            this._x67ca01c85b0d2985.Add(strategy);
        }

        public virtual void FinishTraining()
        {
        }

        public abstract void Iteration();
        public virtual void Iteration(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Iteration();
            }
        }

        public abstract TrainingContinuation Pause();
        public void PostIteration()
        {
            foreach (IStrategy strategy in this._x67ca01c85b0d2985)
            {
                strategy.PostIteration();
            }
        }

        public void PreIteration()
        {
            this._x47b4ed2c32cb276e++;
            foreach (IStrategy strategy in this._x67ca01c85b0d2985)
            {
                strategy.PreIteration();
            }
        }

        public abstract void Resume(TrainingContinuation state);
        [CompilerGenerated]
        private static bool x21985e3d6e8b2b7b(IEndTrainingStrategy xca09b6c2b5b18485)
        {
            return xca09b6c2b5b18485.ShouldStop();
        }

        public abstract bool CanContinue { get; }

        public virtual double Error
        {
            [CompilerGenerated]
            get
            {
                return this.xe063969ae230d439;
            }
            [CompilerGenerated]
            set
            {
                this.xe063969ae230d439 = value;
            }
        }

        public virtual TrainingImplementationType ImplementationType
        {
            get
            {
                return this._xd15d8bd620479255;
            }
        }

        public virtual int IterationNumber
        {
            get
            {
                return this._x47b4ed2c32cb276e;
            }
            set
            {
                this._x47b4ed2c32cb276e = value;
            }
        }

        public abstract IMLMethod Method { get; }

        public virtual IList<IStrategy> Strategies
        {
            get
            {
                return this._x67ca01c85b0d2985;
            }
        }

        public virtual IMLDataSet Training
        {
            [CompilerGenerated]
            get
            {
                return this.xa00923b9f7dd480e;
            }
            [CompilerGenerated]
            set
            {
                this.xa00923b9f7dd480e = value;
            }
        }

        public virtual bool TrainingDone
        {
            get
            {
                if (x31af784cbc72c68d == null)
                {
                    x31af784cbc72c68d = new Func<IEndTrainingStrategy, bool>(BasicTraining.x21985e3d6e8b2b7b);
                }
                return this._x67ca01c85b0d2985.OfType<IEndTrainingStrategy>().Any<IEndTrainingStrategy>(x31af784cbc72c68d);
            }
        }
    }
}

