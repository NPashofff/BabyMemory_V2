using Abp.Application.Services;
using BabyMemory_V2.MultiTenancy.Dto;

namespace BabyMemory_V2.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

