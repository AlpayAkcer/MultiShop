namespace Multishop.Catalog.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
