using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entites
{
    public class ProductPicture
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }
        public string PictureUrl { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
