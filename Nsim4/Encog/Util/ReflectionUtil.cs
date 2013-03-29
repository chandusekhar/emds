namespace Encog.Util
{
    using Encog.Util.File;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class ReflectionUtil
    {
        public const string AfPath = "Encog.Engine.Network.Activation.";
        public const string RBFPath = "Encog.MathUtil.RBF.";
        private static readonly IDictionary<string, string> x07c034140e4ae1f2 = new Dictionary<string, string>();

        private ReflectionUtil()
        {
        }

        public static FieldInfo FindField(Type c, string name)
        {
            return GetAllFields(c).FirstOrDefault<FieldInfo>(field => field.Name.Equals(name));
        }

        public static IList<FieldInfo> GetAllFields(Type c)
        {
            IList<FieldInfo> result = new List<FieldInfo>();
            GetAllFields(c, result);
            return result;
        }

        public static void GetAllFields(Type c, IList<FieldInfo> result)
        {
            int num;
            FieldInfo[] fields = c.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            goto Label_006A;
        Label_0050:
            num++;
        Label_0054:
            if (num < fields.Length)
            {
                FieldInfo item = fields[num];
                result.Add(item);
                goto Label_0050;
            }
            while (c.BaseType != null)
            {
                GetAllFields(c.BaseType, result);
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    return;
                }
            }
            if ((((uint) num) | 15) != 0)
            {
                return;
            }
        Label_006A:
            if (0 != 0)
            {
                goto Label_0050;
            }
            num = 0;
            goto Label_0054;
        }

        public static bool HasAttribute(FieldInfo field, Type t)
        {
            return field.GetCustomAttributes(true).Any<object>(obj => (obj.GetType() == t));
        }

        public static bool HasAttribute(Type t, Type attribute)
        {
            return t.GetCustomAttributes(true).Any<object>(obj => (obj.GetType() == attribute));
        }

        public static void LoadClassmap()
        {
            string str;
            string str2;
            Stream stream = ResourceLoader.CreateStream("Encog.Resources.classes.txt");
            StreamReader reader = new StreamReader(stream);
        Label_0010:
            while ((str = reader.ReadLine()) != null)
            {
                int num = str.LastIndexOf('.');
                if (num != -1)
                {
                    str2 = str.Substring(num + 1);
                    if (0 == 0)
                    {
                        goto Label_0030;
                    }
                }
                if (0 != 0)
                {
                    return;
                }
            }
            if (0 == 0)
            {
                reader.Close();
                stream.Close();
                return;
            }
        Label_0030:
            x07c034140e4ae1f2[str2] = str;
            goto Label_0010;
        }

        public static object LoadObject(string name)
        {
            Assembly[] assemblyArray2;
            int num;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            object obj2 = null;
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                assemblyArray2 = assemblies;
                num = 0;
            }
            while (num < assemblyArray2.Length)
            {
                obj2 = assemblyArray2[num].CreateInstance(name);
                if (obj2 != null)
                {
                    return obj2;
                }
                num++;
            }
            return obj2;
        }

        public static string ResolveEncogClass(string name)
        {
            if (x07c034140e4ae1f2.Count == 0)
            {
                LoadClassmap();
            }
            if (x07c034140e4ae1f2.ContainsKey(name))
            {
                return x07c034140e4ae1f2[name];
            }
            return null;
        }

        public static object ResolveEnum(FieldInfo field, FieldInfo v)
        {
            return field.GetType().GetMembers(BindingFlags.Public | BindingFlags.Static).Cast<MemberInfo>().FirstOrDefault<MemberInfo>(obj => obj.Name.Equals(v));
        }
    }
}

