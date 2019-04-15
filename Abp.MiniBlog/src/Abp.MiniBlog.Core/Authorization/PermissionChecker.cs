using Abp.Authorization;
using Abp.MiniBlog.Authorization.Roles;
using Abp.MiniBlog.Authorization.Users;

namespace Abp.MiniBlog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
