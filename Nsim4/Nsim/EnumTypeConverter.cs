namespace Nsim
{
    using mscorlib;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class EnumTypeConverter : EnumConverter
    {
        [CompilerGenerated]
        private static Func<<>f__AnonymousType2<object, string>, string> x2d372efdef9e88aa;
        private const string x85f3e89c3c80206d = ", ";
        [CompilerGenerated]
        private static Func<<>f__AnonymousType1<<>f__AnonymousType0`2_1<FieldInfo, object>, string>, <>f__AnonymousType2<object, string>> x98afab8c2756fce1;
        private static readonly string[] xa0d5517eb2ed6cd8 = new string[] { ", " };
        [CompilerGenerated]
        private static Func<FieldInfo, <>f__AnonymousType0`2_1<FieldInfo, object>> xcd3a29c3cfb3776e;
        [CompilerGenerated]
        private static Func<<>f__AnonymousType2<object, string>, object> xce2dfaf8dd33dc9c;

        public EnumTypeConverter(Type type) : base(type)
        {
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(string)) || base.CanConvertTo(context, destinationType));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Func<string, object> func;
            string[] strArray;
            long num;
            string str2;
            object obj3;
            bool flag;
            string[] strArray2;
            int num2;
            string str = value as string;
            if ((((uint) flag) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_00E3;
            }
            if (str != null)
            {
                <>c__DisplayClass11 class2;
                IDictionary<string, object> dictionary = GetValuesDictionary(base.EnumType, culture);
                func = new Func<string, object>(class2, (IntPtr) this.<ConvertFrom>b__10);
                flag = str.IndexOf(", ") != -1;
                if ((((uint) num2) - ((uint) num2)) < 0)
                {
                    goto Label_00DE;
                }
                if (0 == 0)
                {
                    goto Label_00E3;
                }
                if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_00C9;
                }
                goto Label_008E;
            }
        Label_000E:
            return base.ConvertFrom(context, culture, value);
        Label_005D:
            if (!flag)
            {
                goto Label_00C9;
            }
            goto Label_000E;
        Label_007E:
            flag = num2 < strArray2.Length;
            if (!flag)
            {
                goto Label_00AD;
            }
        Label_008E:
            str2 = strArray2[num2];
            object obj2 = func.Invoke(str2);
            num |= Convert.ToInt64(obj2);
            if (0 == 0)
            {
                if ((((uint) num) & 0) != 0)
                {
                    if ((((uint) num2) & 0) == 0)
                    {
                        goto Label_000E;
                    }
                    goto Label_005D;
                }
                num2++;
                goto Label_007E;
            }
        Label_00AD:
            if ((((uint) num) & 0) == 0)
            {
                if ((((uint) flag) - ((uint) num2)) <= uint.MaxValue)
                {
                    obj3 = Enum.ToObject(base.EnumType, num);
                }
                return obj3;
            }
            return obj3;
        Label_00C9:
            strArray = str.Split(xa0d5517eb2ed6cd8, StringSplitOptions.None);
            num = 0L;
            strArray2 = strArray;
        Label_00DE:
            num2 = 0;
            goto Label_007E;
        Label_00E3:
            if (flag)
            {
                flag = !base.EnumType.IsDefined(typeof(FlagsAttribute), false);
                goto Label_005D;
            }
            return func.Invoke(str);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            bool flag = destinationType != typeof(string);
            if (!flag)
            {
                if (Enum.IsDefined(base.EnumType, value))
                {
                    return this.GetValueText(value, culture);
                }
                flag = !base.EnumType.IsDefined(typeof(FlagsAttribute), false);
                if (!flag)
                {
                    return this.GetFlagsString(value, culture);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static StringComparer GetCultureAwareComparer(CultureInfo culture)
        {
            bool flag;
            System.Boolean ReflectorVariable0;
            if (culture == null)
            {
                ReflectorVariable0 = false;
                goto Label_0026;
            }
            if (2 != 0)
            {
                ReflectorVariable0 = true;
                goto Label_0026;
            }
        Label_000B:
            return StringComparer.CurrentCulture;
        Label_0026:
            flag = ReflectorVariable0 ? object.Equals(culture, CultureInfo.CurrentCulture) : true;
            if ((0 == 0) && flag)
            {
                goto Label_000B;
            }
            return new CultureAwareComparer(culture);
        }

        private string GetFlagsString(object value, CultureInfo culture)
        {
            // This item is obfuscated and can not be translated.
        }

        private static string GetMemberText(MemberInfo field, object value, CultureInfo culture)
        {
            DescriptionAttribute customAttribute = (DescriptionAttribute) Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            if (!((customAttribute == null) || string.IsNullOrEmpty(customAttribute.Description)))
            {
                return customAttribute.Description;
            }
            return Convert.ToString(value, culture);
        }

        private string GetObjectText(object value, CultureInfo culture)
        {
            object obj2 = Enum.ToObject(base.EnumType, value);
            return this.GetValueText(obj2, culture);
        }

        private static IDictionary<string, object> GetValuesDictionary(Type type, CultureInfo culture)
        {
            <>c__DisplayClasse classe;
            bool flag;
            goto Label_00EF;
        Label_00D4:
            if (!flag)
            {
                goto Label_0103;
            }
        Label_0015:
            if (xcd3a29c3cfb3776e == null)
            {
                xcd3a29c3cfb3776e = new Func<FieldInfo, <>f__AnonymousType0`2_1<FieldInfo, object>>(null, (IntPtr) <GetValuesDictionary>b__5);
            }
            if (x98afab8c2756fce1 == null)
            {
                x98afab8c2756fce1 = new Func<<>f__AnonymousType1<<>f__AnonymousType0`2_1<FieldInfo, object>, string>, <>f__AnonymousType2<object, string>>(null, (IntPtr) <GetValuesDictionary>b__7);
            }
            var enumerable = Enumerable.Select(Enumerable.Select(Enumerable.Select(type.GetFields(BindingFlags.Public | BindingFlags.Static), xcd3a29c3cfb3776e), new Func<<>f__AnonymousType0`2_1<FieldInfo, object>, <>f__AnonymousType1<<>f__AnonymousType0`2_1<FieldInfo, object>, string>>(classe, (IntPtr) this.<GetValuesDictionary>b__6)), x98afab8c2756fce1);
            StringComparer cultureAwareComparer = GetCultureAwareComparer(culture);
            if (x2d372efdef9e88aa == null)
            {
                x2d372efdef9e88aa = new Func<<>f__AnonymousType2<object, string>, string>(null, (IntPtr) <GetValuesDictionary>b__8);
            }
            if (xce2dfaf8dd33dc9c == null)
            {
                xce2dfaf8dd33dc9c = new Func<<>f__AnonymousType2<object, string>, object>(null, (IntPtr) <GetValuesDictionary>b__9);
            }
            return Enumerable.ToDictionary(enumerable, x2d372efdef9e88aa, xce2dfaf8dd33dc9c, cultureAwareComparer);
            if (15 != 0)
            {
                if (0 == 0)
                {
                    if (0 != 0)
                    {
                        IDictionary<string, object> dictionary;
                        return dictionary;
                    }
                    goto Label_0015;
                }
                goto Label_00D4;
            }
        Label_00EF:
            flag = type != null;
            if (8 != 0)
            {
                goto Label_00D4;
            }
        Label_0103:
            throw new ArgumentNullException("type");
        }

        private string GetValueText(object value, CultureInfo culture)
        {
            FieldInfo field;
            string name = Enum.GetName(base.EnumType, value);
            bool flag = !string.IsNullOrEmpty(name);
            goto Label_00C9;
        Label_0018:
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0050;
            }
        Label_002C:
            Debug.Assert(object.Equals(field.GetValue(null), value), string.Format("Equals(field.GetValue(null) = \"{0}\", value = \"{1}\")", field.GetValue(null), value));
        Label_0050:
            return GetMemberText(field, value, culture);
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_0018;
            }
        Label_00C9:
            if (!flag)
            {
                throw new ArgumentException(string.Format("Name for value \"{0}\" does not found in enum \"{1}\".", value, base.EnumType), "value");
            }
            field = base.EnumType.GetField(name, BindingFlags.Public | BindingFlags.Static);
            flag = field != null;
            if (0 == 0)
            {
                if (!flag)
                {
                    throw new InvalidOperationException(string.Format("Field \"{0}\" for value \"{1}\" does not found in enum \"{2}\".", name, value, base.EnumType));
                }
                goto Label_002C;
            }
            goto Label_0018;
        }

        [Serializable]
        private sealed class CultureAwareComparer : StringComparer
        {
            private readonly CultureInfo _culture;

            public CultureAwareComparer(CultureInfo culture)
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture");
                }
                this._culture = culture;
            }

            public override int Compare(string x, string y)
            {
                return this.Culture.CompareInfo.Compare(x, y);
            }

            public override bool Equals(string x, string y)
            {
                return (this.Compare(x, y) == 0);
            }

            public override int GetHashCode(string obj)
            {
                return this.Culture.CompareInfo.GetSortKey(obj).GetHashCode();
            }

            private CultureInfo Culture
            {
                [DebuggerStepThrough]
                get
                {
                    return this._culture;
                }
            }
        }
    }
}

