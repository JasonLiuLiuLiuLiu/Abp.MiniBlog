using System.Collections.Generic;
using System.Linq;
using Abp.MiniBlog.Roles.Dto;
using Abp.MiniBlog.Users.Dto;

namespace Abp.MiniBlog.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
