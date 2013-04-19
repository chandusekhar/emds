using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace emds.TrainLoggers
{
    public class TrainLogger : IDisposable
    {
        public static bool isCreate;
        private static TrainLogger logger;

        private MongoServer server;
        private MongoDatabase database;
        private MongoCollection collection;
        private string connectionString;

        public string CollectionName { get; private set; }
        public string DbName { get; private set; }
        public string HostIP { get; private set; }
        /// <summary>
        /// Формируется при каждом (!)создании объекта.
        /// </summary>
        public Guid IdSession { get; private set; }
        /// <summary>
        /// Номер эпохи обучения. Меняется вручную, добавляется автоматически к документу в методе WriteEvent
        /// </summary>
        public int AgeNumber { get; set; }

        /// <summary>
        /// Записываем в этот массив лог и испльзуем WriteEvent без параметров, он запишет этот массив в базу и создаст новый объект
        /// </summary>
        public Dictionary<string, Object> LogRecord { get; set; }

        private TrainLogger(string collectionName = "NeuralTrainLog", string dbName = "emdsdb", string hostIP = "localhost")
        {
            IdSession = Guid.NewGuid();
            isCreate = true;
            CollectionName = collectionName;
            DbName = dbName;
            HostIP = hostIP;
            AgeNumber = -1;
            connectionString = String.Format("mongodb://{0}/?safe=true", hostIP);
            try
            {
                server = MongoServer.Create(connectionString);
                database = server.GetDatabase(dbName);
                collection = database.GetCollection(collectionName);
                server.Ping();
            }
            catch
            {
                throw new Exception("Не удалось подключиться к MongoDB");
            }
        }

        public void WriteEvent(Dictionary<string, Object> toBsonDocument)
        {
            var doc = new BsonDocument(toBsonDocument);
            doc.Add("sid", IdSession);
            doc.Add("AgeNumber", AgeNumber);
            //collection.Insert(doc);
        }

        /// <summary>
        /// Записывает внутренний объект LogRecord в лог
        /// </summary>
        public void WriteEvent()
        {
            this.WriteEvent(LogRecord);
        }

        public static TrainLogger GetTrainLogger()
        {
            if(isCreate)
                return logger;
            else
            {
                logger = new TrainLogger();
                return logger;
            }
        }
            
        /// <summary>
        /// Освобождает внутренний объект TrainLogger.
        /// </summary>
        public void Dispose()
        {
            server.Disconnect();
            logger = null;
            isCreate = false;
        }
    }
}
