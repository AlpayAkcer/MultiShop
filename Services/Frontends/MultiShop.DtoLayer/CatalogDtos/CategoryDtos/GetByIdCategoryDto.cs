﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
    }
}
