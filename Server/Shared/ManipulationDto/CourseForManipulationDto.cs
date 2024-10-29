using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class CourseForManipulationDto
{
    [Required(ErrorMessage = "Course name is required.")]
    [StringLength(100, ErrorMessage = "Course name can't be longer than 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Course description is required.")]
    [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
    public string Description { get; set; }

    [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
    public decimal Price { get; set; }

    public bool IsProgressLimited { get; set; }
}
