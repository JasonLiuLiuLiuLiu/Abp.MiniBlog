using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Abp.MiniBlog.Authorization.Roles;
using Abp.MiniBlog.Authorization.Users;
using Abp.MiniBlog.MultiTenancy;

namespace Abp.MiniBlog.EntityFrameworkCore
{
    public class MiniBlogDbContext : AbpZeroDbContext<Tenant, Role, User, MiniBlogDbContext>
    {
        public virtual DbSet<Blog.Blog> Blogs { get; set; }

        public virtual DbSet<Comment.Comment> Comments { get; set; }

        public MiniBlogDbContext(DbContextOptions<MiniBlogDbContext> options)
            : base(options)
        {
        }
    }
}
