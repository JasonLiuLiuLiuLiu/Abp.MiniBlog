using Microsoft.AspNetCore.Mvc;
using Abp.MiniBlog.Controllers;

namespace Abp.MiniBlog.Web.Controllers
{
    public class AboutController : MiniBlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
