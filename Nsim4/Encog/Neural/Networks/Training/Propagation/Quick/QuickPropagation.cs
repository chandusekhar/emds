namespace Encog.Neural.Networks.Training.Propagation.Quick
{
    using Encog.ML.Data;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util;
    using Encog.Util.Validate;
    using System;

    public sealed class QuickPropagation : Encog.Neural.Networks.Training.Propagation.Propagation, ILearningRate
    {
        public const string LastGradients = "LAST_GRADIENTS";

        public QuickPropagation(IContainsFlat network, IMLDataSet training) : this(network, training, 2.0)
        {
        }

        public QuickPropagation(IContainsFlat network, IMLDataSet training, double learnRate) : base(network, training)
        {
            ValidateNetwork.ValidateMethodToData(network, training);
            TrainFlatNetworkQPROP kqprop = new TrainFlatNetworkQPROP(network.Flat, this.Training, learnRate);
            base.FlatTraining = kqprop;
        }

        public bool IsValidResume(TrainingContinuation state)
        {
            if (!state.Contents.ContainsKey("LAST_GRADIENTS"))
            {
                return false;
            }
            if (!state.TrainingType.Equals(base.GetType().Name))
            {
                return false;
            }
            double[] numArray = (double[]) state.Contents["LAST_GRADIENTS"];
            return (numArray.Length == ((IContainsFlat) this.Method).Flat.Weights.Length);
        }

        public override TrainingContinuation Pause()
        {
            TrainingContinuation continuation;
            TrainingContinuation continuation2 = new TrainingContinuation();
            do
            {
                continuation2.TrainingType = base.GetType().Name;
                continuation = continuation2;
                TrainFlatNetworkQPROP flatTraining = (TrainFlatNetworkQPROP) base.FlatTraining;
                double[] lastGradient = flatTraining.LastGradient;
                continuation.Contents["LAST_GRADIENTS"] = lastGradient;
            }
            while (0x7fffffff == 0);
            return continuation;
        }

        public override void Resume(TrainingContinuation state)
        {
            if (!this.IsValidResume(state))
            {
                throw new TrainingError("Invalid training resume data length");
            }
            double[] src = (double[]) state.Contents["LAST_GRADIENTS"];
            EngineArray.ArrayCopy(src, ((TrainFlatNetworkQPROP) base.FlatTraining).LastGradient);
        }

        public override bool CanContinue
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
                return ((TrainFlatNetworkQPROP) base.FlatTraining).LastDelta;
            }
        }

        public double LearningRate
        {
            get
            {
                return ((TrainFlatNetworkQPROP) base.FlatTraining).LearningRate;
            }
            set
            {
                ((TrainFlatNetworkQPROP) base.FlatTraining).LearningRate = value;
            }
        }

        public double OutputEpsilon
        {
            get
            {
                return ((TrainFlatNetworkQPROP) base.FlatTraining).OutputEpsilon;
            }
            set
            {
                ((TrainFlatNetworkQPROP) base.FlatTraining).OutputEpsilon = value;
            }
        }

        public double Shrink
        {
            get
            {
                return ((TrainFlatNetworkQPROP) base.FlatTraining).Shrink;
            }
            set
            {
                ((TrainFlatNetworkQPROP) base.FlatTraining).Shrink = value;
            }
        }
    }
}

