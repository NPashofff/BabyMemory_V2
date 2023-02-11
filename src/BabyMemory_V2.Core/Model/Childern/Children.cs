using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Abp.Domain.Entities.Auditing;
using BabyMemory_V2.Authorization.Users;

namespace BabyMemory_V2.Model.Children
{
    public class Children : FullAuditedEntity<long>
    {
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

        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

        public ICollection<Memory.Memory> Memories { get; set; } = new List<Memory.Memory>();

        public ICollection<HealthProcedure.HealthProcedure> HealthProcedures { get; set; } = new List<HealthProcedure.HealthProcedure>();
    }
}
