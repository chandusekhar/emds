namespace Encog.Persist
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Matrices;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EncogFileSection
    {
        private readonly IList<string> _x0383ec486664fa18 = new List<string>();
        private readonly string _x2e150ee07990e32a;
        private readonly string _x7b699cfc8e28e0ea;

        public EncogFileSection(string theSectionName, string theSubSectionName)
        {
            this._x2e150ee07990e32a = theSectionName;
            this._x7b699cfc8e28e0ea = theSubSectionName;
        }

        public static IActivationFunction ParseActivationFunction(IDictionary<string, string> paras, string name)
        {
            IActivationFunction function2;
            try
            {
                IActivationFunction function;
                string[] strArray;
                int num;
                string str = paras[name];
                goto Label_003F;
            Label_000C:
                function.Params[num] = CSVFormat.EgFormat.Parse(strArray[num + 1]);
                num++;
            Label_002B:
                if (num < function.ParamNames.Length)
                {
                    goto Label_000C;
                }
                if (0 == 0)
                {
                    return function;
                }
            Label_003F:
                if (str == null)
                {
                    throw new PersistError("Missing property: " + name);
                }
                strArray = str.Split(new char[] { '|' });
                string str2 = "Encog.Engine.Network.Activation." + strArray[0];
                try
                {
                    function = (IActivationFunction) ReflectionUtil.LoadObject(str2);
                }
                catch (Exception exception)
                {
                    throw new PersistError(exception);
                }
                num = 0;
                goto Label_002B;
            }
            catch (Exception exception2)
            {
                throw new PersistError(exception2);
            }
            return function2;
        }

        public static bool ParseBoolean(IDictionary<string, string> paras, string name)
        {
            string str = null;
            bool flag;
            try
            {
                str = paras[name];
                while (str == null)
                {
                    throw new PersistError("Missing property: " + name);
                }
                if (15 != 0)
                {
                }
                flag = str.Trim().ToLower()[0] == 't';
            }
            catch (FormatException)
            {
                throw new PersistError("Field: " + name + ", invalid integer: " + str);
            }
            return flag;
        }

        public static double ParseDouble(IDictionary<string, string> paras, string name)
        {
            string str = null;
            double num;
            try
            {
                str = paras[name];
                if (str == null)
                {
                    throw new PersistError("Missing property: " + name);
                }
                num = CSVFormat.EgFormat.Parse(str);
            }
            catch (FormatException)
            {
                throw new PersistError("Field: " + name + ", invalid integer: " + str);
            }
            return num;
        }

        public static double[] ParseDoubleArray(IDictionary<string, string> paras, string name)
        {
            string str = null;
            double[] numArray;
            try
            {
                str = paras[name];
                if (str == null)
                {
                    throw new PersistError("Missing property: " + name);
                }
                numArray = NumberList.FromList(CSVFormat.EgFormat, str);
            }
            catch (FormatException)
            {
                throw new PersistError("Field: " + name + ", invalid integer: " + str);
            }
            return numArray;
        }

        public static int ParseInt(IDictionary<string, string> paras, string name)
        {
            string s = null;
            int num;
            try
            {
                s = paras[name];
                goto Label_0077;
            Label_000C:
                return int.Parse(s);
            Label_001A:
                if ((((uint) num) | 0xff) == 0)
                {
                    goto Label_007D;
                }
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_001A;
                }
                goto Label_009B;
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_007D;
                }
            Label_0077:
                if (s == null)
                {
                    throw new PersistError("Missing property: " + name);
                }
                if (0 == 0)
                {
                    goto Label_001A;
                }
            Label_007D:
                if (0 != 0)
                {
                    goto Label_0077;
                }
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_000C;
                }
            Label_009B:
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_000C;
                }
            }
            catch (FormatException)
            {
                throw new PersistError("Field: " + name + ", invalid integer: " + s);
            }
            return num;
        }

        public static int[] ParseIntArray(IDictionary<string, string> paras, string name)
        {
            string str = null;
            int[] numArray;
            try
            {
                str = paras[name];
                goto Label_0034;
            Label_000E:
                if (str == null)
                {
                    goto Label_003B;
                }
                if (15 == 0)
                {
                    if (8 == 0)
                    {
                        goto Label_000E;
                    }
                    if (2 == 0)
                    {
                        return numArray;
                    }
                }
                return NumberList.FromListInt(CSVFormat.EgFormat, str);
            Label_0034:
                if (0x7fffffff != 0)
                {
                    goto Label_000E;
                }
            Label_003B:
                throw new PersistError("Missing property: " + name);
                if (8 != 0)
                {
                    goto Label_000E;
                }
            }
            catch (FormatException)
            {
                throw new PersistError("Field: " + name + ", invalid integer: " + str);
            }
            return numArray;
        }

        public static Matrix ParseMatrix(IDictionary<string, string> paras, string name)
        {
            string str;
            double[] numArray;
            int num;
            int num2;
            Matrix matrix;
            int num3;
            int num4;
            int num5;
            if (paras.ContainsKey(name))
            {
                goto Label_00C3;
            }
            throw new PersistError("Missing property: " + name);
        Label_0017:
            if (num4 < num)
            {
                num5 = 0;
            }
            else
            {
                if ((((uint) num5) & 0) == 0)
                {
                    return matrix;
                }
                goto Label_00C3;
            }
        Label_0021:
            if (num5 < num2)
            {
                matrix[num4, num5] = numArray[num3++];
                if ((((uint) num) + ((uint) num5)) <= uint.MaxValue)
                {
                    num5++;
                    goto Label_0021;
                }
            }
            else
            {
                num4++;
                goto Label_0017;
            }
        Label_0067:
            if (((uint) num3) <= uint.MaxValue)
            {
                num3 = 2;
                num4 = 0;
                goto Label_0017;
            }
        Label_00C3:
            str = paras[name];
            numArray = NumberList.FromList(CSVFormat.EgFormat, str);
            num = (int) numArray[0];
            num2 = (int) numArray[1];
            matrix = new Matrix(num, num2);
            if (((uint) num5) < 0)
            {
                goto Label_0021;
            }
            goto Label_0067;
        }

        public IDictionary<string, string> ParseParams()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            using (IEnumerator<string> enumerator = this._x0383ec486664fa18.GetEnumerator())
            {
                string str;
                string str2;
                int num;
                string str3;
                goto Label_0020;
            Label_0017:
                if (str2.Length > 0)
                {
                    goto Label_007B;
                }
            Label_0020:
                if (enumerator.MoveNext())
                {
                    goto Label_00AF;
                }
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    return dictionary;
                }
            Label_0044:
                str3 = str2.Substring(0, num).Trim();
                string str4 = str2.Substring(num + 1).Trim();
                dictionary[str3] = str4;
                goto Label_0020;
            Label_0073:
                if (num == -1)
                {
                    goto Label_009C;
                }
                goto Label_0044;
            Label_007B:
                num = str2.IndexOf('=');
                if ((((uint) num) - ((uint) num)) >= 0)
                {
                    goto Label_0073;
                }
            Label_009C:
                throw new EncogError("Invalid setup item: " + str);
            Label_00AF:
                str = enumerator.Current;
                if (-2 == 0)
                {
                    return dictionary;
                }
                str2 = str.Trim();
                goto Label_0017;
            }
        }

        public static IList<string> SplitColumns(string line)
        {
            string str2;
            string[] strArray2;
            int num;
            IList<string> list = new List<string>();
            goto Label_00C4;
        Label_000B:
            if (num < strArray2.Length)
            {
                str2 = strArray2[num].Trim();
                if (str2.Length <= 0)
                {
                    goto Label_002A;
                }
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_004B;
                }
                goto Label_00C4;
            }
            return list;
        Label_002A:
            list.Add(str2);
            num++;
            if ((((uint) num) & 0) == 0)
            {
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    return list;
                }
                goto Label_000B;
            }
        Label_004B:
            if (str2[0] == '"')
            {
                str2 = str2.Substring(1);
                if (str2.EndsWith("\""))
                {
                    str2 = str2.Substring(0, str2.Length - 1);
                }
            }
            goto Label_002A;
        Label_00C4:;
            strArray2 = line.Split(new char[] { ',' });
            if (0 == 0)
            {
                num = 0;
                goto Label_000B;
            }
            goto Label_004B;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
                builder.Append(base.GetType().Name);
                if (0 != 0)
                {
                    goto Label_001A;
                }
            }
            builder.Append(" sectionName=");
        Label_001A:
            builder.Append(this._x2e150ee07990e32a);
            builder.Append(", subSectionName=");
            builder.Append(this._x7b699cfc8e28e0ea);
            builder.Append("]");
            return builder.ToString();
        }

        public IList<string> Lines
        {
            get
            {
                return this._x0383ec486664fa18;
            }
        }

        public string LinesAsString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (string str in this._x0383ec486664fa18)
                {
                    builder.Append(str);
                    builder.Append("\n");
                }
                return builder.ToString();
            }
        }

        public string SectionName
        {
            get
            {
                return this._x2e150ee07990e32a;
            }
        }

        public string SubSectionName
        {
            get
            {
                return this._x7b699cfc8e28e0ea;
            }
        }
    }
}

