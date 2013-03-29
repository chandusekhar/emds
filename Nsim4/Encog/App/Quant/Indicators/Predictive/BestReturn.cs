namespace Encog.App.Quant.Indicators.Predictive
{
    using Encog.App.Quant.Indicators;
    using System;
    using System.Collections.Generic;

    public class BestReturn : Indicator
    {
        public const string NAME = "PredictBestReturn";
        private readonly int x422628dd283c8725;

        public BestReturn(int thePeriods, bool output) : base("PredictBestReturn", false, output)
        {
            this.x422628dd283c8725 = thePeriods;
            base.Output = output;
        }

        public sealed override void Calculate(IDictionary<string, BaseCachedColumn> data, int length)
        {
            double[] numArray2;
            int num;
            int num2;
            double minValue;
            double num4;
            int num5;
            double num6;
            double num7;
            int num8;
            double[] numArray = data["close"].Data;
            if ((((uint) num6) + ((uint) num8)) <= uint.MaxValue)
            {
                numArray2 = base.Data;
                goto Label_016D;
            }
            goto Label_00B7;
        Label_004F:
            if (num2 < num)
            {
                minValue = double.MinValue;
                goto Label_010D;
            }
            num8 = length - this.x422628dd283c8725;
        Label_0031:
            if (num8 < length)
            {
                numArray2[num8] = 0.0;
                num8++;
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_00C2;
                }
                if (0 == 0)
                {
                    goto Label_0031;
                }
            }
            else
            {
                base.BeginningIndex = 0;
                base.EndingIndex = (length - this.x422628dd283c8725) - 1;
            }
            if (0xff != 0)
            {
                return;
            }
        Label_00B7:
            minValue = Math.Max(num7, minValue);
        Label_00C2:
            if ((((uint) num4) & 0) != 0)
            {
                return;
            }
        Label_00D9:
            num5++;
        Label_00DF:
            if (num5 <= this.x422628dd283c8725)
            {
                num6 = numArray[num2 + num5];
                num7 = (num6 - num4) / num4;
                if ((((uint) length) - ((uint) num2)) >= 0)
                {
                    if ((((uint) num5) + ((uint) num5)) > uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_00B7;
                }
                goto Label_016D;
            }
            if ((((uint) num7) + ((uint) num4)) <= uint.MaxValue)
            {
                numArray2[num2] = minValue;
                num2++;
                if ((((uint) length) - ((uint) num7)) <= uint.MaxValue)
                {
                    goto Label_004F;
                }
                goto Label_00B7;
            }
        Label_010D:
            if ((((uint) length) | 3) == 0)
            {
                goto Label_00D9;
            }
            num4 = numArray[num2];
            num5 = 1;
            goto Label_00DF;
        Label_016D:
            num = length - this.x422628dd283c8725;
            num2 = 0;
            goto Label_004F;
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

