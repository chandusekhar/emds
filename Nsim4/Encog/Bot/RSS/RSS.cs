namespace Encog.Bot.RSS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    public class RSS
    {
        private readonly Dictionary<string, string> _x233f092c536593eb = new Dictionary<string, string>();
        private readonly List<RSSItem> _xf8b54ce7724a27f2 = new List<RSSItem>();

        public void Load(Uri url)
        {
            XmlDocument document;
            Stream responseStream = ((HttpWebResponse) WebRequest.Create(url).GetResponse()).GetResponseStream();
            if (0 == 0)
            {
                document = new XmlDocument();
                document.Load(responseStream);
            }
            using (IEnumerator enumerator = document.DocumentElement.ChildNodes.GetEnumerator())
            {
                XmlNode current;
                string name;
                goto Label_0064;
            Label_003E:
                if (string.Compare(name, "channel", true) == 0)
                {
                    goto Label_0088;
                }
                if (string.Compare(name, "item", true) == 0)
                {
                    this.x850eee9de1cbe123(current);
                }
            Label_0064:
                if (!enumerator.MoveNext())
                {
                    return;
                }
                current = (XmlNode) enumerator.Current;
                name = current.Name;
                goto Label_003E;
            Label_0088:
                this.x59fdc38f65d85ccf(current);
                goto Label_0064;
            }
        }

        public static DateTime ParseDate(string datestr)
        {
            return DateTime.Parse(datestr);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            using (Dictionary<string, string>.KeyCollection.Enumerator enumerator = this._x233f092c536593eb.Keys.GetEnumerator())
            {
                string current;
                goto Label_0038;
            Label_0019:
                if (0 == 0)
                {
                    builder.Append(this._x233f092c536593eb[current]);
                }
                builder.Append('\n');
            Label_0038:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    builder.Append(current);
                    builder.Append('=');
                    goto Label_0019;
                }
            }
            builder.Append("Items:\n");
            foreach (RSSItem item in this._xf8b54ce7724a27f2)
            {
                builder.Append(item.ToString());
                builder.Append('\n');
            }
            return builder.ToString();
        }

        private void x59fdc38f65d85ccf(XmlNode xd1571e08d75164b0)
        {
            IEnumerator enumerator = xd1571e08d75164b0.ChildNodes.GetEnumerator();
            try
            {
                string name;
                goto Label_002F;
            Label_0010:
                this._x233f092c536593eb.Remove(name);
                this._x233f092c536593eb.Add(name, xd1571e08d75164b0.InnerText);
            Label_002F:
                if (enumerator.MoveNext())
                {
                    XmlNode current = (XmlNode) enumerator.Current;
                    name = current.Name;
                    if (string.Compare(name, "item", true) != 0)
                    {
                        goto Label_0010;
                    }
                    this.x850eee9de1cbe123(current);
                    if (0 == 0)
                    {
                        goto Label_002F;
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                goto Label_0079;
            Label_006F:
                if (0 != 0)
                {
                    goto Label_0087;
                }
                if (2 != 0)
                {
                    goto Label_008C;
                }
            Label_0079:
                if (0 == 0)
                {
                    goto Label_0087;
                }
                if (0 != 0)
                {
                    goto Label_0079;
                }
            Label_007F:
                disposable.Dispose();
                goto Label_006F;
            Label_0087:
                if (disposable != null)
                {
                    goto Label_007F;
                }
            Label_008C:;
            }
        }

        private void x850eee9de1cbe123(XmlNode xccb63ca5f63dc470)
        {
            RSSItem item = new RSSItem();
            item.Load(xccb63ca5f63dc470);
            this._xf8b54ce7724a27f2.Add(item);
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return this._x233f092c536593eb;
            }
        }

        public List<RSSItem> Items
        {
            get
            {
                return this._xf8b54ce7724a27f2;
            }
        }
    }
}

