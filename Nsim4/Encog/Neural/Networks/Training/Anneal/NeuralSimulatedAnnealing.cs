namespace Encog.Neural.Networks.Training.Anneal
{
    using Encog.MathUtil;
    using Encog.ML;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Structure;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util.Logging;
    using System;

    public class NeuralSimulatedAnnealing : BasicTraining
    {
        private readonly ICalculateScore _x2308f8c4f898a271;
        private readonly BasicNetwork _x87a7fc6a72741c2e;
        private readonly NeuralSimulatedAnnealingHelper _xcad10f1a21e41441;
        public const double Cut = 0.5;

        public NeuralSimulatedAnnealing(BasicNetwork network, ICalculateScore calculateScore, double startTemp, double stopTemp, int cycles) : base(TrainingImplementationType.Iterative)
        {
            this._x87a7fc6a72741c2e = network;
            this._x2308f8c4f898a271 = calculateScore;
            NeuralSimulatedAnnealingHelper helper = new NeuralSimulatedAnnealingHelper(this) {
                Temperature = startTemp,
                StartTemperature = startTemp,
                StopTemperature = stopTemp,
                Cycles = cycles
            };
            this._xcad10f1a21e41441 = helper;
        }

        public sealed override void Iteration()
        {
            EncogLogging.Log(1, "Performing Simulated Annealing iteration.");
            base.PreIteration();
            this._xcad10f1a21e41441.Iteration();
            this.Error = this._xcad10f1a21e41441.PerformCalculateScore();
            base.PostIteration();
        }

        public override TrainingContinuation Pause()
        {
            return null;
        }

        public void PutArray(double[] array)
        {
            NetworkCODEC.ArrayToNetwork(array, this._x87a7fc6a72741c2e);
        }

        public void Randomize()
        {
            double[] array = NetworkCODEC.NetworkToArray(this._x87a7fc6a72741c2e);
            int index = 0;
            if (0 == 0)
            {
                while (true)
                {
                    if (index >= array.Length)
                    {
                        NetworkCODEC.ArrayToNetwork(array, this._x87a7fc6a72741c2e);
                        if (0 == 0)
                        {
                            return;
                        }
                    }
                    double num2 = 0.5 - ThreadSafeRandom.NextDouble();
                    num2 /= this._xcad10f1a21e41441.StartTemperature;
                    num2 *= this._xcad10f1a21e41441.Temperature;
                    do
                    {
                        array[index] += num2;
                        index++;
                    }
                    while (0 != 0);
                }
            }
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        public double[] Array
        {
            get
            {
                return NetworkCODEC.NetworkToArray(this._x87a7fc6a72741c2e);
            }
        }

        public double[] ArrayCopy
        {
            get
            {
                return this.Array;
            }
        }

        public ICalculateScore CalculateScore
        {
            get
            {
                return this._x2308f8c4f898a271;
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

