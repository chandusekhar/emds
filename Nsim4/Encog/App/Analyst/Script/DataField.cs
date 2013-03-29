namespace Encog.App.Analyst.Script
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DataField
    {
        private readonly IList<AnalystClassItem> _xd5545b11f6d83f6c;
        [CompilerGenerated]
        private bool x121da66f6445c6d7;
        [CompilerGenerated]
        private double x308fc176e59edb6d;
        [CompilerGenerated]
        private static Func<int, AnalystClassItem, int> x31af784cbc72c68d;
        [CompilerGenerated]
        private string x35b9a94250058afe;
        [CompilerGenerated]
        private double x3c81abf1fbe14011;
        [CompilerGenerated]
        private bool x6965d50debe57e60;
        [CompilerGenerated]
        private double xb28d975ea224e3a8;
        [CompilerGenerated]
        private double xb7e69cb86af43f02;
        [CompilerGenerated]
        private bool xe02060b638a84b38;
        [CompilerGenerated]
        private bool xe54d99eaf8981764;

        public DataField(string theName)
        {
            if (1 != 0)
            {
                this._xd5545b11f6d83f6c = new List<AnalystClassItem>();
                goto Label_0092;
            }
        Label_004B:
            this.Min = double.MaxValue;
            this.Max = double.MinValue;
            this.Mean = double.NaN;
            if (0 == 0)
            {
                this.StandardDeviation = double.NaN;
                this.Integer = true;
                if (-2 == 0)
                {
                    goto Label_0092;
                }
                this.Real = true;
            }
            if (-2147483648 != 0)
            {
                this.Class = true;
                this.Complete = true;
                if (0 == 0)
                {
                    return;
                }
                goto Label_004B;
            }
            return;
        Label_0092:
            this.Name = theName;
            goto Label_004B;
        }

        [CompilerGenerated]
        private static int x423166c51d1af5d1(int x3bd62873fafa6252, AnalystClassItem xc42b25352a9f8ae1)
        {
            return Math.Min(x3bd62873fafa6252, xc42b25352a9f8ae1.Count);
        }

        public bool Class
        {
            [CompilerGenerated]
            get
            {
                return this.x121da66f6445c6d7;
            }
            [CompilerGenerated]
            set
            {
                this.x121da66f6445c6d7 = value;
            }
        }

        public IList<AnalystClassItem> ClassMembers
        {
            get
            {
                return this._xd5545b11f6d83f6c;
            }
        }

        public bool Complete
        {
            [CompilerGenerated]
            get
            {
                return this.xe02060b638a84b38;
            }
            [CompilerGenerated]
            set
            {
                this.xe02060b638a84b38 = value;
            }
        }

        public bool Integer
        {
            [CompilerGenerated]
            get
            {
                return this.xe54d99eaf8981764;
            }
            [CompilerGenerated]
            set
            {
                this.xe54d99eaf8981764 = value;
            }
        }

        public double Max
        {
            [CompilerGenerated]
            get
            {
                return this.x308fc176e59edb6d;
            }
            [CompilerGenerated]
            set
            {
                this.x308fc176e59edb6d = value;
            }
        }

        public double Mean
        {
            [CompilerGenerated]
            get
            {
                return this.x3c81abf1fbe14011;
            }
            [CompilerGenerated]
            set
            {
                this.x3c81abf1fbe14011 = value;
            }
        }

        public double Min
        {
            [CompilerGenerated]
            get
            {
                return this.xb7e69cb86af43f02;
            }
            [CompilerGenerated]
            set
            {
                this.xb7e69cb86af43f02 = value;
            }
        }

        public int MinClassCount
        {
            get
            {
                if (x31af784cbc72c68d == null)
                {
                    x31af784cbc72c68d = new Func<int, AnalystClassItem, int>(DataField.x423166c51d1af5d1);
                }
                return this._xd5545b11f6d83f6c.Aggregate<AnalystClassItem, int>(0x7fffffff, x31af784cbc72c68d);
            }
        }

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return this.x35b9a94250058afe;
            }
            [CompilerGenerated]
            set
            {
                this.x35b9a94250058afe = value;
            }
        }

        public bool Real
        {
            [CompilerGenerated]
            get
            {
                return this.x6965d50debe57e60;
            }
            [CompilerGenerated]
            set
            {
                this.x6965d50debe57e60 = value;
            }
        }

        public double StandardDeviation
        {
            [CompilerGenerated]
            get
            {
                return this.xb28d975ea224e3a8;
            }
            [CompilerGenerated]
            set
            {
                this.xb28d975ea224e3a8 = value;
            }
        }
    }
}

