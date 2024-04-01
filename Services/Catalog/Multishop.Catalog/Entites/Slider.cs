using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Entites
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public bool Status { get; set; }

    }
}
