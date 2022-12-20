using System.Threading.Tasks;
using Abp.Application.Services;
using BabyMemory_V2.Sessions.Dto;

namespace BabyMemory_V2.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
