namespace Encog.App.Analyst.Script.Prop
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using System;
    using System.Text;

    public class PropertyEntry : IComparable<PropertyEntry>
    {
        private readonly PropertyType _x32d9f848c0e43d5d;
        private readonly string _xb32f8dd719a105db;
        private readonly string _xc15bd84e01929885;

        public PropertyEntry(PropertyType theEntryType, string theName, string theSection)
        {
            this._x32d9f848c0e43d5d = theEntryType;
            this._xc15bd84e01929885 = theName;
            this._xb32f8dd719a105db = theSection;
        }

        public int CompareTo(PropertyEntry o)
        {
            return string.CompareOrdinal(this._xc15bd84e01929885, o._xc15bd84e01929885);
        }

        public static string DotForm(string section, string subSection, string name)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(section);
            builder.Append('.');
            builder.Append(subSection);
            builder.Append('.');
            if (0 == 0)
            {
            }
            builder.Append(name);
            return builder.ToString();
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (-2 != 0)
            {
                do
                {
                    builder.Append(base.GetType().Name);
                }
                while (0 != 0);
                builder.Append(" name=");
            }
            builder.Append(this._xc15bd84e01929885);
            builder.Append(", section=");
            builder.Append(this._xb32f8dd719a105db);
            builder.Append("]");
            return builder.ToString();
        }

        public void Validate(string theSection, string subSection, string theName, string v)
        {
            if (!string.IsNullOrEmpty(v))
            {
                try
                {
                    StringBuilder builder;
                    StringBuilder builder2;
                    PropertyType entryType = this.EntryType;
                    goto Label_0179;
                Label_001B:
                    if (ConvertStringConst.String2AnalystFileFormat(v) == AnalystFileFormat.Unknown)
                    {
                        goto Label_00DE;
                    }
                    if (0x7fffffff != 0)
                    {
                        return;
                    }
                    goto Label_0179;
                Label_0037:
                    if (char.ToUpper(v[0]) == 'T')
                    {
                        return;
                    }
                Label_0048:
                    if (char.ToUpper(v[0]) != 'F')
                    {
                        goto Label_0138;
                    }
                    goto Label_00CD;
                Label_0068:
                    builder2.Append(".");
                    throw new AnalystError(builder2.ToString());
                Label_0080:
                    int.Parse(v);
                    return;
                Label_009C:
                    builder2.Append(DotForm(this._xb32f8dd719a105db, subSection, this._xc15bd84e01929885));
                Label_00B5:
                    builder2.Append(", value is ");
                    builder2.Append(v);
                    if (0 == 0)
                    {
                        goto Label_0068;
                    }
                Label_00CD:
                    if (0 == 0)
                    {
                        return;
                    }
                    if (0 == 0)
                    {
                        goto Label_0179;
                    }
                    if (0 == 0)
                    {
                        goto Label_0048;
                    }
                    goto Label_00F3;
                Label_00DE:
                    builder2 = new StringBuilder();
                    builder2.Append("Invalid file format for ");
                    if (0 == 0)
                    {
                        goto Label_011D;
                    }
                Label_00F3:
                    builder.Append(".");
                    throw new AnalystError(builder.ToString());
                Label_010B:
                    CSVFormat.EgFormat.Parse(v);
                    return;
                Label_011D:
                    if (0 == 0)
                    {
                        goto Label_009C;
                    }
                    goto Label_0048;
                Label_0122:
                    if (0 != 0)
                    {
                        goto Label_00B5;
                    }
                    builder.Append(v);
                    goto Label_00F3;
                Label_0138:
                    builder = new StringBuilder();
                    builder.Append("Illegal boolean for ");
                    builder.Append(DotForm(this._xb32f8dd719a105db, subSection, this._xc15bd84e01929885));
                    builder.Append(", value is ");
                    if (0 == 0)
                    {
                        goto Label_0122;
                    }
                    goto Label_00F3;
                Label_0179:
                    switch (entryType)
                    {
                        case PropertyType.TypeBoolean:
                            goto Label_0037;

                        case PropertyType.TypeString:
                        case PropertyType.TypeListString:
                            return;

                        case PropertyType.TypeInteger:
                            goto Label_0080;

                        case PropertyType.TypeDouble:
                            goto Label_010B;

                        case PropertyType.TypeFormat:
                            goto Label_001B;
                    }
                    throw new AnalystError("Unsupported property type.");
                }
                catch (FormatException)
                {
                    StringBuilder builder3;
                    goto Label_0228;
                Label_01B1:
                    builder3.Append(v);
                    builder3.Append(".");
                    goto Label_0225;
                Label_01C8:
                    builder3.Append("Illegal value for ");
                    builder3.Append(DotForm(this._xb32f8dd719a105db, subSection, this._xc15bd84e01929885));
                    builder3.Append(", expecting a ");
                    builder3.Append(this.EntryType.ToString());
                    if (-1 == 0)
                    {
                        goto Label_01C8;
                    }
                    builder3.Append(", but got ");
                    goto Label_01B1;
                Label_0225:
                    if (0 == 0)
                    {
                        throw new AnalystError(builder3.ToString());
                    }
                Label_0228:
                    builder3 = new StringBuilder();
                    goto Label_01C8;
                }
            }
        }

        public PropertyType EntryType
        {
            get
            {
                return this._x32d9f848c0e43d5d;
            }
        }

        public string Key
        {
            get
            {
                return (this._xb32f8dd719a105db + "_" + this._xc15bd84e01929885);
            }
        }

        public string Name
        {
            get
            {
                return this._xc15bd84e01929885;
            }
        }

        public string Section
        {
            get
            {
                return this._xb32f8dd719a105db;
            }
        }
    }
}

