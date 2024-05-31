using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

[DependsOn(
    typeof(BankCashServiceApplicationModule),
    typeof(BankCashServiceDomainTestModule)
    )]
public class BankCashServiceApplicationTestModule : AbpModule
{

}
