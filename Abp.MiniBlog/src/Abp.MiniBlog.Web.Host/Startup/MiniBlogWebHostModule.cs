using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.MiniBlog.Configuration;

namespace Abp.MiniBlog.Web.Host.Startup
{
    [DependsOn(
       typeof(MiniBlogWebCoreModule))]
    public class MiniBlogWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MiniBlogWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MiniBlogWebHostModule).GetAssembly());
        }
    }
}
