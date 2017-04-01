namespace CameraBazaar.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [Username]
        public string UserName { get; set; }

        [Required]
        [Password]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
