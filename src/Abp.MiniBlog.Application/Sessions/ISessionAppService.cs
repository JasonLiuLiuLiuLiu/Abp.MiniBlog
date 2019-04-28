using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.MiniBlog.Sessions.Dto;

namespace Abp.MiniBlog.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
