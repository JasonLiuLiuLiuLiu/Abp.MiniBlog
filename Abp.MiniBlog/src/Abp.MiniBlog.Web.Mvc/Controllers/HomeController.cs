using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.MiniBlog.Controllers;

namespace Abp.MiniBlog.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : MiniBlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}
