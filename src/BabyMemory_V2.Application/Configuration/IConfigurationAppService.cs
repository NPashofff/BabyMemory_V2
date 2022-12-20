using System.Threading.Tasks;
using BabyMemory_V2.Configuration.Dto;

namespace BabyMemory_V2.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
