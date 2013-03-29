namespace Encog.ML.Data.Basic
{
    using Encog.ML.Data;
    using Encog.Util;
    using System;
    using System.Reflection;
    using System.Text;

    [Serializable]
    public class BasicMLData : IMLData, ICloneable
    {
        private double[] _data;

        public BasicMLData(double[] d) : this(d.Length)
        {
            int index = 0;
            while (index < d.Length)
            {
                this._data[index] = d[index];
                if (0 == 0)
                {
                    index++;
                }
            }
        }

        public BasicMLData(int size)
        {
            this._data = new double[size];
        }

        public void Clear()
        {
            EngineArray.Fill(this._data, 0);
        }

        public object Clone()
        {
            return new BasicMLData(this._data);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                builder.Append('[');
                for (int i = 0; i < this.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(',');
                    }
                    builder.Append(this.Data[i]);
                }
                builder.Append(']');
                if (1 != 0)
                {
                    return builder.ToString();
                }
            }
        }

        public virtual int Count
        {
            get
            {
                return this._data.Length;
            }
        }

        public virtual double[] Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        public virtual double this[int x]
        {
            get
            {
                return this._data[x];
            }
            set
            {
                this._data[x] = value;
            }
        }
    }
}

