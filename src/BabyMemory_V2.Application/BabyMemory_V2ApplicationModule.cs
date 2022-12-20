using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BabyMemory_V2.Authorization;

namespace BabyMemory_V2
{
    [DependsOn(
        typeof(BabyMemory_V2CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BabyMemory_V2ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BabyMemory_V2AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BabyMemory_V2ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
