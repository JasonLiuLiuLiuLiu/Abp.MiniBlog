using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;

namespace Abp.MiniBlog.Blog
{
    public class BlogManager:IBlogManager
    {
        private readonly IRepository<Blog,Guid> _blogRepository;

        public BlogManager(IRepository<Blog, Guid> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> GetAsync(Guid id)
        {
            var @blog = await _blogRepository.FirstOrDefaultAsync(id);
            if (@blog == null)
            {
                throw new UserFriendlyException("Could not found the blog, maybe it's deleted!");
            }

            return @blog;
        }

        public async Task CreateAsync(Blog @blog)
        {
            await _blogRepository.InsertAsync(@blog);
        }
    }
}
