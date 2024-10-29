using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto
{
    public class StudentLessonForManipulationDto
    {
        [Required(ErrorMessage = "Completed date and time is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format.")]
        [CompletedDateValidation(ErrorMessage = "Completed date cannot be in the future.")]
        public DateTime CompletedDatetime { get; set; }
    }

    // Custom validation attribute to ensure the date is not in the future
    public class CompletedDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime completedDate)
            {
                if (completedDate > DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage ?? "Date cannot be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
