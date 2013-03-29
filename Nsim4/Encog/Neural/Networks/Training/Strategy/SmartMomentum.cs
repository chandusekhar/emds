namespace Encog.Neural.Networks.Training.Strategy
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using Encog.Neural.Networks.Training;
    using Encog.Util.Logging;
    using System;

    public class SmartMomentum : IStrategy
    {
        private int _x009d742f4c5063d6;
        private IMomentum _x6947f9fc231e17e8;
        private bool _x6c7711ed04d2ac90;
        private double _x8b06dafb536c34dc;
        private double _xaf54fba65f108955;
        private double _xd02ba004f6c6d639;
        private IMLTrain _xd87f6a9c53c2ed9f;
        public const double MaxMomentum = 4.0;
        public const double MinImprovement = 0.0001;
        public const double MomentumCycles = 10.0;
        public const double MomentumIncrease = 0.01;
        public const double StartMomentum = 0.1;

        public void Init(IMLTrain train_0)
        {
            this._xd87f6a9c53c2ed9f = train_0;
            this._x6947f9fc231e17e8 = (IMomentum) train_0;
            this._x6c7711ed04d2ac90 = false;
            this._x6947f9fc231e17e8.Momentum = 0.0;
            this._xd02ba004f6c6d639 = 0.0;
        }

        public void PostIteration()
        {
            if (!this._x6c7711ed04d2ac90)
            {
                this._x6c7711ed04d2ac90 = true;
                return;
            }
            double error = this._xd87f6a9c53c2ed9f.Error;
            this._x8b06dafb536c34dc = (error - this._xaf54fba65f108955) / this._xaf54fba65f108955;
            EncogLogging.Log(0, "Last improvement: " + this._x8b06dafb536c34dc);
            if (3 != 0)
            {
                goto Label_0057;
            }
            if (-1 != 0)
            {
                goto Label_006B;
            }
        Label_000D:
            this._xd02ba004f6c6d639 = 0.0;
            this._x6947f9fc231e17e8.Momentum = 0.0;
            return;
        Label_0057:
            if (this._x8b06dafb536c34dc > 0.0)
            {
                goto Label_013B;
            }
        Label_006B:
            if (Math.Abs(this._x8b06dafb536c34dc) < 0.0001)
            {
                goto Label_013B;
            }
        Label_0084:
            EncogLogging.Log(0, "Setting momentum back to zero.");
            if ((((uint) error) - ((uint) error)) > uint.MaxValue)
            {
                goto Label_0057;
            }
            goto Label_000D;
        Label_00DA:
            this._xd02ba004f6c6d639 *= 1.01;
            if ((((uint) error) + ((uint) error)) < 0)
            {
                goto Label_0084;
            }
            this._x6947f9fc231e17e8.Momentum = this._xd02ba004f6c6d639;
            if ((((uint) error) - ((uint) error)) <= uint.MaxValue)
            {
                EncogLogging.Log(0, "Adjusting momentum: " + this._xd02ba004f6c6d639);
                return;
            }
        Label_013B:
            this._x009d742f4c5063d6++;
            if (this._x009d742f4c5063d6 > 10.0)
            {
                this._x009d742f4c5063d6 = 0;
                if (((int) this._xd02ba004f6c6d639) != 0)
                {
                    goto Label_00DA;
                }
            }
            else
            {
                return;
            }
            this._xd02ba004f6c6d639 = 0.1;
            goto Label_00DA;
        }

        public void PreIteration()
        {
            this._xaf54fba65f108955 = this._xd87f6a9c53c2ed9f.Error;
        }
    }
}

