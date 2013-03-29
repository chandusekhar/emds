namespace Encog.Util.File
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    public sealed class ResourceLoader
    {
        private ResourceLoader()
        {
        }

        public static Stream CreateStream(string resource)
        {
            Stream manifestResourceStream = null;
            Assembly[] assemblies;
            Assembly[] assemblyArray2;
            int num;
            if (((uint) num) >= 0)
            {
                assemblies = AppDomain.CurrentDomain.GetAssemblies();
                goto Label_0039;
            }
            if (8 == 0)
            {
                goto Label_0039;
            }
        Label_001B:
            if (manifestResourceStream == null)
            {
                num++;
            }
            else
            {
                return manifestResourceStream;
            }
        Label_0030:
            if (num < assemblyArray2.Length)
            {
                manifestResourceStream = assemblyArray2[num].GetManifestResourceStream(resource);
                goto Label_001B;
            }
            return manifestResourceStream;
        Label_0039:
            assemblyArray2 = assemblies;
            num = 0;
            goto Label_0030;
        }

        public static string LoadString(string resource)
        {
            string str;
            StringBuilder builder = new StringBuilder();
            Stream stream = CreateStream(resource);
            StreamReader reader = new StreamReader(stream);
        Label_0014:
            if ((str = reader.ReadLine()) != null)
            {
                builder.Append(str);
                if (3 != 0)
                {
                    builder.Append("\r\n");
                    goto Label_0014;
                }
            }
            else
            {
                reader.Close();
                stream.Close();
                if (8 == 0)
                {
                    goto Label_0014;
                }
            }
            return builder.ToString();
        }
    }
}

