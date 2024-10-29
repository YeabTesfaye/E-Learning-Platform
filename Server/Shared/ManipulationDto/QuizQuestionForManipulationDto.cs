using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class QuizQuestionForManipulationDto
{
    [Required(ErrorMessage = "Question title is required.")]
    [StringLength(100, ErrorMessage = "Question title cannot be longer than 100 characters.")]
    public string QuestionTitle { get; set; }
}
