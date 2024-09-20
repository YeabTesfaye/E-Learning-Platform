namespace Shared.DataTransferObjects;


public class QuizAnswerDto{
    public Guid Id { get; set; }
    public string AnswerText { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}