using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BabyMemory_V2.Configuration;
using BabyMemory_V2.EntityFrameworkCore;
using BabyMemory_V2.Migrator.DependencyInjection;

namespace BabyMemory_V2.Migrator
{
    [DependsOn(typeof(BabyMemory_V2EntityFrameworkModule))]
    public class BabyMemory_V2MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BabyMemory_V2MigratorModule(BabyMemory_V2EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(BabyMemory_V2MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BabyMemory_V2Consts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BabyMemory_V2MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
