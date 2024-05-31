using System;
using Microsoft.Extensions.Logging;
using DemoMicroService.BankCashService.EntityFrameworkCore;
using DemoMicroService.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace DemoMicroService.BankCashService.DbMigrations;

public class BankCashServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<BankCashServiceDbContext>
{
    public BankCashServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            loggerFactory,
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            BankCashServiceDbProperties.ConnectionStringName)
    {

    }
}
