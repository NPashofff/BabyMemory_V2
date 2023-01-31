using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BabyMemory_V2.Model.HealthProcedure
{
    public class HealthProcedure
    {
        [Key]
        [MaxLength(GlobalConstants.IdGuidMaxLen)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.HealthProcedureNameMAxLenDb)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.MemoryDescriptionMaxLen)]
        [AllowNull]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Medicine.Medicine> Medicines { get; set; } = new List<Medicine.Medicine>();
    }
}
