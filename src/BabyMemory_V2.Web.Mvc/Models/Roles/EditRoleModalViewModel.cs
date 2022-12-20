using Abp.AutoMapper;
using BabyMemory_V2.Roles.Dto;
using BabyMemory_V2.Web.Models.Common;

namespace BabyMemory_V2.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
