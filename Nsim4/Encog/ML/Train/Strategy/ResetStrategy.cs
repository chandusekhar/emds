namespace Encog.ML.Train.Strategy
{
    using Encog.ML;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Util.Logging;
    using System;

    public class ResetStrategy : IStrategy
    {
        private IMLResettable _x1306445c04667cc7;
        private readonly int _x31fc5c65f8944f8b;
        private readonly double _x3362caa77b1f70b4;
        private int _x73b300efe91f4640;
        private IMLTrain _xd87f6a9c53c2ed9f;

        public ResetStrategy(double required, int cycles)
        {
            this._x3362caa77b1f70b4 = required;
            this._x31fc5c65f8944f8b = cycles;
            this._x73b300efe91f4640 = 0;
        }

        public virtual void Init(IMLTrain train)
        {
            this._xd87f6a9c53c2ed9f = train;
            while (!(train.Method is IMLResettable))
            {
                throw new TrainingError("To use the reset strategy the machine learning method must support MLResettable.");
            }
            this._x1306445c04667cc7 = (IMLResettable) this._xd87f6a9c53c2ed9f.Method;
        }

        public virtual void PostIteration()
        {
        }

        public virtual void PreIteration()
        {
            if (this._xd87f6a9c53c2ed9f.Error <= this._x3362caa77b1f70b4)
            {
                this._x73b300efe91f4640 = 0;
            }
            else if (3 != 0)
            {
                this._x73b300efe91f4640++;
                if (this._x73b300efe91f4640 > this._x31fc5c65f8944f8b)
                {
                    EncogLogging.Log(0, "Failed to imrove network, resetting.");
                    this._x1306445c04667cc7.Reset();
                    this._x73b300efe91f4640 = 0;
                }
            }
        }
    }
}

