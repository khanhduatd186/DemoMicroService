using Volo.Abp.Reflection;

namespace DemoMicroService.BankCashService.Permissions;

public class BankCashServicePermissions
{
    public const string GroupName = "BankCashService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BankCashServicePermissions));
    }
}
