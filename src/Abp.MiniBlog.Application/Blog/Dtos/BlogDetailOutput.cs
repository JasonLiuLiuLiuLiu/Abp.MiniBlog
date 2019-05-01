using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class BlogDetailOutput : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }

        public string Categories { get; set; }

        public bool IsPublished { get; set; } = true;

        public IList<Comment> Comments { get; set; }
    }
}
