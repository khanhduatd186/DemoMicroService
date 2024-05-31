using DemoMicroService.BankCashService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DemoMicroService.BankCashService.Blazor.Pages.BankCashService;

public class BankCashServiceComponentBase : AbpComponentBase
{
    public BankCashServiceComponentBase()
    {
        LocalizationResource = typeof(BankCashServiceResource);
        ObjectMapperContext = typeof(BankCashServiceBlazorModule);
    }
}
