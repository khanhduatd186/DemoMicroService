using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using DemoMicroService.BankCashService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

[DependsOn(
    typeof(BankCashServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BankCashServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BankCashServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BankCashServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
