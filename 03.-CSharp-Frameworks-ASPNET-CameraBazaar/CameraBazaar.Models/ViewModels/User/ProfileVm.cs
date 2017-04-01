namespace CameraBazaar.Models.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Camera;

    public class ProfileVm
    {
        public string Id { get; set; }

        [Display(Name = "Email:")]
        public string Email { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Phone:")]
        public string PhoneNumber { get; set; }

        // Configure in Automapper
        public int CamerasInStock { get; set; }

        // Configure in Automapper
        public int CamerasOutOfStock { get; set; }

        public IEnumerable<AllCameraVm> Cameras { get; set; }
    }
}
