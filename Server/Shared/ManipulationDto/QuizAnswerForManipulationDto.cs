using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class QuizAnswerForManipulationDto
{
    [Required(ErrorMessage = "Answer text is required.")]
    [StringLength(500, ErrorMessage = "Answer text cannot be longer than 500 characters.")]
    public string AnswerText { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
}
     