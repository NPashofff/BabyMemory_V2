using Abp.AutoMapper;
using BabyMemory_V2.Sessions.Dto;

namespace BabyMemory_V2.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
