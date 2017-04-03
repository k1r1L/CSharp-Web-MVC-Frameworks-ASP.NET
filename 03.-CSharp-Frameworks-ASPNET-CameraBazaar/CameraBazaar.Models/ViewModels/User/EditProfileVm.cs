namespace CameraBazaar.Models.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Constants;

    public class EditProfileVm
    {
        public string  UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [Password]
        [Display(Name = "Password:")]
        public string Password { get; set; }


        [PhoneNumber]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Password]
        [Display(Name = "New Password:")]
        public string NewPassword { get; set; }
    }
}
