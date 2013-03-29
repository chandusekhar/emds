namespace Encog.Neural.Networks.Training.Anneal
{
    using Encog.ML.Anneal;
    using Encog.Neural.Networks;
    using System;

    public class NeuralSimulatedAnnealingHelper : SimulatedAnnealing<double>
    {
        private readonly NeuralSimulatedAnnealing _x071bde1041617fce;

        public NeuralSimulatedAnnealingHelper(NeuralSimulatedAnnealing owner)
        {
            this._x071bde1041617fce = owner;
            base.ShouldMinimize = this._x071bde1041617fce.CalculateScore.ShouldMinimize;
        }

        public sealed override double PerformCalculateScore()
        {
            return this._x071bde1041617fce.CalculateScore.CalculateScore((BasicNetwork) this._x071bde1041617fce.Method);
        }

        public sealed override void PutArray(double[] array)
        {
            this._x071bde1041617fce.PutArray(array);
        }

        public sealed override void Randomize()
        {
            this._x071bde1041617fce.Randomize();
        }

        public override double[] Array
        {
            get
            {
                return this._x071bde1041617fce.Array;
            }
        }

        public override double[] ArrayCopy
        {
            get
            {
                return this._x071bde1041617fce.ArrayCopy;
            }
        }
    }
}

