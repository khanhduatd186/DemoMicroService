﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoMicroService.AdministrationService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class AdministrationServiceDbContextFactory : IDesignTimeDbContextFactory<AdministrationServiceDbContext>
{
    public AdministrationServiceDbContext CreateDbContext(string[] args)
    {
        AdministrationServiceEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AdministrationServiceDbContext>()
            .UseNpgsql(GetConnectionStringFromConfiguration(), b =>
            {
                b.MigrationsHistoryTable("__AdministrationService_Migrations");
            });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        return new AdministrationServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration()
            .GetConnectionString(AdministrationServiceDbProperties.ConnectionStringName);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}DemoMicroService.AdministrationService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
