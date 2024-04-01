using AutoMapper;
using Multishop.Catalog.Dtos.CategoryDto;
using Multishop.Catalog.Dtos.ProductDetailDto;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Dtos.ProductPictureDto;
using Multishop.Catalog.Dtos.SliderDtos;
using Multishop.Catalog.Entites;

namespace Multishop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductPicture, ResultProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, CreateProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, GetByIdProductPictureDto>().ReverseMap();
            CreateMap<ProductPicture, UpdateProductPictureDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();


        }
    }
}
