namespace Encog.Neural.Thermal
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Specific;
    using Encog.Neural;
    using Encog.Util;
    using System;

    [Serializable]
    public abstract class ThermalNetwork : BasicML, IMLMethod, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLResettable, IMLAutoAssocation
    {
        private BiPolarMLData _currentState;
        private int _neuronCount;
        private double[] _weights;

        protected ThermalNetwork()
        {
        }

        protected ThermalNetwork(int neuronCount)
        {
            this._neuronCount = neuronCount;
            this._weights = new double[neuronCount * neuronCount];
            this._currentState = new BiPolarMLData(neuronCount);
        }

        public void AddWeight(int fromNeuron, int toNeuron, double v)
        {
            object[] objArray;
            int index = (toNeuron * this._neuronCount) + fromNeuron;
        Label_000D:
            if (index >= this._weights.Length)
            {
                do
                {
                    objArray = new object[4];
                }
                while ((((uint) v) & 0) != 0);
                objArray[0] = "Out of range: fromNeuron:";
                objArray[1] = fromNeuron;
                if ((((uint) v) & 0) == 0)
                {
                    objArray[2] = ", toNeuron: ";
                    objArray[3] = toNeuron;
                    if ((((uint) v) + ((uint) v)) > uint.MaxValue)
                    {
                        goto Label_000D;
                    }
                }
            }
            else
            {
                this._weights[index] += v;
                return;
            }
            throw new NeuralNetworkError(string.Concat(objArray));
        }

        public double CalculateEnergy()
        {
            int num4;
            double num = 0.0;
            int neuronCount = this.NeuronCount;
            int fromNeuron = 0;
            if ((((uint) num4) + ((uint) fromNeuron)) > uint.MaxValue)
            {
                goto Label_0029;
            }
            while (true)
            {
                if (fromNeuron < neuronCount)
                {
                    num4 = 0;
                }
                else
                {
                    return ((-1.0 * num) / 2.0);
                }
                if (0x7fffffff != 0)
                {
                }
                while (num4 < neuronCount)
                {
                    if (fromNeuron == num4)
                    {
                        goto Label_004E;
                    }
                Label_0029:
                    num += (this.GetWeight(fromNeuron, num4) * this._currentState[fromNeuron]) * this._currentState[num4];
                Label_004E:
                    num4++;
                }
                if ((((uint) num) | 15) != 0)
                {
                    fromNeuron++;
                }
            }
        }

        public void Clear()
        {
            EngineArray.Fill(this._weights, 0);
        }

        public abstract IMLData Compute(IMLData input);
        public double GetWeight(int fromNeuron, int toNeuron)
        {
            int index = (toNeuron * this._neuronCount) + fromNeuron;
            return this._weights[index];
        }

        public void Init(int neuronCount, double[] weights, double[] output)
        {
            object[] objArray;
            object[] objArray2;
            if (neuronCount != output.Length)
            {
                if (((uint) neuronCount) <= uint.MaxValue)
                {
                    objArray = new object[5];
                    objArray[0] = "Neuron count(";
                }
                objArray[1] = neuronCount;
                goto Label_00FE;
            }
        Label_0022:
            if ((neuronCount * neuronCount) != weights.Length)
            {
                objArray2 = new object[5];
            }
            else
            {
                this._neuronCount = neuronCount;
                this._weights = weights;
                BiPolarMLData data = new BiPolarMLData(neuronCount) {
                    Data = output
                };
                this._currentState = data;
                return;
            }
        Label_0063:
            if (4 != 0)
            {
                objArray2[0] = "Weight count(";
                objArray2[1] = weights.Length;
                objArray2[2] = ") must be the square of the neuron count(";
                if ((((uint) neuronCount) - ((uint) neuronCount)) <= uint.MaxValue)
                {
                    objArray2[3] = neuronCount;
                    objArray2[4] = ").";
                    throw new NeuralNetworkError(string.Concat(objArray2));
                }
                return;
            }
        Label_00FE:
            objArray[2] = ") must match output count(";
            objArray[3] = output.Length;
            objArray[4] = ").";
            throw new NeuralNetworkError(string.Concat(objArray));
            if ((((uint) neuronCount) + ((uint) neuronCount)) <= uint.MaxValue)
            {
                if ((((uint) neuronCount) + ((uint) neuronCount)) >= 0)
                {
                }
                goto Label_0022;
            }
            goto Label_0063;
        }

        public void Reset()
        {
            this.Reset(0);
        }

        public void Reset(int seed)
        {
            this.CurrentState.Clear();
            EngineArray.Fill(this._weights, (double) 0.0);
        }

        public void SetCurrentState(double[] s)
        {
            this._currentState = new BiPolarMLData(s.Length);
            EngineArray.ArrayCopy(s, this._currentState.Data);
        }

        public void SetWeight(int fromNeuron, int toNeuron, double v)
        {
            int index = (toNeuron * this._neuronCount) + fromNeuron;
            this._weights[index] = v;
        }

        public BiPolarMLData CurrentState
        {
            get
            {
                return this._currentState;
            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    this._currentState[i] = value[i];
                }
            }
        }

        public abstract int InputCount { get; }

        public int NeuronCount
        {
            get
            {
                return this._neuronCount;
            }
            set
            {
                this._neuronCount = value;
            }
        }

        public abstract int OutputCount { get; }

        public double[] Weights
        {
            get
            {
                return this._weights;
            }
            set
            {
                this._weights = value;
            }
        }
    }
}

