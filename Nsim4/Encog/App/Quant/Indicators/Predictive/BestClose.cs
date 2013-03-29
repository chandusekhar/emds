namespace Encog.App.Quant.Indicators.Predictive
{
    using Encog.App.Quant.Indicators;
    using System;
    using System.Collections.Generic;

    public class BestClose : Indicator
    {
        public const string NAME = "PredictBestClose";
        private readonly int x422628dd283c8725;

        public BestClose(int thePeriods, bool output) : base("PredictBestClose", false, output)
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
            int num4;
            int num5;
            double[] numArray = data["close"].Data;
            goto Label_011D;
        Label_0016:
            if (num5 >= length)
            {
                base.BeginningIndex = 0;
                base.EndingIndex = (length - this.x422628dd283c8725) - 1;
                if (((uint) num2) >= 0)
                {
                    if (((uint) length) >= 0)
                    {
                        if (((uint) minValue) >= 0)
                        {
                            return;
                        }
                        goto Label_011D;
                    }
                    goto Label_00D6;
                }
                goto Label_0092;
            }
            numArray2[num5] = 0.0;
            num5++;
            goto Label_0016;
        Label_007C:
            if (num2 < num)
            {
                minValue = double.MinValue;
                num4 = 1;
                goto Label_00A7;
            }
            num5 = length - this.x422628dd283c8725;
            if (0 != 0)
            {
            }
            goto Label_0016;
        Label_0092:
            minValue = Math.Max(numArray[num2 + num4], minValue);
            num4++;
        Label_00A7:
            if (num4 <= this.x422628dd283c8725)
            {
                goto Label_0092;
            }
            numArray2[num2] = minValue;
            num2++;
            if ((((uint) num4) | uint.MaxValue) != 0)
            {
            }
            goto Label_007C;
        Label_00D6:
            if ((((uint) num5) - ((uint) num5)) <= uint.MaxValue)
            {
                num = length - this.x422628dd283c8725;
                num2 = 0;
            }
            goto Label_007C;
        Label_011D:
            numArray2 = base.Data;
            if ((((uint) length) + ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0016;
            }
            goto Label_00D6;
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

