namespace Encog.App.Analyst.Util
{
    using Encog.App.Analyst;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class CSVHeaders
    {
        private readonly IList<string> _x36c9f86d45fbd962;
        private readonly IDictionary<string, int> _x5f81ddd16c23e357;
        [CompilerGenerated]
        private static Func<string, string> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<string, bool> x3ea1037ccf291a94;
        [CompilerGenerated]
        private static Func<string, int> xec790bb6d0304faa;

        public CSVHeaders(IEnumerable<string> inputHeadings)
        {
            this._x36c9f86d45fbd962 = new List<string>();
            this._x5f81ddd16c23e357 = new Dictionary<string, int>();
            foreach (string str in inputHeadings)
            {
                this._x36c9f86d45fbd962.Add(str);
            }
            this.xd586e0c16bdae7fc();
        }

        public CSVHeaders(FileInfo filename, bool headers, CSVFormat format)
        {
            this._x36c9f86d45fbd962 = new List<string>();
            this._x5f81ddd16c23e357 = new Dictionary<string, int>();
            ReadCSV dcsv = null;
            try
            {
                int num;
                dcsv = new ReadCSV(filename.ToString(), headers, format);
                if (2 != 0)
                {
                    goto Label_00D4;
                }
                goto Label_0098;
            Label_003B:
                if (num < dcsv.ColumnCount)
                {
                    goto Label_004E;
                }
            Label_0044:
                this.xd586e0c16bdae7fc();
                return;
            Label_004E:
                this._x36c9f86d45fbd962.Add("field:" + (num + 1));
                num++;
                goto Label_003B;
            Label_0071:
                if (headers)
                {
                    goto Label_0098;
                }
                goto Label_008B;
                if (0 != 0)
                {
                    goto Label_0071;
                }
                if (((uint) headers) <= uint.MaxValue)
                {
                }
            Label_008B:
                num = 0;
                if (0 != 0)
                {
                }
                goto Label_003B;
            Label_0098:
                foreach (string str in dcsv.ColumnNames)
                {
                    this._x36c9f86d45fbd962.Add(str);
                }
                goto Label_0044;
            Label_00D4:
                if ((-2147483648 != 0) && !dcsv.Next())
                {
                    goto Label_0044;
                }
                goto Label_0071;
            }
            finally
            {
                if (dcsv != null)
                {
                    dcsv.Close();
                }
            }
        }

        public int Find(string name)
        {
            string key = name.ToLower();
            if (!this._x5f81ddd16c23e357.ContainsKey(key))
            {
                throw new AnalystError("Can't find column: " + name.ToLower());
            }
            return this._x5f81ddd16c23e357[key];
        }

        public string GetBaseHeader(int index)
        {
            string str = this._x36c9f86d45fbd962[index];
            int length = str.IndexOf('(');
            if ((0 != 0) || (length != -1))
            {
                str = str.Substring(0, length);
            }
            return str.Trim();
        }

        public string GetHeader(int index)
        {
            return this._x36c9f86d45fbd962[index];
        }

        public int GetSlice(int currentIndex)
        {
            int num;
            int index;
            string str3;
            int num4;
            string[] strArray2;
            int num5;
            string str = this._x36c9f86d45fbd962[currentIndex];
            if (0 == 0)
            {
                num = str.IndexOf('(');
                goto Label_0141;
            }
            goto Label_0075;
        Label_003E:
            if (num5 < strArray2.Length)
            {
                str3 = strArray2[num5];
            }
            else
            {
                if (0 == 0)
                {
                    return 0;
                }
                return num4;
            }
        Label_0075:
            if (((uint) currentIndex) > uint.MaxValue)
            {
                goto Label_013F;
            }
            if (!str3.Trim().ToLower().StartsWith("t"))
            {
                num5++;
                goto Label_003E;
            }
            string s = str3.Trim().Substring(1).Trim();
            if (s[0] == '+')
            {
                s = s.Substring(1);
            }
            return int.Parse(s);
        Label_00F7:;
            strArray2 = str.Substring(num + 1, index - (num + 1)).Split(new char[] { ',' });
            num5 = 0;
            if (0 != 0)
            {
                goto Label_0141;
            }
            goto Label_003E;
        Label_0122:
            if (index < num)
            {
                return 0;
            }
            goto Label_00F7;
        Label_013F:
            return 0;
        Label_0141:
            if (num == -1)
            {
                goto Label_013F;
            }
            index = str.IndexOf(')');
            if ((((uint) index) + ((uint) currentIndex)) <= uint.MaxValue)
            {
                if (index == -1)
                {
                    return 0;
                }
                goto Label_0122;
            }
            if ((((uint) index) - ((uint) num4)) < 0)
            {
                goto Label_0122;
            }
            goto Label_00F7;
        }

        public static int ParseTimeSlice(string name)
        {
            int num2;
            string str;
            int index = name.IndexOf('(');
            if (0 == 0)
            {
                goto Label_00A2;
            }
        Label_0034:
            str = name.Substring(index + 1, num2 - (index + 1));
            string[] source = str.Split(new char[] { ',' });
            if (-2147483648 != 0)
            {
                if (x1ecac4c96d3f3733 == null)
                {
                    x1ecac4c96d3f3733 = new Func<string, string>(CSVHeaders.x3e30cb03ff05d597);
                }
                if (x3ea1037ccf291a94 == null)
                {
                    x3ea1037ccf291a94 = new Func<string, bool>(CSVHeaders.x930bfcf4581beee5);
                }
                if (xec790bb6d0304faa == null)
                {
                    xec790bb6d0304faa = new Func<string, int>(CSVHeaders.x512e50e9ebf06cf6);
                }
                return source.Select<string, string>(x1ecac4c96d3f3733).Where<string>(x3ea1037ccf291a94).Select<string, int>(xec790bb6d0304faa).FirstOrDefault<int>();
            }
            goto Label_00A2;
        Label_0045:
            if (num2 >= index)
            {
                goto Label_0034;
            }
        Label_0063:
            return 0;
        Label_00A2:
            if (index == -1)
            {
                return 0;
            }
            num2 = name.IndexOf(')');
            while (num2 == -1)
            {
                return 0;
            Label_0072:
                if (15 != 0)
                {
                    goto Label_0045;
                }
            }
            if ((((uint) num2) - ((uint) index)) < 0)
            {
                goto Label_0072;
            }
            if ((((uint) index) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0045;
            }
            goto Label_0063;
        }

        public int Size()
        {
            return this._x36c9f86d45fbd962.Count;
        }

        public static string TagColumn(string name, int part, int timeSlice, bool multiPart)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name);
            if (((uint) timeSlice) < 0)
            {
                if (0x7fffffff == 0)
                {
                    goto Label_00EC;
                }
                goto Label_0011;
            }
        Label_000B:
            if (multiPart)
            {
                goto Label_00EC;
            }
        Label_0011:
            if (timeSlice != 0)
            {
                goto Label_00EC;
            }
            if ((((uint) part) - ((uint) multiPart)) >= 0)
            {
                goto Label_0155;
            }
        Label_0043:
            builder.Append(timeSlice);
        Label_004B:
            builder.Append(')');
            if (((uint) timeSlice) <= uint.MaxValue)
            {
                if (1 == 0)
                {
                    goto Label_009A;
                }
                goto Label_0155;
            }
            goto Label_000B;
        Label_006D:
            builder.Append('t');
            if (timeSlice > 0)
            {
                builder.Append('+');
                if ((((uint) multiPart) & 0) == 0)
                {
                    goto Label_0122;
                }
                if (8 == 0)
                {
                    goto Label_00A5;
                }
                if ((((uint) multiPart) & 0) == 0)
                {
                    goto Label_000B;
                }
                goto Label_00EC;
            }
            goto Label_0043;
        Label_009A:
            builder.Append(part);
        Label_00A2:
            if (timeSlice == 0)
            {
                goto Label_004B;
            }
        Label_00A5:
            if (!multiPart)
            {
                goto Label_006D;
            }
            builder.Append(',');
            if ((((uint) multiPart) + ((uint) timeSlice)) < 0)
            {
                goto Label_0011;
            }
            goto Label_011C;
        Label_00EC:
            builder.Append('(');
            if (!multiPart)
            {
                goto Label_00A2;
            }
            builder.Append('p');
            if ((((uint) timeSlice) - ((uint) timeSlice)) <= uint.MaxValue)
            {
                goto Label_009A;
            }
        Label_011C:
            if (0 == 0)
            {
                goto Label_006D;
            }
        Label_0122:
            if (0 == 0)
            {
                goto Label_0043;
            }
        Label_0155:
            return builder.ToString();
        }

