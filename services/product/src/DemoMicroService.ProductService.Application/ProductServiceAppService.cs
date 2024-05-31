using DemoMicroService.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
