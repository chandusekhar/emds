namespace Encog.Neural.Networks.Training.Propagation.Back
{
    using Encog.ML.Data;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.Networks.Training.Strategy;
    using Encog.Util.Validate;
    using System;

    public class Backpropagation : Encog.Neural.Networks.Training.Propagation.Propagation, IMomentum, ILearningRate
    {
        public const string PropertyLastDelta = "LAST_DELTA";

        public Backpropagation(IContainsFlat network, IMLDataSet training) : this(network, training, 0.0, 0.0)
        {
            this.AddStrategy(new SmartLearningRate());
            this.AddStrategy(new SmartMomentum());
        }

        public Backpropagation(IContainsFlat network, IMLDataSet training, double learnRate, double momentum) : base(network, training)
        {
            ValidateNetwork.ValidateMethodToData(network, training);
            TrainFlatNetworkBackPropagation propagation = new TrainFlatNetworkBackPropagation(network.Flat, this.Training, learnRate, momentum);
            base.FlatTraining = propagation;
        }

        public bool IsValidResume(TrainingContinuation state)
        {
            if (!state.Contents.ContainsKey("LAST_DELTA"))
            {
                return false;
            }
            if (!state.TrainingType.Equals(base.GetType().Name))
            {
                return false;
            }
            double[] numArray = (double[]) state.Get("LAST_DELTA");
            return (numArray.Length == ((IContainsFlat) this.Method).Flat.Weights.Length);
        }

        public sealed override TrainingContinuation Pause()
        {
            TrainingContinuation continuation;
            TrainingContinuation continuation2 = new TrainingContinuation {
                TrainingType = base.GetType().Name
            };
            if (0 == 0)
            {
                continuation = continuation2;
                TrainFlatNetworkBackPropagation flatTraining = (TrainFlatNetworkBackPropagation) base.FlatTraining;
                double[] lastDelta = flatTraining.LastDelta;
                continuation.Set("LAST_DELTA", lastDelta);
            }
            return continuation;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
            if (!this.IsValidResume(state))
            {
                throw new TrainingError("Invalid training resume data length");
            }
            ((TrainFlatNetworkBackPropagation) base.FlatTraining).LastDelta = (double[]) state.Get("LAST_DELTA");
        }

        public sealed override bool CanContinue
        {
            get
            {
                return true;
            }
        }

        public double[] LastDelta
        {
            get
            {
                return ((TrainFlatNetworkBackPropagation) base.FlatTraining).LastDelta;
            }
        }

        public virtual double LearningRate
        {
            get
            {
                return ((TrainFlatNetworkBackPropagation) base.FlatTraining).LearningRate;
            }
            set
            {
                ((TrainFlatNetworkBackPropagation) base.FlatTraining).LearningRate = value;
            }
        }

        public virtual double Momentum
        {
            get
            {
                return ((TrainFlatNetworkBackPropagation) base.FlatTraining).Momentum;
            }
            set
            {
                ((TrainFlatNetworkBackPropagation) base.FlatTraining).LearningRate = value;
            }
        }
    }
}

