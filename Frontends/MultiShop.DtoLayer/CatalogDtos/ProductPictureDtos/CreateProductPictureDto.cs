using Microsoft.AspNetCore.Http;

namespace MultiShop.DtoLayer.CatalogDtos.ProductPictureDtos
{
    public class CreateProductPictureDto
    {
        public string PictureUrl { get; set; }
        public string ProductId { get; set; }

        public IEnumerable<IFormFile> MultiFile { get; set; }

    }
}
