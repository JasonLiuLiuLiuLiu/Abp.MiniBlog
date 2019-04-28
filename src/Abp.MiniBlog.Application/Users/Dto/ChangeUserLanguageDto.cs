using System.ComponentModel.DataAnnotations;

namespace Abp.MiniBlog.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}