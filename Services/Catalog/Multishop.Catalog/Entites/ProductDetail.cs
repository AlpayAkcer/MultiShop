using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entites
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }

    }
}
