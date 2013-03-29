namespace Encog.App.Analyst.Script
{
    using System;
    using System.Text;

    public class AnalystClassItem : IComparable<AnalystClassItem>
    {
        private int _x10f4d88af727adbc;
        private string _x9035cf16181332fc;
        private string _xc15bd84e01929885;

        public AnalystClassItem(string theCode, string theName, int theCount)
        {
            this._x9035cf16181332fc = theCode;
            this._xc15bd84e01929885 = theName;
            this._x10f4d88af727adbc = theCount;
        }

        public int CompareTo(AnalystClassItem o)
        {
            return string.CompareOrdinal(this._x9035cf16181332fc, o.Code);
        }

        public void IncreaseCount()
        {
            this._x10f4d88af727adbc++;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (15 != 0)
            {
                builder.Append(base.GetType().Name);
            }
            builder.Append(" name=");
            do
            {
                builder.Append(this._xc15bd84e01929885);
                builder.Append(", code=");
                builder.Append(this._x9035cf16181332fc);
            }
            while (0 != 0);
            builder.Append("]");
            return builder.ToString();
        }

        public string Code
        {
            get
            {
                return this._x9035cf16181332fc;
            }
            set
            {
                this._x9035cf16181332fc = value;
            }
        }

        public int Count
        {
            get
            {
                return this._x10f4d88af727adbc;
            }
        }

        public string Name
        {
            get
            {
                return this._xc15bd84e01929885;
            }
            set
            {
                this._xc15bd84e01929885 = value;
            }
        }
    }
}

