using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Abp.MiniBlog.Web.Views
{
    public abstract class MiniBlogRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MiniBlogRazorPage()
        {
            LocalizationSourceName = MiniBlogConsts.LocalizationSourceName;
        }
    }
}
