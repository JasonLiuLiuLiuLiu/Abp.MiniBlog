using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.MiniBlog.Blog.Dtos;
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
            return blogs.Select(u => new BlogDto
            {
                Id = u.Id,
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

            StringBuilder sb = new StringBuilder();
            await _relationRepository.GetAllIncluding(u => u.Categories).Where(u => u.BlogId == input.Id).ForEachAsync(u => sb.Append(u.Categories.Tag+','));

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            return new BlogDetailOutput
            {
                Id = blog.Id,
                Title = blog.Title,
                Excerpt = blog.Excerpt,
                Content = blog.Content,
                Categories = sb.ToString()
            };
        }

        public async Task<Guid> CreateAsync(CreateBlogInput input)
        {
            var blog = new Blog
            {
                Title = input.Title,
                Slug = input.Slug,
                Excerpt = input.Excerpt,
                Content = input.Content
            };
            await _blogManager.CreateAsync(blog);
            return blog.Id;
        }

        public async Task<BlogDto> Update(BlogDto input)
        {
            if (string.IsNullOrEmpty(input.Excerpt))
            {
                var subLength = input.Content.Length <= 5000 ? input.Content.Length : 5000;
                var result = GetPlainTextFromHtml(input.Content.Substring(0, subLength));
                if (result.LastIndexOf('<') > 0)
                    result = result.Substring(0, result.LastIndexOf('<'));
                input.Excerpt = result.Substring(0, result.Length > 120 ? 120 : result.Length);
            }

            if (input.Id == Guid.Empty)
                input.Id = await CreateAsync(new CreateBlogInput()
                {
                    Title = input.Title,
                    Excerpt = input.Excerpt,
                    Content = input.Content
                });
            else
            {
                var blog = await _blogManager.GetAsync(input.Id);
                blog.Title = input.Title;
                blog.Excerpt = input.Excerpt;
                blog.Content = input.Content;
                _blogRepository.Update(blog);
            }

            if (!string.IsNullOrEmpty(input.Tags))
            {
                var tags = input.Tags.Split(',');
                if (tags == null)
                    return input;

                var allTags = _cateRepository.GetAll().Where(u => tags.Contains(u.Tag)).ToList();

                var tagNotIn = tags.Where(t => allTags.All(all => all.Tag != t));

                foreach (var tag in tagNotIn)
                {
                    var tagEntity = new Categories
                    {
                        Tag = tag
                    };
                    _cateRepository.Insert(tagEntity);
                    allTags.Add(tagEntity);
                }
                await UpdateTagRelation(input.Id, allTags);
            }
            return input;
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            var blog = await _blogManager.GetAsync(input.Id);
            await _blogRepository.DeleteAsync(blog);
        }

        private async Task UpdateTagRelation(Guid blogId, List<Categories> tags)
        {
            var allRelation = _relationRepository.GetAllIncluding(u => u.Categories).Where(u => u.BlogId == blogId);
            var needInsert = tags.Where(u => allRelation.All(r => r.CategoriesId != u.Id));
            foreach (var tag in needInsert)
            {
                await _relationRepository.InsertAsync(new BlogAndCategoriesRelation
                {
                    BlogId = blogId,
                    CategoriesId = tag.Id
                });
            }

            var needDelete = allRelation.Where(r => tags.All(u => u.Id != r.CategoriesId));
            foreach (var tag in needDelete)
            {
                await _relationRepository.DeleteAsync(tag.Id);
            }
        }
        private string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }
    }
}
