using Volo.Abp.Modularity;

namespace DemoMicroService.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceDomainTestModule)
    )]
public class AdministrationServiceApplicationTestModule : AbpModule
{

}
