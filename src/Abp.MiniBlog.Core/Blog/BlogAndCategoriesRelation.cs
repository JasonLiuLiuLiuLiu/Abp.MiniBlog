using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Abp.MiniBlog.Blog
{
    public class BlogAndCategoriesRelation : CreationAuditedEntity
    {
        public Guid BlogId { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
