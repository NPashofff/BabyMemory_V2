using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BabyMemory_V2.Authorization.Roles;
using BabyMemory_V2.Authorization.Users;
using BabyMemory_V2.Model.Childern;
using BabyMemory_V2.Model.Event;
using BabyMemory_V2.Model.HealthProcedure;
using BabyMemory_V2.Model.Medicine;
using BabyMemory_V2.Model.Memory;
using BabyMemory_V2.Model.News;
using BabyMemory_V2.MultiTenancy;

namespace BabyMemory_V2.EntityFrameworkCore
{
    public class BabyMemory_V2DbContext : AbpZeroDbContext<Tenant, Role, User, BabyMemory_V2DbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<News> News { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<HealthProcedure> HealthProcedures { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Children> Childrens { get; set; }

        public BabyMemory_V2DbContext(DbContextOptions<BabyMemory_V2DbContext> options)
            : base(options)
        {
        }
    }
}
