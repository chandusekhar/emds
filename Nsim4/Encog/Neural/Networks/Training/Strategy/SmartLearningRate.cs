namespace Encog.Neural.Networks.Training.Strategy
{
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using Encog.Neural.Networks.Training;
    using Encog.Util.Logging;
    using System;

    public class SmartLearningRate : IStrategy
    {
        private double _x6300a707dc67f3a2;
        private ILearningRate _x6947f9fc231e17e8;
        private bool _x6c7711ed04d2ac90;
        private long _x985befeef351542c;
        private double _xaf54fba65f108955;
        private IMLTrain _xd87f6a9c53c2ed9f;
        public const double LearningDecay = 0.99;

        public void Init(IMLTrain train)
        {
            this._xd87f6a9c53c2ed9f = train;
            while (true)
            {
                this._x6c7711ed04d2ac90 = false;
                this._x6947f9fc231e17e8 = (ILearningRate) train;
                this._x985befeef351542c = train.Training.Count;
                this._x6300a707dc67f3a2 = 1.0 / ((double) this._x985befeef351542c);
                EncogLogging.Log(0, "Starting learning rate: " + this._x6300a707dc67f3a2);
                do
                {
                    this._x6947f9fc231e17e8.LearningRate = this._x6300a707dc67f3a2;
                }
                while (-2147483648 == 0);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        public void PostIteration()
        {
            if (!this._x6c7711ed04d2ac90)
            {
                this._x6c7711ed04d2ac90 = true;
                return;
            }
            goto Label_005E;
        Label_0032:
            if (this._xd87f6a9c53c2ed9f.Error > this._xaf54fba65f108955)
            {
                goto Label_0061;
            }
        Label_005B:
            if (0 == 0)
            {
                return;
            }
        Label_005E:
            if (0 == 0)
            {
                goto Label_0032;
            }
        Label_0061:
            this._x6300a707dc67f3a2 *= 0.99;
            this._x6947f9fc231e17e8.LearningRate = this._x6300a707dc67f3a2;
            if (0 == 0)
            {
                EncogLogging.Log(0, "Adjusting learning rate to {}" + this._x6300a707dc67f3a2);
                if (0 == 0)
                {
                    return;
                }
                goto Label_0032;
            }
            goto Label_005B;
        }

        public void PreIteration()
        {
            this._xaf54fba65f108955 = this._xd87f6a9c53c2ed9f.Error;
        }
    }
}

