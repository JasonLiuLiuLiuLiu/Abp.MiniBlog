using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.MiniBlog.MultiTenancy.Dto;

namespace Abp.MiniBlog.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

