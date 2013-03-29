namespace Encog.Util.File
{
    using Encog;
    using System;
    using System.IO;
    using System.Text;

    public static class Directory
    {
        public const int BufferSize = 0x400;

        public static void CopyFile(FileInfo source, FileInfo target)
        {
            try
            {
                FileStream stream;
                FileStream stream2;
                int num;
                byte[] buffer = new byte[0x400];
                goto Label_00A5;
            Label_0010:
                if (num != -1)
                {
                    goto Label_0059;
                }
                stream.Close();
                stream2.Close();
                return;
            Label_0025:
                if ((((uint) num) > uint.MaxValue) || ((((uint) num) - ((uint) num)) > uint.MaxValue))
                {
                    return;
                }
                goto Label_0010;
            Label_0059:
                num = stream.Read(buffer, 0, buffer.Length);
                while (num != -1)
                {
                    stream2.Write(buffer, 0, num);
                    goto Label_0010;
                }
                goto Label_0025;
            Label_0078:
                num = 0;
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0010;
                }
                goto Label_0025;
            Label_0090:
                stream2 = target.OpenWrite();
                goto Label_0078;
            Label_00A5:
                stream = source.OpenRead();
                target.Delete();
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0090;
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static bool DeleteDirectory(FileInfo path)
        {
            return DeleteDirectory(path);
        }

        public static string ReadStream(Stream mask0)
        {
            string str;
            try
            {
                TextReader reader;
                int num;
                StringBuilder builder = new StringBuilder(0x400);
                goto Label_0033;
            Label_000D:
                reader.Close();
                str = builder.ToString();
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    return str;
                }
            Label_0033:
                reader = new StreamReader(mask0);
                char[] buffer = new char[0x400];
                while ((num = reader.Read(buffer, 0, buffer.Length)) > -1)
                {
                    builder.Append(new string(buffer, 0, num));
                }
                if (0 == 0)
                {
                    goto Label_000D;
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
            return str;
        }

        public static string ReadTextFile(string filename)
        {
            string str2;
            try
            {
                StringBuilder builder = new StringBuilder();
                using (StreamReader reader = new StreamReader(filename))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        builder.Append(str);
                        builder.Append("\r\n");
                    }
                }
                str2 = builder.ToString();
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
            return str2;
        }
    }
}

