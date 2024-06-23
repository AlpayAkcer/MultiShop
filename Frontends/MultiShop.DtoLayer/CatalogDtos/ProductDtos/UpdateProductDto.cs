using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
