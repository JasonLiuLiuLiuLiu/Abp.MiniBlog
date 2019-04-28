using Abp.AspNetCore.Mvc.ViewComponents;

namespace Abp.MiniBlog.Web.Views
{
    public abstract class MiniBlogViewComponent : AbpViewComponent
    {
        protected MiniBlogViewComponent()
        {
            LocalizationSourceName = MiniBlogConsts.LocalizationSourceName;
        }
    }
}
