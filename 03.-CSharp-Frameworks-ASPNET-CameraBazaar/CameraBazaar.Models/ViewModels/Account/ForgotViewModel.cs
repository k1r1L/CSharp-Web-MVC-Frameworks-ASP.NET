namespace CameraBazaar.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Email { get; set; }
    }

}
