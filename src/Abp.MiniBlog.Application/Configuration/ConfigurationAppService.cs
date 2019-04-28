using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Abp.MiniBlog.Configuration.Dto;

namespace Abp.MiniBlog.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MiniBlogAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
