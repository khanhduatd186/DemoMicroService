using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoMicroService.AuthServer;

[Dependency(ReplaceServices = true)]
public class DemoMicroServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DemoMicroService";
}
