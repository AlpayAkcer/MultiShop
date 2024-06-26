﻿namespace Multishop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductPictureCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string OfferDiscountCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string DeliveryInfoCollectionName { get; set; }
        public string BrandCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
