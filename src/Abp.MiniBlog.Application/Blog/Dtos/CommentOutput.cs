using System;

namespace Abp.MiniBlog.Blog.Dtos
{
    public class CommentOutput
    {

        public string Author { get; set; }


        public string Content { get; set; }

        public DateTime CreateTime { get; set; }


        public string Gravatar { get; set; }

    }
}
