namespace Encog.MathUtil.Randomize
{
    using System;

    public class GaussianRandomizer : BasicRandomizer
    {
        private readonly double _x0eb49ee242305597;
        private bool _x2df72d022f38625d = false;
        private readonly double _x8db8a12c7e795fea;
        private double _x9b9be9a08b5115a8;

        public GaussianRandomizer(double mean, double standardDeviation)
        {
            this._x0eb49ee242305597 = mean;
            this._x8db8a12c7e795fea = standardDeviation;
        }

        public double BoxMuller(double m, double s)
        {
            double num;
            double num3;
            double num4;
            if (!this._x2df72d022f38625d)
            {
                double num2;
                do
                {
                    num2 = (2.0 * base.NextDouble()) - 1.0;
                    num3 = (2.0 * base.NextDouble()) - 1.0;
                    num4 = (num2 * num2) + (num3 * num3);
                }
                while (num4 >= 1.0);
                num4 = Math.Sqrt((-2.0 * Math.Log(num4)) / num4);
                num = num2 * num4;
                if (((uint) num2) <= uint.MaxValue)
                {
                    if (((uint) m) <= uint.MaxValue)
                    {
                        goto Label_001D;
                    }
                }
                else
                {
                    goto Label_008C;
                }
                goto Label_00FE;
            }
            if (((uint) num3) >= 0)
            {
                goto Label_008C;
            }
        Label_001D:
            this._x9b9be9a08b5115a8 = num3 * num4;
            if ((((uint) num) + ((uint) num4)) < 0)
            {
                goto Label_001D;
            }
            this._x2df72d022f38625d = true;
            goto Label_00FE;
        Label_008C:
            if (((uint) num) <= uint.MaxValue)
            {
                num = this._x9b9be9a08b5115a8;
            }
            this._x2df72d022f38625d = false;
        Label_00FE:
            return (m + (num * s));
        }

        public override double Randomize(double d)
        {
            return this.BoxMuller(this._x0eb49ee242305597, this._x8db8a12c7e795fea);
        }
    }
}

