using System;
using System.Collections.Generic;
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
                Blogs = allBlogs
            });
        }

        public async Task<ActionResult> Edit(Guid? blogId = null)
        {
            BlogDetailOutput blog = new BlogDetailOutput();
            if (blogId != null)
                blog = await _blogAppService.GetDetailAsync(new EntityDto<Guid>(blogId.Value));

            return View("Edit", blog);
        }

        public async Task Update(BlogDetailOutput input)
        {
            if (!string.IsNullOrEmpty(input.Content))
                await _blogAppService.Update(new BlogDto
                {
                    Id = input.Id,
                    Title = input.Title,
                    Excerpt = input.Excerpt,
                    Tags = input.Categories,
                    Content = input.Content
                });
            return;
        }

        public async Task<ActionResult> EditBlogModal(Guid blogId)
        {
            var blog = await _blogAppService.GetDetailAsync(new EntityDto<Guid>(blogId));

            return View("_EditBlogModal", new EditBlogModalViewModel
            {
                Blog = blog
            });
        }

    }
}