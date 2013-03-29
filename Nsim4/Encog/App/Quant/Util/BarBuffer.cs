namespace Encog.App.Quant.Util
{
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class BarBuffer
    {
        private readonly int x422628dd283c8725;
        private readonly IList<double[]> x4a3f0a05c02f235f = new List<double[]>();

        public BarBuffer(int thePeriods)
        {
            this.x422628dd283c8725 = thePeriods;
        }

        public void Add(double d)
        {
            double[] numArray = new double[] { d };
            this.Add(numArray);
        }

        public void Add(double[] d)
        {
            this.x4a3f0a05c02f235f.Insert(0, EngineArray.ArrayCopy(d));
            while (this.x4a3f0a05c02f235f.Count > this.x422628dd283c8725)
            {
                this.x4a3f0a05c02f235f.RemoveAt(this.x4a3f0a05c02f235f.Count - 1);
                break;
            }
        }

        public double Average(int idx)
        {
            int num2;
            double num = 0.0;
            if ((((uint) num) | 0x7fffffff) != 0)
            {
                num2 = 0;
            }
            while (num2 < this.x4a3f0a05c02f235f.Count)
            {
                double[] numArray = this.x4a3f0a05c02f235f[num2];
                num += numArray[idx];
                num2++;
            }
            return (num / ((double) this.x4a3f0a05c02f235f.Count));
        }

        public double AverageGain(int idx)
        {
            int num2;
            int num3;
            double[] numArray;
            double num = 0.0;
            goto Label_0088;
        Label_0025:
            if (num3 < (this.x4a3f0a05c02f235f.Count - 1))
            {
                goto Label_008E;
            }
            if (num2 != 0)
            {
                return (num / ((double) num2));
            }
            if (((uint) num) < 0)
            {
                goto Label_008E;
            }
            return 0.0;
        Label_0088:
            num2 = 0;
            num3 = 0;
            goto Label_0025;
        Label_008E:
            numArray = this.x4a3f0a05c02f235f[num3];
            double[] numArray2 = this.x4a3f0a05c02f235f[num3 + 1];
            double num4 = numArray[idx] - numArray2[idx];
            if (num4 > 0.0)
            {
                num += num4;
            }
            num2++;
            num3++;
            if (((uint) num3) <= uint.MaxValue)
            {
                goto Label_0025;
            }
            goto Label_0088;
        }

        public double AverageLoss(int idx)
        {
            int num2;
            int num3;
            double num4;
            double num = 0.0;
            if ((((uint) num) + ((uint) num4)) >= 0)
            {
                goto Label_00EF;
            }
            goto Label_0038;
        Label_0029:
            return 0.0;
        Label_0038:
            num3++;
            if ((((uint) num) - ((uint) idx)) > uint.MaxValue)
            {
                goto Label_0029;
            }
        Label_0054:
            if (num3 < (this.x4a3f0a05c02f235f.Count - 1))
            {
                double[] numArray = this.x4a3f0a05c02f235f[num3];
                double[] numArray2 = this.x4a3f0a05c02f235f[num3 + 1];
                num4 = numArray[idx] - numArray2[idx];
                if (((uint) num2) >= 0)
                {
                }
                if (num4 < 0.0)
                {
                    num += Math.Abs(num4);
                }
            }
            else
            {
                if (num2 == 0)
                {
                    goto Label_0029;
                }
                if ((((uint) idx) - ((uint) idx)) >= 0)
                {
                    return (num / ((double) num2));
                }
                goto Label_00EF;
            }
            num2++;
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_0038;
            }
        Label_00EF:
            num2 = 0;
            num3 = 0;
            goto Label_0054;
        }

        public double Max(int idx)
        {
            double minValue = double.MinValue;
            foreach (double[] numArray in this.x4a3f0a05c02f235f)
            {
                minValue = Math.Max(numArray[idx], minValue);
            }
            return minValue;
        }

        public double Min(int idx)
        {
            double maxValue = double.MaxValue;
            foreach (double[] numArray in this.x4a3f0a05c02f235f)
            {
                maxValue = Math.Min(numArray[idx], maxValue);
            }
            return maxValue;
        }

        public double[] Pop()
        {
            if (this.x4a3f0a05c02f235f.Count == 0)
            {
                return null;
            }
            int index = this.x4a3f0a05c02f235f.Count - 1;
            double[] numArray = this.x4a3f0a05c02f235f[index];
            this.x4a3f0a05c02f235f.RemoveAt(index);
            return numArray;
        }

        public IList<double[]> Data
        {
            get
            {
                return this.x4a3f0a05c02f235f;
            }
        }

        public bool Full
        {
            get
            {
                return (this.x4a3f0a05c02f235f.Count >= this.x422628dd283c8725);
            }
        }
    }
}

