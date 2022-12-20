using System.Collections.Generic;
using BabyMemory_V2.Roles.Dto;

namespace BabyMemory_V2.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
