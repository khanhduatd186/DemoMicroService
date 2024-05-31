using AutoMapper;
using DemoMicroService.ProductService.Products;

namespace DemoMicroService.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().MapExtraProperties();
    }
}
