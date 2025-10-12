using System.ComponentModel.DataAnnotations;

namespace Checkmate.Services
{
    public class SmallerThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public SmallerThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = Convert.ToDouble(value ?? 0);

            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherProperty == null)
                return new ValidationResult($"Propriété '{_otherPropertyName}' introuvable.");

            var otherValue = Convert.ToDouble(otherProperty.GetValue(validationContext.ObjectInstance) ?? 0);

            if (currentValue > otherValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
        
    }
}
