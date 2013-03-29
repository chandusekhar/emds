namespace Encog.App.Analyst.CSV.Sort
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class SortedField
    {
        private Encog.App.Analyst.CSV.Sort.SortType _x0a082a37646d8463;
        private int _xc0c4c459c6ccbd00;
        [CompilerGenerated]
        private bool x8d1598d2a5cf5a4d;

        public SortedField(int theIndexindex, Encog.App.Analyst.CSV.Sort.SortType t, bool theAscending)
        {
            this._xc0c4c459c6ccbd00 = theIndexindex;
            this.Ascending = theAscending;
            this._x0a082a37646d8463 = t;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            builder.Append(" index=");
            builder.Append(this._xc0c4c459c6ccbd00);
            builder.Append(", type=");
            if (8 != 0)
            {
            }
            builder.Append(this._x0a082a37646d8463);
            builder.Append("]");
            return builder.ToString();
        }

        public bool Ascending
        {
            [CompilerGenerated]
            get
            {
                return this.x8d1598d2a5cf5a4d;
            }
            [CompilerGenerated]
            set
            {
                this.x8d1598d2a5cf5a4d = value;
            }
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

        public Encog.App.Analyst.CSV.Sort.SortType SortType
        {
            get
            {
                return this._x0a082a37646d8463;
            }
            set
            {
                this._x0a082a37646d8463 = value;
            }
        }
    }
}

