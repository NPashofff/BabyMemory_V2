using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using BabyMemory_V2.Model.Childern;
using BabyMemory_V2.Model.Event;

namespace BabyMemory_V2.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public ICollection<Children> Childrens { get; set; } = new List<Children>();

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
