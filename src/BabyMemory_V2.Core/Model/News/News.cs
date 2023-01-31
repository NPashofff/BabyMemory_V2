using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BabyMemory_V2.Model.News
{
    public class News
    {
        [Key]
        [MaxLength(GlobalConstants.IdGuidMaxLen)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

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
