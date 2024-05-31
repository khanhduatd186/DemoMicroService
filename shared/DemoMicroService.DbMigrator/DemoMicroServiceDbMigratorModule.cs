using DemoMicroService.AdministrationService;
using DemoMicroService.AdministrationService.EntityFrameworkCore;
using DemoMicroService.IdentityService;
using DemoMicroService.IdentityService.EntityFrameworkCore;
using DemoMicroService.ProductService;
using DemoMicroService.ProductService.EntityFrameworkCore;
using DemoMicroService.SaasService;
using DemoMicroService.SaasService.EntityFrameworkCore;
using DemoMicroService.Shared.Hosting;
using Volo.Abp.Modularity;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using DemoMicroService.BankCashService;
using DemoMicroService.BankCashService.EntityFrameworkCore;

namespace DemoMicroService.DbMigrator;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(DemoMicroServiceSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule),
     typeof(BankCashServiceApplicationContractsModule),
    typeof(BankCashServiceEntityFrameworkCoreModule)
)]
public class DemoMicroServiceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "DemoMicroService:"; });
    }
}
