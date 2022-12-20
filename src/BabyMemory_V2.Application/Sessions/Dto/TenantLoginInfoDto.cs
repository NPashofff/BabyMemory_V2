using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BabyMemory_V2.MultiTenancy;

namespace BabyMemory_V2.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
