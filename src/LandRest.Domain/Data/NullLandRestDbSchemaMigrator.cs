using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LandRest.Data
{
    /* This is used if database provider does't define
     * ILandRestDbSchemaMigrator implementation.
     */
    public class NullLandRestDbSchemaMigrator : ILandRestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}