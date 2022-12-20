using Abp.MultiTenancy;
using BabyMemory_V2.Authorization.Users;

namespace BabyMemory_V2.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
