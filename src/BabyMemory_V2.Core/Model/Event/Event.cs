using BabyMemory_V2.Authorization.Users;
using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Abp.Domain.Entities.Auditing;

namespace BabyMemory_V2.Model.Event
{
    public class Event : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(GlobalConstants.EventNameMaxLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.EventDescriptionMaxLen)]
        [AllowNull]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EventDate { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

        public User User { get; set; }

        public ICollection<Children.Children> Childrens { get; set; } = new List<Children.Children>();
    }
}
