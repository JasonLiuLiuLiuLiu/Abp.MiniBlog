using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class BlogDetailOutput : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }

        public IList<string> Categories { get; set; } = new List<string>();

        public bool IsPublished { get; set; } = true;

        public IList<Comment> Comments { get; } = new List<Comment>();
    }
}
