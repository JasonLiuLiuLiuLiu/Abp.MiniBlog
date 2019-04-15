using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Abp.MiniBlog.Authorization.Roles;
using Abp.MiniBlog.Authorization.Users;
using Abp.MiniBlog.MultiTenancy;

namespace Abp.MiniBlog.EntityFrameworkCore
{
    public class MiniBlogDbContext : AbpZeroDbContext<Tenant, Role, User, MiniBlogDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MiniBlogDbContext(DbContextOptions<MiniBlogDbContext> options)
            : base(options)
        {
        }
    }
}
