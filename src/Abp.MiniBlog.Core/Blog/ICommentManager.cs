using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Abp.MiniBlog.Blog
{
    public interface ICommentManager : IDomainService
    {
        IAsyncEnumerable<Comment> GetAsync(Guid blogId);

        Task CreateAsync(Comment comment);
    }
}
