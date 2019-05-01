using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Abp.MiniBlog.Blog
{
    public class CommentManager : ICommentManager
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentManager(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IAsyncEnumerable<Comment> GetAsync(Guid blogId)
        {
            return _commentRepository.Query(q => q.Where(c => c.BlogId == blogId)).ToAsyncEnumerable();
        }

        public async Task CreateAsync(Comment comment)
        {
            await _commentRepository.InsertAsync(comment);
        }
    }
}
