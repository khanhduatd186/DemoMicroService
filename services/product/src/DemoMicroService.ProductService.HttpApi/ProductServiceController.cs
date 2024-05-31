using DemoMicroService.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
