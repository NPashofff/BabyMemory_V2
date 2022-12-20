using System.Threading.Tasks;
using BabyMemory_V2.Models.TokenAuth;
using BabyMemory_V2.Web.Controllers;
using Shouldly;
using Xunit;

namespace BabyMemory_V2.Web.Tests.Controllers
{
    public class HomeController_Tests: BabyMemory_V2WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}