namespace CameraBazaar.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Constants;
    using Enums;

    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required]
        [CameraModel]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(EntityValidationConstants.CameraMinQuantity, EntityValidationConstants.CameraMaxQuantity)]
        public int Quantity { get; set; }

        [Required]
        [Range(EntityValidationConstants.CameraMinShutterSpeedLowest, EntityValidationConstants.CameraMinShutterSpeedHighest)]
        public int MinShutterSpeed { get; set; }

        [Required]
        [Range(EntityValidationConstants.CameraMaxShutterSpeedLowest, EntityValidationConstants.CameraMaxShutterSpeedHighest)]
        public int MaxShutterSpeed { get; set; }

        [Required]
        [MinIso]
        public int MinIso { get; set; }

        [Required]
        [MaxIso]
        public int MaxIso { get; set; }

        [Required]
        public bool IsFullFrame { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.VideoResolutionTextLength)]
        public string VideoResolution { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationMessages.DescriptionMessage)]
        public string Description { get; set; }

        [Required]
        [MaxLength]
        [RegularExpression(ValidationRegularExpressions.ImageUrlRegex, ErrorMessage = ValidationMessages.ImageUrlMessage)]
        public string ImageUrl { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
