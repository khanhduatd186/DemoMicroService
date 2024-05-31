using DemoMicroService.BankCashService.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.BankCashService;

public abstract class BankCashServiceAppService : ApplicationService
{
    protected BankCashServiceAppService()
    {
        LocalizationResource = typeof(BankCashServiceResource);
        ObjectMapperContext = typeof(BankCashServiceApplicationModule);
    }
}
