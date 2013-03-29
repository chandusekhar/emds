namespace Encog.Neural.Flat
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil;
    using Encog.MathUtil.Error;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class FlatNetwork
    {
        private IActivationFunction[] _activationFunctions;
        private int _beginTraining;
        private double[] _biasActivation;
        private double _connectionLimit;
        private int[] _contextTargetOffset;
        private int[] _contextTargetSize;
        private int _endTraining;
        private bool _hasContext;
        private int _inputCount;
        private bool _isLimited;
        private int[] _layerContextCount;
        private int[] _layerCounts;
        private int[] _layerFeedCounts;
        private int[] _layerIndex;
        private double[] _layerOutput;
        private double[] _layerSums;
        private int _outputCount;
        private int[] _weightIndex;
        private double[] _weights;
        public const double DefaultBiasActivation = 1.0;
        public const double NoBiasActivation = 0.0;

        public FlatNetwork()
        {
        }

        public FlatNetwork(FlatLayer[] layers)
        {
            this.Init(layers);
        }

        public FlatNetwork(int input, int hidden1, int hidden2, int output, bool tanh)
        {
            // This item is obfuscated and can not be translated.
            FlatLayer[] layerArray;
            IActivationFunction function2;
            int num;
            IActivationFunction function3;
            IActivationFunction activation = new ActivationLinear();
            if (tanh)
            {
                goto Label_01EA;
            }
            goto Label_0219;
        Label_000B:
            this._connectionLimit = 0.0;
            this.Init(layerArray);
            if (0 != 0)
            {
                if (((uint) hidden1) > uint.MaxValue)
                {
                    goto Label_0069;
                }
                goto Label_0219;
            }
            if (((uint) num) < 0)
            {
                goto Label_0189;
            }
            return;
        Label_0069:
            layerArray[3] = new FlatLayer(function2, output, 0.0);
            if ((((uint) num) + ((uint) output)) >= 0)
            {
            }
        Label_0098:
            this._isLimited = false;
            goto Label_000B;
        Label_00A1:
            if (hidden2 != 0)
            {
                if ((((uint) tanh) - ((uint) hidden2)) > uint.MaxValue)
                {
                    goto Label_01AA;
                }
                layerArray = new FlatLayer[4];
                layerArray[0] = new FlatLayer(activation, input, 1.0);
                layerArray[1] = new FlatLayer(function2, hidden1, 1.0);
                if ((((uint) tanh) + ((uint) hidden2)) <= uint.MaxValue)
                {
                    layerArray[2] = new FlatLayer(function2, hidden2, 1.0);
                    if (((uint) hidden2) > uint.MaxValue)
                    {
                        goto Label_015F;
                    }
                    goto Label_0069;
                }
                goto Label_000B;
            }
        Label_010F:
            num = Math.Max(hidden1, hidden2);
            layerArray = new FlatLayer[] { new FlatLayer(activation, input, 1.0), new FlatLayer(function2, num, 1.0), new FlatLayer(function2, output, 0.0) };
            goto Label_0098;
        Label_015F:
            if (((uint) output) > uint.MaxValue)
            {
                goto Label_01AA;
            }
            if ((((uint) tanh) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0198;
            }
        Label_0189:
            if (-1 != 0)
            {
                goto Label_00A1;
            }
            goto Label_010F;
        Label_0198:
            if (hidden1 != 0)
            {
                goto Label_00A1;
            }
            goto Label_010F;
        Label_01AA:
            if (hidden2 != 0)
            {
                goto Label_0198;
            }
            layerArray = new FlatLayer[] { new FlatLayer(activation, input, 1.0), new FlatLayer(function2, output, 0.0) };
            goto Label_0098;
        Label_01EA:
            function2 = new ActivationTANH();
            if (hidden1 != 0)
            {
                goto Label_015F;
            }
            goto Label_01AA;
        Label_0219:
            function3 = new ActivationSigmoid();
            if ((((uint) num) | 2) != 0)
            {
                goto Label_01EA;
            }
            goto Label_010F;
        }

        public double CalculateError(IMLDataSet data)
        {
            double[] numArray;
            IMLDataPair pair;
            int num;
            ErrorCalculation calculation = new ErrorCalculation();
            goto Label_0057;
        Label_0031:
            num++;
        Label_0035:
            if (num < data.Count)
            {
                data.GetRecord((long) num, pair);
                this.Compute(pair.InputArray, numArray);
                calculation.UpdateError(numArray, pair.IdealArray, pair.Significance);
                goto Label_0031;
            }
            if ((((uint) num) | 8) != 0)
            {
                return calculation.Calculate();
            }
        Label_0057:
            numArray = new double[this._outputCount];
            if (0 != 0)
            {
                goto Label_0031;
            }
            pair = BasicMLDataPair.CreatePair(data.InputSize, data.IdealSize);
            num = 0;
            goto Label_0035;
        }

        public void ClearConnectionLimit()
        {
            this._connectionLimit = 0.0;
            this._isLimited = false;
        }

        public void ClearContext()
        {
            int num2;
            bool flag;
            int num4;
            int num = 0;
            if (((uint) flag) >= 0)
            {
                goto Label_00E2;
            }
            goto Label_0059;
        Label_0034:
            while (num4 < this._layerContextCount[num2])
            {
                this._layerOutput[num++] = 0.0;
                num4++;
            }
            num2++;
        Label_0044:
            if (num2 < this._layerIndex.Length)
            {
                flag = (this._layerContextCount[num2] + this._layerFeedCounts[num2]) != this._layerCounts[num2];
                for (int i = 0; i < this._layerFeedCounts[num2]; i++)
                {
                    this._layerOutput[num++] = 0.0;
                    if ((((uint) flag) + ((uint) flag)) < 0)
                    {
                        goto Label_0034;
                    }
                }
                if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0054;
                }
                goto Label_00BC;
            }
            return;
        Label_0054:
            if (flag)
            {
                goto Label_00BC;
            }
            goto Label_0071;
        Label_0059:
            if ((((uint) num2) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0054;
            }
        Label_0071:
            num4 = 0;
            goto Label_0034;
        Label_00BC:
            this._layerOutput[num++] = this._biasActivation[num2];
            if (((uint) num4) <= uint.MaxValue)
            {
                goto Label_0059;
            }
        Label_00E2:
            num2 = 0;
            goto Label_0044;
        }

        public virtual object Clone()
        {
            FlatNetwork result = new FlatNetwork();
            this.CloneFlatNetwork(result);
            return result;
        }

        public void CloneFlatNetwork(FlatNetwork result)
        {
            int num;
            result._inputCount = this._inputCount;
            goto Label_0172;
        Label_001F:
            if (num < result._activationFunctions.Length)
            {
                result._activationFunctions[num] = (IActivationFunction) this._activationFunctions[num].Clone();
                if ((((uint) num) & 0) == 0)
                {
                    if (-2 == 0)
                    {
                        goto Label_0133;
                    }
                    num++;
                    goto Label_001F;
                }
                if ((((uint) num) | 4) != 0)
                {
                    goto Label_0172;
                }
                goto Label_0122;
            }
            result._beginTraining = this._beginTraining;
            result._endTraining = this._endTraining;
            return;
        Label_00BF:
            result._weights = this._weights;
            result._activationFunctions = new IActivationFunction[this._activationFunctions.Length];
            num = 0;
            goto Label_001F;
        Label_0122:
            result._layerIndex = EngineArray.ArrayCopy(this._layerIndex);
        Label_0133:
            result._layerOutput = EngineArray.ArrayCopy(this._layerOutput);
            result._layerSums = EngineArray.ArrayCopy(this._layerSums);
            result._layerFeedCounts = EngineArray.ArrayCopy(this._layerFeedCounts);
            result._contextTargetOffset = EngineArray.ArrayCopy(this._contextTargetOffset);
            result._contextTargetSize = EngineArray.ArrayCopy(this._contextTargetSize);
            result._layerContextCount = EngineArray.ArrayCopy(this._layerContextCount);
            result._biasActivation = EngineArray.ArrayCopy(this._biasActivation);
            result._outputCount = this._outputCount;
            result._weightIndex = this._weightIndex;
            if (3 == 0)
            {
                goto Label_001F;
            }
            goto Label_00BF;
        Label_0172:
            result._layerCounts = EngineArray.ArrayCopy(this._layerCounts);
            if ((((uint) num) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_00BF;
            }
            goto Label_0122;
        }

        public virtual void Compute(double[] input, double[] output)
        {
            int num2;
            int num3;
            int num4;
            int targetIndex = this._layerOutput.Length - this._layerCounts[this._layerCounts.Length - 1];
            goto Label_00C2;
        Label_0024:
            this._layerOutput[num3 + num4] = this._layerOutput[num4];
            num4++;
        Label_003A:
            if (num4 < this._contextTargetSize[0])
            {
                goto Label_0024;
            }
            EngineArray.ArrayCopy(this._layerOutput, 0, output, 0, this._outputCount);
            if (0 == 0)
            {
                if (-1 != 0)
                {
                    return;
                }
                goto Label_00C2;
            }
            if ((((uint) num4) + ((uint) num4)) >= 0)
            {
                goto Label_008E;
            }
        Label_0074:
            this.ComputeLayer(num2);
            num2--;
        Label_007F:
            if (num2 > 0)
            {
                goto Label_0074;
            }
            num3 = this._contextTargetOffset[0];
            num4 = 0;
            goto Label_003A;
        Label_008E:
            if ((((uint) num3) | 15) == 0)
            {
                goto Label_0024;
            }
            num2 = this._layerIndex.Length - 1;
            goto Label_007F;
        Label_00C2:
            EngineArray.ArrayCopy(input, 0, this._layerOutput, targetIndex, this._inputCount);
            if (0 != 0)
            {
                return;
            }
            goto Label_008E;
        }

        protected internal void ComputeLayer(int currentLayer)
        {
            int num8;
            double num9;
            int num10;
            int num11;
            int num12;
            int num = this._layerIndex[currentLayer];
            int start = this._layerIndex[currentLayer - 1];
            int num3 = this._layerCounts[currentLayer];
            int size = this._layerFeedCounts[currentLayer - 1];
            int num5 = this._weightIndex[currentLayer - 1];
            int num6 = start + size;
            int num7 = num + num3;
            goto Label_011B;
        Label_000E:
            this._layerOutput[num11 + num12] = this._layerOutput[start + num12];
            num12++;
        Label_002B:
            if ((((uint) num11) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_011B;
            }
        Label_0046:
            if (num12 < this._contextTargetSize[currentLayer])
            {
                goto Label_000E;
            }
            return;
        Label_0071:
            if (num8 < num6)
            {
                num9 = 0.0;
                num10 = num;
            }
            else
            {
                this._activationFunctions[currentLayer - 1].ActivationFunction(this._layerOutput, start, size);
                num11 = this._contextTargetOffset[currentLayer];
                if (((uint) start) > uint.MaxValue)
                {
                    goto Label_010E;
                }
                num12 = 0;
                goto Label_0046;
            }
        Label_00CF:
            if (num10 < num7)
            {
                num9 += this._weights[num5++] * this._layerOutput[num10];
            }
            else
            {
                this._layerOutput[num8] = num9;
                if (((uint) num8) > uint.MaxValue)
                {
                    goto Label_000E;
                }
                this._layerSums[num8] = num9;
                num8++;
                goto Label_0071;
            }
        Label_010E:
            num10++;
            goto Label_00CF;
        Label_011B:
            num8 = start;
            if ((((uint) num10) + ((uint) num9)) > uint.MaxValue)
            {
                goto Label_002B;
            }
            if ((((uint) num12) & 0) == 0)
            {
                goto Label_0071;
            }
            goto Label_000E;
        }

        public void DecodeNetwork(double[] data)
        {
            object[] objArray;
            if ((data.Length != this._weights.Length) && (0 == 0))
            {
                goto Label_0045;
            }
        Label_0010:
            this._weights = data;
            if (0 == 0)
            {
                return;
            }
            goto Label_0045;
            if (0 == 0)
            {
                if (0 != 0)
                {
                    return;
                }
                goto Label_0010;
            }
        Label_0045:
            objArray = new object[4];
            objArray[0] = "Incompatable weight sizes, can't assign length=";
            objArray[1] = data.Length;
            if (-2 != 0)
            {
                objArray[2] = " to length=";
                objArray[3] = data.Length;
                throw new EncogError(string.Concat(objArray));
            }
            goto Label_0010;
        }

        public double[] EncodeNetwork()
        {
            return this._weights;
        }

        public Type HasSameActivationFunction()
        {
            IActivationFunction[] functionArray;
            int num;
            IList<Type> list = new List<Type>();
            if (0 == 0)
            {
                functionArray = this._activationFunctions;
                num = 0;
                goto Label_002C;
            }
        Label_0009:
            return null;
        Label_002C:
            if (num >= functionArray.Length)
            {
                if (list.Count == 1)
                {
                    return list[0];
                }
                goto Label_0009;
            }
            IActivationFunction function = functionArray[num];
            if (((((uint) num) - ((uint) num)) > uint.MaxValue) || !list.Contains(function.GetType()))
            {
                list.Add(function.GetType());
            }
            num++;
            goto Label_002C;
        }

        public void Init(FlatLayer[] layers)
        {
            int num2;
            int num3;
            int num4;
            int num5;
            FlatLayer layer;
            FlatLayer layer2;
            int num6;
            int num7;
            int length = layers.Length;
            if (((uint) num4) <= uint.MaxValue)
            {
                this._inputCount = layers[0].Count;
                goto Label_0452;
            }
            if (((uint) num5) <= uint.MaxValue)
            {
                goto Label_03A5;
            }
            goto Label_01EF;
        Label_00AA:
            if (num5 >= 0)
            {
                goto Label_0357;
            }
        Label_00B2:
            this._beginTraining = 0;
            this._endTraining = this._layerCounts.Length - 1;
            this._weights = new double[num4];
            this._layerOutput = new double[num3];
            this._layerSums = new double[num3];
            this.ClearContext();
            return;
        Label_00CE:
            num6 += layers[num7].TotalCount;
        Label_00DC:
            num7--;
        Label_00E2:
            if (num7 >= 0)
            {
                while (layers[num7].ContextFedBy == layer)
                {
                    this._hasContext = true;
                    this._contextTargetSize[num2] = layers[num7].ContextCount;
                    if (((uint) num5) >= 0)
                    {
                        goto Label_011B;
                    }
                }
                goto Label_00CE;
            }
            num2++;
            if ((((uint) num4) - ((uint) num4)) <= uint.MaxValue)
            {
                if ((((uint) num7) - ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_0357;
                }
                if ((((uint) num4) & 0) != 0)
                {
                    goto Label_0452;
                }
                num5--;
                goto Label_00AA;
            }
            if ((((uint) num3) + ((uint) num3)) >= 0)
            {
                goto Label_013B;
            }
        Label_011B:
            this._contextTargetOffset[num2] = num6 + (layers[num7].TotalCount - layers[num7].ContextCount);
            goto Label_00CE;
        Label_013B:
            num7 = layers.Length - 1;
            goto Label_00E2;
        Label_0182:
            num6 = 0;
            if ((((uint) num4) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_013B;
            }
            return;
        Label_018A:
            if (num2 == 0)
            {
                this._weightIndex[num2] = 0;
                this._layerIndex[num2] = 0;
                goto Label_0182;
            }
            this._weightIndex[num2] = this._weightIndex[num2 - 1] + (this._layerCounts[num2] * this._layerFeedCounts[num2 - 1]);
            this._layerIndex[num2] = this._layerIndex[num2 - 1] + this._layerCounts[num2 - 1];
            if ((((uint) num7) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0182;
            }
        Label_01EF:
            if ((((uint) num6) | 8) == 0)
            {
                goto Label_00B2;
            }
            num4 += layer.Count * layer2.TotalCount;
            if (0 == 0)
            {
                goto Label_018A;
            }
        Label_026C:
            this._layerFeedCounts[num2] = layer.Count;
            this._layerContextCount[num2] = layer.ContextCount;
            this._activationFunctions[num2] = layer.Activation;
        Label_0299:
            num3 += layer.TotalCount;
            if (layer2 == null)
            {
                goto Label_018A;
            }
            goto Label_01EF;
        Label_02AC:
            if (num5 > 0)
            {
                goto Label_02EB;
            }
        Label_02B1:
            this._biasActivation[num2] = layer.BiasActivation;
            this._layerCounts[num2] = layer.TotalCount;
            goto Label_026C;
        Label_02EB:
            layer2 = layers[num5 - 1];
            if ((((uint) num6) - ((uint) num4)) >= 0)
            {
                if ((((uint) length) - ((uint) num7)) >= 0)
                {
                    goto Label_02B1;
                }
                goto Label_02AC;
            }
            goto Label_03A5;
        Label_0357:
            layer = layers[num5];
            layer2 = null;
            goto Label_03CB;
        Label_03A5:
            this._layerFeedCounts = new int[length];
            this._contextTargetOffset = new int[length];
            this._contextTargetSize = new int[length];
            if ((((uint) length) - ((uint) num3)) < 0)
            {
                goto Label_00DC;
            }
            this._biasActivation = new double[length];
            num2 = 0;
            num3 = 0;
            num4 = 0;
            if ((((uint) length) & 0) == 0)
            {
                num5 = layers.Length - 1;
                goto Label_00AA;
            }
        Label_03CB:
            if ((((uint) num6) - ((uint) num7)) >= 0)
            {
                if ((((uint) num3) - ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_0299;
                }
                if ((((uint) num2) - ((uint) num4)) < 0)
                {
                    goto Label_03A5;
                }
            }
            if (2 != 0)
            {
                goto Label_02AC;
            }
            if ((((uint) num4) | 0x80000000) == 0)
            {
                goto Label_0182;
            }
            goto Label_02EB;
        Label_0452:
            this._outputCount = layers[length - 1].Count;
            this._layerCounts = new int[length];
            this._layerContextCount = new int[length];
            this._weightIndex = new int[length];
            this._layerIndex = new int[length];
            this._activationFunctions = new IActivationFunction[length];
            if (((uint) length) < 0)
            {
                return;
            }
            goto Label_03A5;
        }

        public void Randomize()
        {
            this.Randomize(1.0, -1.0);
        }

        public void Randomize(double hi, double lo)
        {
            for (int i = 0; i < this._weights.Length; i++)
            {
                this._weights[i] = (ThreadSafeRandom.NextDouble() * (hi - lo)) + lo;
            }
        }

        public IActivationFunction[] ActivationFunctions
        {
            get
            {
                return this._activationFunctions;
            }
            set
            {
                this._activationFunctions = value;
            }
        }

        public int BeginTraining
        {
            get
            {
                return this._beginTraining;
            }
            set
            {
                this._beginTraining = value;
            }
        }

        public double[] BiasActivation
        {
            get
            {
                return this._biasActivation;
            }
            set
            {
                this._biasActivation = value;
            }
        }

        public double ConnectionLimit
        {
            get
            {
                return this._connectionLimit;
            }
            set
            {
                this._connectionLimit = value;
                while (Math.Abs((double) (this._connectionLimit - 1E-10)) < 1E-07)
                {
                    this._isLimited = true;
                    break;
                }
            }
        }

        public int[] ContextTargetOffset
        {
            get
            {
                return this._contextTargetOffset;
            }
            set
            {
                this._contextTargetOffset = value;
            }
        }

        public int[] ContextTargetSize
        {
            get
            {
                return this._contextTargetSize;
            }
            set
            {
                this._contextTargetSize = value;
            }
        }

        public int EncodeLength
        {
            get
            {
                return this._weights.Length;
            }
        }

        public int EndTraining
        {
            get
            {
                return this._endTraining;
            }
            set
            {
                this._endTraining = value;
            }
        }

        public bool HasContext
        {
            get
            {
                return this._hasContext;
            }
            set
            {
                this._hasContext = value;
            }
        }

        public int InputCount
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

        public int[] LayerContextCount
        {
            get
            {
                return this._layerContextCount;
            }
            set
            {
                this._layerContextCount = value;
            }
        }

        public int[] LayerCounts
        {
            get
            {
                return this._layerCounts;
            }
            set
            {
                this._layerCounts = value;
            }
        }

        public int[] LayerFeedCounts
        {
            get
            {
                return this._layerFeedCounts;
            }
            set
            {
                this._layerFeedCounts = value;
            }
        }

        public int[] LayerIndex
        {
            get
            {
                return this._layerIndex;
            }
            set
            {
                this._layerIndex = value;
            }
        }

        public double[] LayerOutput
        {
            get
            {
                return this._layerOutput;
            }
            set
            {
                this._layerOutput = value;
            }
        }

        public double[] LayerSums
        {
            get
            {
                return this._layerSums;
            }
            set
            {
                this._layerSums = value;
            }
        }

        public bool Limited
        {
            get
            {
                return this._isLimited;
            }
        }

        public int NeuronCount
        {
            get
            {
                return this._layerCounts.Sum();
            }
        }

        public int OutputCount
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

        public int[] WeightIndex
        {
            get
            {
                return this._weightIndex;
            }
            set
            {
                this._weightIndex = value;
            }
        }

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

