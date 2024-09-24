namespace Shared.DtoForCreation;

public class CourseForCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsProgressLimited { get; set; }
}