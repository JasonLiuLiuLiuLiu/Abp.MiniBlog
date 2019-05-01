using System;
using Abp.Application.Services.Dto;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class BlogListOutput : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Categories { get; set; }
    }
}
