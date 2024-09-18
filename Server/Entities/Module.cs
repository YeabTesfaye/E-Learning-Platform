using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Module
{
    public Guid ModuleId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    [ForeignKey(nameof(Course))]
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
}