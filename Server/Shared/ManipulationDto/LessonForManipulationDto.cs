using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class LessonForManipulationDto
{
    [Required(ErrorMessage = "Course order is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Course order must be greater than zero.")]
    public int CourseOrder { get; set; }

    public string? LessonDetails { get; set; } // Optional

    [Required(ErrorMessage = "Lesson name is required.")]
    [StringLength(100, ErrorMessage = "Lesson name cannot be longer than 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Lesson number is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Lesson number must be greater than zero.")]
    public int Number { get; set; }

    [Url(ErrorMessage = "The Video URL must be a valid URL.")]
    public string? VideoUrl { get; set; } // Optional, but must be a valid URL if provided
}
