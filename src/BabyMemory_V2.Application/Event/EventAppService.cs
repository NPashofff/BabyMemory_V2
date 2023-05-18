using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using BabyMemory_V2.Event.Dto;
using BabyMemory_V2.Users.Dto;

namespace BabyMemory_V2.Event
{
    public class EventAppService : AsyncCrudAppService<Model.Event.Event, EventDto, long, PagedUserResultRequestDto, CreateEventDto, EventDto>
    {
        public EventAppService(IRepository<Model.Event.Event, long> repository)
            : base(repository)
        {
        }

        public override Task<EventDto> UpdateAsync(EventDto input)
        {
            //todo; ?? дали да подам ид от вън
            input.UserId = AbpSession.UserId.Value;
            return base.UpdateAsync(input);
        }

        public override Task<EventDto> CreateAsync(CreateEventDto input)
        {
            input.UserId = AbpSession.UserId.Value;
            return base.CreateAsync(input);
        }
    }
}
