namespace Encog.App.Quant.Indicators
{
    using System;
    using System.Collections.Generic;

    public class MovingAverage : Indicator
    {
        public const string NAME = "MovAvg";
        private readonly int x422628dd283c8725;

        public MovingAverage(int thePeriods, bool output) : base("MovAvg", false, output)
        {
            this.x422628dd283c8725 = thePeriods;
            base.Output = output;
        }

        public sealed override void Calculate(IDictionary<string, BaseCachedColumn> data, int length)
        {
            double[] numArray;
            double[] numArray2;
            int num;
            double num3;
            int num4;
            int num5;
            int num6;
            double num7;
            base.Require(data, "close");
            goto Label_0128;
        Label_0042:
            num3 -= numArray[num4++];
            numArray2[num6++] = num7 / ((double) this.x422628dd283c8725);
            if (0 == 0)
            {
                if (num5 < numArray.Length)
                {
                    goto Label_009E;
                }
                if (((uint) num4) > uint.MaxValue)
                {
                    goto Label_00AC;
                }
                base.BeginningIndex = this.x422628dd283c8725 - 1;
                base.EndingIndex = numArray2.Length - 1;
                num5 = 0;
            }
            while (num5 < (this.x422628dd283c8725 - 1))
            {
                numArray2[num5] = 0.0;
                num5++;
            }
            if ((((uint) num) & 0) == 0)
            {
                return;
            }
            goto Label_0128;
        Label_009E:
            num3 += numArray[num5++];
        Label_00AC:
            num7 = num3;
            goto Label_0042;
        Label_0128:
            numArray = data["close"].Data;
            numArray2 = base.Data;
            num = this.x422628dd283c8725 - 1;
            if (((uint) num) < 0)
            {
                return;
            }
            int num2 = num;
            if (num2 > (this.x422628dd283c8725 - 1))
            {
                if ((((uint) length) & 0) == 0)
                {
                    return;
                }
                goto Label_0042;
            }
            num3 = 0.0;
            num4 = num2 - num;
            num5 = num4;
            if (this.x422628dd283c8725 > 1)
            {
                while (num5 < num2)
                {
                    num3 += numArray[num5++];
                }
            }
            num6 = this.x422628dd283c8725 - 1;
            goto Label_009E;
        }

        public override int Periods
        {
            get
            {
                return this.x422628dd283c8725;
            }
        }
    }
}

