namespace Encog.Neural.Networks.Training.Propagation.Manhattan
{
    using Encog.ML.Data;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using System;

    public class ManhattanPropagation : Encog.Neural.Networks.Training.Propagation.Propagation, ILearningRate
    {
        internal const double xf6b72d186afac58d = 0.001;

        public ManhattanPropagation(IContainsFlat network, IMLDataSet training, double learnRate) : base(network, training)
        {
            base.FlatTraining = new TrainFlatNetworkManhattan(network.Flat, this.Training, learnRate);
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public virtual double LearningRate
        {
            get
            {
                return ((TrainFlatNetworkManhattan) base.FlatTraining).LearningRate;
            }
            set
            {
                ((TrainFlatNetworkManhattan) base.FlatTraining).LearningRate = value;
            }
        }
    }
}

