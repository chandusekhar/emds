namespace Encog.Parse.Tags.Write
{
    using Encog;
    using Encog.Parse;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class WriteTags
    {
        private readonly IDictionary<string, string> _x233f092c536593eb;
        private readonly Stack<string> _x81bd0e59c1618ea6;
        private readonly Stream _x9c13656d94fc62d0;
        private readonly StreamWriter _xaeb8c5bcd15a6e50;

        public WriteTags(Stream output)
        {
            this._x9c13656d94fc62d0 = output;
            this._x81bd0e59c1618ea6 = new Stack<string>();
            this._x233f092c536593eb = new Dictionary<string, string>();
            this._xaeb8c5bcd15a6e50 = new StreamWriter(output);
        }

        public void AddAttribute(string name, string v)
        {
            this._x233f092c536593eb.Add(name, v);
        }

        public void AddCDATA(string text)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('<');
            builder.Append("![CDATA[");
            if (0 == 0)
            {
            }
            builder.Append(text);
            builder.Append("]]");
            builder.Append('>');
            try
            {
                this._xaeb8c5bcd15a6e50.Write(builder.ToString());
            }
            catch (IOException exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
        }

        public void AddProperty(string name, double d)
        {
            this.BeginTag(name);
            this.AddText(d);
            this.EndTag();
        }

        public void AddProperty(string name, int i)
        {
            this.AddProperty(name, i);
        }

        public void AddProperty(string name, string str)
        {
            this.BeginTag(name);
            this.AddText(str);
            this.EndTag();
        }

        public void AddProperty(string name, double[] array, int len)
        {
            if (array == null)
            {
                return;
            }
        Label_004C:
            if ((((uint) len) + ((uint) len)) <= uint.MaxValue)
            {
            }
            StringBuilder builder = new StringBuilder();
            int index = 0;
        Label_0016:
            if (index >= len)
            {
                this.AddProperty(name, builder.ToString());
                if (0xff != 0)
                {
                    return;
                }
            }
            else
            {
                if (index != 0)
                {
                    builder.Append(' ');
                }
                builder.Append(array[index]);
                index++;
                goto Label_0016;
            }
            goto Label_004C;
        }

        public void AddProperty(string name, int[] array, int len)
        {
            StringBuilder builder;
            int num;
            if (array == null)
            {
                return;
            }
            goto Label_0056;
        Label_0008:
            if (num < len)
            {
                goto Label_0026;
            }
        Label_000C:
            this.AddProperty(name, builder.ToString());
            if ((((uint) num) + ((uint) len)) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                    return;
                }
                goto Label_0056;
            }
        Label_0026:
            if (num != 0)
            {
                builder.Append(' ');
            }
            builder.Append(array[num]);
            num++;
            goto Label_0008;
        Label_0056:
            if ((((uint) len) + ((uint) num)) < 0)
            {
                goto Label_000C;
            }
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0056;
            }
            builder = new StringBuilder();
            num = 0;
            goto Label_0008;
        }

        public void AddText(string text)
        {
            try
            {
                this._xaeb8c5bcd15a6e50.Write(text);
            }
            catch (IOException exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
        }

        public void BeginDocument()
        {
        }

        public void BeginTag(string name)
        {
            StringBuilder builder = new StringBuilder();
        Label_0025:
            builder.Append("<");
            builder.Append(name);
            if (0 != 0)
            {
                goto Label_0025;
            }
            if (this._x233f092c536593eb.Count > 0)
            {
                using (IEnumerator<string> enumerator = this._x233f092c536593eb.Keys.GetEnumerator())
                {
                    string str;
                    string str2;
                    goto Label_006D;
                Label_0061:
                    builder.Append("\"");
                Label_006D:
                    if (enumerator.MoveNext())
                    {
                        goto Label_00B5;
                    }
                    goto Label_00D0;
                Label_0078:
                    str2 = this._x233f092c536593eb[str];
                    builder.Append(' ');
                    builder.Append(str);
                    builder.Append('=');
                    builder.Append("\"");
                    builder.Append(str2);
                    goto Label_00BF;
                Label_00B5:
                    str = enumerator.Current;
                    goto Label_0078;
                Label_00BF:
                    if (0 == 0)
                    {
                        goto Label_0061;
                    }
                }
            }
        Label_00D0:
            builder.Append(">");
            try
            {
                this._xaeb8c5bcd15a6e50.Write(builder.ToString());
            }
            catch (IOException exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
            this._x233f092c536593eb.Clear();
            this._x81bd0e59c1618ea6.Push(name);
            if (0 == 0)
            {
                return;
            }
            goto Label_0025;
        }

        public void Close()
        {
            try
            {
                this._x9c13656d94fc62d0.Close();
            }
            catch (Exception exception)
            {
                throw new EncogError(exception);
            }
        }

        public void EndDocument()
        {
            this._xaeb8c5bcd15a6e50.Flush();
        }

        public void EndTag()
        {
            string str;
            StringBuilder builder;
            if (this._x81bd0e59c1618ea6.Count >= 1)
            {
                str = this._x81bd0e59c1618ea6.Pop();
                builder = new StringBuilder();
                if (-1 == 0)
                {
                    goto Label_0053;
                }
            }
            else if (0 == 0)
            {
                goto Label_0053;
            }
            builder.Append("</");
            builder.Append(str);
            builder.Append(">");
            try
            {
                this._xaeb8c5bcd15a6e50.Write(builder.ToString());
                return;
            }
            catch (IOException exception)
            {
                throw new Encog.Parse.ParseError(exception);
            }
            if (8 != 0)
            {
                return;
            }
        Label_0053:
            throw new Encog.Parse.ParseError("Can't create end tag, no beginning tag.");
        }

        public void EndTag(string name)
        {
            if (this._x81bd0e59c1618ea6.Peek().Equals(name))
            {
                this.EndTag();
            }
            else
            {
                string[] strArray = new string[5];
                if (0 == 0)
                {
                    strArray[0] = "End tag mismatch, should be ending: ";
                    strArray[1] = this._x81bd0e59c1618ea6.Peek();
                    strArray[2] = ", but trying to end: ";
                    strArray[3] = name;
                    strArray[4] = ".";
                }
                throw new Encog.Parse.ParseError(string.Concat(strArray));
            }
        }
    }
}

