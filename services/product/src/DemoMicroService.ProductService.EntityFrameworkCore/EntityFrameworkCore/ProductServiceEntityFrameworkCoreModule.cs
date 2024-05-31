using Microsoft.Extensions.DependencyInjection;
using DemoMicroService.ProductService.Products;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using System;
using Volo.Abp.EntityFrameworkCore.PostgreSql;

namespace DemoMicroService.ProductService.EntityFrameworkCore;

[DependsOn(
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(ProductServiceDomainModule)
)]
public class ProductServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ProductServiceEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ProductServiceDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<Product, EfCoreProductRepository>();
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<ProductServiceDbContext>(c =>
            {
                c.UseNpgsql(b =>
                {
                    b.MigrationsHistoryTable("__ProductService_Migrations");
                });
            });
        });
    }
}
