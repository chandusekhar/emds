namespace Encog.Util.CSV
{
    using Encog;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class ReadCSV
    {
        private char _x150fef4785a04465;
        private readonly IDictionary<string, int> _x26c511b92db96554;
        private readonly IList<string> _x44b48f93f08f9199;
        private string[] _x4a3f0a05c02f235f;
        private CSVFormat _x5786461d089b10a0;
        private readonly TextReader _xe134235b3526fa75;
        [CompilerGenerated]
        private string x71c6cc46dd765ef8;
        [CompilerGenerated]
        private string xd9b2bb320951fa32;

        public ReadCSV(Stream stream, bool headers, CSVFormat format)
        {
            this._x44b48f93f08f9199 = new List<string>();
            this._x26c511b92db96554 = new Dictionary<string, int>();
            this._xe134235b3526fa75 = new StreamReader(stream);
            this.x5e9e6297e1dda8c2(headers, format);
        }

        public ReadCSV(Stream istream, bool headers, char delim)
        {
            this._x44b48f93f08f9199 = new List<string>();
            this._x26c511b92db96554 = new Dictionary<string, int>();
            CSVFormat format = new CSVFormat(CSVFormat.DecimalCharacter, delim);
            this._xe134235b3526fa75 = new StreamReader(istream);
            this._x150fef4785a04465 = delim;
            this.x5e9e6297e1dda8c2(headers, format);
        }

        public ReadCSV(string filename, bool headers, CSVFormat format)
        {
            this._x44b48f93f08f9199 = new List<string>();
            this._x26c511b92db96554 = new Dictionary<string, int>();
            this._xe134235b3526fa75 = new StreamReader(filename);
            this.x5e9e6297e1dda8c2(headers, format);
        }

        public ReadCSV(string filename, bool headers, char delim)
        {
            this._x44b48f93f08f9199 = new List<string>();
            this._x26c511b92db96554 = new Dictionary<string, int>();
            CSVFormat format = new CSVFormat(CSVFormat.DecimalCharacter, delim);
            this._xe134235b3526fa75 = new StreamReader(filename);
            this._x150fef4785a04465 = delim;
            this.x5e9e6297e1dda8c2(headers, format);
        }

        public void Close()
        {
            try
            {
                this._xe134235b3526fa75.Close();
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public string Get(int i)
        {
            return this._x4a3f0a05c02f235f[i];
        }

        public string Get(string column)
        {
            if (!this._x26c511b92db96554.ContainsKey(column.ToLower()))
            {
                return null;
            }
            int index = this._x26c511b92db96554[column.ToLower()];
            return this._x4a3f0a05c02f235f[index];
        }

        public int GetCount()
        {
            if (this._x4a3f0a05c02f235f == null)
            {
                return 0;
            }
            return this._x4a3f0a05c02f235f.Length;
        }

        public DateTime GetDate(int column)
        {
            return DateTime.ParseExact(this.Get(column), this.DateFormat, CultureInfo.InvariantCulture);
        }

        public DateTime GetDate(string column)
        {
            return DateTime.ParseExact(this.Get(column), this.DateFormat, CultureInfo.InvariantCulture);
        }

        public double GetDouble(int column)
        {
            string str = this.Get(column);
            return this._x5786461d089b10a0.Parse(str);
        }

        public double GetDouble(string column)
        {
            string str = this.Get(column);
            return this._x5786461d089b10a0.Parse(str);
        }

        public int GetInt(string col)
        {
            string s = this.Get(col);
            try
            {
                return int.Parse(s);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public DateTime GetTime(int column)
        {
            return DateTime.ParseExact(this.Get(column), this.TimeFormat, CultureInfo.InvariantCulture);
        }

        public DateTime GetTime(string column)
        {
            return DateTime.ParseExact(this.Get(column), this.TimeFormat, CultureInfo.InvariantCulture);
        }

        public bool HasMissing()
        {
            string str;
            int index = 0;
        Label_0014:
            if (index < this._x4a3f0a05c02f235f.Length)
            {
                str = this._x4a3f0a05c02f235f[index].Trim();
                if (-2147483648 != 0)
                {
                    goto Label_0026;
                }
                goto Label_002E;
            }
            if (0 == 0)
            {
                return false;
            }
        Label_0026:
            if (str.Length == 0)
            {
                goto Label_004B;
            }
        Label_002E:
            if (!str.Equals("?"))
            {
                if (2 == 0)
                {
                    if (2 != 0)
                    {
                        goto Label_0014;
                    }
                    if (15 == 0)
                    {
                        goto Label_002E;
                    }
                }
                index++;
                goto Label_0014;
            }
        Label_004B:
            return true;
        }

        public bool Next()
        {
            bool flag;
            try
            {
                string str;
                IList<string> list;
            Label_0000:
                str = this._xe134235b3526fa75.ReadLine();
                goto Label_00DC;
            Label_0011:
                if (this._x4a3f0a05c02f235f == null)
                {
                    goto Label_009E;
                }
                if (((uint) flag) < 0)
                {
                    goto Label_0038;
                }
            Label_002E:
                list = this.x1f490eac106aee12(str);
                int num = 0;
            Label_0038:
                foreach (string str2 in list)
                {
                    if (num < this._x4a3f0a05c02f235f.Length)
                    {
                        this._x4a3f0a05c02f235f[num++] = str2;
                    }
                }
                return true;
            Label_0086:
                if (str == null)
                {
                    goto Label_00BD;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_0011;
                }
            Label_009E:
                this.x1b1a26735fdf0f31(str);
                goto Label_002E;
            Label_00AC:
                if (str != null)
                {
                    goto Label_0103;
                }
                if (-2147483648 == 0)
                {
                    return flag;
                }
                if (-2147483648 != 0)
                {
                    goto Label_0086;
                }
            Label_00BD:
                return false;
                if ((((uint) num) - ((uint) flag)) > uint.MaxValue)
                {
                }
                goto Label_0011;
            Label_00DC:
                if (((uint) flag) < 0)
                {
                    goto Label_0011;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_00AC;
                }
            Label_0103:
                if (str.Trim().Length == 0)
                {
                    goto Label_0000;
                }
                goto Label_0086;
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
            return flag;
        }

        public static DateTime ParseDate(string when, string dateFormat)
        {
            try
            {
                return DateTime.ParseExact(when, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return new DateTime();
            }
        }

        private void x1b1a26735fdf0f31(string x311e7a92306d7199)
        {
            IList<string> list = this.x1f490eac106aee12(x311e7a92306d7199);
            this._x4a3f0a05c02f235f = new string[list.Count];
        }

        private IList<string> x1f490eac106aee12(string x311e7a92306d7199)
        {
            if (this.Format.Separator == ' ')
            {
                return x5dc02619c7b497cb(x311e7a92306d7199);
            }
            return this.xc9abdba3fd865542(x311e7a92306d7199);
        }

        private static List<string> x5dc02619c7b497cb(string x311e7a92306d7199)
        {
            List<string> list = new List<string>();
            SimpleParser parser = new SimpleParser(x311e7a92306d7199);
            if (0 == 0)
            {
                goto Label_0036;
            }
        Label_0012:
            list.Add((parser.Peek() == '"') ? parser.ReadQuotedString() : parser.ReadToWhiteSpace());
            parser.EatWhiteSpace();
        Label_0036:
            if (!parser.EOL())
            {
                goto Label_0012;
            }
            return list;
        }

        private void x5e9e6297e1dda8c2(bool x94e6ca5ac178dbd0, CSVFormat x5786461d089b10a0)
        {
            try
            {
                int num;
                this.DateFormat = "yyyy-MM-dd";
                goto Label_00ED;
            Label_0010:
                this._x4a3f0a05c02f235f = null;
                return;
            Label_001C:
                if (x94e6ca5ac178dbd0)
                {
                    string str = this._xe134235b3526fa75.ReadLine();
                    IList<string> list = this.x1f490eac106aee12(str);
                    if (0 != 0)
                    {
                        goto Label_001C;
                    }
                    num = 0;
                    using (IEnumerator<string> enumerator = list.GetEnumerator())
                    {
                        string current;
                        goto Label_0067;
                    Label_0042:
                        this._x26c511b92db96554.Add(current.ToLower(), num++);
                        if (0 != 0)
                        {
                            goto Label_0010;
                        }
                        this._x44b48f93f08f9199.Add(current);
                    Label_0067:
                        if (enumerator.MoveNext() || (((uint) num) < 0))
                        {
                            current = enumerator.Current;
                            while (this._x26c511b92db96554.ContainsKey(current.ToLower()))
                            {
                                throw new EncogError("Two columns cannot have the same name");
                            }
                            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                            {
                                goto Label_0042;
                            }
                        }
                    }
                }
                goto Label_0010;
            Label_00DA:
                this._x5786461d089b10a0 = x5786461d089b10a0;
                goto Label_001C;
            Label_00ED:
                this.TimeFormat = "hhmmss";
                if ((((uint) x94e6ca5ac178dbd0) + ((uint) num)) >= 0)
                {
                    goto Label_00DA;
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        internal long x63dbc74d4bb75204(int xf0476e906b9d9af4)
        {
            string s = this.Get(xf0476e906b9d9af4);
            try
            {
                return long.Parse(s);
            }
            catch (FormatException)
            {
                return 0L;
            }
        }

        private IList<string> xc9abdba3fd865542(string x311e7a92306d7199)
        {
            char ch;
            string str2;
            StringBuilder builder = new StringBuilder();
            List<string> list = new List<string>();
            bool flag = false;
            bool flag2 = false;
            int num = 0;
            goto Label_0105;
        Label_000B:
            if (builder.Length > 0)
            {
                str2 = builder.ToString();
                if (!flag2)
                {
                    str2 = str2.Trim();
                }
            }
            else
            {
                return list;
            }
        Label_0054:
            list.Add(str2);
            if (((((uint) flag) & 0) == 0) && ((((uint) flag2) + ((uint) flag2)) >= 0))
            {
                if ((((uint) flag2) | 0xfffffffe) == 0)
                {
                    if ((((uint) flag2) + ((uint) num)) > uint.MaxValue)
                    {
                        goto Label_0157;
                    }
                    goto Label_012B;
                }
                if ((((uint) flag) + ((uint) num)) >= 0)
                {
                    return list;
                }
            }
            else
            {
                goto Label_000B;
            }
        Label_00A9:
            if ((((uint) flag2) & 0) != 0)
            {
                goto Label_0157;
            }
            if ((((uint) flag2) - ((uint) num)) < 0)
            {
                goto Label_015F;
            }
        Label_00DB:
            builder.Append(ch);
            if ((((uint) num) - ((uint) flag2)) > uint.MaxValue)
            {
                goto Label_0054;
            }
        Label_00FF:
            num++;
        Label_0105:
            if (num < x311e7a92306d7199.Length)
            {
                ch = x311e7a92306d7199[num];
                if (((ch == this.Format.Separator) || ((((uint) flag) - ((uint) flag)) > uint.MaxValue)) && !flag)
                {
                    string item = builder.ToString();
                    if (!flag2)
                    {
                        item = item.Trim();
                        if (0x7fffffff != 0)
                        {
                            if (0 != 0)
                            {
                                return list;
                            }
                        }
                        else
                        {
                            goto Label_01F7;
                        }
                    }
                    list.Add(item);
                    builder.Length = 0;
                    goto Label_01F7;
                }
                goto Label_0157;
            }
            goto Label_000B;
        Label_012B:
            if (ch != '"')
            {
                goto Label_00DB;
            }
            if (builder.Length == 0)
            {
                flag2 = true;
                flag = true;
                if ((((uint) num) + ((uint) flag2)) > uint.MaxValue)
                {
                }
                goto Label_00FF;
            }
            if (((uint) flag2) >= 0)
            {
                goto Label_00A9;
            }
            goto Label_01F7;
        Label_0157:
            if (ch != '"')
            {
                goto Label_012B;
            }
        Label_015F:
            if (flag)
            {
                flag = false;
            }
            else if (((((uint) flag2) - ((uint) flag2)) <= uint.MaxValue) && (1 != 0))
            {
                goto Label_012B;
            }
            goto Label_00FF;
        Label_01F7:
            flag = false;
            flag2 = false;
            goto Label_00FF;
        }

        public int ColumnCount
        {
            get
            {
                if (this._x4a3f0a05c02f235f == null)
                {
                    return 0;
                }
                return this._x4a3f0a05c02f235f.Length;
            }
        }

        public IList<string> ColumnNames
        {
            get
            {
                return this._x44b48f93f08f9199;
            }
        }

        public string DateFormat
        {
            [CompilerGenerated]
            get
            {
                return this.xd9b2bb320951fa32;
            }
            [CompilerGenerated]
            set
            {
                this.xd9b2bb320951fa32 = value;
            }
        }

        public CSVFormat Format
        {
            get
            {
                return this._x5786461d089b10a0;
            }
        }

        public string TimeFormat
        {
            [CompilerGenerated]
            get
            {
                return this.x71c6cc46dd765ef8;
            }
            [CompilerGenerated]
            set
            {
                this.x71c6cc46dd765ef8 = value;
            }
        }
    }
}

