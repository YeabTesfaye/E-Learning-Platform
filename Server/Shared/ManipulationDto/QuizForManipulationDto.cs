using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class QuizForManipulationDto
{
    [Required(ErrorMessage = "Quiz name is required.")]
    [StringLength(100, ErrorMessage = "Quiz name cannot be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Quiz number is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quiz number must be greater than zero.")]
    public int Number { get; set; }

    [Required(ErrorMessage = "Course order is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Course order must be greater than zero.")]
    public int CourseOrder { get; set; }

    public bool IsPassRequired { get; set; }
}
