namespace Encog.Neural.RBF
{
    using Encog;
    using Encog.MathUtil.Randomize;
    using Encog.MathUtil.RBF;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks;
    using Encog.Util;
    using Encog.Util.Simple;
    using System;

    [Serializable]
    public class RBFNetwork : BasicML, IMLMethod, IContainsFlat, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLError
    {
        private readonly FlatNetworkRBF _flat;

        public RBFNetwork()
        {
            this._flat = new FlatNetworkRBF();
        }

        public RBFNetwork(int inputCount, int outputCount, IRadialBasisFunction[] rbf)
        {
            FlatNetworkRBF krbf = new FlatNetworkRBF(inputCount, rbf.Length, outputCount, rbf) {
                RBF = rbf
            };
            this._flat = krbf;
        }

        public RBFNetwork(int inputCount, int hiddenCount, int outputCount, RBFEnum t)
        {
            if (hiddenCount != 0)
            {
                IRadialBasisFunction[] rbf = new IRadialBasisFunction[hiddenCount];
                double volumeNeuronRBFWidth = 2.0 / ((double) hiddenCount);
                this._flat = new FlatNetworkRBF(inputCount, rbf.Length, outputCount, rbf);
                try
                {
                    this.SetRBFCentersAndWidthsEqualSpacing(-1.0, 1.0, t, volumeNeuronRBFWidth, false);
                }
                catch (EncogError)
                {
                    this.RandomizeRBFCentersAndWidths(-1.0, 1.0, t);
                }
            }
            else
            {
                do
                {
                    throw new NeuralNetworkError("RBF network cannot have zero hidden neurons.");
                }
                while ((((uint) outputCount) | 2) == 0);
            }
        }

        public double CalculateError(IMLDataSet data)
        {
            return EncogUtility.CalculateRegressionError(this, data);
        }

        public IMLData Compute(IMLData input)
        {
            IMLData data = new BasicMLData(this.OutputCount);
            this._flat.Compute(input.Data, data.Data);
            return data;
        }

        public void RandomizeRBFCentersAndWidths(double min, double max, RBFEnum t)
        {
            int num2;
            int num3;
            int inputCount = this.InputCount;
            double[] centers = new double[inputCount];
            if ((((uint) inputCount) & 0) == 0)
            {
                num2 = 0;
                goto Label_004D;
            }
        Label_0037:
            while (num3 < this._flat.RBF.Length)
            {
                this.SetRBFFunction(num3, t, centers, RangeRandomizer.Randomize(min, max));
                num3++;
                if ((((uint) num3) - ((uint) num3)) > uint.MaxValue)
                {
                    return;
                }
            }
            return;
        Label_004D:
            if (num2 < inputCount)
            {
                centers[num2] = RangeRandomizer.Randomize(min, max);
            }
            else
            {
                num3 = 0;
                goto Label_0037;
            }
            num2++;
            goto Label_004D;
        }

        public void SetRBFCentersAndWidths(double[][] centers, double[] widths, RBFEnum t)
        {
            for (int i = 0; i < this._flat.RBF.Length; i++)
            {
                this.SetRBFFunction(i, t, centers[i], widths[i]);
            }
        }