        [CompilerGenerated]
        private static string x3e30cb03ff05d597(string x9b4602d5e4f04fcb)
        {
            return x9b4602d5e4f04fcb.Trim();
        }

        [CompilerGenerated]
        private static int x512e50e9ebf06cf6(string xf6987a1745781d6f)
        {
            return int.Parse(xf6987a1745781d6f.Substring(1));
        }

        [CompilerGenerated]
        private static bool x930bfcf4581beee5(string xf6987a1745781d6f)
        {
            return xf6987a1745781d6f.ToLower().StartsWith("t");
        }

        private void x9437465b343430ed()
        {
            <>c__DisplayClass8 class2;
            int num = 0;
        Label_0007:
            if (num < this._x36c9f86d45fbd962.Count)
            {
                int i1;
                int i2;
                goto Label_0139;
            }
            return;
        Label_001C:
            if (this._x36c9f86d45fbd962.Count > i2)
            {
                goto Label_0071;
            }
        Label_0038:
            if ((((uint) num) | 0x7fffffff) == 0)
            {
                goto Label_0071;
            }
        Label_0053:
            num++;
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                goto Label_0007;
            }
            return;
        Label_0071:
            if (this._x36c9f86d45fbd962.Where<string>(new Func<string, int, bool>(class2.<ValidateSameName>b__6)).Any<string>(new Func<string, bool>(class2.<ValidateSameName>b__7)))
            {
                throw new AnalystError("Multiple fields named: " + this._x36c9f86d45fbd962[num]);
            }
            if (-1 != 0)
            {
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_0139;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_0053;
                }
                if (3 == 0)
                {
                    goto Label_001C;
                }
                goto Label_0038;
            }
        Label_00FB:
            if (-2 != 0)
            {
                goto Label_001C;
            }
            goto Label_0038;
        Label_0139:;
            if (8 == 0)
            {
                goto Label_00FB;
            }
            i1 = num;
            i2 = num;
            if (((uint) num) >= 0)
            {
                goto Label_001C;
            }
            if (0 == 0)
            {
                goto Label_0071;
            }
            goto Label_0007;
        }

        private void xd586e0c16bdae7fc()
        {
            int num = 0;
            foreach (string str in this._x36c9f86d45fbd962)
            {
                this._x5f81ddd16c23e357[str.ToLower()] = num++;
            }
            this.x9437465b343430ed();
        }

        public IList<string> Headers
        {
            get
            {
                return this._x36c9f86d45fbd962;
            }
        }
    }
}

