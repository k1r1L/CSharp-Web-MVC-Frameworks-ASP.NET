namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Constants;

    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string passwordAsStr = value.ToString();

            if (!Regex.IsMatch(passwordAsStr, ValidationRegularExpressions.PasswordRegex))
            {
                return new ValidationResult(ValidationMessages.PasswordValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
