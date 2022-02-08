using System.Collections.Generic;
using LandRest.Blogs;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace LandRest
{
    public static class LandRestDtoExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                /* You can add extension properties to DTOs
                 * defined in the depended modules.
                 *
                 * Example:
                 *
                 * ObjectExtensionManager.Instance
                 *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
                 *
                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Object-Extensions
                 */
                
               

                
                // ObjectExtensionManager.Instance
                //     .AddOrUpdate<IdentityUser>(options =>
                //         {
                //             options.AddOrUpdateProperty<List<BlogArticle>>("Articles");
                //             options.AddOrUpdateProperty<List<BlogArticleComment>>("Comments");
                //             options.AddOrUpdateProperty<string>("SecondName");
                //             options.AddOrUpdateProperty<string>("SecondLastName");
                //             options.AddOrUpdateProperty<string>("CvLink");
                //         }
                //     );
            });
        }
    }
}