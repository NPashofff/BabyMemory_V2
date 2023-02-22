using Abp.Application.Services;
using Abp.Domain.Repositories;
using BabyMemory_V2.Events.Dto;
using BabyMemory_V2.Users.Dto;

namespace BabyMemory_V2.Event
{
    public class EventAppService : AsyncCrudAppService<Model.Event.Event, EventDto, long, PagedUserResultRequestDto, CreateEventDto, EventDto>
    {
        public EventAppService(IRepository<Model.Event.Event, long> repository) 
            : base(repository)
        {
        }
    }
}
