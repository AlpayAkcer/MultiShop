using AutoMapper;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Dtos.CategoryDto;
using Multishop.Catalog.Dtos.ContactDtos;
using Multishop.Catalog.Dtos.DeliveryInfoDtos;
using Multishop.Catalog.Dtos.OfferDiscountDtos;
using Multishop.Catalog.Dtos.ProductDetailDto;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Dtos.ProductPictureDto;
using Multishop.Catalog.Dtos.SliderDtos;
using Multishop.Catalog.Dtos.SpecialOfferDtos;
using Multishop.Catalog.Entites;

namespace Multishop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductWithProductDetailDto>().ReverseMap();

            CreateMap<ProductPicture, ResultProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, CreateProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, GetByIdProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, UpdateProductPictureDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

            CreateMap<DeliveryInfo, ResultDeliveryInfoDto>().ReverseMap();
            CreateMap<DeliveryInfo, CreateDeliveryInfoDto>().ReverseMap();
            CreateMap<DeliveryInfo, GetByIdDeliveryInfoDto>().ReverseMap();
            CreateMap<DeliveryInfo, UpdateDeliveryInfoDto>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
        }
    }
}
