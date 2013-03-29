namespace Encog.MathUtil
{
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class NumericRange
    {
        private readonly double _x0eb49ee242305597;
        private readonly double _x628ea9b89457a2a9;
        private readonly double _x8db8a12c7e795fea;
        private readonly double _xcce91100698a4514;
        private readonly double _xd12d1dba8a023d95;
        private readonly int _xdc8f3f8857bee4c6;

        public NumericRange(IList<double> values)
        {
            double num3;
            double num4;
            double current;
            Func<double, double> selector = null;
            double num = 0.0;
            double num2 = 0.0;
            goto Label_016A;
        Label_00F1:
            using (IEnumerator<double> enumerator = values.GetEnumerator())
            {
                goto Label_011B;
            Label_00FB:
                if ((((uint) current) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0142;
                }
                num4 += current * current;
            Label_011B:
                if (!enumerator.MoveNext())
                {
                    goto Label_0157;
                }
                current = enumerator.Current;
                num = Math.Max(num, current);
                num2 = Math.Min(num2, current);
            Label_0142:
                num3 += current;
                goto Label_00FB;
            }
        Label_0157:
            this._xdc8f3f8857bee4c6 = values.Count;
            this._x628ea9b89457a2a9 = num;
            this._xd12d1dba8a023d95 = num2;
            this._x0eb49ee242305597 = num3 / ((double) this._xdc8f3f8857bee4c6);
            this._xcce91100698a4514 = Math.Sqrt(num4 / ((double) this._xdc8f3f8857bee4c6));
            if (((((uint) num2) & 0) != 0) || ((((uint) num2) + ((uint) current)) >= 0))
            {
                if (selector == null)
                {
                    selector = new Func<double, double>(this, (IntPtr) this.xf29670e286f5562f);
                }
                double num6 = values.Sum<double>(selector);
                this._x8db8a12c7e795fea = Math.Sqrt(num6 / ((double) this._xdc8f3f8857bee4c6));
                if ((((uint) current) + ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_00F1;
                }
                if ((((uint) num6) - ((uint) current)) <= uint.MaxValue)
                {
                    return;
                }
            }
        Label_016A:
            num3 = 0.0;
            num4 = 0.0;
            goto Label_00F1;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Range: ");
            if (0 == 0)
            {
                builder.Append(Format.FormatDouble(this._xd12d1dba8a023d95, 5));
                builder.Append(" to ");
                builder.Append(Format.FormatDouble(this._x628ea9b89457a2a9, 5));
                builder.Append(",samples: ");
                builder.Append(Format.FormatInteger(this._xdc8f3f8857bee4c6));
            }
            builder.Append(",mean: ");
            builder.Append(Format.FormatDouble(this._x0eb49ee242305597, 5));
            builder.Append(",rms: ");
            builder.Append(Format.FormatDouble(this._xcce91100698a4514, 5));
            do
            {
                builder.Append(",s.deviation: ");
                builder.Append(Format.FormatDouble(this._x8db8a12c7e795fea, 5));
            }
            while (0xff == 0);
            return builder.ToString();
        }

        [CompilerGenerated]
        private double xf29670e286f5562f(double x73f821c71fe1e676)
        {
            return Math.Pow(x73f821c71fe1e676 - this._x0eb49ee242305597, 2.0);
        }

        public double High
        {
            get
            {
                return this._x628ea9b89457a2a9;
            }
        }

        public double Low
        {
            get
            {
                return this._xd12d1dba8a023d95;
            }
        }

        public double Mean
        {
            get
            {
                return this._x0eb49ee242305597;
            }
        }

        public double RMS
        {
            get
            {
                return this._xcce91100698a4514;
            }
        }

        public int Samples
        {
            get
            {
                return this._xdc8f3f8857bee4c6;
            }
        }

        public double StandardDeviation
        {
            get
            {
                return this._x8db8a12c7e795fea;
            }
        }
    }
}

