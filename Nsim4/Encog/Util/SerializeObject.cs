namespace Encog.Util
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class SerializeObject
    {
        private SerializeObject()
        {
        }

        public static object Load(string filename)
        {
            Stream serializationStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            object obj2 = new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        public static void Save(string filename, object obj)
        {
            Stream serializationStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            new BinaryFormatter().Serialize(serializationStream, obj);
            serializationStream.Close();
        }
    }
}

