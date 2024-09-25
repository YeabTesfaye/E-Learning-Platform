namespace Shared.DtoForUpdate;

public class CourseForUpdateDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsProgressLimited { get; set; }
}