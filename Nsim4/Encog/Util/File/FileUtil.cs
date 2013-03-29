namespace Encog.Util.File
{
    using Encog;
    using Encog.Bot;
    using System;
    using System.IO;
    using System.Text;

    public class FileUtil
    {
        public static FileInfo AddFilenameBase(FileInfo filename, string bs)
        {
            string fileExt;
            int num;
            int num2;
            bool flag;
            string fileName = GetFileName(filename);
            if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
            {
                fileExt = GetFileExt(filename);
                num = fileName.LastIndexOf('_');
                num2 = fileName.LastIndexOf(Path.PathSeparator);
                flag = false;
            }
            if (num != -1)
            {
                if (num2 != -1)
                {
                    flag = num > num2;
                    goto Label_0048;
                }
                goto Label_004E;
            }
            if ((((uint) num) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_004E;
            }
        Label_0048:
            while (flag)
            {
                fileName = fileName.Substring(0, num);
                break;
            }
            return new FileInfo(fileName + bs + "." + fileExt);
        Label_004E:
            flag = true;
            goto Label_0048;
        }

        public static FileInfo CombinePath(FileInfo dir, string f)
        {
            return new FileInfo(Path.Combine(dir.ToString(), f));
        }

        public static void Copy(FileInfo source, FileInfo target)
        {
            try
            {
                target.Delete();
                FileStream os = target.OpenWrite();
                Stream stream2 = source.OpenRead();
                Copy(stream2, os);
                do
                {
                    os.Close();
                }
                while (0x7fffffff == 0);
                stream2.Close();
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static void Copy(Stream mask0, Stream os)
        {
            try
            {
                int num;
                byte[] buffer = new byte[BotUtil.BufferSize];
                goto Label_0017;
            Label_000D:
                if (num > 0)
                {
                    goto Label_0025;
                }
            Label_0011:
                if (num <= 0)
                {
                    return;
                }
            Label_0017:
                num = mask0.Read(buffer, 0, buffer.Length);
                goto Label_000D;
            Label_0025:
                os.Write(buffer, 0, num);
                goto Label_0011;
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static void CopyResource(string resource, FileInfo targetFile)
        {
            try
            {
                Stream stream = ResourceLoader.CreateStream(resource);
                targetFile.Delete();
                if (3 != 0)
                {
                    Stream os = targetFile.OpenWrite();
                    Copy(stream, os);
                    stream.Close();
                    os.Close();
                }
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static int CopyStream(Stream input, Stream output)
        {
            byte[] buffer;
            int num2;
            int num = 0;
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0041;
            }
        Label_0018:
            if (num2 <= 0)
            {
                return num;
            }
        Label_001C:
            output.Write(buffer, 0, num2);
            num += num2;
            if ((((uint) num2) + ((uint) num2)) >= 0)
            {
                goto Label_0060;
            }
        Label_0041:
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_001C;
            }
            buffer = new byte[0x8000];
        Label_0060:
            num2 = input.Read(buffer, 0, buffer.Length);
            goto Label_0018;
        }

        public static string ForceExtension(string name, string ext)
        {
            return (GetFileName(new FileInfo(name)) + "." + ext);
        }

        public static string GetFileExt(FileInfo file)
        {
            int num;
            string str = file.ToString();
            do
            {
                num = str.LastIndexOf(".");
            }
            while (0 != 0);
            while (num == -1)
            {
                return "";
            }
            return str.Substring(num + 1, str.Length - (num + 1));
        }

        public static string GetFileName(FileInfo file)
        {
            string str = file.ToString();
            int length = str.LastIndexOf(".");
            if (length == -1)
            {
                return str;
            }
            return str.Substring(0, length);
        }

        public static string ReadFileAsString(FileInfo filePath)
        {
            TextReader reader;
            char[] chArray;
            int num;
            StringBuilder builder = new StringBuilder(0x3e8);
            if (0 == 0)
            {
                goto Label_003B;
            }
        Label_000E:
            while ((num = reader.Read(chArray, 0, chArray.Length)) != -1)
            {
                string str = new string(chArray, 0, num);
                builder.Append(str);
                if (0xff != 0)
                {
                    chArray = new char[0x400];
                    if (0xff == 0)
                    {
                        goto Label_0070;
                    }
                    if (0 != 0)
                    {
                        goto Label_003B;
                    }
                }
            }
            reader.Close();
            goto Label_0070;
        Label_003B:
            reader = new StreamReader(filePath.OpenRead());
            chArray = new char[0x400];
            goto Label_000E;
        Label_0070:
            return builder.ToString();
        }

        public static void WriteFileAsString(FileInfo path, string str)
        {
            FileStream stream = path.Create();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Close();
            stream.Close();
        }
    }
}

