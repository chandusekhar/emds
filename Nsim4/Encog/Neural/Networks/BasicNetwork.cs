namespace Encog.Neural.Networks
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks.Layers;
    using Encog.Neural.Networks.Structure;
    using Encog.Util;
    using Encog.Util.CSV;
    using Encog.Util.Simple;
    using System;
    using System.Text;

    [Serializable]
    public class BasicNetwork : BasicML, IMLMethod, IContainsFlat, IMLContext, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLEncodable, IMLResettable, IMLClassification, IMLError
    {
        private readonly NeuralStructure _structure;
        public const double DefaultConnectionLimit = 1E-10;
        public const string TagBeginTraining = "beginTraining";
        public const string TagBiasActivation = "biasActivation";
        public const string TagConnectionLimit = "connectionLimit";
        public const string TagContextTargetOffset = "contextTargetOffset";
        public const string TagContextTargetSize = "contextTargetSize";
        public const string TagEndTraining = "endTraining";
        public const string TagHasContext = "hasContext";
        public const string TagLayerContextCount = "layerContextCount";
        public const string TagLayerCounts = "layerCounts";
        public const string TagLayerFeedCounts = "layerFeedCounts";
        public const string TagLayerIndex = "layerIndex";
        public const string TagLimit = "CONNECTION_LIMIT";
        public const string TagWeightIndex = "weightIndex";

        public BasicNetwork()
        {
            this._structure = new NeuralStructure(this);
        }

        public void AddLayer(ILayer layer)
        {
            layer.Network = this;
            this._structure.Layers.Add(layer);
        }

        public void AddWeight(int fromLayer, int fromNeuron, int toNeuron, double v)
        {
            double num = this.GetWeight(fromLayer, fromNeuron, toNeuron);
            this.SetWeight(fromLayer, fromNeuron, toNeuron, num + v);
        }

        public double CalculateError(IMLDataSet data)
        {
            return EncogUtility.CalculateRegressionError(this, data);
        }

        public int CalculateNeuronCount()
        {
            int num = 0;
            foreach (ILayer layer in this._structure.Layers)
            {
                num += layer.NeuronCount;
            }
            return num;
        }

        public int Classify(IMLData input)
        {
            return this.Winner(input);
        }

        public void ClearContext()
        {
            if (this._structure.Flat != null)
            {
                this._structure.Flat.ClearContext();
            }
        }

        public object Clone()
        {
            return (BasicNetwork) ObjectCloner.DeepCopy(this);
        }

        public IMLData Compute(IMLData input)
        {
            IMLData data2;
            try
            {
                IMLData data = new BasicMLData(this._structure.Flat.OutputCount);
                this._structure.Flat.Compute(input.Data, data.Data);
                data2 = data;
            }
            catch (IndexOutOfRangeException exception)
            {
                throw new NeuralNetworkError("Index exception: there was likely a mismatch between layer sizes, or the size of the input presented to the network.", exception);
            }
            return data2;
        }

        public void Compute(double[] input, double[] output)
        {
            BasicMLData data = new BasicMLData(input);
            EngineArray.ArrayCopy(this.Compute(data).Data, output);
        }

        public void DecodeFromArray(double[] encoded)
        {
            this._structure.RequireFlat();
            double[] weights = this._structure.Flat.Weights;
            do
            {
                if (weights.Length != encoded.Length)
                {
                    throw new NeuralNetworkError("Size mismatch, encoded array should be of length " + weights.Length);
                }
                EngineArray.ArrayCopy(encoded, weights);
            }
            while (-2 == 0);
        }

        public string DumpWeights()
        {
            StringBuilder result = new StringBuilder();
            NumberList.ToList(CSVFormat.EgFormat, result, this._structure.Flat.Weights);
            return result.ToString();
        }

        public void EnableConnection(int fromLayer, int fromNeuron, int toNeuron, bool enable)
        {
            double num = this.GetWeight(fromLayer, fromNeuron, toNeuron);
            if (!enable)
            {
                if ((((uint) num) + ((uint) num)) < 0)
                {
                    goto Label_0051;
                }
                if (!this._structure.ConnectionLimited)
                {
                    base.SetProperty("CONNECTION_LIMIT", (double) 1E-10);
                    goto Label_0023;
                }
                goto Label_003D;
            }
            if (this._structure.ConnectionLimited && (Math.Abs(num) < this._structure.ConnectionLimit))
            {
                if ((((uint) num) - ((uint) enable)) > uint.MaxValue)
                {
                    goto Label_0023;
                }
                goto Label_0051;
            }
            return;
        Label_0023:
            this._structure.UpdateProperties();
        Label_003D:
            this.SetWeight(fromLayer, fromNeuron, toNeuron, 0.0);
            return;
        Label_0051:
            this.SetWeight(fromLayer, fromNeuron, toNeuron, RangeRandomizer.Randomize(-1.0, 1.0));
        }

        public int EncodedArrayLength()
        {
            this._structure.RequireFlat();
            return this._structure.Flat.EncodeLength;
        }

        public void EncodeToArray(double[] encoded)
        {
            this._structure.RequireFlat();
            double[] weights = this._structure.Flat.Weights;
            if (0 == 0)
            {
                if (0 == 0)
                {
                    if (weights.Length != encoded.Length)
                    {
                        goto Label_002D;
                    }
                }
                else
                {
                    goto Label_002D;
                }
            }
            EngineArray.ArrayCopy(weights, encoded);
            return;
        Label_002D:
            throw new NeuralNetworkError("Size mismatch, encoded array should be of length " + weights.Length);
        }

        public bool Equals(BasicNetwork other)
        {
            return this.Equals(other, 10);
        }

        public bool Equals(BasicNetwork other, int precision)
        {
            return NetworkCODEC.Equals(this, other, precision);
        }

        public IActivationFunction GetActivation(int layer)
        {
            this._structure.RequireFlat();
            int index = (this.LayerCount - layer) - 1;
            return this._structure.Flat.ActivationFunctions[index];
        }

        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public double GetLayerBiasActivation(int l)
        {
            if (!this.IsLayerBiased(l))
            {
                throw new NeuralNetworkError("Error, the specified layer does not have a bias: " + l);
            }
            this._structure.RequireFlat();
            int index = (this.LayerCount - l) - 1;
            int num2 = this._structure.Flat.LayerIndex[index];
            int num3 = this._structure.Flat.LayerCounts[index];
            return this._structure.Flat.LayerOutput[(num2 + num3) - 1];
        }

        public int GetLayerNeuronCount(int l)
        {
            this._structure.RequireFlat();
            int index = (this.LayerCount - l) - 1;
            return this._structure.Flat.LayerFeedCounts[index];
        }

        public double GetLayerOutput(int layer, int neuronNumber)
        {
            int num2;
            double[] layerOutput;
            this._structure.RequireFlat();
            do
            {
                int index = (this.LayerCount - layer) - 1;
                num2 = this._structure.Flat.LayerIndex[index] + neuronNumber;
                layerOutput = this._structure.Flat.LayerOutput;
            }
            while (0 != 0);
            if ((((uint) layer) <= uint.MaxValue) && (num2 >= layerOutput.Length))
            {
                throw new NeuralNetworkError("The layer index: " + num2 + " specifies an output index larger than the network has.");
            }
            return layerOutput[num2];
        }

        public int GetLayerTotalNeuronCount(int l)
        {
            this._structure.RequireFlat();
            int index = (this.LayerCount - l) - 1;
            return this._structure.Flat.LayerCounts[index];
        }

        public double GetWeight(int fromLayer, int fromNeuron, int toNeuron)
        {
            this._structure.RequireFlat();
            while (true)
            {
                int num3;
                int num4;
                int num5;
                this.ValidateNeuron(fromLayer, fromNeuron);
                this.ValidateNeuron(fromLayer + 1, toNeuron);
                do
                {
                    int num2;
                    int index = (this.LayerCount - fromLayer) - 1;
                    if ((((uint) num5) + ((uint) num3)) <= uint.MaxValue)
                    {
                        if ((((uint) index) + ((uint) num5)) < 0)
                        {
                            break;
                        }
                        num2 = index - 1;
                        while (num2 < 0)
                        {
                            throw new NeuralNetworkError("The specified layer is not connected to another layer: " + fromLayer);
                        }
                    }
                    num3 = this._structure.Flat.WeightIndex[num2];
                    num4 = this._structure.Flat.LayerCounts[index];
                }
                while (0 != 0);
                num5 = (num3 + fromNeuron) + (toNeuron * num4);
                if (4 != 0)
                {
                    return this._structure.Flat.Weights[num5];
                }
            }
        }

        public bool IsConnected(int layer, int fromNeuron, int toNeuron)
        {
            return false;
        }

        public bool IsLayerBiased(int l)
        {
            this._structure.RequireFlat();
            int index = (this.LayerCount - l) - 1;
            return (this._structure.Flat.LayerCounts[index] != this._structure.Flat.LayerFeedCounts[index]);
        }

        public void Reset()
        {
            if (this.LayerCount < 3)
            {
                new RangeRandomizer(-1.0, 1.0).Randomize(this);
            }
            else
            {
                new NguyenWidrowRandomizer(-1.0, 1.0).Randomize(this);
            }
        }

        public void Reset(int seed)
        {
            this.Reset();
        }

        public void SetLayerBiasActivation(int l, double v)
        {
            int num2;
            int num3;
            if (!this.IsLayerBiased(l))
            {
                throw new NeuralNetworkError("Error, the specified layer does not have a bias: " + l);
            }
            do
            {
                this._structure.RequireFlat();
                int index = (this.LayerCount - l) - 1;
                num2 = this._structure.Flat.LayerIndex[index];
                num3 = this._structure.Flat.LayerCounts[index];
                this._structure.Flat.LayerOutput[(num2 + num3) - 1] = v;
            }
            while ((((uint) num3) - ((uint) num2)) > uint.MaxValue);
        }

        public void SetWeight(int fromLayer, int fromNeuron, int toNeuron, double v)
        {
            int num5;
            this._structure.RequireFlat();
            int index = (this.LayerCount - fromLayer) - 1;
            int num2 = index - 1;
            if (num2 < 0)
            {
                throw new NeuralNetworkError("The specified layer is not connected to another layer: " + fromLayer);
            }
            int num3 = this._structure.Flat.WeightIndex[num2];
            int num4 = this._structure.Flat.LayerCounts[index];
            do
            {
                num5 = (num3 + fromNeuron) + (toNeuron * num4);
            }
            while ((((uint) fromNeuron) + ((uint) num3)) < 0);
            if (0 == 0)
            {
                this._structure.Flat.Weights[num5] = v;
            }
        }

        public sealed override string ToString()
        {
            // This item is obfuscated and can not be translated.
            int num;
            StringBuilder builder = new StringBuilder();
            if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
            {
                builder.Append("[BasicNetwork: Layers=");
                if ((0 != 0) || ((((uint) num) + ((uint) num)) < 0))
                {
                    goto Label_003B;
                }
            }
            if (this._structure.Flat == null)
            {
            }
        Label_003B:
            num = this._structure.Layers.Count;
            builder.Append(num);
            builder.Append("]");
            return builder.ToString();
        }

        public sealed override void UpdateProperties()
        {
            this._structure.UpdateProperties();
        }

        public void ValidateNeuron(int targetLayer, int neuron)
        {
            if (targetLayer < 0)
            {
                goto Label_004A;
            }
            goto Label_0078;
        Label_0008:
            if (neuron >= 0)
            {
                goto Label_0027;
            }
        Label_000C:
            throw new NeuralNetworkError("Invalid neuron number: " + neuron);
        Label_0027:
            if (neuron < this.GetLayerTotalNeuronCount(targetLayer))
            {
                return;
            }
            if (((uint) neuron) >= 0)
            {
            }
            goto Label_000C;
        Label_004A:
            throw new NeuralNetworkError("Invalid layer count: " + targetLayer);
            if ((((uint) targetLayer) + ((uint) targetLayer)) >= 0)
            {
                goto Label_0008;
            }
        Label_0078:
            if (targetLayer >= this.LayerCount)
            {
                goto Label_004A;
            }
            if ((((uint) neuron) | 1) != 0)
            {
                goto Label_0008;
            }
            goto Label_0027;
        }

        public int Winner(IMLData input)
        {
            return EngineArray.MaxIndex(this.Compute(input).Data);
        }

        public double BiasActivation
        {
            set
            {
                int num;
                if (this._structure.Flat != null)
                {
                    num = 0;
                    goto Label_0037;
                }
                if (((uint) value) <= uint.MaxValue)
                {
                    foreach (ILayer layer in this._structure.Layers)
                    {
                        if (layer.HasBias())
                        {
                            layer.BiasActivation = value;
                        }
                    }
                    return;
                }
            Label_0022:
                if (this.IsLayerBiased(num))
                {
                    this.SetLayerBiasActivation(num, value);
                }
                num++;
            Label_0037:
                if (num < this.LayerCount)
                {
                    goto Label_0022;
                }
            }
        }

        public FlatNetwork Flat
        {
            get
            {
                return this.Structure.Flat;
            }
        }

        public virtual int InputCount
        {
            get
            {
                this._structure.RequireFlat();
                return this.Structure.Flat.InputCount;
            }
        }

        public int LayerCount
        {
            get
            {
                this._structure.RequireFlat();
                return this._structure.Flat.LayerCounts.Length;
            }
        }

        public virtual int OutputCount
        {
            get
            {
                this._structure.RequireFlat();
                return this.Structure.Flat.OutputCount;
            }
        }

        public NeuralStructure Structure
        {
            get
            {
                return this._structure;
            }
        }
    }
}

