using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Abp.Domain.Entities.Auditing;

namespace BabyMemory_V2.Model.Memory
{
    public class Memory : FullAuditedEntity<long>
    {
        public DateTime CreationDate { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MemoryNameMaxLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.MemoryDescriptionMaxLen)]
        [AllowNull]
        public string Description { get; set; }

        [MaxLength(GlobalConstants.UrlMaxLen)]
        [AllowNull]
        [Display(Name = GlobalConstants.ImageName)]
        public string Picture { get; set; }
    }
}
