using Volo.Abp.Bundling;

namespace DemoMicroService.Blazor;

public class DemoMicroServiceBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css");
    }
}
