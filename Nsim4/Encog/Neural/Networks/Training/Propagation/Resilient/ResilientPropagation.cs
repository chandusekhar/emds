namespace Encog.Neural.Networks.Training.Propagation.Resilient
{
    using Encog.ML.Data;
    using Encog.Neural.Flat.Train.Prop;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util;
    using System;

    public class ResilientPropagation : Encog.Neural.Networks.Training.Propagation.Propagation
    {
        public const string LastGradients = "LAST_GRADIENTS";
        public const string UpdateValues = "UPDATE_VALUES";

        public ResilientPropagation(IContainsFlat network, IMLDataSet training) : this(network, training, 0.1, 50.0)
        {
        }

        public ResilientPropagation(IContainsFlat network, IMLDataSet training, double initialUpdate, double maxStep) : base(network, training)
        {
            TrainFlatNetworkResilient resilient = new TrainFlatNetworkResilient(network.Flat, this.Training, 1E-17, initialUpdate, maxStep);
            base.FlatTraining = resilient;
        }

        public bool IsValidResume(TrainingContinuation state)
        {
            if (state.Contents.ContainsKey("LAST_GRADIENTS"))
            {
                if (0 == 0)
                {
                    if (0x7fffffff != 0)
                    {
                    }
                    if (!state.Contents.ContainsKey("UPDATE_VALUES"))
                    {
                        goto Label_004B;
                    }
                }
                if (state.TrainingType.Equals(base.GetType().Name))
                {
                    double[] numArray = (double[]) state.Get("LAST_GRADIENTS");
                    return (numArray.Length == ((IContainsFlat) this.Method).Flat.Weights.Length);
                }
                return false;
            }
        Label_004B:
            return false;
        }

        public sealed override TrainingContinuation Pause()
        {
            TrainingContinuation continuation = new TrainingContinuation {
                TrainingType = base.GetType().Name
            };
            continuation.Set("LAST_GRADIENTS", ((TrainFlatNetworkResilient) base.FlatTraining).LastGradient);
            continuation.Set("UPDATE_VALUES", ((TrainFlatNetworkResilient) base.FlatTraining).UpdateValues);
            return continuation;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
            if (!this.IsValidResume(state))
            {
                throw new TrainingError("Invalid training resume data length");
            }
            double[] src = (double[]) state.Get("LAST_GRADIENTS");
            double[] numArray2 = (double[]) state.Get("UPDATE_VALUES");
            EngineArray.ArrayCopy(src, ((TrainFlatNetworkResilient) base.FlatTraining).LastGradient);
            if (8 != 0)
            {
            }
            EngineArray.ArrayCopy(numArray2, ((TrainFlatNetworkResilient) base.FlatTraining).UpdateValues);
        }

        public sealed override bool CanContinue
        {
            get
            {
                return true;
            }
        }
    }
}

