using DemoMicroService.BankCashService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.BankCashService;

public abstract class BankCashServiceController : AbpControllerBase
{
    protected BankCashServiceController()
    {
        LocalizationResource = typeof(BankCashServiceResource);
    }
}
