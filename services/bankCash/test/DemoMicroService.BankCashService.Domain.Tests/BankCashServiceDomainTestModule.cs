using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(BankCashServiceDomainModule),
    typeof(BankCashServiceTestBaseModule)
)]
public class BankCashServiceDomainTestModule : AbpModule
{

}
