using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace BabyMemory_V2.Events.Dto
{
    [AutoMap(typeof(Model.Event.Event))]
    public class EventDto : EntityDto<long>
    {
    }
}
