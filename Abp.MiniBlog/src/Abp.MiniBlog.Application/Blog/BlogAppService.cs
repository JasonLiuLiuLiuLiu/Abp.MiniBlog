using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.MiniBlog.Blog.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Abp.MiniBlog.Blog
{
    class BlogAppService:MiniBlogAppServiceBase,IBlogAppService
    {
        private readonly IRepository<Blog, Guid> _blogRepository;

        public BlogAppService(IRepository<Blog, Guid> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<ListResultDto<BlogListDto>> GetListAsync(GetBlogListInput input)
        {
            var blogs = await _blogRepository.GetAll().Include(e => e.Comments).OrderByDescending(e => e.CreationTime)
                .Take(64).ToListAsync();
            return new ListResultDto<BlogListDto>(blogs.MapTo<List<BlogListDto>>());
        }
    }
}
