namespace Encog.ML.Data.Basic
{
    using Encog.ML.Data;
    using System;
    using System.Text;

    [Serializable]
    public class BasicMLDataPair : IMLDataPair, ICloneable
    {
        private readonly IMLData _calced;
        private readonly IMLData _error;
        private readonly IMLData _ideal;
        private readonly IMLData _input;
        private double _significance;

        public BasicMLDataPair(IMLData input)
        {
            this._significance = 1.0;
            this._input = input;
            this._ideal = null;
            this._error = null;
            this._calced = null;
        }

        public BasicMLDataPair(IMLData input, IMLData ideal)
        {
            this._significance = 1.0;
            this._input = input;
            this._ideal = ideal;
            this._calced = null;
            this._error = null;
        }

        public BasicMLDataPair(IMLData input, IMLData ideal, IMLData calced)
        {
            this._significance = 1.0;
            this._input = input;
            this._ideal = ideal;
            this._calced = calced;
            this._error = null;
        }

        public BasicMLDataPair(IMLData input, IMLData ideal, IMLData calced, IMLData error)
        {
            this._significance = 1.0;
            this._input = input;
            this._ideal = ideal;
            this._calced = calced;
            this._error = error;
        }

        public object Clone()
        {
            IMLData input = null;
            IMLData data3;
            IMLData data4;
            goto Label_009F;
        Label_000D:
            data4 = (IMLData) this._error.Clone();
            if (-2147483648 != 0)
            {
                goto Label_00AF;
            }
        Label_0028:
            if (this._error != null)
            {
                goto Label_000D;
            }
            goto Label_005D;
        Label_0045:
            if (this._calced != null)
            {
                data3 = (IMLData) this._calced.Clone();
            }
            data4 = null;
        Label_004F:
            if ((2 == 0) || (-2147483648 != 0))
            {
                if (0 == 0)
                {
                    goto Label_0028;
                }
                if (0 != 0)
                {
                    goto Label_0045;
                }
                goto Label_000D;
            }
        Label_005D:
            if (15 != 0)
            {
                goto Label_00AF;
            }
            if (0 != 0)
            {
                goto Label_0045;
            }
        Label_009F:
            while (this._input != null)
            {
                input = (IMLData) this._input.Clone();
                if (0 == 0)
                {
                    break;
                }
            }
            IMLData ideal = null;
            if (this._ideal != null)
            {
                ideal = (IMLData) this._ideal.Clone();
                if (0 != 0)
                {
                    goto Label_004F;
                }
            }
            data3 = null;
            goto Label_0045;
        Label_00AF:
            return new BasicMLDataPair(input, ideal, data3, data4);
        }

        public static IMLDataPair CreatePair(int inputSize, int idealSize)
        {
            if (idealSize > 0)
            {
                return new BasicMLDataPair(new BasicMLData(inputSize), new BasicMLData(idealSize));
            }
            return new BasicMLDataPair(new BasicMLData(inputSize));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('[');
            if (0 == 0)
            {
                builder.Append("Input:");
                builder.Append(this.Input);
                builder.Append(",Ideal:");
            }
            builder.Append(this.Ideal);
            builder.Append(",Calced:");
            builder.Append(this.Calced);
            builder.Append(",Error:");
            builder.Append(this.Error);
            builder.Append(']');
            return builder.ToString();
        }

        public virtual IMLData Calced
        {
            get
            {
                return this._calced;
            }
        }

        public double[] CalcedArray
        {
            get
            {
                if (this._calced != null)
                {
                    return this._calced.Data;
                }
                return null;
            }
            set
            {
                this._calced.Data = value;
            }
        }

        public virtual IMLData Error
        {
            get
            {
                return this._error;
            }
        }

        public double[] ErrorArray
        {
            get
            {
                if (this._error != null)
                {
                    return this._error.Data;
                }
                return null;
            }
            set
            {
                this._error.Data = value;
            }
        }

        public virtual IMLData Ideal
        {
            get
            {
                return this._ideal;
            }
        }

        public double[] IdealArray
        {
            get
            {
                if (this._ideal != null)
                {
                    return this._ideal.Data;
                }
                return null;
            }
            set
            {
                this._ideal.Data = value;
            }
        }

        public virtual IMLData Input
        {
            get
            {
                return this._input;
            }
        }

        public double[] InputArray
        {
            get
            {
                return this._input.Data;
            }
            set
            {
                this._input.Data = value;
            }
        }

        public bool IsSupervised
        {
            get
            {
                return (this._ideal != null);
            }
        }

        public double Significance
        {
            get
            {
                return this._significance;
            }
            set
            {
                this._significance = value;
            }
        }

        public bool Supervised
        {
            get
            {
                return (this._ideal != null);
            }
        }
    }
}

