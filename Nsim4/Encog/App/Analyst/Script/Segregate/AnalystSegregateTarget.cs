namespace Encog.App.Analyst.Script.Segregate
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class AnalystSegregateTarget
    {
        private string _xb44380e048627945;
        [CompilerGenerated]
        private int xaa4855c327bf2631;

        public AnalystSegregateTarget(string theFile, int thePercent)
        {
            this._xb44380e048627945 = theFile;
            this.Percent = thePercent;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
                builder.Append(base.GetType().Name);
                builder.Append(" file=");
            }
            builder.Append(this._xb44380e048627945);
            builder.Append(", percent=");
            builder.Append(this._xb44380e048627945);
            if (0 == 0)
            {
                builder.Append("]");
            }
            return builder.ToString();
        }

        public string File
        {
            get
            {
                return this._xb44380e048627945;
            }
            set
            {
                this._xb44380e048627945 = value;
            }
        }

        public int Percent
        {
            [CompilerGenerated]
            get
            {
                return this.xaa4855c327bf2631;
            }
            [CompilerGenerated]
            set
            {
                this.xaa4855c327bf2631 = value;
            }
        }
    }
}

