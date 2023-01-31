using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BabyMemory_V2.Model.Childern
{
    public class Children
    {
        [Key]
        [MaxLength(GlobalConstants.IdGuidMaxLen)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLenDb)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLenDb)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(GlobalConstants.UrlMaxLen)]
        [AllowNull]
        public string Picture { get; set; }

        public ICollection<Memory.Memory> Memories { get; set; } = new List<Memory.Memory>();

        public ICollection<HealthProcedure.HealthProcedure> HealthProcedures { get; set; } = new List<HealthProcedure.HealthProcedure>();
    }
}
