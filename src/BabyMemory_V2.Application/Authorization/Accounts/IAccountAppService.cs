using System.Threading.Tasks;
using Abp.Application.Services;
using BabyMemory_V2.Authorization.Accounts.Dto;

namespace BabyMemory_V2.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
