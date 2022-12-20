using System.ComponentModel.DataAnnotations;

namespace BabyMemory_V2.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}