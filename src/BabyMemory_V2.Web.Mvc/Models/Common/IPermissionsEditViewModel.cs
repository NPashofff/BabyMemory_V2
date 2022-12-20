using System.Collections.Generic;
using BabyMemory_V2.Roles.Dto;

namespace BabyMemory_V2.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}