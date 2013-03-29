namespace Encog.Util
{
    using Encog;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class ObjectCloner
    {
        private ObjectCloner()
        {
        }

        public static object DeepCopy(object oldObj)
        {
            object obj2;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            try
            {
                formatter.Serialize(serializationStream, oldObj);
                serializationStream.Flush();
                serializationStream.Position = 0L;
                obj2 = formatter.Deserialize(serializationStream);
            }
            catch (Exception exception)
            {
                throw new EncogError(exception);
            }
            finally
            {
                if (serializationStream != null)
                {
                    serializationStream.Dispose();
                }
            }
            return obj2;
        }
    }
}

