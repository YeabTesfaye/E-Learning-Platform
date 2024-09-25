namespace Shared.DtoForUpdate;

public class QuizForUpdateDto
{

    public string? Name { get; set; }
    public int Number { get; set; }
    public int CourseOrder { get; set; }
    public int MinPassScore { get; set; }
    public bool IsPassRequired { get; set; }
}