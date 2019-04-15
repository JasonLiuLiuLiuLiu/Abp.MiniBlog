using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Abp.MiniBlog.Comment
{
    [Table("Comments")]
    public class Comment:CreationAuditedEntity
    {
        [Required]
        public string Author { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsAdmin { get; set; }

        public virtual Blog.Blog  Blog{ get; protected set; }

        public virtual Guid BlogId { get; protected set; }

    }
}
