namespace Encog.ML.Data.Basic
{
    using Encog.MathUtil;
    using Encog.ML.Data;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    [Serializable]
    public class BasicMLComplexData : IMLData, ICloneable, IMLComplexData
    {
        private ComplexNumber[] _data;

        public BasicMLComplexData(ComplexNumber[] d)
        {
            this._data = d;
        }

        public BasicMLComplexData(double[] d) : this(d.Length)
        {
        }

        public BasicMLComplexData(IMLData d)
        {
            IMLComplexData data;
            int num;
            int num2;
            goto Label_00EF;
        Label_002C:
            while (num2 < d.Count)
            {
                this._data[num2] = new ComplexNumber(d[num2], 0.0);
                num2++;
            }
            if ((((uint) num) | 0xff) != 0)
            {
                return;
            }
            goto Label_00EF;
        Label_0066:
            num2 = 0;
            goto Label_002C;
        Label_0099:
            if (!(d is IMLComplexData))
            {
                goto Label_0066;
            }
        Label_00C1:
            data = (IMLComplexData) d;
            num = 0;
            while (num < d.Count)
            {
                this._data[num] = new ComplexNumber(data.GetComplexData(num));
            Label_00E0:
                num++;
            }
            return;
        Label_00EF:
            if (((uint) num2) >= 0)
            {
                goto Label_0099;
            }
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_00C1;
            }
            if ((((uint) num2) & 0) != 0)
            {
                return;
            }
            if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                    if ((((uint) num) - ((uint) num)) < 0)
                    {
                        goto Label_0099;
                    }
                    if (((uint) num) < 0)
                    {
                        goto Label_002C;
                    }
                    goto Label_0066;
                }
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_00E0;
                }
            }
            goto Label_0099;
        }

        public BasicMLComplexData(int size)
        {
            this._data = new ComplexNumber[size];
        }

        public void Clear()
        {
            for (int i = 0; i < this._data.Length; i++)
            {
                this._data[i] = new ComplexNumber(0.0, 0.0);
            }
        }

        public object Clone()
        {
            return new BasicMLComplexData(this);
        }

        public ComplexNumber GetComplexData(int index)
        {
            return this._data[index];
        }

        public void SetComplexData(ComplexNumber[] d)
        {
            this._data = d;
        }

        public void SetComplexData(int index, ComplexNumber d)
        {
            this._data[index] = d;
        }

        public string ToString()
        {
            int num;
            StringBuilder builder = new StringBuilder("[");
            goto Label_0052;
        Label_0010:
            if (num >= this._data.Length)
            {
                builder.Append("]");
                return builder.ToString();
            }
        Label_0034:
            if (num != 0)
            {
                builder.Append(',');
            }
        Label_0037:
            builder.Append(this._data[num].ToString());
            num++;
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_0037;
                }
                goto Label_0010;
            }
        Label_0052:
            builder.Append(base.GetType().Name);
            builder.Append(":");
            num = 0;
            if (-1 != 0)
            {
                goto Label_0010;
            }
            goto Label_0034;
        }

        public ComplexNumber[] ComplexData
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

        public int Count
        {
            get
            {
                return this._data.Count<ComplexNumber>();
            }
        }

        public virtual double[] Data
        {
            get
            {
                double[] numArray = new double[this._data.Length];
                int index = 0;
                while (index < numArray.Length)
                {
                    do
                    {
                        numArray[index] = this._data[index].Real;
                        index++;
                    }
                    while ((((uint) index) - ((uint) index)) < 0);
                }
                return numArray;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this._data[i] = new ComplexNumber(value[i], 0.0);
                }
            }
        }

        public virtual double this[int x]
        {
            get
            {
                return this._data[x].Real;
            }
            set
            {
                this._data[x] = new ComplexNumber(value, 0.0);
            }
        }
    }
}

