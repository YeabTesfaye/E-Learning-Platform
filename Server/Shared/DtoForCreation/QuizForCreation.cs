namespace Shared.DtoForCreation;

public class QuizForCreation
{
    public string Name { get; set; } = string.Empty;
    public int Number { get; set; }
    public int CourseOrder { get; set; }
    public bool IsPassRequired { get; set; }
}