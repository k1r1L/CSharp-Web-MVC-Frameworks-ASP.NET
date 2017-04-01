namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class MaxIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int maxIso = int.Parse(value.ToString());

            if (maxIso < EntityValidationConstants.CameraMaxIsoLowest || maxIso > EntityValidationConstants.CameraMaxIsoHighest)
            {
                return new ValidationResult(ValidationMessages.MaxIsoValidationMessage);
            }

            if (maxIso % 100 != 0)
            {
                return new ValidationResult(ValidationMessages.MaxIsoValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
