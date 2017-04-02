namespace CameraBazaar.Models.ViewModels.Camera
{
    using System.ComponentModel.DataAnnotations;
    using Constants;
    using Enums;

    public class EditCameraVm
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required, RegularExpression(ValidationRegularExpressions.CameraModelRegex, ErrorMessage = ValidationMessages.CameraModelValidationMessage)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, Range(0, 100)]
        public int Quantity { get; set; }
    }
}
