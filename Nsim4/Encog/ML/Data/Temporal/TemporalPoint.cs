namespace Encog.ML.Data.Temporal
{
    using System;
    using System.Reflection;
    using System.Text;

    public class TemporalPoint : IComparable<TemporalPoint>
    {
        private int _x2868ae090935eb96;
        private double[] _x4a3f0a05c02f235f;

        public TemporalPoint(int size)
        {
            this._x4a3f0a05c02f235f = new double[size];
        }

        public int CompareTo(TemporalPoint that)
        {
            if (this.Sequence == that.Sequence)
            {
                return 0;
            }
            if (this.Sequence < that.Sequence)
            {
                return -1;
            }
            return 1;
        }

        public override string ToString()
        {
            int num;
            StringBuilder builder = new StringBuilder("[TemporalPoint:");
            builder.Append("Seq:");
            builder.Append(this._x2868ae090935eb96);
            if (15 != 0)
            {
                builder.Append(",Data:");
                num = 0;
            }
            goto Label_0043;
        Label_0027:
            builder.Append(',');
        Label_0030:
            builder.Append(this._x4a3f0a05c02f235f[num]);
            num++;
        Label_0043:
            if (num < this._x4a3f0a05c02f235f.Length)
            {
                if (num <= 0)
                {
                    goto Label_0030;
                }
                goto Label_0027;
            }
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                builder.Append("]");
                if (0 != 0)
                {
                    goto Label_0027;
                }
            }
            return builder.ToString();
        }

        public double[] Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
            set
            {
                this._x4a3f0a05c02f235f = value;
            }
        }

        public double this[int x]
        {
            get
            {
                return this._x4a3f0a05c02f235f[x];
            }
            set
            {
                this._x4a3f0a05c02f235f[x] = value;
            }
        }

        public int Sequence
        {
            get
            {
                return this._x2868ae090935eb96;
            }
            set
            {
                this._x2868ae090935eb96 = value;
            }
        }
    }
}

