using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LandRest.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class LandRestMigrationsDbContextFactory : IDesignTimeDbContextFactory<LandRestMigrationsDbContext>
    {
        public LandRestMigrationsDbContext CreateDbContext(string[] args)
        {
            LandRestEfCoreEntityExtensionMappings.Configure();
            
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<LandRestMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("default"));

            return new LandRestMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LandRest.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);
            
            return builder.Build();
        }
    }
}