using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.MiniBlog.Blog;
using Abp.MiniBlog.Blog.Dtos;
using Abp.MiniBlog.Controllers;
using Abp.MiniBlog.Web.Models.Blogs;

namespace Abp.MiniBlog.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : MiniBlogControllerBase
    {
        private readonly IBlogAppService _blogAppService;

        public HomeController(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        public ActionResult Index()
        {
            var allBlogs = _blogAppService.GetListAsync(new GetBlogListInput()).Result;
            return View(new BlogsListViewModel
            {
                Blogs = allBlogs
            });
        }

        public async Task<ActionResult> Detail(Guid? blogId = null)
        {
            if (blogId != null)
                return View(await _blogAppService.GetDetailAsync(new EntityDto<Guid>(blogId.Value)));
            else
                return Redirect("Index");
        }
    }
}
