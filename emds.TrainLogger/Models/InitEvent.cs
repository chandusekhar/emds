using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace emds.TrainLoggers.Models
{
    public class InitEvent
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Анкета")]
        public string Anketa { get; set; }

        [BsonElement("AgeNumber")]
        public int AgeNumber { get; set; }

        [BsonElement("IterationCount")]
        public int IterationCount { get; set; }

        [BsonElement("NeuralNetName")]
        public string NeuralNetName { get; set; }

        [BsonElement("Path")]
        public string Path { get; set; }

        [BsonElement("event")]
        public string Event { get; set; }

        [BsonElement("sid")]
        public Guid Sid { get; set; }

        [BsonElement("TrainDataSize")]
        public int TrainDataSize { get; set; }

        public override string ToString()
        {
            return NeuralNetName.Replace('_', ' ').Remove(NeuralNetName.Length - 4, 4);
        }
    }
}
