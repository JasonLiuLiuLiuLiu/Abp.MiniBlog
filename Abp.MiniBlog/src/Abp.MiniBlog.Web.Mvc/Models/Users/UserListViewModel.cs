using System.Collections.Generic;
using Abp.MiniBlog.Roles.Dto;
using Abp.MiniBlog.Users.Dto;

namespace Abp.MiniBlog.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
