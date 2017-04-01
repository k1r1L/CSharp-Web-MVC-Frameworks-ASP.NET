namespace CameraBazaar.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Constants;

    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneNumberAsStr = value.ToString();

            if (!Regex.IsMatch(phoneNumberAsStr, ValidationRegularExpressions.PhoneRegex))
            {
                return new ValidationResult(ValidationMessages.PhoneValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
