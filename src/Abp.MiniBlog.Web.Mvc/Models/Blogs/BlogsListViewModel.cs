using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.MiniBlog.Blog.Dtos;

namespace Abp.MiniBlog.Web.Models.Blogs
{
    public class BlogsListViewModel
    {
        public IReadOnlyList<BlogDto> Blogs { get; set; }
    }
}
