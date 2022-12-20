using BabyMemory_V2.Sessions.Dto;

namespace BabyMemory_V2.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            var userName = LoginInformations.User.UserName;

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.User.Name + " " + LoginInformations.User.Surname;
            //return LoginInformations.Tenant == null
            //    ? ".\\" + userName
            //    : LoginInformations.Tenant.TenancyName + "\\" + userName;
        }
    }
}
