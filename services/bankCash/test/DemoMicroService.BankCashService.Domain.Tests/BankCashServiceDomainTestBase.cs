using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class BankCashServiceDomainTestBase<TStartupModule> : BankCashServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
