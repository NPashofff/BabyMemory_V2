using Abp.Application.Services.Dto;

namespace BabyMemory_V2.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

