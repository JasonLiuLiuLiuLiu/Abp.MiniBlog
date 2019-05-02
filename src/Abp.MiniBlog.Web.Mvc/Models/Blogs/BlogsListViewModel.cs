using System.Collections.Generic;
using Abp.MiniBlog.Blog.Dtos;

namespace Abp.MiniBlog.Web.Models.Blogs
{
    public class BlogsListViewModel
    {
        public IReadOnlyList<BlogListOutput> Blogs { get; set; }

        public IReadOnlyList<TopTagLOutput> Tags { get; set; }
    }
}
