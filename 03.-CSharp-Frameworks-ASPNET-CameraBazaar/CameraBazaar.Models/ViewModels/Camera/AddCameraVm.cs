namespace CameraBazaar.Models.ViewModels.Camera
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Constants;
    using Enums;

    public class AddCameraVm
    {
        [Required]
        public Make Make { get; set; }

        [Required, RegularExpression(ValidationRegularExpressions.CameraModelRegex, ErrorMessage = ValidationMessages.CameraModelValidationMessage)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, Range(0, 100)]
        public int Quantity { get; set; }

        [Required, Range(1, 30)]
        [Display(Name = "Min shutter speed")]
        public int MinShutterSpeed { get; set; }

        [Required, Range(2000, 8000)]
        [Display(Name = "Max shutter speed")]
        public int MaxShutterSpeed { get; set; }

        [MinIso, Required]
        [Display(Name = "Min ISO")]
        public int MinIso { get; set; }

        [Required, Range(200, 409600), MaxIso]
        [Display(Name = "Max ISO")]
        public int MaxIso { get; set; }

        [Display(Name = "Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [Required, StringLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public LightMetering LightMetering { get; set; }

        [StringLength(6000), Required]
        public string Description { get; set; }

        [Required]
        [RegularExpression(ValidationRegularExpressions.ImageUrlRegex, ErrorMessage = ValidationMessages.ImageUrlMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}
