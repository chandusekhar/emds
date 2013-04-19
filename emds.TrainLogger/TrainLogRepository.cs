using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB;
using MongoDB.Driver;
using emds.TrainLoggers.Models;
using MongoDB.Driver.Builders;

namespace emds.TrainLoggers
{
    public class TrainLogRepository
    {
        private MongoServer server;
        private MongoDatabase database;
        private MongoCollection collection;
        private string connectionString;

        public string CollectionName { get; private set; }
        public string DbName { get; private set; }
        public string HostIP { get; private set; }

        public TrainLogRepository(string collectionName = "NeuralTrainLog", string dbName = "emdsdb", string hostIP = "localhost")
        {
            CollectionName = collectionName;
            DbName = dbName;
            HostIP = hostIP;
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

        public IEnumerable<InitEvent> GetAllTrainLog()
        {
            var q = Query.EQ("event", "init");
            return collection.FindAs<InitEvent>(q);
        }

        public IEnumerable<Iteration> GetIteration(Guid sid)
        {
            var q = Query.And(Query.EQ("event", "iteration"), Query.EQ("sid", sid));
            return collection.FindAs<Iteration>(q); //.SetSortOrder("{AgeNumber: 1}");
        }

        public IEnumerable<ProcessPair> GetProcessPair(Guid sid, int age)
        {
            var q = Query.And(Query.EQ("sid", sid), Query.EQ("event", "ProcessPair"), Query.EQ("AgeNumber", age));
            return collection.FindAs<ProcessPair>(q);
        }

        
    }
}
