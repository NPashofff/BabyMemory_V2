using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BabyMemory_V2.Configuration;

namespace BabyMemory_V2.Web.Host.Startup
{
    [DependsOn(
       typeof(BabyMemory_V2WebCoreModule))]
    public class BabyMemory_V2WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BabyMemory_V2WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BabyMemory_V2WebHostModule).GetAssembly());
        }
    }
}
