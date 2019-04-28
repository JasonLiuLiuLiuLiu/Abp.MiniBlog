using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Abp.MiniBlog.Configuration;
using Abp.MiniBlog.Web;

namespace Abp.MiniBlog.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MiniBlogDbContextFactory : IDesignTimeDbContextFactory<MiniBlogDbContext>
    {
        public MiniBlogDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MiniBlogDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MiniBlogDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MiniBlogConsts.ConnectionStringName));

            return new MiniBlogDbContext(builder.Options);
        }
    }
}
