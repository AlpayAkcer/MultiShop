﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos
{
    public class UpdateSpecialOfferDto
    {
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PictureUrl { get; set; }
    }
}
