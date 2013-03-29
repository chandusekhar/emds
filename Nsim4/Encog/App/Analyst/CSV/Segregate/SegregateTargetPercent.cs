namespace Encog.App.Analyst.CSV.Segregate
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class SegregateTargetPercent
    {
        private int _x4afa7e85b5b4d006;
        private FileInfo _xb41a802ca5fde63b;
        [CompilerGenerated]
        private int x901df02b2ae3adc2;

        public SegregateTargetPercent(FileInfo outputFile, int thePercent)
        {
            this._x4afa7e85b5b4d006 = thePercent;
            this._xb41a802ca5fde63b = outputFile;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
                goto Label_0031;
            }
        Label_000E:
            builder.Append(this._x4afa7e85b5b4d006);
            do
            {
                builder.Append("]");
            }
            while (4 == 0);
            if (0 == 0)
            {
                return builder.ToString();
            }
        Label_0031:
            builder.Append(base.GetType().Name);
            builder.Append(" filename=");
            builder.Append(this._xb41a802ca5fde63b.ToString());
            builder.Append(", percent=");
            goto Label_000E;
        }

        public FileInfo Filename
        {
            get
            {
                return this._xb41a802ca5fde63b;
            }
            set
            {
                this._xb41a802ca5fde63b = value;
            }
        }

        public int NumberRemaining
        {
            [CompilerGenerated]
            get
            {
                return this.x901df02b2ae3adc2;
            }
            [CompilerGenerated]
            set
            {
                this.x901df02b2ae3adc2 = value;
            }
        }

        public int Percent
        {
            get
            {
                return this._x4afa7e85b5b4d006;
            }
            set
            {
                this._x4afa7e85b5b4d006 = value;
            }
        }
    }
}

