using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Abp.MiniBlog.Blog
{
    [Table("Blogs")]
    public class Blog:FullAuditedEntity<Guid>
    {
        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Excerpt { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsPublished { get; set; } = true;

        [ForeignKey("BlogId")]
        public IList<Comment.Comment> Comments { get; } = new List<Comment.Comment>();
    }
}
