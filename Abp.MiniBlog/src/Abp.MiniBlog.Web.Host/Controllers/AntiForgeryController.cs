using Microsoft.AspNetCore.Antiforgery;
using Abp.MiniBlog.Controllers;

namespace Abp.MiniBlog.Web.Host.Controllers
{
    public class AntiForgeryController : MiniBlogControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
