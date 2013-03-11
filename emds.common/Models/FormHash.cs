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
        [BsonElement("Hash")]
        public string Hash { get; set; }
        [BsonElement("GID")]
        public Guid GID { get; set; }
    }
}
