namespace Encog.Parse.Tags
{
    using Encog.Parse;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tag
    {
        private readonly IDictionary<string, string> _x233f092c536593eb = new Dictionary<string, string>();
        private Type _x43163d22e8cd5a71;
        private string _xc15bd84e01929885 = "";

        public void Clear()
        {
            this._x233f092c536593eb.Clear();
            this._xc15bd84e01929885 = "";
            this._x43163d22e8cd5a71 = Type.Begin;
        }

        public virtual object Clone()
        {
            Tag tag = new Tag {
                Name = this.Name,
                TagType = this.TagType
            };
            foreach (string str in this._x233f092c536593eb.Keys)
            {
                string str2 = this._x233f092c536593eb[str];
                tag.Attributes[str] = str2;
            }
            return tag;
        }

        public int GetAttributeInt(string attributeId)
        {
            int num;
            try
            {
                num = int.Parse(this.GetAttributeValue(attributeId));
            }
            catch (Exception exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
            return num;
        }

        public string GetAttributeValue(string name)
        {
            if (!this._x233f092c536593eb.ContainsKey(name))
            {
                return null;
            }
            return this._x233f092c536593eb[name];
        }

        public void SetAttribute(string name, string valueRen)
        {
            this._x233f092c536593eb[name] = valueRen;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("<");
            if (this._x43163d22e8cd5a71 == Type.End)
            {
                builder.Append("/");
                if (0 == 0)
                {
                }
            }
            goto Label_0032;
        Label_0010:
            builder.Append(">");
            return builder.ToString();
        Label_0032:
            builder.Append(this._xc15bd84e01929885);
            using (IEnumerator<string> enumerator = this._x233f092c536593eb.Keys.GetEnumerator())
            {
                string str;
                string str2;
            Label_0055:
                if (enumerator.MoveNext())
                {
                    goto Label_00D0;
                }
                goto Label_0010;
            Label_0066:
                if (str2 == null)
                {
                    goto Label_00A6;
                }
                do
                {
                    builder.Append(str);
                    builder.Append("=\"");
                    builder.Append(str2);
                    if (0 == 0)
                    {
                        builder.Append("\"");
                        goto Label_00A1;
                    }
                    if (0 == 0)
                    {
                    }
                }
                while (0 == 0);
                if (0 == 0)
                {
                    goto Label_0066;
                }
            Label_00A1:
                if (0 == 0)
                {
                    goto Label_00C8;
                }
                goto Label_0066;
            Label_00A6:
                builder.Append("\"");
                builder.Append(str);
                builder.Append("\"");
                goto Label_0055;
            Label_00C8:
                if (0 == 0)
                {
                    goto Label_0055;
                }
                goto Label_0010;
            Label_00D0:
                str = enumerator.Current;
                str2 = this._x233f092c536593eb[str];
                builder.Append(' ');
                goto Label_0066;
            }
        }

        public IDictionary<string, string> Attributes
        {
            get
            {
                return this._x233f092c536593eb;
            }
        }

        public string Name
        {
            get
            {
                return this._xc15bd84e01929885;
            }
            set
            {
                this._xc15bd84e01929885 = value;
            }
        }

        public Type TagType
        {
            get
            {
                return this._x43163d22e8cd5a71;
            }
            set
            {
                this._x43163d22e8cd5a71 = value;
            }
        }

        public enum Type
        {
            Begin,
            End,
            Comment,
            CDATA
        }
    }
}

