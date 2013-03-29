namespace Encog.Neural.NEAT
{
    using Encog.Engine.Network.Activation;
    using Encog.ML.Genetic.Population;
    using Encog.Neural;
    using Encog.Neural.NEAT.Training;
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class NEATPopulation : BasicPopulation
    {
        private IActivationFunction _neatActivationFunction;
        private IActivationFunction _outputActivationFunction;
        private bool _snapshot;
        public const string PropertyNEATActivation = "neatAct";
        public const string PropertyOutputActivation = "outAct";

        public NEATPopulation()
        {
            this._neatActivationFunction = new ActivationSigmoid();
            this._outputActivationFunction = new ActivationLinear();
        }

        public NEATPopulation(int inputCount, int outputCount, int populationSize) : base(populationSize)
        {
            int num;
            NEATGenome genome;
            this._neatActivationFunction = new ActivationSigmoid();
            this._outputActivationFunction = new ActivationLinear();
            this.InputCount = inputCount;
            goto Label_00D5;
        Label_0010:
            if (num >= populationSize)
            {
                NEATGenome genome2 = (NEATGenome) base.Genomes[0];
                base.Innovations = new NEATInnovationList(this, genome2.Links, genome2.Neurons);
                if ((((uint) outputCount) & 0) != 0)
                {
                    goto Label_00D5;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_009D;
            }
        Label_0086:
            genome = new NEATGenome(base.AssignGenomeID(), inputCount, outputCount);
            base.Add(genome);
            num++;
            goto Label_0010;
        Label_009D:
            throw new NeuralNetworkError("Population must have more than zero genomes.");
        Label_00D5:
            this.OutputCount = outputCount;
            if ((-2147483648 != 0) && (populationSize != 0))
            {
                num = 0;
                if ((((uint) num) - ((uint) populationSize)) <= uint.MaxValue)
                {
                    goto Label_0010;
                }
                goto Label_0086;
            }
            goto Label_009D;
        }

        public int InputCount { get; set; }

        public IActivationFunction NeatActivationFunction
        {
            get
            {
                return this._neatActivationFunction;
            }
            set
            {
                this._neatActivationFunction = value;
            }
        }

        public IActivationFunction OutputActivationFunction
        {
            get
            {
                return this._outputActivationFunction;
            }
            set
            {
                this._outputActivationFunction = value;
            }
        }

        public int OutputCount { get; set; }

        public bool Snapshot
        {
            get
            {
                return this._snapshot;
            }
            set
            {
                this._snapshot = value;
            }
        }
    }
}

