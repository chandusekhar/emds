namespace Encog.Util
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class SimpleParser
    {
        private int _x4bb7150016476773;
        private int _xae56ed48d6444ef5;
        [CompilerGenerated]
        private string xcfc0aadd3a6d1f82;

        public SimpleParser(string line)
        {
            this.Line = line;
        }

        public void Advance()
        {
            if (this._x4bb7150016476773 < this.Line.Length)
            {
                this._x4bb7150016476773++;
            }
        }

        public void Advance(int p)
        {
            this._x4bb7150016476773 = Math.Min(this.Line.Length, this._x4bb7150016476773 + p);
        }

        public void EatWhiteSpace()
        {
        Label_0004:
            if (!this.EOL())
            {
                if (this.IsWhiteSpace())
                {
                    this.Advance();
                    goto Label_0004;
                }
            }
            else
            {
                return;
            }
            if (0 == 0)
            {
                return;
            }
            goto Label_0004;
        }

        public bool EOL()
        {
            return (this._x4bb7150016476773 >= this.Line.Length);
        }

        public bool IsIdentifier()
        {
            if (this.EOL())
            {
                return false;
            }
            if (!char.IsLetterOrDigit(this.Peek()))
            {
                return (this.Peek() == '_');
            }
            return true;
        }

        public bool IsWhiteSpace()
        {
            return (" \t\n\r".IndexOf(this.Peek()) != -1);
        }

        public bool LookAhead(string str, bool ignoreCase)
        {
            int num;
            char ch;
            char ch2;
            if (this.Remaining() >= str.Length)
            {
                num = 0;
            }
            else
            {
                return false;
            }
        Label_0014:
            if (num < str.Length)
            {
                ch = str[num];
                if ((((uint) num) - ((uint) ignoreCase)) > uint.MaxValue)
                {
                    goto Label_0014;
                }
            }
            else
            {
                return true;
            }
        Label_0052:
            ch2 = this.Line[this._x4bb7150016476773 + num];
            if (ignoreCase)
            {
                ch = char.ToLower(ch);
                ch2 = char.ToLower(ch2);
                if (2 == 0)
                {
                    goto Label_0052;
                }
            }
            if (ch == ch2)
            {
                num++;
                goto Label_0014;
            }
            return false;
        }

        public void Mark()
        {
            this._xae56ed48d6444ef5 = this._x4bb7150016476773;
        }

        public bool ParseThroughComma()
        {
            this.EatWhiteSpace();
            if (0 == 0)
            {
                if (this.EOL() || ((0 == 0) && (this.Peek() != ',')))
                {
                    return false;
                }
                this.Advance();
            }
            return true;
        }

        public char Peek()
        {
            if (this.EOL())
            {
                return '\0';
            }
            if (this._x4bb7150016476773 >= this.Line.Length)
            {
                return '\0';
            }
            return this.Line[this._x4bb7150016476773];
        }

        public char ReadChar()
        {
            if (this.EOL())
            {
                return '\0';
            }
            char ch = this.Peek();
            this.Advance();
            return ch;
        }

        public string ReadQuotedString()
        {
            StringBuilder builder;
            if ((this.Peek() == '"') || ((0 == 0) && (8 == 0)))
            {
                builder = new StringBuilder();
                this.Advance();
                if (4 != 0)
                {
                    while ((this.Peek() != '"') && !this.EOL())
                    {
                        builder.Append(this.ReadChar());
                    }
                    this.Advance();
                }
            }
            else
            {
                return "";
            }
            return builder.ToString();
        }

        public string ReadToWhiteSpace()
        {
            StringBuilder builder = new StringBuilder();
        Label_000A:
            if (!this.IsWhiteSpace())
            {
                if (!this.EOL())
                {
                    builder.Append(this.ReadChar());
                    goto Label_000A;
                }
            }
            else if (4 == 0)
            {
                goto Label_000A;
            }
            return builder.ToString();
        }

        public int Remaining()
        {
            return Math.Max(this.Line.Length - this._x4bb7150016476773, 0);
        }

        public void Reset()
        {
            this._x4bb7150016476773 = this._xae56ed48d6444ef5;
        }

        public string Line
        {
            [CompilerGenerated]
            get
            {
                return this.xcfc0aadd3a6d1f82;
            }
            [CompilerGenerated]
            set
            {
                this.xcfc0aadd3a6d1f82 = value;
            }
        }
    }
}

