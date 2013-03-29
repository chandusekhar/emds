namespace Encog.App.Analyst.Script.Prop
{
    using Encog;
    using Encog.App.Analyst;
    using Encog.Util.CSV;
    using Encog.Util.File;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public sealed class PropertyConstraints
    {
        private readonly IDictionary<string, List<PropertyEntry>> _x4a3f0a05c02f235f = new Dictionary<string, List<PropertyEntry>>();
        private static PropertyConstraints _x6ed4ed9ed59eb694;

        private PropertyConstraints()
        {
            try
            {
                ReadCSV dcsv;
                string str;
                string str2;
                string str3;
                PropertyType typeFormat;
                PropertyEntry entry;
                List<PropertyEntry> list;
                Stream stream = ResourceLoader.CreateStream("Encog.Resources.analyst.csv");
                goto Label_01A2;
            Label_0021:
                list.Add(entry);
            Label_002A:
                if (dcsv.Next())
                {
                    goto Label_017D;
                }
                dcsv.Close();
                stream.Close();
                return;
            Label_0048:
                if (0 == 0)
                {
                    goto Label_0059;
                }
            Label_004B:
                if (this._x4a3f0a05c02f235f.ContainsKey(str))
                {
                    goto Label_009E;
                }
            Label_0059:
                list = new List<PropertyEntry>();
                this._x4a3f0a05c02f235f[str] = list;
                goto Label_00BC;
            Label_0070:
                if ("string".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_00B1;
                }
                throw new AnalystError("Unknown type constraint: " + str3);
            Label_0091:
                entry = new PropertyEntry(typeFormat, str2, str);
                goto Label_004B;
            Label_009E:
                list = this._x4a3f0a05c02f235f[str];
                goto Label_00B6;
            Label_00AE:
                if (0 == 0)
                {
                    goto Label_0070;
                }
            Label_00B1:
                typeFormat = PropertyType.TypeString;
                goto Label_0091;
            Label_00B6:
                if (0 == 0)
                {
                    goto Label_0021;
                }
            Label_00BC:
                if (8 != 0)
                {
                    goto Label_01B8;
                }
            Label_00CA:
                while ("list-string".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    typeFormat = PropertyType.TypeListString;
                    goto Label_0091;
                }
                if (3 == 0)
                {
                    goto Label_0185;
                }
                goto Label_00AE;
            Label_00EC:
                if ("int".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_0114;
                }
                goto Label_013C;
            Label_00FD:
                if (!"format".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_00EC;
                }
                typeFormat = PropertyType.TypeFormat;
                goto Label_0091;
            Label_0114:
                typeFormat = PropertyType.TypeInteger;
                goto Label_0091;
            Label_0119:
                if ("real".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_0153;
                }
                if (0 != 0)
                {
                    goto Label_009E;
                }
                if (15 == 0)
                {
                    goto Label_0021;
                }
                goto Label_00FD;
            Label_013C:
                if (2 != 0)
                {
                    goto Label_00CA;
                }
                if (0 == 0)
                {
                    goto Label_01A2;
                }
                goto Label_0091;
            Label_014B:
                if (0 != 0)
                {
                    goto Label_0048;
                }
                goto Label_0119;
            Label_0153:
                typeFormat = PropertyType.TypeDouble;
                if (-2147483648 == 0)
                {
                    goto Label_017D;
                }
                goto Label_0091;
            Label_0167:
                if ("boolean".Equals(str3, StringComparison.InvariantCultureIgnoreCase))
                {
                    goto Label_019D;
                }
                goto Label_014B;
            Label_017D:
                str = dcsv.Get(0);
            Label_0185:
                str2 = dcsv.Get(1);
                str3 = dcsv.Get(2);
                if (15 != 0)
                {
                    goto Label_0167;
                }
            Label_019D:
                typeFormat = PropertyType.TypeBoolean;
                goto Label_0091;
            Label_01A2:
                dcsv = new ReadCSV(stream, false, CSVFormat.EgFormat);
                goto Label_002A;
            Label_01B8:
                if (0 == 0)
                {
                    goto Label_0021;
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public PropertyEntry FindEntry(string v)
        {
            string[] strArray = v.Split(new char[] { '.' });
            string section = strArray[0];
            string subSection = strArray[1];
            string name = strArray[2];
            return this.GetEntry(section, subSection, name);
        }

        public List<PropertyEntry> GetEntries(string section, string subSection)
        {
            string str = section + ":" + subSection;
            return this._x4a3f0a05c02f235f[str];
        }

        public PropertyEntry GetEntry(string section, string subSection, string name)
        {
            string str;
            do
            {
                str = section.ToUpper() + ":" + subSection.ToUpper();
            }
            while (-2147483648 == 0);
            IList<PropertyEntry> source = this._x4a3f0a05c02f235f[str];
            if ((0 != 0) || (source == null))
            {
                throw new AnalystError("Unknown section and subsection: " + section + "." + subSection);
            }
            return source.FirstOrDefault<PropertyEntry>(entry => entry.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static PropertyConstraints Instance
        {
            get
            {
                return (_x6ed4ed9ed59eb694 ?? (_x6ed4ed9ed59eb694 = new PropertyConstraints()));
            }
        }
    }
}

