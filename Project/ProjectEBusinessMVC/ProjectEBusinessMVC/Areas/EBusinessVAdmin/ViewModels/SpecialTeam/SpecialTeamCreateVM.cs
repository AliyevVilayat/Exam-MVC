using System.ComponentModel.DataAnnotations;

namespace ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.SpecialTeam
{
    public class SpecialTeamCreateVM
    {
        [Required, MaxLength(50, ErrorMessage = "The maximum length of an input Fullname can be 50")]
        public string? FullName { get; set; }

        [Required, MaxLength(30, ErrorMessage = "The maximum length of an input Position can be 30")]
        public string? Position { get; set; }

        [Required]
        public IFormFile? Img { get; set; }

        [MaxLength(100, ErrorMessage = "The maximum length of an input Social Media Links can be 100")]
        public string? FacebookSM { get; set; }

        [MaxLength(100, ErrorMessage = "The maximum length of an input Social Media Links can be 100")]
        public string? TwitterSM { get; set; }

        [MaxLength(100, ErrorMessage = "The maximum length of an input Social Media Links can be 100")]
        public string? InstagramSM { get; set; }
    }
}
