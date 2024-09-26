using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class EnrolmentForManipulationDto
{
    [Required(ErrorMessage = "Enrolment date is required.")]
    public DateTime EnrolmentDatetime { get; set; }

    [Required(ErrorMessage = "Completion date is required.")]
    [DateGreaterThan("EnrolmentDatetime", ErrorMessage = "Completion date must be later than enrolment date.")]
    public DateTime CompletedDatetime { get; set; }
}


// Custom Validation Attribute
public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            // If the value is null, validation can be considered valid; depending on the logic you want.
            return ValidationResult.Success;
        }

        var currentValue = (DateTime)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
        {
            return new ValidationResult($"Unknown property: {_comparisonProperty}");
        }

        var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

        // Compare the dates
        if (comparisonValue.HasValue && currentValue <= comparisonValue.Value)
        {
            return new ValidationResult(ErrorMessage ?? "The date must be greater than the comparison date.");
        }

        return ValidationResult.Success;
    }
}

