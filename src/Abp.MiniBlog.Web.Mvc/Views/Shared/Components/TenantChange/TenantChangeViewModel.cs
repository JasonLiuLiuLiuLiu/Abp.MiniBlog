using Abp.AutoMapper;
using Abp.MiniBlog.Sessions.Dto;

namespace Abp.MiniBlog.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
