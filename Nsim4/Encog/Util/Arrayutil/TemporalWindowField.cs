namespace Encog.Util.Arrayutil
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class TemporalWindowField
    {
        private TemporalType _xab8fe3cd8c5556fb;
        private string _xc15bd84e01929885;
        [CompilerGenerated]
        private string x40ef43a91b34de26;

        public TemporalWindowField(string theName)
        {
            this._xc15bd84e01929885 = theName;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
            }
            builder.Append(base.GetType().Name);
            builder.Append(" name=");
            builder.Append(this._xc15bd84e01929885);
            builder.Append(", action=");
            builder.Append(this._xab8fe3cd8c5556fb);
            if (3 != 0)
            {
                builder.Append("]");
            }
            return builder.ToString();
        }

        public TemporalType Action
        {
            get
            {
                return this._xab8fe3cd8c5556fb;
            }
            set
            {
                this._xab8fe3cd8c5556fb = value;
            }
        }

        public bool Input
        {
            get
            {
                if (this._xab8fe3cd8c5556fb != TemporalType.Input)
                {
                    return (this._xab8fe3cd8c5556fb == TemporalType.InputAndPredict);
                }
                return true;
            }
        }

        public string LastValue
        {
            [CompilerGenerated]
            get
            {
                return this.x40ef43a91b34de26;
            }
            [CompilerGenerated]
            set
            {
                this.x40ef43a91b34de26 = value;
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

        public bool Predict
        {
            get
            {
                if (this._xab8fe3cd8c5556fb != TemporalType.Predict)
                {
                    return (this._xab8fe3cd8c5556fb == TemporalType.InputAndPredict);
                }
                return true;
            }
        }
    }
}

