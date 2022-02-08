using System.Threading.Tasks;

namespace LandRest.Data
{
    public interface ILandRestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
