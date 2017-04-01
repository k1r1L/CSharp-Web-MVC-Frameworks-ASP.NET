namespace CameraBazaar.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class RegisterViewModel
    {
        [Required]
        [Username]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "UserName")]
        public string Email { get; set; }

        [Required]   
        [Password]    
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [PhoneNumber]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}
