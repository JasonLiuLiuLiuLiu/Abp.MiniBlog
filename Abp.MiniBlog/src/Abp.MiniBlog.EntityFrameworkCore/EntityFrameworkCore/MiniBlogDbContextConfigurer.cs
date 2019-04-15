using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Abp.MiniBlog.EntityFrameworkCore
{
    public static class MiniBlogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MiniBlogDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MiniBlogDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
