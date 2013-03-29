namespace Encog.Neural.Networks.Training.Propagation.SCG
{
    using Encog.ML.Data;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation;
    using System;

    public class ScaledConjugateGradient : Encog.Neural.Networks.Training.Propagation.Propagation
    {
        public ScaledConjugateGradient(IContainsFlat network, IMLDataSet training) : base(network, training)
        {
            TrainFlatNetworkSCG kscg = new TrainFlatNetworkSCG(network.Flat, this.Training);
            base.FlatTraining = kscg;
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
    }
}

