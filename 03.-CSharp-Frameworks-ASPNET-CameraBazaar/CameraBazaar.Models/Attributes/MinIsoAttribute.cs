namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class MinIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int minIso = int.Parse(value.ToString());

            if (minIso != EntityValidationConstants.CameraMinIsoFirstValue && minIso != EntityValidationConstants.CameraMinIsoSecondValue)
            {
                return new ValidationResult(ValidationMessages.MinIsoValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
