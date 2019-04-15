using Abp.Application.Services.Dto;

namespace Abp.MiniBlog.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

