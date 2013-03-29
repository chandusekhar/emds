namespace Encog.Bot.Browse
{
    using Encog.Bot.Browse.Range;
    using Encog.Bot.DataUnits;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WebPage
    {
        private DocumentRange _x37a96021dbbe3532;
        private readonly IList<DataUnit> _x4a3f0a05c02f235f = new List<DataUnit>();
        private readonly IList<DocumentRange> _x552e2aea89909776 = new List<DocumentRange>();

        public void AddContent(DocumentRange span)
        {
            span.Source = this;
            this._x552e2aea89909776.Add(span);
        }

        public void AddDataUnit(DataUnit unit)
        {
            this._x4a3f0a05c02f235f.Add(unit);
        }

        public DocumentRange Find(Type c, int index)
        {
            int num = index;
            using (IEnumerator<DocumentRange> enumerator = this.Contents.GetEnumerator())
            {
                DocumentRange range;
                goto Label_0045;
            Label_0010:
                if (((uint) index) > uint.MaxValue)
                {
                    goto Label_0087;
                }
                num--;
                if ((((uint) index) & 0) != 0)
                {
                    goto Label_004F;
                }
                goto Label_0045;
            Label_003C:
                if (range.GetType() == c)
                {
                    goto Label_004F;
                }
            Label_0045:
                if (enumerator.MoveNext())
                {
                    goto Label_006A;
                }
                goto Label_0067;
            Label_004F:
                if (num <= 0)
                {
                    return range;
                }
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0010;
                }
            Label_0067:
                if (0 == 0)
                {
                    goto Label_0087;
                }
            Label_006A:
                range = enumerator.Current;
                goto Label_003C;
            }
        Label_0087:
            return null;
        }

        public Link FindLink(string str)
        {
            return this.Contents.OfType<Link>().FirstOrDefault<Link>(link => link.GetTextOnly().Equals(str));
        }

        public int getDataSize()
        {
            return this._x4a3f0a05c02f235f.Count;
        }

        public DataUnit GetDataUnit(int i)
        {
            return this._x4a3f0a05c02f235f[i];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DocumentRange range in this.Contents)
            {
                builder.Append(range.ToString());
                builder.Append("\n");
            }
            return builder.ToString();
        }

        public IList<DocumentRange> Contents
        {
            get
            {
                return this._x552e2aea89909776;
            }
        }

        public IList<DataUnit> Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
        }

        public DocumentRange Title
        {
            get
            {
                return this._x37a96021dbbe3532;
            }
            set
            {
                this._x37a96021dbbe3532 = value;
                this._x37a96021dbbe3532.Source = this;
            }
        }
    }
}

