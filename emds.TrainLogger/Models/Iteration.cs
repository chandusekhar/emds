using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace emds.TrainLoggers.Models
{
    public class Iteration
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("event")]
        public string Event { get; set; }

        [BsonElement("weightBefore")]
        public double[] WeightBefore { get; set; }

        [BsonElement("newWeights")]
        public double[] NewWeights { get; set; }

        [BsonElement("gradient")]
        public double[] Gradient { get; set; }

        [BsonElement("gradientR")]
        public double[] GradientR { get; set; }

        [BsonElement("CurrentError")]
        public double CurrentError { get; set; }

        [BsonElement("AgeNumber")]
        public int AgeNumber { get; set; }

        [BsonElement("sid")]
        public Guid Sid { get; set; }

        [BsonElement("Time")]
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return AgeNumber.ToString();
        }
    }
}
