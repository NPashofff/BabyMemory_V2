using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BabyMemory_V2.Model.Memory
{
    public class Memory
    {
        [Key]
        [MaxLength(GlobalConstants.IdGuidMaxLen)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

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
