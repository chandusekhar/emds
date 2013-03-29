namespace Encog.ML.Train.Strategy
{
    using Encog.ML;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Util.Logging;
    using System;

    public class Greedy : IStrategy
    {
        private IMLEncodable _x1306445c04667cc7;
        private bool _x6c7711ed04d2ac90;
        private double[] _x8ca12f17f1ae2b01;
        private double _xaf54fba65f108955;
        private IMLTrain _xd87f6a9c53c2ed9f;

        public virtual void Init(IMLTrain train)
        {
            this._xd87f6a9c53c2ed9f = train;
            this._x6c7711ed04d2ac90 = false;
            while (!(train.Method is IMLEncodable))
            {
                throw new TrainingError("To make use of the Greedy strategy the machine learning method must support MLEncodable.");
            }
            do
            {
                this._x1306445c04667cc7 = (IMLEncodable) train.Method;
            }
            while (2 == 0);
            this._x8ca12f17f1ae2b01 = new double[this._x1306445c04667cc7.EncodedArrayLength()];
        }

        public virtual void PostIteration()
        {
            if (!this._x6c7711ed04d2ac90)
            {
                goto Label_0053;
            }
            if (4 != 0)
            {
                goto Label_0024;
            }
            goto Label_0019;
        Label_0011:
            if (0 != 0)
            {
                goto Label_0024;
            }
            return;
        Label_0019:
            if (15 == 0)
            {
                goto Label_0011;
            }
            return;
        Label_0024:
            if (this._xd87f6a9c53c2ed9f.Error > this._xaf54fba65f108955)
            {
                EncogLogging.Log(0, "Greedy strategy dropped last iteration.");
                this._xd87f6a9c53c2ed9f.Error = this._xaf54fba65f108955;
                if (-2 != 0)
                {
                    goto Label_003A;
                }
                goto Label_0083;
            }
            if (0 == 0)
            {
                goto Label_0083;
            }
        Label_003A:
            this._x1306445c04667cc7.DecodeFromArray(this._x8ca12f17f1ae2b01);
            if (2 != 0)
            {
                return;
            }
        Label_0053:
            this._x6c7711ed04d2ac90 = true;
            goto Label_0011;
        Label_0083:
            if (0 == 0)
            {
                goto Label_0019;
            }
        }

        public virtual void PreIteration()
        {
            if (this._x1306445c04667cc7 != null)
            {
                this._xaf54fba65f108955 = this._xd87f6a9c53c2ed9f.Error;
                this._x1306445c04667cc7.EncodeToArray(this._x8ca12f17f1ae2b01);
                this._xd87f6a9c53c2ed9f.Error = this._xaf54fba65f108955;
            }
        }
    }
}

