using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BabyMemory_V2.Configuration.Dto;

namespace BabyMemory_V2.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BabyMemory_V2AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
