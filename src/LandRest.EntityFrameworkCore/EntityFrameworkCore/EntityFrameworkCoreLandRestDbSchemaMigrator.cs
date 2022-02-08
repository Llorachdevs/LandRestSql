using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LandRest.Data;
using Volo.Abp.DependencyInjection;

namespace LandRest.EntityFrameworkCore
{
    public class EntityFrameworkCoreLandRestDbSchemaMigrator
        : ILandRestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLandRestDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LandRestDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LandRestDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
