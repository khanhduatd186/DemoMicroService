using AutoMapper;
using DemoMicroService.ProductService.Products;

namespace DemoMicroService.ProductService.Blazor;

public class ProductServiceBlazorAutoMapperProfile : Profile
{
    public ProductServiceBlazorAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>().MapExtraProperties();
    }
}
