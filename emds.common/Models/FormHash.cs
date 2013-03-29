using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace emds.common.Models
{
    public class FormHash
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Hash")]
        public string Hash { get; set; }
        [BsonElement("GID")]
        public Guid GID { get; set; }
        [BsonElement("Data")]
        public double[] Data { get; set; }
    }
}
