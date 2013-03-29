namespace Nsim
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal class Config : x15b8c53ba4818b71
    {
        [CompilerGenerated]
        private int? x37137cd008466d06;
        [CompilerGenerated]
        private bool x5c4c4e346b95faf7;

        public Config()
        {
            try
            {
                XElement root;
                XElement element2;
                bool flag;
                string uri = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\' }) + @"\Config.xml";
                goto Label_0152;
            Label_0035:
                if (0 == 0)
                {
                    return;
                }
                goto Label_0035;
            Label_003B:
                if (!flag)
                {
                    goto Label_0070;
                }
                goto Label_0035;
            Label_0042:
                this.x3ca5a760576c2053 = 1;
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_0114;
                }
                goto Label_0035;
            Label_0070:
                this.x3ca5a760576c2053 = new int?(element2.Attribute("ThreadCount").AsInt(0));
                goto Label_0035;
            Label_009B:
                if (flag)
                {
                    return;
                }
            Label_00A2:
                this.xfc82d6bf51352ebe = element2.Attribute("Enabled").AsBool(false);
                flag = !this.xfc82d6bf51352ebe;
                if (flag)
                {
                    goto Label_0042;
                }
                flag = element2.Attribute("ThreadCount") == null;
                goto Label_003B;
            Label_00ED:
                if (0 != 0)
                {
                    goto Label_0114;
                }
            Label_00F0:
                element2 = root.Element("MultiThreading");
                flag = element2 == null;
                goto Label_009B;
            Label_010E:
                if (!flag)
                {
                    return;
                }
                goto Label_00ED;
            Label_0114:
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    goto Label_010E;
                }
                goto Label_00F0;
            Label_012E:
                if (!flag)
                {
                    return;
                }
                root = XDocument.Load(uri).Root;
                flag = root != null;
                goto Label_010E;
            Label_0152:
                if (15 == 0)
                {
                    goto Label_00A2;
                }
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_0114;
                }
                flag = File.Exists(uri);
                goto Label_012E;
                if ((((uint) flag) | 0x7fffffff) != 0)
                {
                    goto Label_0114;
                }
                if (8 != 0)
                {
                    goto Label_00ED;
                }
                goto Label_009B;
            }
            catch (Exception)
            {
            }
        }

        public int? x3ca5a760576c2053
        {
            [CompilerGenerated]
            get
            {
                return this.x37137cd008466d06;
            }
            [CompilerGenerated]
            private set
            {
                this.x37137cd008466d06 = value;
            }
        }

        public bool xfc82d6bf51352ebe
        {
            [CompilerGenerated]
            get
            {
                return this.x5c4c4e346b95faf7;
            }
            [CompilerGenerated]
            private set
            {
                this.x5c4c4e346b95faf7 = value;
            }
        }
    }
}

