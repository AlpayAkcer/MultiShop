﻿namespace Multishop.Catalog.Dtos.OfferDiscountDtos
{
    public class CreateOfferDiscountDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PictureUrl { get; set; }
        public string ButtonTitle { get; set; }
        public bool Status { get; set; }
    }
}
