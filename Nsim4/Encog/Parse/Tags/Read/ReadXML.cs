namespace Encog.Parse.Tags.Read
{
    using Encog.Parse;
    using Encog.Parse.Tags;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ReadXML : ReadTags
    {
        public ReadXML(Stream istream) : base(istream)
        {
        }

        public bool FindTag(string name, bool beginTag)
        {
        Label_0002:
            if (!base.ReadToTag())
            {
                return false;
            }
            if (!beginTag)
            {
                if (base.LastTag.Name.Equals(name) && (base.LastTag.TagType == Tag.Type.End))
                {
                    return true;
                }
                goto Label_0002;
            }
            if (!base.LastTag.Name.Equals(name) || (base.LastTag.TagType != Tag.Type.Begin))
            {
                goto Label_0002;
            }
            return true;
        }

        public int ReadIntToTag()
        {
            int num;
            try
            {
                num = int.Parse(this.ReadTextToTag());
            }
            catch (Exception exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
            return num;
        }

        public IDictionary<string, string> ReadPropertyBlock()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string name = base.LastTag.Name;
            while (true)
            {
                while (!base.ReadToTag())
                {
                    if (0 == 0)
                    {
                        return dictionary;
                    }
                }
                if (base.LastTag.Name.Equals(name) && ((base.LastTag.TagType == Tag.Type.End) && (0xff != 0)))
                {
                    return dictionary;
                }
                string str2 = base.LastTag.Name;
                string str3 = this.ReadTextToTag().Trim();
                dictionary[str2] = str3;
            }
        }

        public string ReadTextToTag()
        {
            bool flag;
            int num;
            StringBuilder builder = new StringBuilder();
            if (0 == 0)
            {
                flag = false;
            }
            else
            {
                goto Label_002F;
            }
        Label_001C:
            if (flag)
            {
                return builder.ToString();
            }
        Label_002F:
            num = base.Read();
        Label_0008:
            if ((num != -1) && (num != 0))
            {
                builder.Append((char) num);
            }
            else
            {
                flag = true;
                if (0 != 0)
                {
                    goto Label_0008;
                }
            }
            goto Label_001C;
        }
    }
}

