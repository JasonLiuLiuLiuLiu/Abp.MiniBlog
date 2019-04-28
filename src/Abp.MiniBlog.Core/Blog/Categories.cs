using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;

namespace Abp.MiniBlog.Blog
{
    public class Categories:CreationAuditedEntity
    {
        [Required]
        public string Tag { get; set; }
    }
}
