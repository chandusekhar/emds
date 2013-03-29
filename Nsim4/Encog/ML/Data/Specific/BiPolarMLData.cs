namespace Encog.ML.Data.Specific
{
    using Encog.MathUtil.Matrices;
    using Encog.ML.Data;
    using System;
    using System.Reflection;
    using System.Text;

    [Serializable]
    public class BiPolarMLData : IMLData, ICloneable
    {
        private bool[] _data;

        public BiPolarMLData(bool[] d)
        {
            int num;
            if (15 != 0)
            {
                this._data = new bool[d.Length];
                num = 0;
            }
            while (num < d.Length)
            {
                this._data[num] = d[num];
                num++;
            }
        }

        public BiPolarMLData(int size)
        {
            this._data = new bool[size];
        }

        public void Clear()
        {
            for (int i = 0; i < this._data.Length; i++)
            {
                this._data[i] = false;
            }
        }

        public virtual object Clone()
        {
            return new BiPolarMLData(this._data);
        }

        public bool GetBoolean(int i)
        {
            return this._data[i];
        }

        public void SetBoolean(int index, bool b)
        {
            this._data[index] = b;
        }

        public string ToString()
        {
            int num;
            StringBuilder builder = new StringBuilder();
            goto Label_00B5;
        Label_000B:
            builder.Append(']');
            if (8 != 0)
            {
                goto Label_00C5;
            }
            goto Label_00B5;
        Label_0026:
            num++;
        Label_002A:
            if (num < this.Count)
            {
            Label_003C:
                builder.Append((this[num] > 0.0) ? "T" : "F");
                if (((uint) num) < 0)
                {
                    if (-1 == 0)
                    {
                        goto Label_002A;
                    }
                    goto Label_003C;
                }
                if (((((uint) num) | 8) != 0) && (num == (this.Count - 1)))
                {
                    goto Label_0026;
                }
            }
            else
            {
                goto Label_000B;
            }
            builder.Append(",");
            if (0 == 0)
            {
                goto Label_0026;
            }
            goto Label_000B;
        Label_00B5:
            builder.Append('[');
            if (4 != 0)
            {
                num = 0;
                goto Label_002A;
            }
        Label_00C5:
            return builder.ToString();
        }

        public int Count
        {
            get
            {
                return this._data.Length;
            }
        }

        public double[] Data
        {
            get
            {
                return BiPolarUtil.Bipolar2double(this._data);
            }
            set
            {
                this._data = BiPolarUtil.Double2bipolar(value);
            }
        }

        public double this[int x]
        {
            get
            {
                return BiPolarUtil.Bipolar2double(this._data[x]);
            }
            set
            {
                this._data[x] = BiPolarUtil.Double2bipolar(value);
            }
        }
    }
}

