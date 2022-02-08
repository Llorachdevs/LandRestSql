using LandRest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LandRest.Permissions
{
    public class LandRestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LandRestPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(LandRestPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LandRestResource>(name);
        }
    }
}
