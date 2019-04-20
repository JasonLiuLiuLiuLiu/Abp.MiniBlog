using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.MiniBlog.Authorization;

namespace Abp.MiniBlog
{
    [DependsOn(
        typeof(MiniBlogCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MiniBlogApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MiniBlogAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MiniBlogApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
