namespace Encog.Neural.Networks.Training.Cross
{
    using Encog.ML;
    using Encog.ML.Data.Folded;
    using Encog.ML.Train;
    using System;

    public abstract class CrossTraining : BasicTraining
    {
        private readonly FoldedDataSet _x3952df2eab48841c;
        private readonly IMLMethod _x87a7fc6a72741c2e;

        protected CrossTraining(IMLMethod network, FoldedDataSet training) : base(TrainingImplementationType.Iterative)
        {
            this._x87a7fc6a72741c2e = network;
            this.Training = training;
            this._x3952df2eab48841c = training;
        }

        public FoldedDataSet Folded
        {
            get
            {
                return this._x3952df2eab48841c;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }
    }
}

