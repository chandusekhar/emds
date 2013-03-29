namespace Encog.Util.Arrayutil
{
    using System;
    using System.Text;

    public class ClassItem
    {
        private int _xc0c4c459c6ccbd00;
        private string _xc15bd84e01929885;

        public ClassItem(string theName, int theIndex)
        {
            this._xc15bd84e01929885 = theName;
            this._xc0c4c459c6ccbd00 = theIndex;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
                goto Label_0053;
            }
        Label_000E:
            builder.Append(" name=");
        Label_001A:
            builder.Append(this._xc15bd84e01929885);
            builder.Append(", index=");
            builder.Append(this._xc0c4c459c6ccbd00);
            builder.Append("]");
            if (4 != 0)
            {
                return builder.ToString();
            }
        Label_0053:
            builder.Append(base.GetType().Name);
            if (0xff == 0)
            {
                goto Label_001A;
            }
            goto Label_000E;
        }

        public int Index
        {
            get
            {
                return this._xc0c4c459c6ccbd00;
            }
            set
            {
                this._xc0c4c459c6ccbd00 = value;
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

