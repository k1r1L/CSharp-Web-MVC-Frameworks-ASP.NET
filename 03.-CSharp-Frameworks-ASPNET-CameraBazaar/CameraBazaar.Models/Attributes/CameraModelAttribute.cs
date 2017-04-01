namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Constants;

    public class CameraModelAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string modelAsStr = value as string;

            if (!Regex.IsMatch(modelAsStr, ValidationRegularExpressions.CameraModelRegex))
            {
                return new ValidationResult(ValidationMessages.CameraModelValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
