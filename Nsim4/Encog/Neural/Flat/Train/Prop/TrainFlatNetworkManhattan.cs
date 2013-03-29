namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using System;

    public class TrainFlatNetworkManhattan : TrainFlatNetworkProp
    {
        private readonly double _x04273e480202ea1d;
        private double _x9b481c22b6706459;

        public TrainFlatNetworkManhattan(FlatNetwork network, IMLDataSet training, double theLearningRate) : base(network, training)
        {
            this._x9b481c22b6706459 = theLearningRate;
            this._x04273e480202ea1d = 1E-17;
        }

        public override void InitOthers()
        {
        }

        public sealed override double UpdateWeight(double[] gradients, double[] lastGradient, int index)
        {
            if (Math.Abs(gradients[index]) < this._x04273e480202ea1d)
            {
                return 0.0;
            }
            if (gradients[index] > 0.0)
            {
                return this._x9b481c22b6706459;
            }
            return -this._x9b481c22b6706459;
        }

        public double LearningRate
        {
            get
            {
                return this._x9b481c22b6706459;
            }
            set
            {
                this._x9b481c22b6706459 = value;
            }
        }
    }
}

