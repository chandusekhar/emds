namespace Encog.Parse.Tags.Read
{
    using Encog.Parse;
    using Encog.Parse.Tags;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ReadTags
    {
        private readonly PeekableInputStream _x337e217cb3ba0627;
        private string _x86f29885f41183a5;
        private static IDictionary<string, char> _xd1768ddee4fdb90a;
        private string _xfa01f9cedae2093c;
        private readonly Tag _xffe521cc76054baf = new Tag();
        public int CharBullet = 0x95;
        public int CharTrademark = 0x81;
        public int MaxLength = 0x2710;

        public ReadTags(Stream istream)
        {
            if (-2147483648 != 0)
            {
                this._x337e217cb3ba0627 = new PeekableInputStream(istream);
                if ((0 == 0) && (_xd1768ddee4fdb90a != null))
                {
                    return;
                }
                _xd1768ddee4fdb90a = new Dictionary<string, char>();
                if (1 != 0)
                {
                    _xd1768ddee4fdb90a["nbsp"] = ' ';
                    _xd1768ddee4fdb90a["lt"] = '<';
                    goto Label_00DE;
                }
            }
        Label_003C:
            if (0 == 0)
            {
                return;
            }
        Label_00DE:
            _xd1768ddee4fdb90a["gt"] = '>';
            _xd1768ddee4fdb90a["amp"] = '&';
            _xd1768ddee4fdb90a["quot"] = '"';
            _xd1768ddee4fdb90a["bull"] = (char) ((ushort) this.CharBullet);
            _xd1768ddee4fdb90a["trade"] = (char) ((ushort) this.CharTrademark);
            if (0x7fffffff == 0)
            {
                return;
            }
            goto Label_003C;
        }

        protected void EatWhitespace()
        {
            while (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek()))
            {
                this._x337e217cb3ba0627.Read();
            }
        }

        public bool IsIt(string name, bool start)
        {
            if (!this.LastTag.Name.Equals(name))
            {
                return false;
            }
            if (start)
            {
                return (this.LastTag.TagType == Tag.Type.Begin);
            }
            return (this.LastTag.TagType == Tag.Type.End);
        }

        protected string ParseAttributeName()
        {
            StringBuilder builder;
            int num;
            this.EatWhitespace();
            if ((((uint) num) <= uint.MaxValue) && ("\"'".IndexOf((char) this._x337e217cb3ba0627.Peek()) == -1))
            {
                builder = new StringBuilder();
            }
            else
            {
                return this.ParseString();
            }
            while ((!char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek()) && (this._x337e217cb3ba0627.Peek() != 0x3d)) && ((this._x337e217cb3ba0627.Peek() != 0x3e) && (this._x337e217cb3ba0627.Peek() != -1)))
            {
                num = this.xdd33c6adbeca0968();
                builder.Append((char) num);
            }
            return builder.ToString();
        }

        protected string ParseString()
        {
            int num;
            int num2;
            StringBuilder builder = new StringBuilder();
            if (0xff != 0)
            {
                this.EatWhitespace();
                if ("\"'".IndexOf((char) this._x337e217cb3ba0627.Peek()) == -1)
                {
                Label_0036:
                    if (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek()))
                    {
                        goto Label_01F5;
                    }
                    if (this._x337e217cb3ba0627.Peek() == -1)
                    {
                        if (((uint) num2) <= uint.MaxValue)
                        {
                            goto Label_01F5;
                        }
                    }
                    else
                    {
                        if (this._x337e217cb3ba0627.Peek() != 0x3e)
                        {
                            builder.Append(this.xdd33c6adbeca0968());
                        }
                        else if (((uint) num2) >= 0)
                        {
                            if (3 == 0)
                            {
                                goto Label_013A;
                            }
                            goto Label_01F5;
                        }
                        goto Label_0036;
                    }
                    goto Label_0086;
                }
                num = this._x337e217cb3ba0627.Read();
                goto Label_0125;
            }
            goto Label_01F5;
        Label_0086:
            if ((((uint) num) + ((uint) num)) < 0)
            {
                goto Label_0125;
            }
        Label_00A1:
            if ("\"'".IndexOf((char) this._x337e217cb3ba0627.Peek()) != -1)
            {
                this._x337e217cb3ba0627.Read();
            }
            goto Label_01F5;
        Label_0125:
            if (this._x337e217cb3ba0627.Peek() == num)
            {
                goto Label_00A1;
            }
        Label_013A:
            if (this._x337e217cb3ba0627.Peek() != -1)
            {
                if (builder.Length <= this.MaxLength)
                {
                    num2 = this.xdd33c6adbeca0968();
                    if (num2 == 13)
                    {
                        goto Label_0160;
                    }
                    goto Label_0196;
                }
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_0181;
                }
                if ((((uint) num2) + ((uint) num)) >= 0)
                {
                    goto Label_0086;
                }
                goto Label_0125;
            }
            if ((((uint) num2) - ((uint) num)) >= 0)
            {
                goto Label_00A1;
            }
        Label_0160:
            if ((((uint) num) - ((uint) num)) >= 0)
            {
            }
        Label_0178:
            if (-1 == 0)
            {
                goto Label_0196;
            }
            goto Label_0125;
        Label_0181:
            if (0 != 0)
            {
                goto Label_0178;
            }
            goto Label_0125;
        Label_0196:
            if (num2 == 10)
            {
                goto Label_0181;
            }
            builder.Append((char) num2);
            goto Label_0125;
        Label_01F5:
            return builder.ToString();
        }

        protected void ParseTag()
        {
            StringBuilder builder;
            int num;
            int num2;
            string str;
            string str2;
            this._xffe521cc76054baf.Clear();
            goto Label_04A2;
        Label_0010:
            if (this._x337e217cb3ba0627.Peek() != -1)
            {
                str = this.ParseAttributeName();
                str2 = null;
                goto Label_00EA;
            }
            if (0x7fffffff != 0)
            {
                goto Label_003B;
            }
        Label_0023:
            if (this._x337e217cb3ba0627.Peek() != 0x3e)
            {
                goto Label_0010;
            }
        Label_003B:
            this._x337e217cb3ba0627.Read();
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                return;
            }
            if ((((uint) num2) | 0xff) != 0)
            {
                goto Label_04A2;
            }
            goto Label_0145;
        Label_0094:
            this._xffe521cc76054baf.SetAttribute(str, str2);
            goto Label_0023;
        Label_00B0:
            this.EatWhitespace();
            if (this._x337e217cb3ba0627.Peek() != 0x3d)
            {
                goto Label_0094;
            }
            this._x337e217cb3ba0627.Read();
            if ((((uint) num2) & 0) == 0)
            {
                str2 = this.ParseString();
                if (4 == 0)
                {
                    goto Label_0320;
                }
                goto Label_0094;
            }
            goto Label_0010;
        Label_00EA:
            if (str.Equals("/"))
            {
                this.EatWhitespace();
                if ((0xff != 0) && (this._x337e217cb3ba0627.Peek() != 0x3e))
                {
                    if (0 == 0)
                    {
                        goto Label_00B0;
                    }
                    goto Label_0023;
                }
            }
            else
            {
                goto Label_00B0;
            }
            this._xfa01f9cedae2093c = this._xffe521cc76054baf.Name;
            goto Label_003B;
        Label_0145:
            if (builder[0] != '/')
            {
                this._xffe521cc76054baf.Name = builder.ToString();
                this._xffe521cc76054baf.TagType = Tag.Type.Begin;
                if (4 == 0)
                {
                    goto Label_0345;
                }
            }
            else
            {
                this._xffe521cc76054baf.Name = builder.ToString().Substring(1);
                this._xffe521cc76054baf.TagType = Tag.Type.End;
            }
            goto Label_0023;
        Label_01AB:
            this.EatWhitespace();
            goto Label_0145;
        Label_01B3:
            if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_01AB;
            }
        Label_0209:
            if (this._x337e217cb3ba0627.Peek() != 0x3e)
            {
                if ((builder.Length > 0) && (this._x337e217cb3ba0627.Peek() == 0x2f))
                {
                    if ((((uint) num2) | 15) == 0)
                    {
                        goto Label_0279;
                    }
                    if (0 != 0)
                    {
                        goto Label_01B3;
                    }
                    goto Label_01AB;
                }
                builder.Append((char) this._x337e217cb3ba0627.Read());
                goto Label_028E;
            }
            if (0 != 0)
            {
                goto Label_0145;
            }
            goto Label_01AB;
        Label_0279:
            if (this._x337e217cb3ba0627.Peek("![CDATA["))
            {
                goto Label_0345;
            }
        Label_028E:
            if (this._x337e217cb3ba0627.Peek() != -1)
            {
                if (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek()) && ((((uint) num) + ((uint) num)) >= 0))
                {
                    goto Label_01B3;
                }
                goto Label_0209;
            }
            goto Label_01AB;
        Label_02C4:
            if (!this._x337e217cb3ba0627.Peek("]]"))
            {
                num2 = this._x337e217cb3ba0627.Read();
                goto Label_0320;
            }
        Label_02DC:
            this._x337e217cb3ba0627.Skip((long) "]]".Length);
            this._xffe521cc76054baf.TagType = Tag.Type.CDATA;
            this._xffe521cc76054baf.Name = builder.ToString();
            return;
        Label_0320:
            if (-2 == 0)
            {
                goto Label_00EA;
            }
            if (num2 != -1)
            {
                builder.Append((char) num2);
                if ((((uint) num2) & 0) != 0)
                {
                }
                goto Label_02C4;
            }
            goto Label_02DC;
        Label_032E:
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_0279;
            }
        Label_0345:
            this._x337e217cb3ba0627.Skip((long) "![CDATA[".Length);
            goto Label_02C4;
        Label_03C1:
            this._x337e217cb3ba0627.Skip((long) "-->".Length);
            this._xffe521cc76054baf.TagType = Tag.Type.Comment;
            this._xffe521cc76054baf.Name = builder.ToString();
            return;
        Label_03FF:
            if ((((uint) num2) | 0xfffffffe) == 0)
            {
            Label_03EB:
                if (((uint) num) > uint.MaxValue)
                {
                    while (num != -1)
                    {
                        builder.Append((char) num);
                    Label_0433:
                        if (!this._x337e217cb3ba0627.Peek("-->"))
                        {
                            num = this._x337e217cb3ba0627.Read();
                            continue;
                        }
                        goto Label_03EB;
                    }
                    goto Label_03FF;
                }
                goto Label_03C1;
            }
            if (2 != 0)
            {
                goto Label_03C1;
            }
            goto Label_032E;
        Label_04A2:
            if ((((uint) num) + ((uint) num2)) < 0)
            {
                if (0xff == 0)
                {
                    goto Label_00EA;
                }
                goto Label_00B0;
            }
            this._xfa01f9cedae2093c = null;
            builder = new StringBuilder();
            if (4 != 0)
            {
                if ((((uint) num2) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_003B;
                }
                this._x337e217cb3ba0627.Read();
                if (this._x337e217cb3ba0627.Peek("!--"))
                {
                    this._x337e217cb3ba0627.Skip((long) "!--".Length);
                    goto Label_0433;
                }
                if ((((uint) num2) | uint.MaxValue) == 0)
                {
                    goto Label_0010;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_032E;
                }
                goto Label_03C1;
            }
            goto Label_0145;
        }

        public int Read()
        {
            if (this._xfa01f9cedae2093c == null)
            {
                if (this._x86f29885f41183a5 == null)
                {
                    if (-2 == 0)
                    {
                    }
                }
                else
                {
                    if (!this.x2dcb1baab64fbe12(this._x86f29885f41183a5))
                    {
                        return this._x337e217cb3ba0627.Read();
                    }
                    this._x86f29885f41183a5 = null;
                    if (3 == 0)
                    {
                        goto Label_0022;
                    }
                    if (0xff == 0)
                    {
                        goto Label_006A;
                    }
                }
                if (this._x337e217cb3ba0627.Peek() == 60)
                {
                    goto Label_00B2;
                }
            }
            else
            {
                goto Label_0147;
            }
        Label_0022:
            if (this._x337e217cb3ba0627.Peek() != 0x26)
            {
                return this._x337e217cb3ba0627.Read();
            }
            return this.xdd33c6adbeca0968();
        Label_003B:
            if (0 == 0)
            {
                goto Label_0045;
            }
        Label_003E:
            if (15 == 0)
            {
                goto Label_004F;
            }
        Label_0045:
            return 0;
        Label_004F:
            if (!StringUtil.EqualsIgnoreCase(this._xffe521cc76054baf.Name, "style"))
            {
                goto Label_00AB;
            }
            goto Label_0081;
        Label_006A:
            if (!StringUtil.EqualsIgnoreCase(this._xffe521cc76054baf.Name, "script"))
            {
                goto Label_004F;
            }
        Label_0081:
            this._x86f29885f41183a5 = this._xffe521cc76054baf.Name.ToLower();
            goto Label_0045;
        Label_00AB:
            if (0xff != 0)
            {
                if (3 != 0)
                {
                    goto Label_003B;
                }
                goto Label_0147;
            }
        Label_00B2:
            this.ParseTag();
            if (this._xffe521cc76054baf.TagType == Tag.Type.Begin)
            {
                goto Label_006A;
            }
            if (0 == 0)
            {
                if (0 == 0)
                {
                    goto Label_003E;
                }
                if (0 != 0)
                {
                    goto Label_003B;
                }
                goto Label_004F;
            }
            goto Label_00AB;
        Label_0147:
            this._xffe521cc76054baf.Clear();
            this._xffe521cc76054baf.Name = this._xfa01f9cedae2093c;
            this._xffe521cc76054baf.TagType = Tag.Type.End;
            this._xfa01f9cedae2093c = null;
            return 0;
        }

        public bool ReadToTag()
        {
            int num;
            while ((num = this.Read()) != -1)
            {
                if (num == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (1 != 0)
            {
                builder.Append("[ReadTags: currentTag=");
                if (8 != 0)
                {
                    if ((this._xffe521cc76054baf != null) || (-2147483648 == 0))
                    {
                        goto Label_000D;
                    }
                    goto Label_0030;
                }
                if (4 == 0)
                {
                    goto Label_0058;
                }
            }
        Label_000D:
            builder.Append(this._xffe521cc76054baf.ToString());
        Label_0030:
            builder.Append("]");
        Label_0058:
            return builder.ToString();
        }

        private bool x2dcb1baab64fbe12(IEnumerable<char> xc15bd84e01929885)
        {
            bool flag;
            int depth = 0;
            if (15 != 0)
            {
                goto Label_01AB;
            }
        Label_000C:
            if (0 == 0)
            {
                goto Label_002A;
            }
        Label_000F:
            if ((((uint) depth) + ((uint) flag)) < 0)
            {
                goto Label_00C8;
            }
        Label_002A:
            using (IEnumerator<char> enumerator = xc15bd84e01929885.GetEnumerator())
            {
                goto Label_0037;
            Label_0033:
                depth++;
            Label_0037:
                if (!enumerator.MoveNext())
                {
                    if (((uint) depth) > uint.MaxValue)
                    {
                        return flag;
                    }
                }
                else
                {
                    char current = enumerator.Current;
                    while (char.ToLower((char) this._x337e217cb3ba0627.Peek(depth)) != char.ToLower(current))
                    {
                        return false;
                    }
                    if (-2147483648 != 0)
                    {
                        goto Label_0033;
                    }
                }
            }
            return true;
        Label_00AF:
            if (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek(depth)))
            {
                depth++;
            }
            else
            {
                goto Label_000F;
            }
        Label_00C8:
            if (this._x337e217cb3ba0627.Peek(depth) != -1)
            {
                goto Label_00AF;
            }
            goto Label_000C;
        Label_00E4:
            if (this._x337e217cb3ba0627.Peek(depth) != 0x2f)
            {
                return false;
            }
            depth++;
            goto Label_014A;
        Label_00FC:
            if (this._x337e217cb3ba0627.Peek(depth) == -1)
            {
                if (0 != 0)
                {
                    goto Label_01AB;
                }
                goto Label_00E4;
            }
        Label_0134:
            if (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek(depth)))
            {
                depth++;
                goto Label_00FC;
            }
            if (0 != 0)
            {
                goto Label_00FC;
            }
            if ((((uint) depth) + ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_00E4;
            }
        Label_014A:
            if (((uint) depth) >= 0)
            {
                goto Label_00C8;
            }
            if (0 != 0)
            {
                goto Label_01AB;
            }
            if (((uint) flag) < 0)
            {
                goto Label_002A;
            }
            goto Label_00AF;
        Label_0169:
            if (this._x337e217cb3ba0627.Peek(depth) != 60)
            {
                return false;
            }
            depth++;
            goto Label_00FC;
        Label_01AB:
            while (this._x337e217cb3ba0627.Peek(depth) != -1)
            {
                if (char.IsWhiteSpace((char) this._x337e217cb3ba0627.Peek(depth)))
                {
                    depth++;
                    continue;
                }
                goto Label_0169;
            }
            if ((((uint) depth) | 2) != 0)
            {
                goto Label_0169;
            }
            goto Label_0134;
        }

        private char xdd33c6adbeca0968()
        {
            int num;
            int num2;
            StringBuilder builder;
            string str;
            char ch = (char) this._x337e217cb3ba0627.Read();
            goto Label_0178;
        Label_0027:
            if (num > 0)
            {
                this.Read();
                num--;
                if (0 == 0)
                {
                    goto Label_0027;
                }
            }
            else
            {
                if (4 != 0)
                {
                    return ch;
                }
                goto Label_0178;
            }
        Label_005B:
            num = 0;
            goto Label_0027;
        Label_0077:
            ch = _xd1768ddee4fdb90a[str];
            goto Label_0027;
        Label_00D5:
            if (!char.IsWhiteSpace((char) num2))
            {
                goto Label_014E;
            }
            goto Label_00E8;
        Label_00E3:
            if ((num2 != 0x3b) && (num2 != -1))
            {
                if (0 == 0)
                {
                    goto Label_00D5;
                }
                goto Label_0105;
            }
        Label_00E8:
            str = builder.ToString().Trim().ToLower();
            if (str.Length <= 0)
            {
                num = 0;
                goto Label_0027;
            }
            if (str[0] == '#')
            {
                try
                {
                    ch = (char) int.Parse(str.Substring(1));
                }
                catch (Exception)
                {
                    num = 0;
                }
                goto Label_0027;
            }
            if (!_xd1768ddee4fdb90a.ContainsKey(str))
            {
                goto Label_005B;
            }
        Label_0105:;
            goto Label_0077;
        Label_0110:
            builder.Append((char) num2);
            goto Label_00E3;
        Label_014E:
            switch (this._x337e217cb3ba0627.Peek(num++))
            {
                case 0x26:
                case 0x3b:
                    goto Label_00E3;

                default:
                    if (!char.IsWhiteSpace((char) num2))
                    {
                        goto Label_0110;
                    }
                    if (2 == 0)
                    {
                        goto Label_00D5;
                    }
                    goto Label_00E3;
            }
        Label_0178:
            num = 0;
            if (ch == '&')
            {
                builder = new StringBuilder();
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_00E8;
                }
                goto Label_014E;
            }
            if ((((uint) num) & 0) == 0)
            {
                if (((uint) num2) >= 0)
                {
                    if (((uint) num) > uint.MaxValue)
                    {
                        goto Label_0110;
                    }
                    goto Label_0027;
                }
                goto Label_0077;
            }
            goto Label_005B;
        }

        public Tag LastTag
        {
            get
            {
                return this._xffe521cc76054baf;
            }
        }
    }
}

