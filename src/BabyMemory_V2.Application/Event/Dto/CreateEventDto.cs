using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;

namespace BabyMemory_V2.Event.Dto
{
    /// <summary>
    /// CreateEventDto
    /// </summary>
    [AutoMap(typeof(Model.Event.Event))]
    public class CreateEventDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.EventDescriptionMaxLen)]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EventDate { get; set; }

        [Required] public bool IsPublic { get; set; } = true;

        [Required]
        public long UserId { get; set; }
    }
}
