using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using BabyMemory_V2.Authorization.Users;
using BabyMemory_V2.Editions;

namespace BabyMemory_V2.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
