using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.MiniBlog.Authorization;
using Abp.MiniBlog.Blog;
using Abp.MiniBlog.Web.Models.Blogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abp.MiniBlog.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Blogs)]
    public class BlogsController : Controller
    {
        private readonly IBlogAppService _blogAppService;

        public BlogsController(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        // GET: Blogs
        public ActionResult Index()
        {
            var allBlogs = _blogAppService.GetListAsync(null).Result;
            return View(new BlogsListViewModel
            {
                Blogs = allBlogs.Items
            });
        }

    }
}