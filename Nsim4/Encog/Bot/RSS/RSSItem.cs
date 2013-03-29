namespace Encog.Bot.RSS
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Xml;

    public class RSSItem
    {
        private string _x37a96021dbbe3532;
        private string _xc2358fbac7da3d45;
        private DateTime _xccf8b068badcb542;
        private string _xe9c763083b68a7ee;

        public void Load(XmlNode node)
        {
            using (IEnumerator enumerator = node.ChildNodes.GetEnumerator())
            {
                XmlNode node2;
                string str;
                string str2;
            Label_000E:
                if (enumerator.MoveNext())
                {
                    goto Label_00A4;
                }
                if (0 != 0)
                {
                    goto Label_000E;
                }
                goto Label_00D5;
            Label_0021:
                str2 = node2.InnerText;
                this._xccf8b068badcb542 = Encog.Bot.RSS.RSS.ParseDate(str2);
                goto Label_000E;
            Label_0036:
                if (string.Compare(str, "pubDate", true) == 0)
                {
                    goto Label_0021;
                }
                goto Label_00CF;
            Label_0046:
                this._xc2358fbac7da3d45 = node2.InnerText;
                goto Label_000E;
            Label_0054:
                if (string.Compare(str, "description", true) == 0)
                {
                    goto Label_0046;
                }
                if (0xff != 0)
                {
                    goto Label_0036;
                }
                if (0 == 0)
                {
                    goto Label_0021;
                }
                goto Label_00CF;
            Label_006E:
                this._xe9c763083b68a7ee = node2.InnerText;
                goto Label_000E;
            Label_0081:
                if (string.Compare(str, "title", true) == 0)
                {
                    goto Label_00B9;
                }
                if (string.Compare(str, "link", true) != 0)
                {
                    goto Label_0054;
                }
                if (0x7fffffff != 0)
                {
                    goto Label_006E;
                }
            Label_00A4:
                node2 = (XmlNode) enumerator.Current;
            Label_00B0:
                str = node2.Name;
                goto Label_0081;
            Label_00B9:
                this._x37a96021dbbe3532 = node2.InnerText;
                if (0 != 0)
                {
                    goto Label_00B0;
                }
                goto Label_000E;
            Label_00CF:
                if (0 == 0)
                {
                    goto Label_000E;
                }
            Label_00D5:;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('[');
            builder.Append("title=\"");
            do
            {
                builder.Append(this._x37a96021dbbe3532);
                builder.Append("\",link=\"");
                builder.Append(this._xe9c763083b68a7ee);
            }
            while (0x7fffffff == 0);
            builder.Append("\",date=\"");
            builder.Append(this._xccf8b068badcb542);
            builder.Append("\"]");
            return builder.ToString();
        }

        public DateTime Date
        {
            get
            {
                return this._xccf8b068badcb542;
            }
            set
            {
                this._xccf8b068badcb542 = value;
            }
        }

        public string Description
        {
            get
            {
                return this._xc2358fbac7da3d45;
            }
            set
            {
                this._xc2358fbac7da3d45 = value;
            }
        }

        public string Link
        {
            get
            {
                return this._xe9c763083b68a7ee;
            }
            set
            {
                this._xe9c763083b68a7ee = value;
            }
        }

        public string Title
        {
            get
            {
                return this._x37a96021dbbe3532;
            }
            set
            {
                this._x37a96021dbbe3532 = value;
            }
        }
    }
}

