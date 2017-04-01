namespace CameraBazaar.Models.ViewModels.Camera
{
    using System.ComponentModel.DataAnnotations;

    public class DetailsCameraVm
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        //Configure in Automapper
        public bool InStock { get; set; }

        [Display(Name = "Min Shutter Speed:")]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max Shutter Speed:")]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO:")]
        public int MinIso { get; set; }

        [Display(Name = "Max ISO:")]
        public int MaxIso { get; set; }

        [Display(Name = "Is Full Frame:")]
        public bool IsFullFrame { get; set; }

        [Display(Name = "Video Resolution: ")]
        public string VideoResolution { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        //Configure in Automapper
        public string SellerUsername { get; set; }
    }
}
