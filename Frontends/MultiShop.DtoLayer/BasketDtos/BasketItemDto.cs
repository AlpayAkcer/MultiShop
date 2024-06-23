﻿namespace MultiShop.DtoLayer.BasketDtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}