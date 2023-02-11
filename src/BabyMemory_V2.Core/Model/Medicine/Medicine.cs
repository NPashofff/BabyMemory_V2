using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace BabyMemory_V2.Model.Medicine
{
    public class Medicine : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(GlobalConstants.MedicineNameMaxLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.MedicineDescriptionMaxLen)]
        public string? Description { get; set; }

        public ICollection<HealthProcedure.HealthProcedure> HealthProcedures { get; set; }
    }
}
