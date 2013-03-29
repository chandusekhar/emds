namespace Encog.App.Analyst.CSV.Filter
{
    using System;
    using System.Text;

    public class ExcludedField
    {
        private string _x5fc53c4ffd3eb8c9;
        private int _xade3b695478596d6;

        public ExcludedField(int theFieldNumber, string theFieldValue)
        {
            this._xade3b695478596d6 = theFieldNumber;
            this._x5fc53c4ffd3eb8c9 = theFieldValue;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            while (true)
            {
                builder.Append(base.GetType().Name);
                builder.Append(" fieldNumber=");
                do
                {
                    builder.Append(this._xade3b695478596d6);
                    builder.Append(", value=");
                    builder.Append(this._x5fc53c4ffd3eb8c9);
                }
                while (0 != 0);
                builder.Append("]");
                if (8 != 0)
                {
                    return builder.ToString();
                }
            }
        }

        public int FieldNumber
        {
            get
            {
                return this._xade3b695478596d6;
            }
            set
            {
                this._xade3b695478596d6 = value;
            }
        }

        public string FieldValue
        {
            get
            {
                return this._x5fc53c4ffd3eb8c9;
            }
            set
            {
                this._x5fc53c4ffd3eb8c9 = value;
            }
        }
    }
}

