using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BabyMemory_V2.Authorization.Users;
using BabyMemory_V2.Constant;
using BabyMemory_V2.Model.Children;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using BabyMemory_V2.Model.Childern;

namespace BabyMemory_V2.Event.Dto
{
    [AutoMap(typeof(Model.Event.Event))]
    public class EventDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EventDate { get; set; }

        public bool IsPublic { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public ICollection<ChildrenDto> Childrens { get; set; } = new List<ChildrenDto>();
    }
}
