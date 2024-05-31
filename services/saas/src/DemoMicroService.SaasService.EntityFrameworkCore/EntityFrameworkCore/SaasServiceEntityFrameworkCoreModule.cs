using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using Volo.Saas.EntityFrameworkCore;

namespace DemoMicroService.SaasService.EntityFrameworkCore;

[DependsOn(
    typeof(SaasServiceDomainModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule)
)]
public class SaasServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        SaasServiceEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SaasServiceDbContext>(options =>
        {
            options.ReplaceDbContext<ISaasDbContext>();

                /* includeAllEntities: true allows to use IRepository<TEntity, TKey> also for non aggregate root entities */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<SaasServiceDbContext>(c =>
            {
                c.UseNpgsql(b =>
                {
                    b.MigrationsHistoryTable("__SaasService_Migrations");
                });
            });
        });
    }
}
