using DemoMicroService.ProductService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DemoMicroService.ProductService.Blazor.Pages;

public class ProductServiceComponentBase : AbpComponentBase
{
    public ProductServiceComponentBase()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceBlazorModule);
    }
}
