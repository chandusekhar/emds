namespace Encog.Neural.ART
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Specific;
    using Encog.Neural;
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class ART1 : BasicART, IMLMethod, IMLInputOutput, IMLInput, IMLOutput, IMLResettable, IMLClassification
    {
        private double _a1;
        private double _b1;
        private double _c1;
        private double _d1;
        private int _f1Count;
        private int _f2Count;
        [NonSerialized]
        private bool[] _inhibitF2;
        private double _l;
        private int _noWinner;
        private BiPolarMLData _outputF1;
        private BiPolarMLData _outputF2;
        private double _vigilance;
        private Matrix _weightsF1ToF2;
        private Matrix _weightsF2ToF1;

        public ART1()
        {
            if (-2147483648 != 0)
            {
                this._a1 = 1.0;
                this._b1 = 1.5;
                this._c1 = 5.0;
                if (2 == 0)
                {
                    goto Label_001C;
                }
                this._d1 = 0.9;
            }
            this._l = 3.0;
        Label_001C:
            this._vigilance = 0.9;
        }

        public ART1(int theF1Count, int theF2Count)
        {
            if ((((uint) theF2Count) + ((uint) theF2Count)) <= uint.MaxValue)
            {
                goto Label_00FE;
            }
            goto Label_00F2;
        Label_0026:
            this.Reset();
            if (-2 != 0)
            {
                if (0 == 0)
                {
                    return;
                }
                goto Label_00FE;
            }
            goto Label_00F2;
        Label_0031:
            this._noWinner = this._f2Count;
            if (((uint) theF1Count) <= uint.MaxValue)
            {
                goto Label_0026;
            }
            goto Label_00D2;
        Label_0071:
            this._weightsF2ToF1 = new Matrix(this._f2Count, this._f1Count);
            this._inhibitF2 = new bool[this._f2Count];
            this._outputF1 = new BiPolarMLData(this._f1Count);
            this._outputF2 = new BiPolarMLData(this._f2Count);
            goto Label_0031;
        Label_00D2:
            if (0 != 0)
            {
                goto Label_0071;
            }
            if (0 == 0)
            {
                this._weightsF1ToF2 = new Matrix(this._f1Count, this._f2Count);
                if ((((uint) theF1Count) | 0xff) == 0)
                {
                    goto Label_0031;
                }
                goto Label_0071;
            }
            goto Label_0026;
        Label_00F2:
            this._f1Count = theF1Count;
            this._f2Count = theF2Count;
            goto Label_00D2;
        Label_00FE:
            this._a1 = 1.0;
            this._b1 = 1.5;
            this._c1 = 5.0;
            this._d1 = 0.9;
            this._l = 3.0;
            this._vigilance = 0.9;
            goto Label_00F2;
        }

        public void AdjustWeights()
        {
            double num2;
            int i = 0;
            goto Label_0028;
        Label_0024:
            i++;
        Label_0028:
            if (i < this._f1Count)
            {
                if (this._outputF1.GetBoolean(i))
                {
                    num2 = this.Magnitude(this._outputF1);
                    this._weightsF1ToF2[i, this.Winner] = 1.0;
                    if ((((uint) i) & 0) == 0)
                    {
                        this._weightsF2ToF1[this.Winner, i] = this._l / ((this._l - 1.0) + num2);
                        goto Label_0024;
                    }
                }
                this._weightsF1ToF2[i, this.Winner] = 0.0;
                this._weightsF2ToF1[this.Winner, i] = 0.0;
                if (0 == 0)
                {
                    goto Label_0024;
                }
            }
            if ((((uint) num2) - ((uint) num2)) >= 0)
            {
                return;
            }
            goto Label_0024;
        }

        public int Classify(IMLData input)
        {
            int num;
            BiPolarMLData data = new BiPolarMLData(this._f1Count);
            BiPolarMLData output = new BiPolarMLData(this._f2Count);
            if (input.Count != data.Count)
            {
                throw new NeuralNetworkError("Input array size does not match.");
            }
            goto Label_0022;
        Label_0013:
            return -1;
        Label_0022:
            num = 0;
            while (num < data.Count)
            {
                data.SetBoolean(num, input[num] > 0.0);
                num++;
            }
            this.Compute(data, output);
            if (!this.HasWinner)
            {
                goto Label_0013;
            }
            return this.Winner;
            if (-1 == 0)
            {
                goto Label_0013;
            }
            goto Label_0022;
        }

        public IMLData Compute(IMLData input)
        {
            if (!(input is BiPolarMLData))
            {
                throw new NeuralNetworkError("Input to ART1 logic network must be BiPolarNeuralData.");
            }
            BiPolarMLData output = new BiPolarMLData(this._f1Count);
            this.Compute((BiPolarMLData) input, output);
            return output;
        }

        public void Compute(BiPolarMLData input, BiPolarMLData output)
        {
            bool flag;
            bool flag2;
            double num2;
            double num3;
            int index = 0;
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_016D;
            }
            if ((((uint) index) + ((uint) flag)) >= 0)
            {
                goto Label_009E;
            }
        Label_0040:
            if (!flag)
            {
                if (!flag2)
                {
                    goto Label_012B;
                }
            }
            else if ((((uint) num2) - ((uint) index)) < 0)
            {
                goto Label_016D;
            }
            if (flag)
            {
                this.AdjustWeights();
                if ((((uint) num3) & 0) == 0)
                {
                    return;
                }
            }
            else
            {
                if ((((uint) num2) | 0x7fffffff) != 0)
                {
                    return;
                }
                goto Label_009E;
            }
            goto Label_0040;
        Label_009E:
            if ((num3 / num2) < this._vigilance)
            {
                this._inhibitF2[this.Winner] = true;
            }
            else
            {
                flag = true;
            }
            goto Label_0040;
        Label_012B:
            this.Input = input;
            this.ComputeF2();
            this.GetOutput(output);
            if (this.Winner != this._noWinner)
            {
                this.ComputeF1(input);
            }
            else
            {
                flag2 = true;
                goto Label_0040;
            }
            if ((((uint) num2) | uint.MaxValue) == 0)
            {
                goto Label_0197;
            }
            if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num2) - ((uint) flag2)) < 0)
                {
                    goto Label_018A;
                }
                num2 = this.Magnitude(input);
                num3 = this.Magnitude(this._outputF1);
                goto Label_009E;
            }
        Label_016D:
            if ((((uint) index) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_0040;
            }
            goto Label_0197;
        Label_018A:
            this._inhibitF2[index] = false;
            index++;
        Label_0197:
            if (index < this._f2Count)
            {
                goto Label_018A;
            }
            flag = false;
            flag2 = false;
            goto Label_012B;
        }

        private void ComputeF1(BiPolarMLData input)
        {
            int i = 0;
            if ((((uint) i) - ((uint) i)) >= 0)
            {
                goto Label_001E;
            }
        Label_001A:
            i++;
        Label_001E:
            if (i >= this._f1Count)
            {
                return;
            }
            double num2 = this._weightsF1ToF2[i, this.Winner] * (this._outputF2.GetBoolean(this.Winner) ? ((double) 1) : ((double) 0));
            double num3 = (((input.GetBoolean(i) ? ((double) 1) : ((double) 0)) + (this._d1 * num2)) - this._b1) / ((1.0 + (this._a1 * ((input.GetBoolean(i) ? ((double) 1) : ((double) 0)) + (this._d1 * num2)))) + this._c1);
            if ((((uint) num2) - ((uint) i)) > uint.MaxValue)
            {
                goto Label_001E;
            }
            this._outputF1.SetBoolean(i, num3 > 0.0);
            goto Label_001A;
        }

        private void ComputeF2()
        {
            int num;
            double num3;
            int num4;
            double negativeInfinity = double.NegativeInfinity;
            if ((((uint) num4) + ((uint) num3)) <= uint.MaxValue)
            {
                this.Winner = this._noWinner;
                if (((uint) negativeInfinity) > uint.MaxValue)
                {
                    goto Label_00D7;
                }
                num = 0;
            }
            else
            {
                goto Label_00B3;
            }
        Label_002E:
            if (num < this._f2Count)
            {
                if (this._inhibitF2[num])
                {
                    goto Label_00A4;
                }
                num3 = 0.0;
                num4 = 0;
                goto Label_0076;
            }
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00B3;
            }
            if (this.Winner == this._noWinner)
            {
                return;
            }
        Label_005F:
            this._outputF2.SetBoolean(this.Winner, true);
            return;
        Label_0076:
            if (num4 < this._f1Count)
            {
                goto Label_00B3;
            }
            if (num3 > negativeInfinity)
            {
                negativeInfinity = num3;
                this.Winner = num;
                if ((((uint) num3) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_005F;
                }
            }
        Label_00A4:
            this._outputF2.SetBoolean(num, false);
            num++;
            goto Label_002E;
        Label_00B3:
            num3 += this._weightsF2ToF1[num, num4] * (this._outputF1.GetBoolean(num4) ? ((double) 1) : ((double) 0));
        Label_00D7:
            num4++;
            goto Label_0076;
        }

        private void GetOutput(BiPolarMLData output)
        {
            for (int i = 0; i < this._f2Count; i++)
            {
                output.SetBoolean(i, this._outputF2.GetBoolean(i));
            }
        }

        public double Magnitude(BiPolarMLData input)
        {
            double num = 0.0;
            int i = 0;
            while (i < this._f1Count)
            {
                num += input.GetBoolean(i) ? ((double) 1) : ((double) 0);
                i++;
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                }
            }
            return num;
        }

        public void Reset()
        {
            this.Reset(0);
        }

        public void Reset(int seed)
        {
            int num = 0;
            while (num < this._f1Count)
            {
                do
                {
                    for (int i = 0; i < this._f2Count; i++)
                    {
                        this._weightsF1ToF2[num, i] = ((this._b1 - 1.0) / this._d1) + 0.2;
                        this._weightsF2ToF1[i, num] = (this._l / ((this._l - 1.0) + this._f1Count)) - 0.1;
                    }
                    num++;
                }
                while (-2147483648 == 0);
            }
        }

        public double A1
        {
            get
            {
                return this._a1;
            }
            set
            {
                this._a1 = value;
            }
        }

        public double B1
        {
            get
            {
                return this._b1;
            }
            set
            {
                this._b1 = value;
            }
        }

        public double C1
        {
            get
            {
                return this._c1;
            }
            set
            {
                this._c1 = value;
            }
        }

        public double D1
        {
            get
            {
                return this._d1;
            }
            set
            {
                this._d1 = value;
            }
        }

        public int F1Count
        {
            get
            {
                return this._f1Count;
            }
            set
            {
                this._f1Count = value;
                this._outputF1 = new BiPolarMLData(this._f1Count);
            }
        }

        public int F2Count
        {
            get
            {
                return this._f2Count;
            }
            set
            {
                this._f2Count = value;
                this._inhibitF2 = new bool[this._f2Count];
                this._outputF2 = new BiPolarMLData(this._f2Count);
            }
        }

        public bool HasWinner
        {
            get
            {
                return (this.Winner != this._noWinner);
            }
        }

        private BiPolarMLData Input
        {
            set
            {
                double num2;
                int i = 0;
                if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
                {
                }
                while (i < this._f1Count)
                {
                    num2 = (value.GetBoolean(i) ? ((double) 1) : ((double) 0)) / ((1.0 + (this._a1 * ((value.GetBoolean(i) ? ((double) 1) : ((double) 0)) + this._b1))) + this._c1);
                    this._outputF1.SetBoolean(i, num2 > 0.0);
                    if ((((uint) num2) | 3) != 0)
                    {
                        i++;
                    }
                }
            }
        }

        public int InputCount
        {
            get
            {
                return this._f1Count;
            }
        }

        public double L
        {
            get
            {
                return this._l;
            }
            set
            {
                this._l = value;
            }
        }

        public int NoWinner
        {
            get
            {
                return this._noWinner;
            }
            set
            {
                this._noWinner = value;
            }
        }

        public int OutputCount
        {
            get
            {
                return this._f2Count;
            }
        }

        public double Vigilance
        {
            get
            {
                return this._vigilance;
            }
            set
            {
                this._vigilance = value;
            }
        }

        public Matrix WeightsF1ToF2
        {
            get
            {
                return this._weightsF1ToF2;
            }
            set
            {
                this._weightsF1ToF2 = value;
            }
        }

        public Matrix WeightsF2ToF1
        {
            get
            {
                return this._weightsF2ToF1;
            }
            set
            {
                this._weightsF2ToF1 = value;
            }
        }

        public int Winner { get; private set; }
    }
}

