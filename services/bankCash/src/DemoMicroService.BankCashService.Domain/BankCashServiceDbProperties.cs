namespace DemoMicroService.BankCashService;

public static class BankCashServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BankCashService";
}
