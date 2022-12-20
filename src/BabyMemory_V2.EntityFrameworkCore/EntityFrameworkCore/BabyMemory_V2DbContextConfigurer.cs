using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BabyMemory_V2.EntityFrameworkCore
{
    public static class BabyMemory_V2DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BabyMemory_V2DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BabyMemory_V2DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
