using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ToDo.API.Entities
{
    public class ToDo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
