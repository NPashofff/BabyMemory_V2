using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;

namespace BabyMemory_V2.Model.Childern
{
    public class ChildrenAddViewModel
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
        [Display(Name = GlobalConstants.ImageName)]
        public string Picture { get; set; } = GlobalConstants.DefaultPicture;
    }
}
