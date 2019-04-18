using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.MiniBlog.Authorization;
using Abp.MiniBlog.Blog;
using Abp.MiniBlog.Blog.Dtos;
using Abp.MiniBlog.Controllers;
using Abp.MiniBlog.Web.Models.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Abp.MiniBlog.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Blogs)]
    public class BlogsController : MiniBlogControllerBase
    {
        private readonly IBlogAppService _blogAppService;

        public BlogsController(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        // GET: Blogs
        public ActionResult Index()
        {
            var allBlogs = _blogAppService.GetListAsync(new GetBlogListInput()).Result;
            return View(new BlogsListViewModel
            {
                Blogs = allBlogs.Items
            });
        }

        public async Task<ActionResult> EditBlogModal(Guid blogId)
        {
            var blog = await _blogAppService.GetDetailAsync(new EntityDto<Guid>(blogId));

            return View("_EditBlogModal",new EditBlogModalViewModel
            {
                Blog = blog
            });
        }

    }
}