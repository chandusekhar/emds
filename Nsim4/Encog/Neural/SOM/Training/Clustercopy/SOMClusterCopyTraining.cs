namespace Encog.Neural.Som.Training.Clustercopy
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.SOM;
    using System;

    public class SOMClusterCopyTraining : BasicTraining
    {
        private readonly SOMNetwork _x87a7fc6a72741c2e;

        public SOMClusterCopyTraining(SOMNetwork network, IMLDataSet training) : base(TrainingImplementationType.OnePass)
        {
            this._x87a7fc6a72741c2e = network;
            this.Training = training;
        }

        public sealed override void Iteration()
        {
            int num = 0;
            foreach (IMLDataPair pair in this.Training)
            {
                this.x3342cd5bc15ae07b(num++, pair.Input);
            }
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        private void x3342cd5bc15ae07b(int x7079b5ea66d0bae1, IMLData xcdaeea7afaf570ff)
        {
            for (int i = 0; i < this._x87a7fc6a72741c2e.InputCount; i++)
            {
                this._x87a7fc6a72741c2e.Weights[i, x7079b5ea66d0bae1] = xcdaeea7afaf570ff[i];
            }
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
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

