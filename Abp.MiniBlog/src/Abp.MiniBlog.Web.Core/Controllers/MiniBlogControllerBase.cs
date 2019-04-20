using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Abp.MiniBlog.Controllers
{
    public abstract class MiniBlogControllerBase: AbpController
    {
        protected MiniBlogControllerBase()
        {
            LocalizationSourceName = MiniBlogConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
