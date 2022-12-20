using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BabyMemory_V2.Configuration;
using BabyMemory_V2.Web;

namespace BabyMemory_V2.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BabyMemory_V2DbContextFactory : IDesignTimeDbContextFactory<BabyMemory_V2DbContext>
    {
        public BabyMemory_V2DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BabyMemory_V2DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BabyMemory_V2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(BabyMemory_V2Consts.ConnectionStringName));

            return new BabyMemory_V2DbContext(builder.Options);
        }
    }
}
