using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BabyMemory_V2.Model.Medicine
{
    public class Medicine
    {
        [Key]
        [MaxLength(GlobalConstants.IdGuidMaxLen)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.MedicineNameMaxLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.MedicineDescriptionMaxLen)]
        public string? Description { get; set; }

        public ICollection<HealthProcedure.HealthProcedure> HealthProcedures { get; set; }
    }
}
