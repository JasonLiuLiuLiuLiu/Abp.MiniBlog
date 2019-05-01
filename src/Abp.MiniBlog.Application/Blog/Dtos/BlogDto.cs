using System;
using Abp.Application.Services.Dto;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class BlogDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; } = true;

        public string Tags { get; set; }
    }
}
