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
        
        public string CollectionName { get; private set; }
        public string DbName { get; private set; }
        public string ConnectionString { get; private set; }

        public TrainLogRepository(string collectionName = "NeuralTrainLog", string dbName = "emdsdb", string connectionString = "mongodb://localhost/?safe=true")
        {
            CollectionName = collectionName;
            DbName = dbName;
            ConnectionString = String.Format("{0}/{1}", connectionString, dbName);
            try
            {
                var client = new MongoClient(ConnectionString);
                server = client.GetServer();
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