        public void SetRBFCentersAndWidthsEqualSpacing(double minPosition, double maxPosition, RBFEnum t, double volumeNeuronRBFWidth, bool useWideEdgeRBFs)
        {
            int num2;
            double num3;
            int num4;
            double num5;
            double num6;
            double[][] numArray;
            double[] numArray2;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int length = this._flat.RBF.Length;
            goto Label_0257;
        Label_0013:
            num7++;
        Label_0019:
            if (num7 < length)
            {
                numArray[num7] = new double[num2];
                if (((uint) num8) >= 0)
                {
                    num8 = num4;
                    num9 = num7;
                    goto Label_019F;
                }
                goto Label_012A;
            }
            this.SetRBFCentersAndWidths(numArray, numArray2, t);
            return;
        Label_003B:
            if ((((uint) volumeNeuronRBFWidth) | 8) == 0)
            {
                goto Label_019F;
            }
            if ((((uint) maxPosition) & 0) == 0)
            {
                goto Label_0013;
            }
            return;
        Label_012A:
            if (num10 <= 0)
            {
                bool flag = false;
                if ((((uint) num5) + ((uint) num6)) >= 0)
                {
                    num11 = 0;
                    while (true)
                    {
                        if (num11 < numArray[0].Length)
                        {
                            if ((numArray[num7][num11] == 1.0) || (numArray[num7][num11] == 0.0))
                            {
                                flag = true;
                            }
                            num11++;
                        }
                        else if (flag && useWideEdgeRBFs)
                        {
                            numArray2[num7] = num6;
                            if (((uint) num8) > uint.MaxValue)
                            {
                                goto Label_015C;
                            }
                            if (0 != 0)
                            {
                                goto Label_003B;
                            }
                            if ((((uint) num11) & 0) == 0)
                            {
                                if ((((uint) useWideEdgeRBFs) + ((uint) maxPosition)) >= 0)
                                {
                                    goto Label_0013;
                                }
                                goto Label_0257;
                            }
                        }
                        else
                        {
                            numArray2[num7] = volumeNeuronRBFWidth;
                            goto Label_003B;
                        }
                        if ((((uint) num9) + ((uint) maxPosition)) < 0)
                        {
                            goto Label_0183;
                        }
                    }
                }
                goto Label_0230;
            }
        Label_015C:
            numArray[num7][num10 - 1] = (((int) (((double) num9) / Math.Pow((double) num8, (double) (num10 - 1)))) * (num3 / ((double) (num8 - 1)))) + minPosition;
        Label_0183:
            num9 = num9 % ((int) Math.Pow((double) num8, (double) (num10 - 1)));
            goto Label_01BA;
        Label_019F:
            num10 = num2;
            if ((((uint) num4) + ((uint) useWideEdgeRBFs)) <= uint.MaxValue)
            {
                goto Label_012A;
            }
        Label_01BA:
            if (((uint) num11) >= 0)
            {
                num10--;
            }
            goto Label_012A;
        Label_0230:
            if (num4 != num5)
            {
                throw new NeuralNetworkError("Total number of RBF neurons must be some integer to the power of 'dimensions'.\n" + Format.FormatDouble((double) num4, 5) + " <> " + Format.FormatDouble(num5, 5));
            }
            num6 = 2.5 * volumeNeuronRBFWidth;
            numArray = new double[length][];
            numArray2 = new double[length];
            num7 = 0;
            goto Label_0019;
        Label_0257:
            num2 = this.InputCount;
            num3 = Math.Abs((double) (maxPosition - minPosition));
            num4 = (int) Math.Pow((double) length, 1.0 / ((double) num2));
            num5 = Math.Pow((double) length, 1.0 / ((double) num2));
            goto Label_0230;
        }

        public void SetRBFFunction(int index, RBFEnum t, double[] centers, double width)
        {
            if (t == RBFEnum.Gaussian)
            {
                this._flat.RBF[index] = new GaussianFunction(0.5, centers, width);
            }
            else
            {
                if (t == RBFEnum.Multiquadric)
                {
                    this._flat.RBF[index] = new MultiquadricFunction(0.5, centers, width);
                    if (-2 != 0)
                    {
                        return;
                    }
                }
                else if (t != RBFEnum.InverseMultiquadric)
                {
                    return;
                }
                this._flat.RBF[index] = new InverseMultiquadricFunction(0.5, centers, width);
            }
        }

        public override void UpdateProperties()
        {
        }

        public FlatNetwork Flat
        {
            get
            {
                return this._flat;
            }
        }

        public virtual int InputCount
        {
            get
            {
                return this._flat.InputCount;
            }
        }

        public virtual int OutputCount
        {
            get
            {
                return this._flat.OutputCount;
            }
        }

        public IRadialBasisFunction[] RBF
        {
            get
            {
                return this._flat.RBF;
            }
            set
            {
                this._flat.RBF = value;
            }
        }
    }
}

