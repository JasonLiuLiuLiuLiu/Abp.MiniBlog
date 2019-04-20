using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class CreateBlogInput
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; } = true;
    }
}
