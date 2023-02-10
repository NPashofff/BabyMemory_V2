using BabyMemory_V2.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BabyMemory_V2.Model.Childern
{
    public class ChildrenViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Display(Name = GlobalConstants.ImageName)]
        public string Picture { get; set; }

        public ICollection<Memory.Memory> Memories { get; set; } = new List<Memory.Memory>();

        public ICollection<HealthProcedure.HealthProcedure> HealthProcedures { get; set; } = new List<HealthProcedure.HealthProcedure>();
    }
}
