using System.Threading.Tasks;
using Abp.MiniBlog.Configuration.Dto;

namespace Abp.MiniBlog.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
