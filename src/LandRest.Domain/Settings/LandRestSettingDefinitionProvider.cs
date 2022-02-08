using Volo.Abp.Settings;

namespace LandRest.Settings
{
    public class LandRestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LandRestSettings.MySetting1));
        }
    }
}
