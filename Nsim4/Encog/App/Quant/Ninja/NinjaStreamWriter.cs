namespace Encog.App.Quant.Ninja
{
    using Encog;
    using Encog.Util.CSV;
    using Encog.Util.Time;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class NinjaStreamWriter
    {
        private readonly IList<string> x26c511b92db96554 = new List<string>();
        private StringBuilder x311e7a92306d7199;
        private CSVFormat x5786461d089b10a0;
        private TextWriter x662b9cecc8fe240a;
        private bool x94e6ca5ac178dbd0;
        private bool x9abf89599926190e;
        [CompilerGenerated]
        private int xafc2a72678f93093;

        public NinjaStreamWriter()
        {
            this.Percision = 10;
            this.x9abf89599926190e = false;
        }

        public void BeginBar(DateTime dt)
        {
            if (this.x662b9cecc8fe240a == null)
            {
                if (0 == 0)
                {
                    goto Label_0062;
                }
            }
            else if (this.x311e7a92306d7199 != null)
            {
                do
                {
                    throw new EncogError("Must call end bar");
                }
                while (15 == 0);
            }
            this.x311e7a92306d7199 = new StringBuilder();
            this.x311e7a92306d7199.Append(NumericDateUtil.DateTime2Long(dt));
            this.x311e7a92306d7199.Append(this.x5786461d089b10a0.Separator);
            this.x311e7a92306d7199.Append(NumericDateUtil.x93295384d7a86d9d(dt));
            if (2 != 0)
            {
                return;
            }
        Label_0062:
            throw new EncogError("Must open file first.");
        }

        public void Close()
        {
            if (this.x662b9cecc8fe240a == null)
            {
                throw new EncogError("Must open file first.");
            }
            this.x662b9cecc8fe240a.Close();
        }

        public void EndBar()
        {
            if (this.x662b9cecc8fe240a != null)
            {
                if ((this.x311e7a92306d7199 == null) || (0 != 0))
                {
                    throw new EncogError("Must call BeginBar first.");
                }
            }
            else
            {
                if (0 == 0)
                {
                    throw new EncogError("Must open file first.");
                }
                goto Label_0036;
            }
        Label_0011:
            if (this.x94e6ca5ac178dbd0)
            {
                goto Label_0040;
            }
        Label_0019:
            this.x662b9cecc8fe240a.WriteLine(this.x311e7a92306d7199.ToString());
            this.x311e7a92306d7199 = null;
        Label_0036:
            this.x9abf89599926190e = true;
            if (0 == 0)
            {
                return;
            }
        Label_0040:
            if (this.x9abf89599926190e)
            {
                goto Label_0019;
            }
            this.x6c260f7f6142106c();
            if (2 != 0)
            {
                goto Label_0019;
            }
            goto Label_0011;
        }

        public void Open(string filename, bool headers, CSVFormat format)
        {
            this.x662b9cecc8fe240a = new StreamWriter(filename);
            this.x5786461d089b10a0 = format;
            this.x94e6ca5ac178dbd0 = headers;
        }

        public void StoreColumn(string name, double d)
        {
            if (this.x311e7a92306d7199 == null)
            {
                goto Label_009B;
            }
            if (this.x311e7a92306d7199.Length > 0)
            {
                goto Label_006A;
            }
        Label_001B:
            this.x311e7a92306d7199.Append(this.x5786461d089b10a0.Format(d, this.Percision));
            if ((0 == 0) && this.x9abf89599926190e)
            {
                if ((((uint) d) - ((uint) d)) <= uint.MaxValue)
                {
                    if ((((uint) d) + ((uint) d)) <= uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_009B;
                }
            }
            else
            {
                this.x26c511b92db96554.Add(name);
                return;
            }
        Label_006A:
            this.x311e7a92306d7199.Append(this.x5786461d089b10a0.Separator);
            goto Label_001B;
        Label_009B:
            throw new EncogError("Must call BeginBar first.");
        }

        private void x6c260f7f6142106c()
        {
            StringBuilder builder;
            if (this.x662b9cecc8fe240a != null)
            {
                goto Label_0024;
            }
            goto Label_00DB;
        Label_000D:
            this.x662b9cecc8fe240a.WriteLine(builder.ToString());
            if (0 == 0)
            {
                if (-2147483648 != 0)
                {
                    return;
                }
                goto Label_00DB;
            }
        Label_0024:
            builder = new StringBuilder();
            do
            {
                builder.Append("date");
            }
            while (0xff == 0);
            builder.Append(this.x5786461d089b10a0.Separator);
            builder.Append("time");
            using (IEnumerator<string> enumerator = this.x26c511b92db96554.GetEnumerator())
            {
                string str;
                goto Label_007D;
            Label_0069:
                builder.Append(str);
                builder.Append("\"");
            Label_007D:
                if (enumerator.MoveNext())
                {
                    goto Label_00A1;
                }
                goto Label_000D;
            Label_0087:
                if (builder.Length > 0)
                {
                    goto Label_00AA;
                }
            Label_0090:
                builder.Append("\"");
                if (0 == 0)
                {
                }
                goto Label_0069;
            Label_00A1:
                str = enumerator.Current;
                goto Label_0087;
            Label_00AA:
                builder.Append(this.x5786461d089b10a0.Separator);
                goto Label_0090;
            }
            goto Label_000D;
        Label_00DB:
            throw new EncogError("Must open file first.");
        }

        public int Percision
        {
            [CompilerGenerated]
            get
            {
                return this.xafc2a72678f93093;
            }
            [CompilerGenerated]
            set
            {
                this.xafc2a72678f93093 = value;
            }
        }
    }
}

