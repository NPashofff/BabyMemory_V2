using BabyMemory_V2.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace BabyMemory_V2.Model.Childern
{
    [AutoMapTo(typeof(Children.Children))]
    public class CreateChildrenDto : EntityDto<long>
    {
        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLenDb)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLenDb)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public long UserId { get; set; }

        [MaxLength(GlobalConstants.UrlMaxLen)]
        [Display(Name = GlobalConstants.ImageName)]
        public string Picture { get; set; } = GlobalConstants.DefaultPicture;
    }
}
