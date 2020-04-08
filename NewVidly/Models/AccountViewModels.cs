using System.ComponentModel.DataAnnotations;

namespace NewVidly.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
