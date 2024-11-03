using System.ComponentModel.DataAnnotations;

namespace Web_bestcoder.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
