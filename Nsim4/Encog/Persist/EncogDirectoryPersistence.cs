namespace Encog.Persist
{
    using Encog;
    using Encog.Util.Logging;
    using System;
    using System.IO;
    using System.Text;

    public class EncogDirectoryPersistence
    {
        private readonly FileInfo _xb6a159a84cb992d6;

        public EncogDirectoryPersistence(FileInfo parent)
        {
            this._xb6a159a84cb992d6 = parent;
        }

        public string GetEncogType(string name)
        {
            string str2;
            try
            {
                string[] strArray;
                FileInfo info = new FileInfo(Path.Combine(this._xb6a159a84cb992d6.FullName, name));
                TextReader reader = new StreamReader(info.OpenRead());
                if (-1 != 0)
                {
                    strArray = reader.ReadLine().Split(new char[] { ',' });
                }
                reader.Close();
                str2 = strArray[1];
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
            return str2;
        }

        public object LoadFromDirectory(string name)
        {
            FileInfo file = new FileInfo(Path.Combine(this._xb6a159a84cb992d6.FullName, name));
            return LoadObject(file);
        }

        public static object LoadObject(FileInfo file)
        {
            FileStream stream = null;
            object obj3;
            try
            {
                stream = file.OpenRead();
                obj3 = LoadObject(stream);
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
            finally
            {
                if (stream != null)
                {
                    try
                    {
                        stream.Close();
                    }
                    catch (IOException exception2)
                    {
                        EncogLogging.Log(exception2);
                    }
                }
            }
            return obj3;
        }

        public static object LoadObject(Stream mask0)
        {
            string str2;
            string[] strArray = xa8adf7fbd1cf75d9(mask0).Split(new char[] { ',' });
            if ((0 == 0) && "encog".Equals(strArray[0]))
            {
                IEncogPersistor persistor;
                if (4 != 0)
                {
                    do
                    {
                        str2 = strArray[1];
                        persistor = PersistorRegistry.Instance.GetPersistor(str2);
                        if (0x7fffffff == 0)
                        {
                            goto Label_002E;
                        }
                    }
                    while (0 != 0);
                    if (persistor == null)
                    {
                        goto Label_002E;
                    }
                    if (persistor.FileVersion < int.Parse(strArray[4]))
                    {
                        throw new PersistError("The file you are trying to read is from a later version of Encog.  Please upgrade Encog to read this file.");
                    }
                }
                else if (0 == 0)
                {
                    goto Label_002E;
                }
                return persistor.Read(mask0);
            }
            throw new PersistError("Not a valid EG file.");
        Label_002E:
            throw new PersistError("Do not know how to read the object: " + str2);
        }

        public static void SaveObject(FileInfo filename, object obj)
        {
            FileStream os = null;
            try
            {
                filename.Delete();
                os = filename.OpenWrite();
                SaveObject(os, obj);
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
            finally
            {
                try
                {
                    if (os != null)
                    {
                        os.Close();
                    }
                }
                catch (IOException exception2)
                {
                    EncogLogging.Log(exception2);
                }
            }
        }

        public static void SaveObject(Stream os, object obj)
        {
            try
            {
                StreamWriter writer;
                IEncogPersistor persistor = PersistorRegistry.Instance.GetPersistor(obj.GetType());
                goto Label_00B7;
            Label_0016:
                if (-2147483648 == 0)
                {
                    goto Label_0030;
                }
                persistor.Save(os, obj);
                return;
            Label_002A:
                os.Flush();
            Label_0030:
                writer = new StreamWriter(os);
                DateTime now = DateTime.Now;
                writer.WriteLine(string.Concat(new object[] { "encog,", persistor.PersistClassString, ",java,", EncogFramework.Version, ",", persistor.FileVersion, ",", now.Ticks / 0x2710L }));
                writer.Flush();
                goto Label_0016;
            Label_00B7:
                if (persistor == null)
                {
                    throw new PersistError("Do not know how to persist object: " + obj.GetType().Name);
                }
                goto Label_002A;
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
        }

        public void SaveToDirectory(string name, object obj)
        {
            FileInfo filename = new FileInfo(Path.Combine(this._xb6a159a84cb992d6.FullName, name));
            SaveObject(filename, obj);
        }

        private static string xa8adf7fbd1cf75d9(Stream x38d3faec2c610827)
        {
            string str;
            try
            {
                char ch;
                int num;
                StringBuilder builder = new StringBuilder();
                goto Label_0040;
            Label_0008:
                builder.Append(ch);
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_0040;
                }
                goto Label_002F;
            Label_002A:
                if (ch != '\n')
                {
                    goto Label_0008;
                }
            Label_002F:
                if (ch == '\n')
                {
                    return builder.ToString();
                }
            Label_0040:
                num = x38d3faec2c610827.ReadByte();
                if (num == -1)
                {
                    return builder.ToString();
                }
                ch = (char) num;
                if (ch == '\r')
                {
                    goto Label_002F;
                }
                goto Label_002A;
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
            return str;
        }

        public FileInfo Parent
        {
            get
            {
                return this._xb6a159a84cb992d6;
            }
        }
    }
}

