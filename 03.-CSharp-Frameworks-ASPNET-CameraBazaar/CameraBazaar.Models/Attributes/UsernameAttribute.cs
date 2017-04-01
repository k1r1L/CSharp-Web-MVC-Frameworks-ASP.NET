namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Constants;

    public class UsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string usernameAsStr = value.ToString();

            if (!Regex.IsMatch(usernameAsStr, ValidationRegularExpressions.UsernameRegex))
            {
                return new ValidationResult(ValidationMessages.UsernameValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
