using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BabyMemory_V2.EntityFrameworkCore;
using BabyMemory_V2.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BabyMemory_V2.Web.Tests
{
    [DependsOn(
        typeof(BabyMemory_V2WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BabyMemory_V2WebTestModule : AbpModule
    {
        public BabyMemory_V2WebTestModule(BabyMemory_V2EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BabyMemory_V2WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BabyMemory_V2WebMvcModule).Assembly);
        }
    }
}