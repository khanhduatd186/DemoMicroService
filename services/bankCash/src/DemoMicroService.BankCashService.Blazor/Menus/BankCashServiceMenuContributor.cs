using System.Threading.Tasks;
using DemoMicroService.BankCashService.Localization;
using Volo.Abp.UI.Navigation;

namespace DemoMicroService.BankCashService.Blazor.Menus;

public class BankCashServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BankCashServiceResource>();
        return Task.CompletedTask;
    }
}
