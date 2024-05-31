using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

[DependsOn(
    typeof(BankCashServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class BankCashServiceApplicationContractsModule : AbpModule
{

}
