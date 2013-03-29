namespace Encog.ML.Train.Strategy
{
    using Encog.ML;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Util.Logging;
    using System;

    public class RequiredImprovementStrategy : IStrategy
    {
        private IMLResettable _x1306445c04667cc7;
        private readonly int _x31fc5c65f8944f8b;
        private readonly double _x3362caa77b1f70b4;
        private readonly double _x5b76a34f819b422d;
        private int _x73b300efe91f4640;
        private double _xaf54fba65f108955;
        private IMLTrain _xd87f6a9c53c2ed9f;

        public RequiredImprovementStrategy(int cycles) : this(0.01, 0.1, cycles)
        {
        }

        public RequiredImprovementStrategy(double required, int cycles) : this(required, 0.1, cycles)
        {
        }

        public RequiredImprovementStrategy(double required, double threshold, int cycles)
        {
            this._xaf54fba65f108955 = double.NaN;
            if (4 != 0)
            {
                this._x3362caa77b1f70b4 = required;
            }
            this._x31fc5c65f8944f8b = cycles;
            this._x73b300efe91f4640 = 0;
            this._x5b76a34f819b422d = threshold;
        }

        public virtual void Init(IMLTrain train)
        {
            this._xd87f6a9c53c2ed9f = train;
            if (!(train.Method is IMLResettable))
            {
                throw new TrainingError("To use the required improvement strategy the machine learning method must support MLResettable.");
            }
            this._x1306445c04667cc7 = (IMLResettable) this._xd87f6a9c53c2ed9f.Method;
        }

        public virtual void PostIteration()
        {
        }

        public virtual void PreIteration()
        {
            double num;
            if (this._xd87f6a9c53c2ed9f.Error <= this._x5b76a34f819b422d)
            {
                goto Label_005A;
            }
            if (((uint) num) >= 0)
            {
                goto Label_0084;
            }
            if ((((uint) num) | 0x7fffffff) != 0)
            {
                goto Label_010C;
            }
        Label_0043:
            if (0 != 0)
            {
                goto Label_00F1;
            }
            this._xaf54fba65f108955 = this._xd87f6a9c53c2ed9f.Error;
        Label_005A:
            this._xaf54fba65f108955 = Math.Min(this._xd87f6a9c53c2ed9f.Error, this._xaf54fba65f108955);
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                return;
            }
        Label_0084:
            if (!double.IsNaN(this._xaf54fba65f108955))
            {
                num = this._xaf54fba65f108955 - this._xd87f6a9c53c2ed9f.Error;
            }
            else
            {
                if (0 == 0)
                {
                    goto Label_0043;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_010C;
                }
                goto Label_00BA;
            }
        Label_00AE:
            if (num < this._x3362caa77b1f70b4)
            {
                this._x73b300efe91f4640++;
                goto Label_010C;
            }
        Label_00BA:
            this._x73b300efe91f4640 = 0;
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                    if (-1 != 0)
                    {
                    }
                    goto Label_005A;
                }
                goto Label_0043;
            }
            goto Label_010C;
        Label_00F1:
            this._x73b300efe91f4640 = 0;
            this._xaf54fba65f108955 = double.NaN;
            goto Label_005A;
        Label_010C:
            if (0 != 0)
            {
                goto Label_00AE;
            }
            if (this._x73b300efe91f4640 <= this._x31fc5c65f8944f8b)
            {
                goto Label_005A;
            }
            EncogLogging.Log(0, "Failed to improve network, resetting.");
            this._x1306445c04667cc7.Reset();
            goto Label_00F1;
        }
    }
}

