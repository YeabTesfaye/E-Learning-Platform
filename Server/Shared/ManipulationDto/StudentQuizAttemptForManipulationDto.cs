using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class StudentQuizAttemptForManipulationDto
{
    [Required(ErrorMessage = "Attempt date and time is required.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format.")]
    [AttemptDateValidation(ErrorMessage = "Attempt date cannot be in the future.")]
    public DateTime AttemptDatetime { get; set; }

    [Required(ErrorMessage = "Score is required.")]
    [Range(0, 100, ErrorMessage = "Score must be between 0 and 100.")]
    public int ScoreAchieved { get; set; }
}

// Custom validation attribute to ensure the attempt date is not in the future
public class AttemptDateValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime attemptDate)
        {
            if (attemptDate > DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "Date cannot be in the future.");
            }
        }
        return ValidationResult.Success;
    }
}
