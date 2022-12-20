using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BabyMemory_V2.Configuration;

namespace BabyMemory_V2.Web.Startup
{
    [DependsOn(typeof(BabyMemory_V2WebCoreModule))]
    public class BabyMemory_V2WebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BabyMemory_V2WebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<BabyMemory_V2NavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BabyMemory_V2WebMvcModule).GetAssembly());
        }
    }
}
