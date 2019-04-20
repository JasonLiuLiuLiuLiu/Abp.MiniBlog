using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.MiniBlog.Authorization.Users;
using Abp.MiniBlog.Blog.Dtos;
using Abp.MiniBlog.Users.Dto;
using Abp.UI;
using Microsoft.EntityFrameworkCore;

namespace Abp.MiniBlog.Blog
{
    public class BlogAppService : MiniBlogAppServiceBase, IBlogAppService
    {
        private readonly IRepository<Blog, Guid> _blogRepository;
        private readonly IBlogManager _blogManager;

        public BlogAppService(IRepository<Blog, Guid> blogRepository, IBlogManager blogManager)
        {
            _blogRepository = blogRepository;
            _blogManager = blogManager;
        }

        public async Task<ListResultDto<BlogDto>> GetListAsync(GetBlogListInput input)
        {
            var blogs = await _blogRepository.GetAll().Include(e => e.Comments).OrderByDescending(e => e.CreationTime)
                .Take(64).ToListAsync();
            return new ListResultDto<BlogDto>(blogs.MapTo<List<BlogDto>>());
        }

        public async Task<BlogDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var @event = await _blogRepository
                .GetAll()
                .Include(e => e.Comments)
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @event.MapTo<BlogDetailOutput>();
        }

        public async Task CreateAsync(CreateBlogInput input)
        {
            var blog = new Blog
            {
                Title = input.Title,
                Slug = input.Slug,
                Excerpt = input.Excerpt,
                Content = input.Content
            };
            await _blogManager.CreateAsync(blog);
        }

        public async Task<BlogDto> Update(BlogDto input)
        {
            var blog = await _blogManager.GetAsync(input.Id);
            MapToEntity(input,blog);
            _blogRepository.Update(blog);
            return input;
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            var blog = await _blogManager.GetAsync(input.Id);
            await _blogRepository.DeleteAsync(blog);
        }

        private void MapToEntity(BlogDto input, Blog user)
        {
            ObjectMapper.Map(input, user);
        }
    }
}
