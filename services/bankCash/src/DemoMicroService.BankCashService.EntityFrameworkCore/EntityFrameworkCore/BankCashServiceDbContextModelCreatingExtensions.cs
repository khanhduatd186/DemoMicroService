using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DemoMicroService.BankCashService.EntityFrameworkCore;

public static class BankCashServiceDbContextModelCreatingExtensions
{
    public static void ConfigureBankCashService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BankCashServiceConsts.DbTablePrefix + "YourEntities", BankCashServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
