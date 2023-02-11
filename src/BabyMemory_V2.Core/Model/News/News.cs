using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Abp.Domain.Entities.Auditing;

namespace BabyMemory_V2.Model.News
{
    public class News : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(GlobalConstants.NewsNameMaxLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.NewsDescriptionMaxLen)]
        [AllowNull]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
