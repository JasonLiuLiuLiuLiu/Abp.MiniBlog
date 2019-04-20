using System;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Abp.MiniBlog.Blog
{
    public interface IBlogManager:IDomainService
    {
        Task<Blog> GetAsync(Guid id);

        Task CreateAsync(Blog @event);
    }
}
