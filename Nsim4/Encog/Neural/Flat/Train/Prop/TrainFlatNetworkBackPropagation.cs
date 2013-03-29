namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.ML.Data;
    using Encog.Neural.Flat;
    using System;

    public class TrainFlatNetworkBackPropagation : TrainFlatNetworkProp
    {
        private double _x9b481c22b6706459;
        private double[] _xe4def4d471bbc130;
        private double _xef52c16be8e501c9;

        public TrainFlatNetworkBackPropagation(FlatNetwork network, IMLDataSet training, double theLearningRate, double theMomentum) : base(network, training)
        {
            this._xef52c16be8e501c9 = theMomentum;
            this._x9b481c22b6706459 = theLearningRate;
            this._xe4def4d471bbc130 = new double[network.Weights.Length];
        }

        public override void InitOthers()
        {
        }

        public sealed override double UpdateWeight(double[] gradients, double[] lastGradient, int index)
        {
            double num = (gradients[index] * this._x9b481c22b6706459) + (this._xe4def4d471bbc130[index] * this._xef52c16be8e501c9);
            this._xe4def4d471bbc130[index] = num;
            return num;
        }

        public double[] LastDelta
        {
            get
            {
                return this._xe4def4d471bbc130;
            }
            set
            {
                this._xe4def4d471bbc130 = value;
            }
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

        public double Momentum
        {
            get
            {
                return this._xef52c16be8e501c9;
            }
            set
            {
                this._xef52c16be8e501c9 = value;
            }
        }
    }
}

