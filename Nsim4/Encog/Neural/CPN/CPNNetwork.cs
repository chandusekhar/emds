namespace Encog.Neural.CPN
{
    using Encog.MathUtil.Matrices;
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util.Simple;
    using System;

    [Serializable]
    public class CPNNetwork : BasicML, IMLMethod, IMLRegression, IMLInputOutput, IMLInput, IMLOutput, IMLResettable, IMLError
    {
        private readonly int _inputCount;
        private readonly int _instarCount;
        private readonly int _outstarCount;
        private readonly Matrix _weightsInputToInstar;
        private readonly Matrix _weightsInstarToOutstar;
        private readonly int _winnerCount;

        public CPNNetwork(int theInputCount, int theInstarCount, int theOutstarCount, int theWinnerCount)
        {
        Label_0057:
            this._inputCount = theInputCount;
        Label_005E:
            this._instarCount = theInstarCount;
            this._outstarCount = theOutstarCount;
            this._weightsInputToInstar = new Matrix(this._inputCount, this._instarCount);
            if (0 == 0)
            {
                this._weightsInstarToOutstar = new Matrix(this._instarCount, this._outstarCount);
                if ((((uint) theInputCount) - ((uint) theWinnerCount)) > uint.MaxValue)
                {
                    goto Label_005E;
                }
                this._winnerCount = theWinnerCount;
                if ((((uint) theWinnerCount) - ((uint) theOutstarCount)) > uint.MaxValue)
                {
                    goto Label_0057;
                }
            }
        }

        public double CalculateError(IMLDataSet data)
        {
            return EncogUtility.CalculateRegressionError(this, data);
        }

        public IMLData Compute(IMLData input)
        {
            IMLData data = this.ComputeInstar(input);
            return this.ComputeOutstar(data);
        }

        public IMLData ComputeInstar(IMLData input)
        {
            int num;
            double num4;
            int num5;
            double num6;
            double minValue;
            IMLData data = new BasicMLData(this._instarCount);
            int index = 0;
            bool[] flagArray = new bool[this._instarCount];
            int num2 = 0;
            goto Label_018A;
        Label_0011:
            if (num2 < this._instarCount)
            {
                goto Label_0033;
            }
            return data;
        Label_001C:
            data.Data[num2] = 0.0;
        Label_002D:
            num2++;
            goto Label_0011;
        Label_0033:
            if (!flagArray[num2])
            {
                goto Label_001C;
            }
        Label_0039:
            if (((((uint) num2) + ((uint) num4)) <= uint.MaxValue) && (Math.Abs(num6) <= 1E-07))
            {
                goto Label_001C;
            }
            data.Data[num2] /= num6;
            goto Label_002D;
        Label_00AE:
            if (num < this._winnerCount)
            {
                minValue = double.MinValue;
                if ((((uint) num4) + ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_01F6;
                }
                num2 = 0;
                goto Label_00C6;
            }
            if ((((uint) num4) + ((uint) num)) <= uint.MaxValue)
            {
                num2 = 0;
                goto Label_0011;
            }
            goto Label_0033;
        Label_00BC:
            if (!flagArray[num2])
            {
                goto Label_010B;
            }
        Label_00C2:
            num2++;
        Label_00C6:
            if (num2 < this._instarCount)
            {
                goto Label_00BC;
            }
            flagArray[index] = true;
            if (0xff == 0)
            {
                goto Label_0039;
            }
            num6 += data[index];
            if ((((uint) index) - ((uint) minValue)) > uint.MaxValue)
            {
                goto Label_0039;
            }
            num++;
            goto Label_00AE;
        Label_010B:
            if (data[num2] > minValue)
            {
                index = num2;
                minValue = data[index];
            }
            goto Label_00C2;
        Label_0125:
            num6 = 0.0;
            num = 0;
            goto Label_00AE;
        Label_018A:
            if (num2 < this._instarCount)
            {
                num4 = 0.0;
                if ((((uint) index) + ((uint) num)) >= 0)
                {
                    goto Label_01F6;
                }
            }
            else
            {
                if ((((uint) num) + ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_001C;
                }
                goto Label_0125;
            }
        Label_01B3:
            while (num5 < this._inputCount)
            {
                num4 += this._weightsInputToInstar[num5, num2] * input[num5];
                num5++;
            }
            if (((uint) index) >= 0)
            {
                data[num2] = num4;
                flagArray[num2] = false;
                if ((((uint) num4) & 0) != 0)
                {
                    if ((((uint) minValue) | 4) != 0)
                    {
                        goto Label_00BC;
                    }
                    goto Label_010B;
                }
                num2++;
                goto Label_018A;
            }
            goto Label_0125;
        Label_01F6:
            num5 = 0;
            goto Label_01B3;
        }

        public IMLData ComputeOutstar(IMLData input)
        {
            int num;
            double num2;
            int num3;
            IMLData data = new BasicMLData(this._outstarCount);
            goto Label_0099;
        Label_0030:
            if (num < this._outstarCount)
            {
                num2 = 0.0;
                num3 = 0;
            }
            else
            {
                if ((((uint) num) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0074;
                }
                return data;
            }
        Label_0053:
            if (num3 >= this._instarCount)
            {
                data[num] = num2;
                num++;
                if ((((uint) num2) | uint.MaxValue) == 0)
                {
                    goto Label_0099;
                }
                goto Label_0030;
            }
        Label_0074:
            num2 += this._weightsInstarToOutstar[num3, num] * input[num3];
            num3++;
            goto Label_0053;
        Label_0099:
            num = 0;
            goto Label_0030;
        }

        public void Reset()
        {
            this.Reset(0);
        }

        public void Reset(int seed)
        {
            ConsistentRandomizer randomizer = new ConsistentRandomizer(-1.0, 1.0, seed);
            randomizer.Randomize(this._weightsInputToInstar);
            randomizer.Randomize(this._weightsInstarToOutstar);
        }

        public override void UpdateProperties()
        {
        }

        public int InputCount
        {
            get
            {
                return this._inputCount;
            }
        }

        public int InstarCount
        {
            get
            {
                return this._instarCount;
            }
        }

        public int OutputCount
        {
            get
            {
                return this._outstarCount;
            }
        }

        public int OutstarCount
        {
            get
            {
                return this._outstarCount;
            }
        }

        public Matrix WeightsInputToInstar
        {
            get
            {
                return this._weightsInputToInstar;
            }
        }

        public Matrix WeightsInstarToOutstar
        {
            get
            {
                return this._weightsInstarToOutstar;
            }
        }

        public int WinnerCount
        {
            get
            {
                return this._winnerCount;
            }
        }
    }
}

