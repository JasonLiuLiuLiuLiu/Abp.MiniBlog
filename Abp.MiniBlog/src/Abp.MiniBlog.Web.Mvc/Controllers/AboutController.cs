using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.MiniBlog.Controllers;

namespace Abp.MiniBlog.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MiniBlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
