namespace Encog.Neural.PNN
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class BasicPNN : AbstractPNN, IMLMethod, IMLRegression, IMLInputOutput, IMLInput, IMLOutput
    {
        private int[] _countPer;
        private double[] _priors;
        private BasicMLDataSet _samples;
        private readonly double[] _sigma;

        public BasicPNN(PNNKernelType kernel, PNNOutputMode outmodel, int inputCount, int outputCount) : base(kernel, outmodel, inputCount, outputCount)
        {
            base.SeparateClass = false;
            this._sigma = new double[inputCount];
        }

        public sealed override IMLData Compute(IMLData input)
        {
            double num3;
            int num4;
            int num7;
            int num8;
            int num9;
            int num10;
            IMLData data;
            int num11;
            int num12;
            double[] numArray = new double[base.OutputCount];
            double num = 0.0;
            int num2 = -1;
            using (IEnumerator<IMLDataPair> enumerator = this._samples.GetEnumerator())
            {
                IMLDataPair pair;
                double num5;
                int num6;
                goto Label_02AB;
            Label_0293:
                if ((((uint) num6) | 0xff) == 0)
                {
                    goto Label_02CA;
                }
            Label_02AB:
                if (enumerator.MoveNext())
                {
                    goto Label_059A;
                }
                if (base.OutputMode == PNNOutputMode.Classification)
                {
                    num = 0.0;
                    num9 = 0;
                    if ((((uint) num7) | 15) == 0)
                    {
                        return data;
                    }
                    if ((((uint) num3) - ((uint) num2)) < 0)
                    {
                        goto Label_00F5;
                    }
                    goto Label_0139;
                }
                goto Label_004F;
            Label_02BC:
                if (base.OutputMode == PNNOutputMode.Regression)
                {
                    goto Label_0342;
                }
                goto Label_02AB;
            Label_02CA:
                if (num2 != base.Exclude)
                {
                    goto Label_05F3;
                }
                goto Label_02AB;
            Label_02DC:
                numArray[num8] += num3 * pair.Ideal[num8];
                num8++;
            Label_0306:
                if (num8 < base.OutputCount)
                {
                    goto Label_02DC;
                }
                num += num3;
                if (((uint) num9) >= 0)
                {
                    goto Label_0347;
                }
                if ((((uint) num4) | 0x7fffffff) != 0)
                {
                    goto Label_02BC;
                }
            Label_0342:
                num8 = 0;
                goto Label_0306;
            Label_0347:
                if ((((uint) num11) + ((uint) num)) >= 0)
                {
                    goto Label_0293;
                }
                goto Label_02CA;
            Label_0364:
                if ((((uint) num2) + ((uint) num12)) < 0)
                {
                    goto Label_04A2;
                }
                goto Label_02BC;
            Label_0386:
                if (base.OutputMode == PNNOutputMode.Unsupervised)
                {
                    goto Label_03F2;
                }
                goto Label_0364;
            Label_0395:
                if (num7 >= base.InputCount)
                {
                    num += num3;
                    if ((((uint) num3) - ((uint) num5)) > uint.MaxValue)
                    {
                        goto Label_0306;
                    }
                    goto Label_02AB;
                }
                numArray[num7] += num3 * pair.Input[num7];
                num7++;
                goto Label_0395;
            Label_03F2:
                num7 = 0;
                goto Label_0395;
            Label_03F7:
                numArray[num6] += num3;
                goto Label_02AB;
            Label_0412:
                if (base.OutputMode == PNNOutputMode.Classification)
                {
                    goto Label_042F;
                }
                goto Label_0386;
            Label_0422:
                num3 = 1E-40;
                goto Label_0412;
            Label_042F:
                num6 = (int) pair.Ideal[0];
                if ((((uint) num10) | 15) == 0)
                {
                    goto Label_059A;
                }
                goto Label_03F7;
            Label_045B:
                if (num3 >= 1E-40)
                {
                    goto Label_0412;
                }
                if ((((uint) num2) | 0xff) == 0)
                {
                    goto Label_02CA;
                }
                goto Label_0422;
            Label_0485:
                if ((((uint) num7) - ((uint) num8)) > uint.MaxValue)
                {
                    goto Label_0386;
                }
                goto Label_04AD;
            Label_04A2:
                if (base.Kernel == PNNKernelType.Reciprocal)
                {
                    goto Label_04CC;
                }
                goto Label_045B;
            Label_04AD:
                if ((((uint) num11) + ((uint) num)) < 0)
                {
                    goto Label_04A2;
                }
                goto Label_0588;
            Label_04CC:
                num3 = 1.0 / (1.0 + num3);
                goto Label_0485;
            Label_04E9:
                if (base.Kernel == PNNKernelType.Gaussian)
                {
                    goto Label_0519;
                }
                goto Label_04A2;
            Label_04FD:
                num3 += num5 * num5;
                num4++;
            Label_050D:
                if (num4 < base.InputCount)
                {
                    goto Label_054E;
                }
                goto Label_04E9;
            Label_0519:
                num3 = Math.Exp(-num3);
                if ((((uint) num10) & 0) == 0)
                {
                    goto Label_045B;
                }
                if (((uint) num2) >= 0)
                {
                    goto Label_04E9;
                }
            Label_0549:
                num4 = 0;
                goto Label_050D;
            Label_054E:
                num5 = input[num4] - pair.Input[num4];
                num5 /= this._sigma[num4];
                goto Label_04FD;
            Label_0588:
                if (((uint) num3) <= uint.MaxValue)
                {
                    goto Label_0603;
                }
            Label_059A:
                pair = enumerator.Current;
                if ((((uint) num) + ((uint) num11)) > uint.MaxValue)
                {
                    goto Label_04AD;
                }
                num2++;
                if ((((uint) num2) - ((uint) num7)) > uint.MaxValue)
                {
                    goto Label_04FD;
                }
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_02CA;
                }
            Label_05F3:
                num3 = 0.0;
                goto Label_0549;
            Label_0603:
                if (((uint) num12) >= 0)
                {
                    goto Label_045B;
                }
                goto Label_0293;
            }
            if ((((uint) num) - ((uint) num7)) <= uint.MaxValue)
            {
                if (((uint) num4) < 0)
                {
                }
                goto Label_065E;
            }
        Label_0043:
            while (num12 < base.OutputCount)
            {
                numArray[num12] /= num;
                num12++;
            }
            if ((((uint) num8) - ((uint) num11)) >= 0)
            {
                goto Label_0679;
            }
            goto Label_0071;
        Label_004F:
            if (base.OutputMode == PNNOutputMode.Unsupervised)
            {
                num11 = 0;
                while (num11 < base.InputCount)
                {
                    numArray[num11] /= num;
                    num11++;
                }
                goto Label_0679;
            }
            if (base.OutputMode == PNNOutputMode.Regression)
            {
                num12 = 0;
                goto Label_0043;
            }
        Label_0071:
            if ((((uint) num8) + ((uint) num9)) >= 0)
            {
                goto Label_0679;
            }
            goto Label_004F;
        Label_00F5:
            data = new BasicMLData(1);
            goto Label_01C3;
        Label_0139:
            if (num9 < base.OutputCount)
            {
                if (this._priors[num9] < 0.0)
                {
                    goto Label_01BA;
                }
                numArray[num9] *= this._priors[num9] / ((double) this._countPer[num9]);
                goto Label_065E;
            }
            if (((((uint) num3) | uint.MaxValue) == 0) || (num < 1E-40))
            {
                num = 1E-40;
            }
            num10 = 0;
        Label_00EB:
            if (num10 < base.OutputCount)
            {
                numArray[num10] /= num;
                if (((uint) num9) >= 0)
                {
                    if ((((uint) num11) + ((uint) num4)) <= uint.MaxValue)
                    {
                        num10++;
                    }
                    if ((((uint) num4) - ((uint) num12)) <= uint.MaxValue)
                    {
                        goto Label_00EB;
                    }
                    goto Label_01C3;
                }
                goto Label_0139;
            }
            goto Label_00F5;
        Label_01BA:
            num += numArray[num9];
            num9++;
            goto Label_0139;
        Label_01C3:
            if ((((uint) num3) - ((uint) num10)) <= uint.MaxValue)
            {
                data[0] = EngineArray.MaxIndex(numArray);
                return data;
            }
            goto Label_004F;
        Label_065E:
            if ((((uint) num7) - ((uint) num8)) <= uint.MaxValue)
            {
                goto Label_01BA;
            }
        Label_0679:
            return new BasicMLData(numArray);
        }

        public override void UpdateProperties()
        {
        }

        public int[] CountPer
        {
            get
            {
                return this._countPer;
            }
        }

        public double[] Priors
        {
            get
            {
                return this._priors;
            }
        }

        public BasicMLDataSet Samples
        {
            get
            {
                return this._samples;
            }
            set
            {
                int num2;
                this._samples = value;
                if (base.OutputMode != PNNOutputMode.Classification)
                {
                    return;
                }
                this._countPer = new int[base.OutputCount];
                this._priors = new double[base.OutputCount];
                using (IEnumerator<IMLDataPair> enumerator = value.GetEnumerator())
                {
                    int num;
                    goto Label_008B;
                Label_0072:
                    this._countPer[num]++;
                Label_008B:
                    if (!enumerator.MoveNext())
                    {
                        if ((((uint) num) - ((uint) num2)) > uint.MaxValue)
                        {
                            goto Label_008B;
                        }
                        if ((((uint) num) & 0) == 0)
                        {
                            goto Label_00F6;
                        }
                    }
                    IMLDataPair current = enumerator.Current;
                    num = (int) current.Ideal[0];
                    if (num >= this._countPer.Length)
                    {
                        throw new NeuralNetworkError("Training data contains more classes than neural network has output neurons to hold.");
                    }
                    goto Label_0072;
                }
                if (0 == 0)
                {
                    goto Label_00F6;
                }
            Label_000B:
                this._priors[num2] = -1.0;
                num2++;
            Label_0020:
                if (num2 < this._priors.Length)
                {
                    goto Label_000B;
                }
                return;
            Label_00F6:
                num2 = 0;
                goto Label_0020;
            }
        }

        public double[] Sigma
        {
            get
            {
                return this._sigma;
            }
        }
    }
}

