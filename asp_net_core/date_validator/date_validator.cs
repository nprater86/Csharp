public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if(value is DateTime && DateTime.Compare(DateTime.Now, (DateTime)value) >= 0)
        {
            return new ValidationResult("Date must be a future date");
        }
        return ValidationResult.Success;
    }
}

