using System.Collections.Generic;
using Abp.MiniBlog.Roles.Dto;

namespace Abp.MiniBlog.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
