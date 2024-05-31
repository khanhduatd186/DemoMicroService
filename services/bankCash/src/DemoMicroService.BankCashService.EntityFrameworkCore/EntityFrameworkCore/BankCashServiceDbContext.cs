using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.BankCashService.EntityFrameworkCore;

[ConnectionStringName(BankCashServiceDbProperties.ConnectionStringName)]
public class BankCashServiceDbContext : AbpDbContext<BankCashServiceDbContext>
{

    public BankCashServiceDbContext(DbContextOptions<BankCashServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBankCashService();
    }
}
