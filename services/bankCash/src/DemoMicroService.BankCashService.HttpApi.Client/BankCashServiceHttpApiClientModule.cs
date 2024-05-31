using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DemoMicroService.BankCashService;

[DependsOn(
    typeof(BankCashServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BankCashServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(typeof(BankCashServiceApplicationContractsModule).Assembly,
            BankCashServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BankCashServiceHttpApiClientModule>();
        });
    }
}
