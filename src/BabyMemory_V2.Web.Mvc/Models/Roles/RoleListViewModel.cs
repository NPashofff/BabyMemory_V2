using System.Collections.Generic;
using BabyMemory_V2.Roles.Dto;

namespace BabyMemory_V2.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
