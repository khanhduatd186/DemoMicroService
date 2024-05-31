using Volo.Abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(BankCashServiceDomainSharedModule)
)]
public class BankCashServiceDomainModule : AbpModule
{
}
