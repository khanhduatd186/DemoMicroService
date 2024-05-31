using System;
using System.Net.Http;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using IdentityModel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DemoMicroService.AdministrationService;
using DemoMicroService.Blazor.Components.Layout;
using DemoMicroService.Blazor.Navigation;
using DemoMicroService.IdentityService;
using DemoMicroService.ProductService;
using DemoMicroService.ProductService.Blazor;
using DemoMicroService.SaasService;
using Volo.Abp.Account.Pro.Admin.Blazor.WebAssembly;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AuditLogging.Blazor.WebAssembly;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Pro.Blazor.Server.WebAssembly;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using OpenIddict.Abstractions;
using Volo.Abp.AspNetCore.Components.Web.LeptonXTheme.Components;
using Volo.Abp.AspNetCore.Components.WebAssembly.LeptonXTheme;
using Volo.Abp.LanguageManagement.Blazor.WebAssembly;
using Volo.Abp.LeptonX.Shared;
using Volo.Abp.OpenIddict.Pro.Blazor.WebAssembly;
using Volo.Abp.TextTemplateManagement.Blazor.WebAssembly;
using Volo.Payment.Admin.Blazor.WebAssembly;
using Volo.Saas.Host;
using Volo.Saas.Host.Blazor.WebAssembly;
using Volo.Saas.Tenant.Blazor.WebAssembly;

namespace DemoMicroService.Blazor;

[DependsOn(
    typeof(AbpAutofacWebAssemblyModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyLeptonXThemeModule),
    typeof(AbpIdentityProBlazorWebAssemblyModule),
    typeof(SaasHostBlazorWebAssemblyModule),
    typeof(SaasTenantBlazorWebAssemblyModule),
    typeof(AbpPaymentAdminBlazorWebAssemblyModule),
    typeof(AbpAccountAdminBlazorWebAssemblyModule),
    typeof(AbpAuditLoggingBlazorWebAssemblyModule),
    typeof(TextTemplateManagementBlazorWebAssemblyModule),
    typeof(LanguageManagementBlazorWebAssemblyModule),
    typeof(AbpOpenIddictProBlazorWebAssemblyModule),
    typeof(DemoMicroServiceSharedLocalizationModule),
    typeof(ProductServiceBlazorModule),
    typeof(ProductServiceHttpApiClientModule),
    typeof(AdministrationServiceHttpApiClientModule),
    typeof(SaasServiceHttpApiClientModule),
    typeof(IdentityServiceHttpApiClientModule)
)]
public class DemoMicroServiceBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
        var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

        ConfigureAuthentication(builder);
        ConfigureHttpClient(context, environment);
        ConfigureBlazorise(context);
        ConfigureRouter(context);
        ConfigureUI(builder);
        ConfigureMenu(context);
        ConfigureAutoMapper(context);
        ConfigureTheme();
    }

    private void ConfigureTheme()
    {
        Configure<LeptonXThemeOptions>(options =>
        {
            options.DefaultStyle = LeptonXStyleNames.System;
        });
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(DemoMicroServiceBlazorModule).Assembly;
        });
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new DemoMicroServiceMenuContributor(context.Services.GetConfiguration()));
        });
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();
    }

    private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("AuthServer", options.ProviderOptions);
            options.UserOptions.NameClaim = OpenIddictConstants.Claims.Name;
            options.UserOptions.RoleClaim = OpenIddictConstants.Claims.Role;
            options.ProviderOptions.DefaultScopes.Add("roles");
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("phone");
            options.ProviderOptions.DefaultScopes.Add("AccountService");
            options.ProviderOptions.DefaultScopes.Add("IdentityService");
            options.ProviderOptions.DefaultScopes.Add("AdministrationService");
            options.ProviderOptions.DefaultScopes.Add("SaasService");
            options.ProviderOptions.DefaultScopes.Add("ProductService");
        });
    }

    private static void ConfigureUI(WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#ApplicationContainer");
        builder.RootComponents.Add<HeadOutlet>("head::after");
    }

    private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
    {
        context.Services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri(environment.BaseAddress)
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DemoMicroServiceBlazorModule>();
        });
    }
}
