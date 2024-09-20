namespace Shared.DataTransferObjects;

public class CourseDto{
  public Guid Id { get; set; }
public string Name { get; set; } = string.Empty;
public string Description { get; set; } = string.Empty;
public decimal Price { get; set; }
public int Credits { get; set; }
}