using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace emds.TrainLoggers.Models
{
    public class ProcessPair
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("event")]
        public string Event { get; set; }

        [BsonElement("Pair")]
        public int Pair { get; set; }

        [BsonElement("AgeNumber")]
        public int AgeNumber { get; set; }

        [BsonElement("layerOutput")]
        public double[] LayerOutput { get; set; }

        [BsonElement("layersums")]
        public double[] LayerSums { get; set; }

        [BsonElement("error")]
        public double[] Error { get; set; }

        [BsonElement("PairLayerDelta")]
        public double[] PairLayerDelta { get; set; }

        [BsonElement("PairGradient")]
        public double[] PairGradient { get; set; }

        [BsonElement("sid")]
        public Guid Sid { get; set; }

        public override string ToString()
        {
            return Pair.ToString();
        }
    }
}
