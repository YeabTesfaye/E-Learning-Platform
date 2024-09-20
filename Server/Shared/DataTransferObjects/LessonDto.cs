namespace Shared.DataTransferObjects;


public class LessonDto{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Number { get; set; }
    public string VideoUrl { get; set; }  = string.Empty;
    public string LessonDetails { get; set; } = string.Empty;
    public int CourseOrder { get; set; }
}