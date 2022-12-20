using Abp.Authorization;
using BabyMemory_V2.Authorization.Roles;
using BabyMemory_V2.Authorization.Users;

namespace BabyMemory_V2.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
