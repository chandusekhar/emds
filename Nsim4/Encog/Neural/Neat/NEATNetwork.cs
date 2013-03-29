namespace Encog.Neural.NEAT
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Util.Simple;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class NEATNetwork : BasicML, IMLMethod, IMLContext, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLError
    {
        private IActivationFunction _activationFunction;
        private int _inputCount;
        private int _networkDepth;
        private readonly IList<NEATNeuron> _neurons;
        private IActivationFunction _outputActivationFunction;
        private int _outputCount;
        private bool _snapshot;
        public const string PropertyLinks = "links";
        public const string PropertyNetworkDepth = "depth";
        public const string PropertySnapshot = "snapshot";

        public NEATNetwork()
        {
            this._neurons = new List<NEATNeuron>();
            this._snapshot = false;
        }

        public NEATNetwork(int inputCount, int outputCount)
        {
            this._neurons = new List<NEATNeuron>();
            if ((((uint) inputCount) - ((uint) outputCount)) >= 0)
            {
                this._snapshot = false;
            }
            this._inputCount = inputCount;
            this._outputCount = outputCount;
            this._networkDepth = 0;
            this._activationFunction = new ActivationSigmoid();
        }

        public NEATNetwork(int inputCount, int outputCount, IEnumerable<NEATNeuron> neurons, IActivationFunction activationFunction, IActivationFunction outputActivationFunction, int networkDepth)
        {
            this._neurons = new List<NEATNeuron>();
            while (true)
            {
                this._snapshot = false;
                this._inputCount = inputCount;
                if (0xff != 0)
                {
                }
                this._outputCount = outputCount;
                this._outputActivationFunction = outputActivationFunction;
                foreach (NEATNeuron neuron in neurons)
                {
                    this._neurons.Add(neuron);
                }
                this._networkDepth = networkDepth;
                this._activationFunction = activationFunction;
                if (((uint) networkDepth) >= 0)
                {
                    return;
                }
            }
        }

        public virtual double CalculateError(IMLDataSet data)
        {
            return EncogUtility.CalculateRegressionError(this, data);
        }

        public virtual void ClearContext()
        {
            foreach (NEATNeuron neuron in this._neurons)
            {
                neuron.Output = 0.0;
            }
        }

        public virtual IMLData Compute(IMLData input)
        {
            int num;
            int num2;
            int num3;
            int num4;
            double num5;
            double weight;
            double output;
            IMLData data = new BasicMLData(this._outputCount);
            goto Label_0271;
        Label_001B:
            num4++;
        Label_0021:
            if (num4 < this._neurons.Count)
            {
                NEATNeuron neuron = this._neurons[num4];
                num5 = 0.0;
                foreach (NEATLink link in neuron.InboundLinks)
                {
                    weight = link.Weight;
                    do
                    {
                        output = link.FromNeuron.Output;
                    }
                    while ((((uint) weight) - ((uint) num2)) < 0);
                    num5 += weight * output;
                }
                double[] d = new double[] { num5 / neuron.ActivationResponse };
                this._activationFunction.ActivationFunction(d, 0, d.Length);
                this._neurons[num4].Output = d[0];
                if (neuron.NeuronType == NEATNeuronType.Output)
                {
                    data[num3++] = neuron.Output;
                    if ((((uint) num2) - ((uint) num4)) < 0)
                    {
                        goto Label_0206;
                    }
                    if (-1 == 0)
                    {
                        goto Label_025D;
                    }
                }
                goto Label_001B;
            }
            num2++;
        Label_0037:
            if (num2 < num)
            {
                num3 = 0;
                if ((((uint) weight) - ((uint) weight)) >= 0)
                {
                    if (1 != 0)
                    {
                        num4 = 0;
                        data.Clear();
                        while (this._neurons[num4].NeuronType == NEATNeuronType.Input)
                        {
                            this._neurons[num4].Output = input[num4];
                            num4++;
                        }
                        goto Label_01BB;
                    }
                    goto Label_001B;
                }
                if (((uint) output) <= uint.MaxValue)
                {
                    goto Label_0271;
                }
                goto Label_0239;
            }
        Label_003E:
            this._outputActivationFunction.ActivationFunction(data.Data, 0, data.Count);
            return data;
        Label_01BB:
            this._neurons[num4++].Output = 1.0;
            if (((uint) output) <= uint.MaxValue)
            {
                goto Label_0021;
            }
        Label_0206:
            num2 = 0;
            goto Label_0037;
        Label_0239:
            num = this._networkDepth;
            if ((((uint) num5) | 0x7fffffff) == 0)
            {
                goto Label_003E;
            }
            goto Label_0206;
        Label_025D:
            if (this._neurons.Count == 0)
            {
                throw new NeuralNetworkError("This network has not been evolved yet, it has no neurons in the NEAT synapse.");
            }
            num = 1;
            if (this._snapshot)
            {
                goto Label_0239;
            }
            goto Label_0206;
        Label_0271:
            if (1 == 0)
            {
                goto Label_001B;
            }
            if (0 != 0)
            {
                goto Label_01BB;
            }
            goto Label_025D;
        }

        public override void UpdateProperties()
        {
        }

        public IActivationFunction ActivationFunction
        {
            get
            {
                return this._activationFunction;
            }
            set
            {
                this._activationFunction = value;
            }
        }

        public virtual int InputCount
        {
            get
            {
                return this._inputCount;
            }
            set
            {
                this._inputCount = value;
            }
        }

        public int NetworkDepth
        {
            get
            {
                return this._networkDepth;
            }
            set
            {
                this._networkDepth = value;
            }
        }

        public IList<NEATNeuron> Neurons
        {
            get
            {
                return this._neurons;
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

        public virtual int OutputCount
        {
            get
            {
                return this._outputCount;
            }
            set
            {
                this._outputCount = value;
            }
        }

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

