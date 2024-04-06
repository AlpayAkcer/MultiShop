using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entites
{
    public class DeliveryInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DeliveryInfoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
