using AutoMapper;
using DemoMicroService.ProductService.Products;

namespace DemoMicroService.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>().MapExtraProperties();
    }
}
