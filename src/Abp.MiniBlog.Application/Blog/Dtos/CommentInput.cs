using System;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class CommentInput
    {
        public Guid BlogId { get; set; }
        public string Author { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}
