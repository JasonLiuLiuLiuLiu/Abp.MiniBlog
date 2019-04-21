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
        private readonly IRepository<Categories, int> _cateRepository;
        private readonly IRepository<BlogAndCategoriesRelation, int> _relationRepository;
        private readonly IBlogManager _blogManager;

        public BlogAppService(IRepository<Blog, Guid> blogRepository, IBlogManager blogManager, IRepository<Categories, int> cateRepository, IRepository<BlogAndCategoriesRelation, int> relationRepository)
        {
            _blogRepository = blogRepository;
            _blogManager = blogManager;
            _cateRepository = cateRepository;
            _relationRepository = relationRepository;
        }

        public async Task<List<BlogDto>> GetListAsync(GetBlogListInput input)
        {
            var blogs = await _blogRepository.GetAll().Include(e => e.Comments).OrderByDescending(e => e.CreationTime)
                .Take(64).ToListAsync();
            return blogs.Select(u=>new BlogDto
            {
                Title = u.Title,
                Excerpt = u.Excerpt,
                Content = u.Content
            }).ToList();
        }

        public async Task<BlogDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var blog = await _blogRepository
                .GetAll()
                .Include(e => e.Comments)
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (blog == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }



            return new BlogDetailOutput
            {
                Id=blog.Id,
                Title = blog.Title,
                Excerpt = blog.Excerpt,
                Content = blog.Content,
                Categories = "1,2,3,4,5,6"
            };
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
            if (input.Id == Guid.Empty)
                await CreateAsync(new CreateBlogInput()
                {
                    Title = input.Title,
                    Excerpt = input.Excerpt,
                    Content = input.Content
                });
            else
            {
                var blog = await _blogManager.GetAsync(input.Id);
                MapToEntity(input,blog);
                _blogRepository.Update(blog);
            }

            var tags = input.Tags.Split(',');
            if(tags==null)
                return input;

            var allTags=_cateRepository.GetAll().Where(u=>tags.Contains(u.Tag)).ToList();

            var tagNotIn = tags.Where(t => allTags.All(all => all.Tag != t));

            foreach (var tag in tagNotIn)
            {
                var tagEntity=new Categories
                {
                    Tag = tag
                };
                _cateRepository.Insert(tagEntity);
                allTags.Add(tagEntity);
            }

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
