using Volo.Abp.Modularity;

namespace DemoMicroService.BankCashService;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class BankCashServiceApplicationTestBase<TStartupModule> : BankCashServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
