namespace Encog.Neural.Networks.Training.Propagation
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Error;
    using Encog.Neural.Flat.Train;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Util;
    using Encog.Util.Concurrency;
    using Encog.Util.Logging;
    using System;

    public abstract class Propagation : BasicTraining, IMLTrain, ITrain, IMultiThreadable
    {
        private readonly IContainsFlat _x87a7fc6a72741c2e;
        private ITrainFlatNetwork _xd23ba9901cc70fd5;

        protected Propagation(IContainsFlat network, IMLDataSet training) : base(TrainingImplementationType.Iterative)
        {
            this._x87a7fc6a72741c2e = network;
            this.Training = training;
        }

        public sealed override void FinishTraining()
        {
            base.FinishTraining();
            this._xd23ba9901cc70fd5.FinishTraining();
        }

        public sealed override void Iteration()
        {
            try
            {
                base.PreIteration();
                this._xd23ba9901cc70fd5.Iteration();
                this.Error = this._xd23ba9901cc70fd5.Error;
                base.PostIteration();
                EncogLogging.Log(1, "Training iteration done, error: " + this.Error);
            }
            catch (IndexOutOfRangeException exception)
            {
                EncogValidate.ValidateNetworkForTraining(this._x87a7fc6a72741c2e, this.Training);
                throw new EncogError(exception);
            }
        }

        public sealed override void Iteration(int count)
        {
            try
            {
                base.PreIteration();
                this._xd23ba9901cc70fd5.Iteration(count);
                this.IterationNumber = this._xd23ba9901cc70fd5.IterationNumber;
                this.Error = this._xd23ba9901cc70fd5.Error;
                base.PostIteration();
                do
                {
                    EncogLogging.Log(1, "Training iterations done, error: " + this.Error);
                }
                while (0 != 0);
            }
            catch (IndexOutOfRangeException exception)
            {
                EncogValidate.ValidateNetworkForTraining(this._x87a7fc6a72741c2e, this.Training);
                throw new EncogError(exception);
            }
        }

        public IErrorFunction ErrorFunction
        {
            get
            {
                return ((TrainFlatNetworkProp) this._xd23ba9901cc70fd5).ErrorFunction;
            }
            set
            {
                ((TrainFlatNetworkProp) this._xd23ba9901cc70fd5).ErrorFunction = value;
            }
        }

        public bool FixFlatSpot
        {
            get
            {
                return ((TrainFlatNetworkProp) this._xd23ba9901cc70fd5).FixFlatSpot;
            }
            set
            {
                ((TrainFlatNetworkProp) this._xd23ba9901cc70fd5).FixFlatSpot = value;
            }
        }

        public ITrainFlatNetwork FlatTraining
        {
            get
            {
                return this._xd23ba9901cc70fd5;
            }
            set
            {
                this._xd23ba9901cc70fd5 = value;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public int ThreadCount
        {
            get
            {
                return this._xd23ba9901cc70fd5.NumThreads;
            }
            set
            {
                this._xd23ba9901cc70fd5.NumThreads = value;
            }
        }
    }
}

