namespace Encog.Util
{
    using Encog;
    using System;
    using System.IO;
    using System.Text;

    public static class DirectoryUtil
    {
        public const int BufferSize = 0x400;

        public static void CopyFile(string source, string target)
        {
            try
            {
                Stream stream;
                Stream stream2;
                int num;
                byte[] buffer = new byte[0x400];
                goto Label_0047;
            Label_000D:
                stream2.Close();
                goto Label_0044;
            Label_0015:
                stream2.Write(buffer, 0, num);
                goto Label_0024;
            Label_0020:
                if (num != -1)
                {
                    goto Label_0015;
                }
            Label_0024:
                if (num == -1)
                {
                    stream.Close();
                    goto Label_000D;
                }
                num = stream.Read(buffer, 0, buffer.Length);
                goto Label_0020;
            Label_0044:
                if (0 == 0)
                {
                    return;
                }
            Label_0047:
                stream = new FileStream(source, FileMode.Open);
                stream2 = new FileStream(target, FileMode.OpenOrCreate);
                num = 0;
                if ((0 != 0) || (0xff == 0))
                {
                }
                goto Label_0024;
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static string ReadStream(Stream istream)
        {
            string str2;
            try
            {
                byte[] buffer;
                string str;
                StringBuilder builder = new StringBuilder(0x400);
                goto Label_002A;
            Label_000D:
                if (istream.Read(buffer, 0, buffer.Length) > -1)
                {
                    goto Label_003E;
                }
                str2 = builder.ToString();
                if (1 != 0)
                {
                    return str2;
                }
            Label_002A:
                if (-2147483648 == 0)
                {
                    return str2;
                }
                buffer = new byte[0x400];
                goto Label_000D;
            Label_003E:
                str = Encoding.ASCII.GetString(buffer);
                builder.Append(str);
                if (4 != 0)
                {
                    goto Label_000D;
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
            return str2;
        }

        public static string ReadTextFile(string filename)
        {
            Stream istream = new FileStream(filename, FileMode.Open);
            string str = ReadStream(istream);
            istream.Close();
            return str;
        }
    }
}

